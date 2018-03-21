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
                        string SQL = constructQuery(input, new List<string>() { "ProductID", "ProductName", "Type", "Colour", "Range" }, "PRODUCTS");
                        List<SearchData> result = SQLI.searchQuery<Products>(SQL).Cast<SearchData>().ToList();
                        return result;
                    }
                case 1:
                    {
                        string SQL = constructQuery(input, new List<string>() { "StoreCode", "StoreName", "TownCity", "PostCode"}, "STORES");
                        List<SearchData> result = SQLI.searchQuery<Store>(SQL).Cast<SearchData>().ToList();
                        return result;
                    }
                case 2:
                    {
                        string SQLS = constructQuery(input, new List<string>() { "StoreCode", "StoreName", "TownCity", "PostCode" }, "STORES");
                        string SQLP = constructQuery(input, new List<string>() { "ProductID", "ProductName", "Type", "Colour", "Range" }, "PRODUCTS");
                        List<SearchData> resultS = SQLI.searchQuery<Store>(SQLS).Cast<SearchData>().ToList();
                        List<SearchData> resultP = SQLI.searchQuery<Products>(SQLP).Cast<SearchData>().ToList();
                        List<Stock> stock = SQLI.searchQuery<Stock>("SELECT * FROM Stock");
                        return Filter.FilterSort(resultP.Cast<Products>().ToList(), resultS.Cast<Store>().ToList(), stock.Cast<Stock>().ToList());
                    }
            }
            return null;
        }
        private static String constructQuery(SearchParams input, List<String> values, String table)
        {
            String sql = "Select * FROM " + table;
            var FirstConditon = true;
            for(var i = 0; i<values.Count; i++)
            {
                if (input.GetType().GetProperty(values[i]).GetValue(input) !=  null)
                {
                    if (FirstConditon)
                    {
                        FirstConditon = false;
                        sql += " WHERE ";
                    } else
                    {
                        sql += "AND ";
                    }
                    sql += values[i] + " LIKE '" + "%"+input.GetType().GetProperty(values[i]).GetValue(input, null)+"%'" + " ";                  
                }
            }
            return sql;
        }
    }
}
