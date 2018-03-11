using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelProject
{
    public class Store : SearchData
    {
        public string StoreCode { get; set;}
        public string StoreName { get; set;}
        public string TownCity { get; set;}
        public string PostCode { get; set;}

        public Store(string storeid, string storename, string towncity, string postcode)
        {
            this.StoreCode = storeid;
            this.StoreName = storename;
            this.TownCity = towncity;
            this.PostCode = postcode;

            this.SearchType = 1;
        }

    }
}
