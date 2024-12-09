using BulkyBook.DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BulkyBook.Models;
using BulkyBook.DataAccess.Repository.IRepository;
namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        /*public readonly ApplicationDbContext _db;*/
       /* private readonly ICategoryRepository _categoryRepo;*/

        private readonly IUnitOfWork _unitOfWork;

        /*public CategoryController(ApplicationDbContext db)
        {
           this._db  = db;
        }*/

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;

        }

        // GET: CatrgoryController
        public ActionResult Index()
        {
            Console.WriteLine("Hello");
            var objCategoryList=_categoryRepo.GetAll().ToList();
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
                _categoryRepo.Add(category);
                _categoryRepo.Save();
                TempData["success"] = "New Category Has been created";
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
                /*var category = _db.Categories.SingleOrDefault(c => c.Id == id);*/
                var category=_categoryRepo.Get(u=>u.Id == id);

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
               /* _db.Categories.Update(category);
                _db.SaveChanges();*/

                _categoryRepo.Update(category);
                _categoryRepo.Save();


                TempData["success"] = "Category has been edited....";
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
            /* var ItemToBeRemoved=_db.Categories.FirstOrDefault(x => x.Id == id);*/
            var ItemToBeRemoved = _categoryRepo.Get(u => u.Id == id);
            if (ItemToBeRemoved != null)
            {
              /*  _db.Categories.Remove(ItemToBeRemoved);
                _db.SaveChanges();*/

                _categoryRepo.Remove(ItemToBeRemoved);
                _categoryRepo.Save();


            }
            TempData["success"] = "Deleted successfully";
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
