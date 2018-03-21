using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelProject
{
    public class Stock
    {
        public int StockID { get; set; }
        public string ProductID { get; set; }
        public string StoreID { get; set; }
        public int StockLevel { get; set; }

        public Stock(string stockID, string productID, string storeID, string stockLevel)
        {
            this.StockID = Convert.ToInt32(stockID);
            this.StockLevel = Convert.ToInt32(stockLevel);
            this.ProductID = productID;
            this.StoreID = storeID;
        }
    }
}
