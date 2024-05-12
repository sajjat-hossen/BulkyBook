using BulkyBookWeb.Models;

namespace BulkyBookWeb.Repository.Interfaces
{
    public interface ICategory
    {
        IEnumerable<Category> GetALL();
        void AddCategory(Category category);
        Category FindCategoryById(int id);
        void UpdateCategory(Category category);
        void RemoveCategory(Category category);
    }
}
