using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ALevelProject
{
    static class Filter
    {
        static public List<SearchData> FilterSort(List<Products> products, List<Store> store, List<Stock> stock)
        {
            return CreateAdvancedSearch(store, CreateProductHash(products), stock);           
        }
        static private Hashtable CreateStockHash(List<List<int>> stock)
        {
            Hashtable stockHash = new Hashtable();

            for(int i = 0; i < stock.Count; i++)
            {
                stockHash.Add(stock[i][1], stock[i][2]);
            }

            return stockHash;
        }
        static private Hashtable CreateProductHash(List<Products> products)
        {
            Hashtable productHash = new Hashtable();

            for(int i = 0; i < products.Count; i++)
            {
                productHash.Add(products[i].ProductID.Replace(" ", string.Empty), products[i]);
            }

            return productHash;
        }
        static private List<SearchData> CreateAdvancedSearch(List<Store> stores, Hashtable productHash, List<Stock> stockList)
        {
            List<AdvancedSearch> advancedSearchL = new List<AdvancedSearch>();

            for(int i = 0; i < stores.Count; i++)
            {
                var productIds = stockList.FindAll(a => a.StoreID.Replace(" ", string.Empty) == stores[i].StoreCode.Replace(" ", string.Empty));
                List<Products> productList = new List<Products>();
                foreach(var id in productIds)
                {
                    productList.Add((Products)productHash[id.ProductID.Replace(" ", string.Empty)]);
                }
                advancedSearchL.Add((AdvancedSearch)Activator.CreateInstance(typeof(AdvancedSearch), stores[i].StoreCode, stores[i].StoreName, stores[i].TownCity, stores[i].PostCode, productList));
            }
            return advancedSearchL.Cast<SearchData>().ToList();
        }
    }
}
