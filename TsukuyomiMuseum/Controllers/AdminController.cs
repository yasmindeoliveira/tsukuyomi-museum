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

        // ---------------------------------- CreateEvent ----------------------------------
        [HttpGet]
        public IActionResult CreateEvent()
        {
            using MuseumContext db = new();

            Event Modello = new();

            return View("CreateEvent", Modello);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEvent(Event formData)
        {
            if (!ModelState.IsValid)
            {
                using MuseumContext db = new();

                return View("CreateEvent", formData);

            }
            using (MuseumContext db = new MuseumContext())
            {

                db.Events.Add(formData);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        // ---------------------------------- UpdateEvent ----------------------------------
        [HttpGet]
        public IActionResult UpdateEvent(int id)
        {
            using (MuseumContext db = new MuseumContext())
            {
                Event evento = db.Events.Where(p => p.EventId == id).FirstOrDefault();

                if (evento == null)
                {
                    return NotFound("L'evento cercato non è disponibile");
                }

                Event Modello = new();

                return View("UpdateEvent", Modello);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateEvent(Event formData)
        {
            if (!ModelState.IsValid)
            {
                using MuseumContext db = new();

                return View("UpdateEvent", formData);
            }

            using (MuseumContext db = new MuseumContext())
            {
                Event evento = db.Events.Where(p => p.EventId == formData.EventId).FirstOrDefault();

                if (evento != null)
                {
                    evento.Name = formData.Name;
                    evento.Description = formData.Description;
                    evento.Price = formData.Price;
                    evento.PhotoUrl = formData.PhotoUrl;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("L'evento non è stato trovato");
                }

            }

        }

        // ---------------------------------- RemoveEvent ----------------------------------
        [HttpPost]
        public IActionResult RemoveEvent(int id)
        {

            using (MuseumContext db = new MuseumContext())
            {
                Event evento = (from p in db.Events
                                   where p.EventId == id
                                   select p).FirstOrDefault();

                db.Remove(evento);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        // ---------------------------------- CreatePublication ----------------------------------
        [HttpGet]
        public IActionResult CreatePublication()
        {
            using MuseumContext db = new();

            Publication Modello = new();

            return View("CreatePublication", Modello);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePublication(Publication formData)
        {
            if (!ModelState.IsValid)
            {
                using MuseumContext db = new();

                return View("CreatePublication", formData);

            }
            using (MuseumContext db = new MuseumContext())
            {

                db.Publications.Add(formData);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        // ---------------------------------- UpdatePublication ----------------------------------
        [HttpGet]
        public IActionResult UpdatePublication(int id)
        {
            using (MuseumContext db = new MuseumContext())
            {
                Publication publication = db.Publications.Where(p => p.PublicationId == id).FirstOrDefault();

                if (publication == null)
                {
                    return NotFound("La publicazione cercata non è disponibile");
                }

                Publication Modello = new();

                return View("UpdatePublication", Modello);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePublication(Publication formData)
        {
            if (!ModelState.IsValid)
            {
                using MuseumContext db = new();

                return View("UpdatePublication", formData);
            }

            using (MuseumContext db = new MuseumContext())
            {
                Publication publication = db.Publications.Where(p => p.PublicationId == formData.PublicationId).FirstOrDefault();

                if (publication != null)
                {
                    publication.Title = formData.Title;
                    publication.Description = formData.Description;
                    publication.PhotoUrl = formData.PhotoUrl;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("La publicazione non è stato trovato");
                }

            }

        }

        // ---------------------------------- RemovePublication ----------------------------------
        [HttpPost]
        public IActionResult RemovePublication(int id)
        {

            using (MuseumContext db = new MuseumContext())
            {
                Publication publication = (from p in db.Publications
                                where p.PublicationId == id
                                select p).FirstOrDefault();

                db.Remove(publication);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }
    }
}
