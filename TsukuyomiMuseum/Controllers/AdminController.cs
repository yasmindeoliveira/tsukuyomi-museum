using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using TsukuyomiMuseum.Database;
using TsukuyomiMuseum.Models;

namespace TsukuyomiMuseum.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            using (MuseumContext db = new MuseumContext())
            {
                List<Product> productList = db.Products.ToList();
                return View("Index", productList);
            }
            
        }

        // ---------------------------------- CreateProduct ----------------------------------
        [HttpGet]
        public IActionResult CreateProduct ()
        {
            using MuseumContext db = new();

            List<Category> categories = db.Categories.ToList();
            AdminView Modello = new();
            Modello.categories = categories;
            Modello.product = new Product();

            return View("CreateProduct", Modello);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct (AdminView formData)
        {
            if (!ModelState.IsValid)
            {
                using MuseumContext db = new();

                List<Category> categories = db.Categories.ToList();
                formData.categories = categories;

                return View("CreateProduct", formData);

            }
            using (MuseumContext db = new MuseumContext())
            {

                db.Products.Add(formData.product);
                db.SaveChanges();
            }

            return RedirectToAction("Index");    

        }

        // ---------------------------------- UpdateProduct ----------------------------------
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            using (MuseumContext db = new MuseumContext())
            {
                Product product = db.Products.Where(p => p.ProductId == id).Include(c => c.Category).FirstOrDefault();

                if (product == null)
                {
                    return NotFound("Il prodotto cercato non è disponibile");
                }

                List<Category> categories = db.Categories.ToList();
                AdminView Modello = new();
                Modello.product = product;
                Modello.categories = categories;

                return View("UpdateProduct", Modello);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProduct(AdminView formData)
        {
            if (!ModelState.IsValid)
            {
                using MuseumContext db = new();

                List<Category> categories = db.Categories.ToList();
                formData.categories = categories;

                return View("UpdateProduct", formData);
            }

            using (MuseumContext db = new MuseumContext())
            {
                Product product = db.Products.Where(p => p.ProductId == formData.product.ProductId).FirstOrDefault();

                if (product != null)
                {
                    product.Name = formData.product.Name;
                    product.Description = formData.product.Description;
                    product.Price = formData.product.Price;
                    product.PhotoUrl = formData.product.PhotoUrl;
                    product.Quantity = formData.product.Quantity;
                    product.CategoryId = formData.product.CategoryId;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("Il prodotto non è stato trovato");
                }

            }

        }

        // ---------------------------------- RemoveProduct ----------------------------------
        [HttpPost]
        public IActionResult RemoveProduct(int id)
        {

            using (MuseumContext db = new MuseumContext())
            {
                Product product = (from p in db.Products
                               where p.ProductId == id
                               select p).FirstOrDefault();

                db.Remove(product);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }
    }
}
