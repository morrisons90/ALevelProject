using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelProject
{
    public class Products : SearchData 
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Type { get; set; }
        public string Colour { get; set; }
        public string Range { get; set; }
        public string Date { get; set; }

        public Products(string id,string name, string type, string colour, string range, string date)
        {
            this.ProductID = id;
            this.ProductName = name;
            this.Type = type;
            this.Colour = colour;
            this.Range = range;
            this.Date = date;

            this.SearchType = 0;
        }

    }
}
