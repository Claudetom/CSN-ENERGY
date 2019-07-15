using LibraryCatalog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_CSN_ENERGY.Models
{
    /// <summary>
    /// Class Book Catalog pour la vue
    /// </summary>
    public class CatalogBooksViewModel
    {
        /// <summary>
        /// Contiendra le le nom du livre sélectionné
        /// </summary>
        [Required]
        [Display(Name = "Nom du livre:")]
        public string BookName { get; set; }

        /// <summary>
        /// Cette propriété contiendra tous les noms de livre disponibles pour la sélection
        /// </summary>
        public IEnumerable<SelectListItem> ListeBookName { get; set; }

        /// <summary>
        /// Cette propriété contiendra tous les noms de livre sélectionnés
        /// </summary>
        [Display(Name = "Liste des livres:")]
        public string[] SelectedBookNames { get; set; }

        /// <summary>
        /// Contiendra la quantité disponible
        /// </summary>
        [Required]
        [Display(Name = "Quantité disponible:")]
        public int Quantity { get; set; } = -1;

        /// <summary>
        /// Contiendra le prix de la sélection
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [Display(Name = "Prix:")]
        public double Price { get; set; } = -1;

    }
}
