using BulkyBookWeb.Models;
using BulkyBookWeb.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory<Category> category;

        public CategoryController(ICategory<Category> category)
        {
            this.category = category;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> objCategoryList = await category.GetALL();

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
        public async Task<IActionResult> Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                await category.AddCategory(obj);
                TempData["success"] = "Category Created Successfully";
                
                return RedirectToAction("Index");
            }
            
            return View(obj);
        }

		// Get
		public async Task<IActionResult> Edit(int? id)
		{   
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = await category.FindCategoryById((int)id);
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
        public async  Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = await category.FindCategoryById((int)id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            
            return View(categoryFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            var obj = await category.FindCategoryById((int)id);
            if (obj == null)
            {
                return NotFound();
            }
            await category.RemoveCategory(obj);
			TempData["success"] = "Category Deleted Successfully";
			
            return RedirectToAction("Index");
        }
    }
}
