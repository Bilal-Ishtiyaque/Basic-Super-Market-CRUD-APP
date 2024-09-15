using Microsoft.AspNetCore.Mvc;
using Supermarket.Models;

namespace Supermarket.Controllers
{
    public class CategoriesController : Controller
    {
        //When you open "Categories" section, this action method executes. This method shows all categories available in Repository.
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories(); //returns List<Categories> or List of categories.
            return View(categories);
        }

        //When you click on "Edit" this action method executes.
        public IActionResult Edit(int? id)
        {
			ViewBag.Action = "edit";
            //var category = new Category{ CategoryId = id.HasValue?id.Value:0};
            var category = CategoriesRepository.GetCategoryById(id.HasValue?id.Value:0);

            return View(category);
        }

        //When you click "Save", this action method executes. The data you entered, comes into this action method.
        [HttpPost]
		public IActionResult Edit(Category category)
		{
            if (ModelState.IsValid)
            {
				CategoriesRepository.UpdateCategory(category.CategoryId, category);

				return RedirectToAction(nameof(Index));
			}

            return View(category);
		}

		public IActionResult Add()
		{
			ViewBag.Action = "add";
			return View();
		}

		[HttpPost]
		public IActionResult Add(Category category)
		{
			if (ModelState.IsValid)
			{
				CategoriesRepository.AddCategory(category);

				return RedirectToAction(nameof(Index));
			}

			return View(category);
		}

		public IActionResult Delete(int categoryId)
		{
			CategoriesRepository.DeleteCategory(categoryId);
			return RedirectToAction(nameof(Index));
		}



	}
}
