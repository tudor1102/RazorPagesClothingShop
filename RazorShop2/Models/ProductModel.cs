using LearnASPNETCoreRazorPagesWithRealApps.Helpers;
using RazorShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace RazorShop.Models
{
    public class ProductModel
    {
        
        private List<Product> Products { get; set; }
        public ProductModel()
        {
            Products = new List<Product>()
            {
                new Product{
                    ID="1",
                    Name="Tommy Hilfiger T-Shirt",
                    Photo="/lib/tommyH.jpg",
                    Price=120,
                    Quantity=0
                },
                new Product{
                    ID="2",
                    Name="Tommy Hilfiger T-Shirt 2",
                    Photo="/lib/h6.jpg",
                    Price=120,
                    Quantity=0
                },
                new Product{
                    ID="3",
                    Name="Tommy Hilfiger T-Shirt 3",
                    Photo="/lib/h3.jpg",
                    Price=120,
                     Quantity=0
                },
                new Product{
                    ID="4",
                    Name="Tommy Hilfiger T-Shirt ",
                    Photo="/lib/tommyH.jpg",
                    Price=120,
                       Quantity=0
                },
            };
            
        }

        public List<Product> findAll()
        {
            return this.Products;
        }

        public Product find(string id)
        {
            return this.Products.Where(p => p.ID == id).FirstOrDefault();
        }

    }
}
