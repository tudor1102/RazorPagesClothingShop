using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnASPNETCoreRazorPagesWithRealApps.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorShop.Entities;
using RazorShop.Models;

namespace RazorShop.Pages
{
    public class ClothingModel : PageModel
    {
        public List<Product> Products { get; set; }
        public int TotalItems { get; set; }
        public void OnGet()
        {
            ProductModel productModel = new ProductModel();

            Products = productModel.findAll();
            TotalItems = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "Products").Count();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "ClothingProd", Products);
        }

        public void OnPost(string ID)
        {
            Products = SessionHelper.GetObjectFromJson < List<Product>>(HttpContext.Session, "ClothingProd");
            Product toBuy = Products.Where(p => p.ID == ID).FirstOrDefault();
            List<Product> Stored = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "Products");
            if (Stored.Exists(p=>p.ID==toBuy.ID))
            {
                int auxQuant = SessionHelper.GetObjectFromJson<int>(HttpContext.Session, toBuy.Name);
                auxQuant++;
                Stored.Where(p => p.ID == toBuy.ID).FirstOrDefault().Quantity = auxQuant;
                SessionHelper.SetObjectAsJson(HttpContext.Session, toBuy.Name, toBuy.Quantity);
            }
            else
            { 
                toBuy.Quantity++;
                 SessionHelper.SetObjectAsJson(HttpContext.Session, toBuy.Name, toBuy.Quantity);
                Stored.Add(toBuy);
            }
          
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Products", Stored);
        }
    }
}