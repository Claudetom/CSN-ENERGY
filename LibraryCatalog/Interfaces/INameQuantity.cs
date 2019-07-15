using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryCatalog.Interfaces
{
    public interface INameQuantity
    {
        string Name { get; }
        int Quantity { get; }
    }
}
