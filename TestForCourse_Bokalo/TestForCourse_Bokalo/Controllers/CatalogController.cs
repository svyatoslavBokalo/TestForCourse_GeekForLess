using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestForCourse_Bokalo.Data;
using TestForCourse_Bokalo.Models;

namespace TestForCourse_Bokalo.Controllers
{
    public class CatalogController : Controller
    {
        public DbContextApplication db;

        public CatalogController(DbContextApplication db)
        {
            this.db = db;
        }
        [HttpGet]        
        
        public async Task<IActionResult> Show(int? id)
        {
            Catalog catalog = null;

            if (id == null)
            {
                // Загрузка головної сторінки (папки "Creating Digital Images")
                catalog = db.Catalogs
                    .Include(c => c.SubCatalogs)
                    .FirstOrDefault(c => c.NameFolder == "Creating Digital Images");
            }
            else
            {
                // Загрузка вибраної папки з id
                catalog = db.Catalogs
                    .Include(c => c.SubCatalogs)
                    .FirstOrDefault(c => c.Id == id);
            }

            return View(catalog);
        }
    }
}
