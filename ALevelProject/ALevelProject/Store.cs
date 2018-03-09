using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelProject
{
    class Store : SearchData
    {
        public string storeID { get; set;}
        public string storeName { get; set;}
        public string cityTown { get; set;}
        public string postcode { get; set;}

        public Store(string[] row)
        {
            this.storeID = row[0];
            this.storeName = row[1];
            this.cityTown = row[2];
            this.postcode = row[3];
        }

    }
}
