using BulkyBookWeb.Models;

namespace BulkyBookWeb.Repository.Interfaces
{
    public interface ICategory<T> where T : class
    {
        Task<IEnumerable<T>> GetALL();
        Task AddCategory(T entity);
        Task<T> FindCategoryById(int id);
        Task UpdateCategory(T entity);
        Task RemoveCategory(T entity);
    }
}