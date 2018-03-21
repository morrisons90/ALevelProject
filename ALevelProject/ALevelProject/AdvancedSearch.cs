using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelProject
{
    class AdvancedSearch : SearchData
    {
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public string TownCity { get; set; }
        public string PostCode { get; set; }
        public List<Products> Products { get; set; }

        public AdvancedSearch(string storeId, string storeName, string townCity, string postCode, List<Products> products)
        {
            this.StoreCode = storeId;
            this.StoreName = storeName;
            this.TownCity = townCity;
            this.PostCode = postCode;
            this.Products = products;
            this.SearchType = 2;
        }
        public void addProduct(Products product)
        {
            this.Products.Add(product);
        }

    }
}
