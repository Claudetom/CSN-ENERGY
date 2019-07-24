using LibraryCatalog.Interfaces;
using LibraryCatalog.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LibraryCatalog.Class
{
    public class Store : IStore
    {
        #region *** Variables ***
        /// <summary>
        /// Répertoire par défaut pour la lecture des fichiers Json
        /// </summary>
        public string pathDirectoryJson = Path.Combine(Directory.GetCurrentDirectory(), "Datas");

        /// <summary>
        /// Permet de stocké les exception lors du traitement de la liste des livres sélectionné
        /// Utile pour quand même poursuivre le traitement des livres dispo
        /// </summary>
        public List<INameQuantity> listeNameQuantity;
        #endregion

        #region *** Propriétés ***
        /// <summary>
        /// Liste du contenu du JSON (Cache)
        /// </summary
        public Books CatalogBooks { get; set; } = new Books();
        #endregion

        /// <summary>
        /// Importe le fichier Json en mémoire dans un objet de type BooksModel
        /// </summary>
        /// <param name="catalogAsJson"></param>
        void IStore.Import(string catalogAsJson)
        {
            var jsonPath = Path.Combine(pathDirectoryJson, catalogAsJson);

            if (!File.Exists(jsonPath))
                throw new Exception("Le fichier catalogue n'existe pas ");

            //Lecture du fichier et parsing
            CatalogBooks = JsonConvert.DeserializeObject<Books>(File.ReadAllText(jsonPath));
            CatalogBooks.Catalog = CatalogBooks.Catalog.OrderBy(p => p.Category);
        }

        /// <summary>
        /// Permet de retourner la quantité selon le titre
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int IStore.Quantity(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return -1;

            var t = CatalogBooks.Catalog.Where(a => a.Name == name).Select(a => a.Quantity).Sum();
            return t;
        }

        /// <summary>
        /// Permet le traitement du panier 
        /// </summary>
        /// <param name="basketByNames"></param>
        /// <returns></returns>
        double IStore.Buy(params string[] basketByNames)
        {
            listeNameQuantity = new List<INameQuantity>();

            if (basketByNames[0] == null)
                return -1;

            IList<string> maListe = basketByNames[0].Split(',').ToList();
            Dictionary<string, SelectBook> monDico2 = new Dictionary<string, SelectBook>();

            foreach (var item in maListe)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;

                //récupère nom du livre
                var nomLivre = item.Trim();
                //récupère la catégorie du livre
                var categorieDuLivre = CatalogBooks.Catalog.Where(a => a.Name == nomLivre).Select(a => a.Category).First();

                //Selon la categorie
                if (monDico2.ContainsKey(categorieDuLivre))
                {
                    SelectBook.BookName result = monDico2[categorieDuLivre].ListeBookName.Find(p => p.NameBook == nomLivre);

                    if (!string.IsNullOrEmpty(result.NameBook))
                    {
                        monDico2[categorieDuLivre].NumberToCategorie += 1;
                        monDico2[categorieDuLivre].ListeBookName.Remove(result);
                        result.Count += 1;
                        monDico2[categorieDuLivre].ListeBookName.Add(result);
                    }
                    else
                    {
                        monDico2[categorieDuLivre].ListeBookName.Add(new SelectBook.BookName { NameBook = nomLivre, Count = 1 });
                        monDico2[categorieDuLivre].NumberToCategorie += 1;
                    }
                }
                else
                    //nouvelle catégorie
                    monDico2.Add(categorieDuLivre, new SelectBook { CategorieName = categorieDuLivre, ListeBookName = new List<SelectBook.BookName> { new SelectBook.BookName { NameBook = nomLivre, Count = 1 } }, NumberToCategorie = 1 });
            }

            var price = PriceCalcul(monDico2);

            return price;
        }

        //Si j'avais eu plusieurs fonctions de traitement , j'aurais créé une factory de calcul
        /// <summary>
        /// Traitement de la sélection de livre et retourne le prix
        /// </summary>
        /// <param name="monDico2">dictionnaire des livres par catégorie et par titre</param>
        /// <returns>le prix</returns>
        private double PriceCalcul(Dictionary<string, SelectBook> monDico2)
        {
            //Partie calcule
            //--------------
            var price = 0d;

            //Parcours chaque categories
            foreach (KeyValuePair<string, SelectBook> item in monDico2)
            {
                SelectBook selb = item.Value;
                var categorie = item.Key;
                var categorieCount = selb.NumberToCategorie;

                //récupère la remise pour cette catégorie
                double remise = CatalogBooks.Category.Where(a => a.Name == categorie && a.Name == categorie).Select(a => a.Discount).Sum();
                remise = Math.Round(1 - remise, 2);

                //Parcours les livres de la catégorie
                foreach (SelectBook.BookName sb in selb.ListeBookName)
                {
                    var bookName = sb.NameBook;
                    var nbrExemplaireIdentique = sb.Count;

                    //récupère la quantité du stock
                    var quantity = CatalogBooks.Catalog.Where(a => a.Category == categorie && a.Name == bookName).Select(a => a.Quantity).Sum();

                    try
                    {
                        //si le nombre d'exemplaires est supérieur à la quantité réelle (dans ce cas génère une erreur qui sera affichée par la suite)
                        if (nbrExemplaireIdentique > quantity)
                        {
                            listeNameQuantity.Add(new NameQuantity() { Name = bookName, Quantity = nbrExemplaireIdentique });
                            throw new NotEnoughInventoryException(listeNameQuantity);
                        }
                        else
                        {
                            //récupère les données d'un livre correspondant
                            Catalog book = CatalogBooks.Catalog.Where(a => a.Category == categorie && a.Name == bookName).First();

                            //boucle sur le nombre d'exemplaires
                            for (int i = 0; i < nbrExemplaireIdentique; i++)
                            {
                                //Si plusieurs livres dans la même catégorie, le 1er est à (- la remise) les autres au prix, si un seul prix normal
                                var isRemise = (nbrExemplaireIdentique > 1 && i == 0) || (nbrExemplaireIdentique == 1 && categorieCount > 1);
                                price += isRemise ? book.Price * remise : book.Price;
                            }
                        }
                    }
                    catch (NotEnoughInventoryException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return price;
        }

    }

    public class SelectBook
    {
        public struct BookName
        {
            public int Count;
            public string NameBook;
        }
        public List<BookName> ListeBookName { get; set; }
        public string CategorieName { get; set; }
        public int NumberToCategorie { get; set; }


    }

}
