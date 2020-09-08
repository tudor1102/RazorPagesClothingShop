using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace RazorShop.Entities
{
    public class Product
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public string Photo { get; set; }
        public double Price { get; set; }

        public int Quantity { get; set; }
        public Product()
        {
            
        }
    }
}
