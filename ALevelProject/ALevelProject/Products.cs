using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelProject
{
    class Products : SearchData 
    {
        string ProductID { get; set; }
        string ProductName { get; set; }
        string Type { get; set; }
        string Colour { get; set; }
        string Range { get; set; }

        public Products(string[] row)
        {
            this.ProductID = row[0];
            this.ProductName = row[1];
            this.Type = row[2];
            this.Colour = row[3];
            this.Range = row[4];
        }

    }
}
