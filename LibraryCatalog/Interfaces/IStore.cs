using LibraryCatalog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryCatalog.Interfaces
{
    public interface IStore
    {
        Books CatalogBooks { get; set; }

        void Import(string catalogAsJson);

        int Quantity(string name);

        double Buy(params string[] basketByNames);
    }
}
