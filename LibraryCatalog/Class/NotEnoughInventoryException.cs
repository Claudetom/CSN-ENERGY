using LibraryCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryCatalog.Class
{
    [Serializable]
    public class NotEnoughInventoryException : Exception
    {
        public IEnumerable<INameQuantity> Missing { get; set; }

        public NotEnoughInventoryException(IEnumerable<INameQuantity> missing)
        {
            Missing = missing;
        }
    }
}
