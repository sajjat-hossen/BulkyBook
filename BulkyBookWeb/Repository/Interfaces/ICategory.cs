using BulkyBookWeb.Models;

namespace BulkyBookWeb.Repository.Interfaces
{
    public interface ICategory
    {
        Task<IEnumerable<ICategory>> GetAll();
        Task AddCategory(Category category);
        Task<Category> FindCategoyByID(int id);
        Task UpdateCategory(Category category);
        Task RemoveCategory(int id);

    }
}