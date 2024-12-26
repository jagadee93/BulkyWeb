using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {

        private readonly IUnitOfWork unitOfWork;


        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }




        public IActionResult Index()
        {
            var ListOfBooks=unitOfWork.Product.GetAll().ToList();
           

            return View(ListOfBooks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.CategoryId.ToString()
            });
            //ViewBag.CategoryList = CategoryList;
            ViewData["CategoryList"]= CategoryList;
            return View();  
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("Creating an ");
                unitOfWork.Product.Add(product);
                unitOfWork.Save();
                TempData["success"] = "New Book has been added";
                return RedirectToAction("Index");
            }
            Console.WriteLine(ModelState.ErrorCount);
            TempData["error"] = "Book not created try again ";
            return RedirectToAction("Index");
        }



        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var product = unitOfWork.Product.Get(u => u.Id == id);
                if (product == null)
                {

                    return NotFound();
                }

                return View(product);
            }
            return NotFound();
        }


        public ActionResult Manage()
        {
            var ListOfBooks=unitOfWork.Product.GetAll().ToList();
            return View(ListOfBooks);

        }


        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Product.Update(product);
                unitOfWork.Save();
                TempData["success"] = "Product has been Edited";
            }
            return  RedirectToAction("Details");
        }


        public IActionResult Delete(int id)
        {
            var ItemTobeRemoved=unitOfWork.Product.Get(u=>u.Id==id);
            if (ItemTobeRemoved != null)
            {
                unitOfWork.Product.Remove(ItemTobeRemoved);
                unitOfWork.Save();
                TempData["success"] = "Product has been deleted";
            }
            return RedirectToAction("Index");
        }


        public IActionResult Details(int? id)
        {

            Console.WriteLine(id+"Here is detail id");
            if(id==0|| id == null)
            {
                return NotFound();
            }


            var product = unitOfWork.Product.Get(u => u.Id == id);
            if (product != null)
            {
                Console.WriteLine($"Product {product.Id} {product.Description}");
                return View(product);
            }
            return NotFound();
        }




    }
}
