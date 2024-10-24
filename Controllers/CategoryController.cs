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

            try
            {
                var category = _db.Categories.SingleOrDefault(c => c.Id == id);
                if (category != null)
                {
                    return View(category);
                }
                return RedirectToAction("Index", "Category");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Category");
            }
           
        }

        // POST: CatrgoryController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            try
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index","Category");
            }
            catch
            {
                return View();
            }
        }

        // GET: CatrgoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var ItemToBeRemoved=_db.Categories.FirstOrDefault(x => x.Id == id);
            if (ItemToBeRemoved != null)
            {
                _db.Categories.Remove(ItemToBeRemoved);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "Category");
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
