using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelProject
{
    static public class SearchControler
    {
        public static List<SearchData> Search(SearchParams input) {
            switch (input.SearchType)
            {
                case 0:
                    {
                        String SQL = "SELECT* FROM products WHERE ProductID = '" + input.ProductID + "' AND ProductName = '" + input.ProductName + "' AND Type = '" + input.Type + "' AND Colour = '" + input.Colour + "' AND Range = '" + input.Colour + "'; ";
                        List<SearchData> result = SQLI.searchQuery<Products>(SQL).Cast<SearchData>().ToList();
                         return result;
                    }
                case 1:
                    {
                        string SQL = "SELECT* FROM stores WHERE LocationID = '" + input.StoreCode + "' AND Name = '" + input.StoreName + "' AND CityTown = '" + input.TownCity + "' AND Postcode = '" + input.Postcode + "'; ";
                        List<SearchData> result = SQLI.searchQuery<Store>(SQL).Cast<SearchData>().ToList();
                        return result;
                    }
            }
            return null;
        }
    }
}
