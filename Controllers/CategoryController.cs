using BulkyWeb.data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BulkyWeb.Models;
namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
           this._db  = db;
        }

        // GET: CatrgoryController
        public ActionResult Index()
        {
            var objCategoryList= _db.Categories.ToList();
            return View(objCategoryList);
        }

        //// GET: CatrgoryController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

         //GET: CatrgoryController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatrgoryController/Create
        [HttpPost]
     
        public ActionResult Create(Category category)
        {
            try
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
              
                return RedirectToAction("Index","Category");
            }
            catch
            {
                return View();
            }
        }

        // GET: CatrgoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CatrgoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CatrgoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CatrgoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
