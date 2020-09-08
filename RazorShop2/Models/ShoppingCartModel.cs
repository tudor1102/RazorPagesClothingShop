using RazorShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorShop.Models
{
    public class ShoppingCartModel
    {
        public List<Product> Products { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public ShoppingCartModel()
        {

        }
    }
}
