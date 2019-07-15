using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryCatalog.Models
{
    /// <summary>
    /// Modèle pour les données livres (Category and Catalog)
    /// </summary>
    public class Books
    {
        [Display(Name = "Category")]
        public IEnumerable<Category> Category { get; set; }

        [Display(Name = "Catalog")]
        public IEnumerable<Catalog> Catalog { get; set; }
    }

    /// <summary>
    /// Modèle pour la Category
    /// </summary>
    public class Category
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Discount")]
        public float Discount { get; set; }
    }

    /// <summary>
    /// Modèle pour le Catalog
    /// </summary>
    public class Catalog
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Price")]
        public int Price { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }

}
