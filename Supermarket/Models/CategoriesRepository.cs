//This is Static Inmemory Repository where all the data operations are encapsulated.
//Everytime we run this application, we will have atleast three categories to work with.
namespace Supermarket.Models
{
	public class CategoriesRepository
	{
		private static List<Category> _categories = new List<Category>()
		{
			new Category{ CategoryId = 1, Name = "Beverage", Description = "Beverage"},
			new Category{ CategoryId = 2, Name = "Bakery", Description = "Bakery"},
			new Category{ CategoryId = 3, Name = "Meat", Description = "Meat"}
		};

		public static void AddCategory(Category category)
		{
			var maxId = _categories.Max(c => c.CategoryId);
			category.CategoryId = maxId + 1;
			_categories.Add(category);
		}

		public static List<Category> GetCategories() => _categories;

		public static Category? GetCategoryById(int categoryId)
		{
			var category = _categories.FirstOrDefault(c => c.CategoryId == categoryId);
			if(category != null)
			{
				//we are returning a new copy of category object not a real category object.
				return new Category
				{
					CategoryId = category.CategoryId,
					Name = category.Name,
					Description = category.Description,
				};
			}

			return null;
		}

		public static void UpdateCategory(int categoryId, Category category)
		{
			if (categoryId != category.CategoryId) return;

			var categoryToUpdate = _categories.FirstOrDefault(c => c.CategoryId == categoryId);
			if (categoryToUpdate != null)
			{
				categoryToUpdate.Name = category.Name;
				categoryToUpdate.Description = category.Description;
			}
		}

		public static void DeleteCategory(int categoryId)
		{
			var category = _categories.FirstOrDefault(c => c.CategoryId == categoryId);
			if (category != null)
			{
				_categories.Remove(category);
			}
		}


	}
}
