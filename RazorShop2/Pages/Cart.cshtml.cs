using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnASPNETCoreRazorPagesWithRealApps.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorShop.Entities;
using RazorShop2.Models;

namespace RazorShop2.Pages
{
    public class CartModel : PageModel
    {
        private readonly AppDbContext _db;
        public List<Product> Products { get; set; }

        [BindProperty]
        public ClientModel Client { get; set; }
        public double Total { get; set; }
        public CartModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Products = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "Products");
            foreach(Product P in Products)
            {
                Total += P.Quantity * P.Price;
            }
        }

        public IActionResult OnPostDelete(string id)
        {
            Products = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "Products");
            Product toDelete = Products.Where(p => p.ID == id).FirstOrDefault();
            Products.Remove(toDelete);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Products", Products);
            return RedirectToPage("Cart");
        }

        public async Task<IActionResult> OnPost()
        {
            Client.Products = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "Products");
            await _db.AddAsync(Client);
            await _db.SaveChangesAsync();
            return RedirectToPage("ThankYou");
        }
    }
}