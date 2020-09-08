using RazorShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorShop.Models
{
    public class ShadeModel
    {
        public List<Product> Products { get; set; }
        public ShadeModel()
        {


            Products = new List<Product>() {
            new Product
            {
                ID="5",
                Name="Shades Black",
                Photo="/lib/s1.jpg",
                Price=120,
                Quantity=0
            },
            new Product
            {
                ID="6",
                Name="Shades Blue",
                Photo="/lib/s2.jpg",
                Price=120,
                Quantity=0
            },
            new Product
            {
                ID="7",
                Name="Shades Red",
                Photo="/lib/s3.jpg",
                Price=120,
                Quantity=0
            },
            new Product
            {
                ID="8",
                Name="Shades Holo",
                Photo="/lib/s4.jpg",
                Price=120,
                Quantity=0
            },
        };
        }

        public List<Product> GetProducts()
        {
            return Products;
        }

        public Product find(string id)
        {
            return Products.Where(p => p.ID == id).FirstOrDefault();
        }
    }
}
