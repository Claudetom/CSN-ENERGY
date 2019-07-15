using LibraryCatalog.Interfaces;
using System;
using System.Collections.Generic;
using LibraryCatalog.Models;
using LibraryCatalog.Class;

namespace LibraryCatalog
{
    public class BookStore
    {
        #region *** Declarations ***

        public IStore Store;
        #endregion

        #region *** Methods ***
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nameJson">Chemin du fichier Json</param>
        public BookStore(string nameJson)
        {
            Initialisation(nameJson);
        }

        /// <summary>
        /// Function de départ (importation du fichier JSON)
        /// </summary>
        /// <param name="nameJson"></param>
        public void Initialisation(string nameJson)
        {
            if (Store == null)
                Store = new Store();

            Store.Import(nameJson);
        }

        #endregion


    }
}
