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
        //J'aurais pu passer par un "ViewData[xxx] ViewBag.key n'est pas dispo sous core" pour le passage des valeurs du controler aux vues, mais je préfère l'utilisation de model
        //=====

        #region *** Propriétés ***
        /// <summary>
        /// permet de retourner l'objet Store façon Singleton (toujours instancié)
        /// </summary>
        public static IStore Store { get; } = Store ?? new Store();
        #endregion

        public IActionResult Index()
        {
            Import_Catalog();

             // Récupère l'objet model de vue
            CatalogBooksViewModel model = GetCatalogBooksViewModel(null, false);
            ViewData["CatalogBooksViewModel"] = model;

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
            ViewData["CatalogBooksViewModel"] =  model;

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
            ViewData["CatalogBooksViewModel"] = model;

            SetCatalogBooksViewModel(OrigModel);

            //Retourne à l'index
            return View("Index", OrigModel);
        }

        [HttpGet]
        public IActionResult Import_Catalog()
        {
            //GetStore();

            //importe les données
            Store.Import("CatalogBooks.json");

            CatalogBooksViewModel model = CreateListeBookName();
            ViewData["CatalogBooksViewModel"] = model;

            SetCatalogBooksViewModel(model);

            //Ne change pas de page 
            return NoContent();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region *** Méthode de traitement ***
        /// <summary>
        /// Récupère le model qui est en session
        /// </summary>
        /// <returns></returns>
        private CatalogBooksViewModel GetCatalogBooksViewModel(CatalogBooksViewModel modelPassing, bool isQuantity)
        {
            CatalogBooksViewModel model;

            // Récupère l'objet model de vue
            if (HttpContext.Session.Keys.Contains("CatalogBooksViewModel"))
                model = HttpContext.Session.GetObjectFromJson<CatalogBooksViewModel>("CatalogBooksViewModel");
            else
                model = CreateListeBookName();

            if (modelPassing != null)
            {
                model.BookName = modelPassing.BookName ?? model.BookName;
                model.ListeBookName = modelPassing.ListeBookName ?? model.ListeBookName;

                model.Price = !isQuantity ? Store.Buy(modelPassing.SelectedBookNames) : (modelPassing.Price != -1 ? modelPassing.Price : model.Price);
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
                //  je regarde pas !
            }
            HttpContext.Session.SetObjectAsJson("CatalogBooksViewModel", model);

            return ModelState.IsValid;
        }

        /// <summary>
        /// Permet de créer une liste de <SelectListItem>des noms de livres</SelectListItem>
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
