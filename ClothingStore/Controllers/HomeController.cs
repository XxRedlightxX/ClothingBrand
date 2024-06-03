using ClothingStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Security.Claims;
using System.Linq;

namespace ClothingStore.Controllers
{
    public class HomeController : Controller
    {
        

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

       

        public IActionResult Index()
        {
            var listCategorie = _context.Categorie.Include(categorie => categorie.clothes).ToList();
            return View(listCategorie);
        }

       

        public IActionResult ajouterPoste()
        {
            ViewData["CategorieId"] = new SelectList(_context.Categorie, "CategorieId", "NomCategorie");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ajouterPoste(Clothe post, IFormFile photo)
        {

            //var posti = await _context.Clothes.FindAsync(postId);

           

             

            /*if (post.CategorieId == null) // Assuming 0 indicates that the category was not set
            {
                post.CategorieId = 1; // Default category ID
            }*/


            if (photo != null && photo.Length > 0)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {

                    photo.CopyTo(memoryStream);
                    
                    post.Photo = memoryStream.ToArray();
                }
            }
            _context.Clothes.Add(post);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

      


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}