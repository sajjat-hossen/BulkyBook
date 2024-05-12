using BulkyBookWeb.Models;

namespace BulkyBookWeb.Repository.Interfaces
{
    public interface ICategory<T> where T : class
    {
        IEnumerable<T> GetALL();
        void AddCategory(T entity);
        T FindCategoryById(int id);
        void UpdateCategory(T entity);
        void RemoveCategory(T entity);
    }
}