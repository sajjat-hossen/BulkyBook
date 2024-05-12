using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BulkyBookWeb.Repository.Services
{
    public class CategoryService<T> : ICategory<T> where T : class
    {
        private readonly ApplicationDbContext db;
        DbSet<T> dbSet;

        public CategoryService(ApplicationDbContext db)
        {
            this.db = db;
            dbSet = db.Set<T>();
        }
        #region AddCategory

        public void AddCategory(T category)
        {
            dbSet.Add(category);
            db.SaveChanges();
        }

        #endregion

        #region RemoveCategory

        public void RemoveCategory(T category)
        {
            dbSet.Remove(category);
            db.SaveChanges();
        }

        #endregion

        #region FindCategoryById

        public T FindCategoryById(int id)
        {
            var category = dbSet.Find(id);
            return category;
        }

        #endregion

        #region GetAll

        public IEnumerable<T> GetALL()
        {
            IEnumerable<T> objCategoryList = dbSet.ToList();
            return objCategoryList;
        }

        #endregion

        #region UpdateCategory

        public void UpdateCategory(T category)
        {
            dbSet.Update(category);
            db.SaveChanges();
        }

        #endregion

    }
}
