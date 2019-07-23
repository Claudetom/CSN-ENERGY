using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LibraryCatalog.Class;
using LibraryCatalog.Interfaces;
using LibraryCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test_CSN_ENERGY.Models;
using Microsoft.AspNetCore.Http;
using Test_CSN_ENERGY.Extensions;

namespace Test_CSN_ENERGY.Controllers
{
    public class HomeController : Controller
    {
        //=====
        //J'aurais pu passer par un "ViewBag" pour le passage des valeurs du controler aux vues, mais je préfère l'utilisation de model
        //=====

        #region *** Declarations ***
        public static IStore Store;
        #endregion

        public IActionResult Index()
        {
            Import_Catalog();

            // Récupère l'objet model de vue
            CatalogBooksViewModel model = GetCatalogBooksViewModel(null, false);
            return View(model);
        }

        /// <summary>
        /// Se produit lors du Post "Quantity"
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Quantity(CatalogBooksViewModel model)
        {
            // Récupère l'objet model de vue
            CatalogBooksViewModel OrigModel = GetCatalogBooksViewModel(model, true);
            SetCatalogBooksViewModel(OrigModel);

            //Retourne à l'index
            return View("Index", OrigModel);
        }

        /// <summary>
        /// Se produit lors du Post "Basket"
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Basket(CatalogBooksViewModel model)
        {
            // Récupère l'objet model de vue
            CatalogBooksViewModel OrigModel = GetCatalogBooksViewModel(model, false);
            SetCatalogBooksViewModel(OrigModel);

            //Retourne à l'index
            return View("Index", OrigModel);
        }

        [HttpGet]
        public IActionResult Import_Catalog()
        {
            GetStore();

            //importe les données
            Store.Import("CatalogBooks.json");

            CatalogBooksViewModel model = CreateListeBookName();

            SetCatalogBooksViewModel(model);

            //Ne change pas de page 
            return NoContent();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void GetStore()
        {
            if (Store == null)
                Store = new Store();
        }

        #region *** Méthode de traitement ***
        /// <summary>
        /// Récupère le model qui est en session
        /// </summary>
        /// <returns></returns>
        private CatalogBooksViewModel GetCatalogBooksViewModel(CatalogBooksViewModel modelPassing, bool isQuantity)
        {
            // Récupère l'objet model de vue
            CatalogBooksViewModel model = null;

            if (HttpContext.Session.Keys.Contains("CatalogBooksViewModel"))
                model = HttpContext.Session.GetObjectFromJson<CatalogBooksViewModel>("CatalogBooksViewModel");
            else
                model = CreateListeBookName();

            if (modelPassing != null)
            {
                model.BookName = modelPassing.BookName ?? model.BookName;
                model.ListeBookName = modelPassing.ListeBookName ?? model.ListeBookName;
                model.Price = !isQuantity ? Store.Buy(modelPassing.SelectedBookNames) : (modelPassing.Price != -1 ? modelPassing.Price : model.Price);

                //Avant mais enlevé la catégorie, car c'était moche lors de la sélection (vu que cette liste sert pour le calcul de quantity et price)
                //model.Quantity = isQuantity ? Store.Quantity(modelPassing.BookName?.Split(':')[1]) : (modelPassing.Quantity != -1 ? modelPassing.Quantity : model.Quantity);

                model.Quantity = isQuantity ? Store.Quantity(modelPassing.BookName) : (modelPassing.Quantity != -1 ? modelPassing.Quantity : model.Quantity);

                model.SelectedBookNames = modelPassing.SelectedBookNames ?? model.SelectedBookNames;

                //Traitement des messages pour l'affichage
                if (((Store)Store).listeNameQuantity != null && ((Store)Store).listeNameQuantity.Count > 0)
                {
                    ViewBag.Message = "<span>Rupture de stock pour</span><br/>";
                    foreach (NameQuantity err in ((Store)Store).listeNameQuantity)
                    {
                        ViewBag.Message += $"<span>{err.Name}, nombre de livre : {err.Quantity}</span><br/>";
                    }
                }
            }

            return model;
        }

        /// <summary>
        /// Sauve le model en session
        /// </summary>
        /// <param name="model">Le model</param>
        /// <returns>IsValid</returns>
        private bool SetCatalogBooksViewModel(CatalogBooksViewModel model)
        {
            if (ModelState.IsValid)
            {
                //  
            }
            HttpContext.Session.SetObjectAsJson("CatalogBooksViewModel", model);

            return ModelState.IsValid;
        }

        /// <summary>
        /// Permet de créer une liste des noms de livres
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<Catalog> cat)
        {
            var selectList = new List<SelectListItem>();

            foreach (var book in cat)
            {
                selectList.Add(new SelectListItem
                {
                    //Avant (quand il y'avait dans mon 1er exemple, la cat. et nom du livre)
                    //Value = $"{book.Category}:{book.Name}",

                    Value = book.Name.Trim(),
                    Text = $"{book.Category.Trim()} - {book.Name.Trim()}"
                });
            }

            return selectList;
        }

        /// <summary>
        /// Permet de créer la liste des livres et de copier le catalog dans le model utilisé par la vue 
        /// </summary>
        /// <returns>retourne le model avec les données de livres et catalog complet</returns>
        private CatalogBooksViewModel CreateListeBookName()
        {
            var model = new CatalogBooksViewModel
            {
                ListeBookName = GetSelectListItems(Store.CatalogBooks.Catalog),
                Catalog = Store.CatalogBooks.Catalog
            };

            return model;
        }
        #endregion
    }

}
