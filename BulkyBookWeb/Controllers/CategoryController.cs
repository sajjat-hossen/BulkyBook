using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory category;

        public CategoryController(ICategory category)
        {
            this.category = category;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = category.GetALL();
            return View(objCategoryList);
        }
        // Get
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                category.AddCategory(obj);
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

		// Get
		public IActionResult Edit(int? id)
		{   
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = category.FindCategoryById((int)id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
			return View(categoryFromDb);
		}

		// POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category obj)
		{
			if (ModelState.IsValid)
			{
				category.UpdateCategory(obj);
				TempData["success"] = "Category Edited Successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}

        // Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = category.FindCategoryById((int)id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = category.FindCategoryById((int)id);
            if (obj == null)
            {
                return NotFound();
            }
            category.RemoveCategory(obj);
			TempData["success"] = "Category Deleted Successfully";
			return RedirectToAction("Index");
        }
    }
}
