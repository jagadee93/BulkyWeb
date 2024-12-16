using BulkyBook.DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BulkyBook.Models;
using BulkyBook.DataAccess.Repository.IRepository;
namespace BulkyBookWeb.Areas.Admin.Controllers
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

        //Now we are  creating object for CategoryRepository in UnitOfWorl
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: CatrgoryController
        public ActionResult Index()
        {
            Console.WriteLine("Hello");
            var objCategoryList = _unitOfWork.Category.GetAll().ToList();
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
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "New Category Has been created";
                return RedirectToAction("Index", "Category");
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
                var category = _unitOfWork.Category.Get(u => u.Id == id);

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

                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();


                TempData["success"] = "Category has been edited....";
                return RedirectToAction("Index", "Category");
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
            var ItemToBeRemoved = _unitOfWork.Category.Get(u => u.Id == id);
            if (ItemToBeRemoved != null)
            {
                /*  _db.Categories.Remove(ItemToBeRemoved);
                  _db.SaveChanges();*/

                _unitOfWork.Category.Remove(ItemToBeRemoved);
                _unitOfWork.Save();


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
