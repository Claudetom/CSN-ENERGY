using LibraryCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryCatalog.Class
{
    public class NameQuantity : INameQuantity
    {
        public string Name { get; set; } = string.Empty;

        public int Quantity { get; set; } = 0;
    }
}
