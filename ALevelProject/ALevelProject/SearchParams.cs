using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelProject
{
    public class SearchParams
    {
        public string ProductID;
        public string ProductName;
        public string Type;
        public string Colour;
        public string range;
        public DateTime Date;
        public string ProductSortBy;
        public string StoreCode;
        public string StoreName;
        public string TownCity;
        public string Postcode;
        public string StoreSearchBy; 
        public int SearchType { get; set; }/*Number based on product/store/both type of search */
    }
}
