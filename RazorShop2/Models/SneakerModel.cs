using RazorShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorShop.Models
{
    public class SneakerModel
    {
        public List<Product> Products { get; set; }
      
        public SneakerModel()
        {
            Products = new List<Product>()
            {
            new Product
            {
                ID="9",
                Name="Nike Sneakers Orange",
                Photo="/lib/n4.jpg",
                Price=120,
                Quantity=0
            },
            new Product
            {
                ID="10",
                Name="Nike Sneakers Gray",
                Photo="/lib/n5.jpg",
                Price=120,
                Quantity=0
            },
            new Product
            {
                ID="11",
                Name="Nike Sneakers Black",
                Photo="/lib/n3.jpg",
                Price=120,
                Quantity=0
            },
            new Product
            {
                ID="12",
                Name="Nike Sneakers Orange",
                Photo="/lib/n4.jpg",
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
   
