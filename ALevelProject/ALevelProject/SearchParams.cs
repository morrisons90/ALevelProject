using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelProject
{
    public class SearchParams
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Type { get; set; }
        public string Colour { get; set; }
        public string Range { get; set; }
        public string Date { get; set; }
        public string ProductSortBy { get; set; }
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public string TownCity { get; set; }
        public string PostCode { get; set; }
        public string StoreSearchBy { get; set; }
        public int SearchType { get; set; }/*Number based on product/store/both type of search */
    }
}
