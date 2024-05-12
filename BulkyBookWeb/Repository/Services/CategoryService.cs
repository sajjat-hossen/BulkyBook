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

        public async Task AddCategory(T category)
        {
            await dbSet.AddAsync(category);
            await db.SaveChangesAsync();
        }

        #endregion

        #region RemoveCategory

        public async Task RemoveCategory(T category)
        {
            dbSet.Remove(category);
            await db.SaveChangesAsync();
        }

        #endregion

        #region FindCategoryById

        public async Task<T> FindCategoryById(int id)
        {
            var category = await dbSet.FindAsync(id);
            return category;
        }

        #endregion

        #region GetAll

        public async Task<IEnumerable<T>> GetALL()
        {
            IEnumerable<T> objCategoryList = await dbSet.ToListAsync();
            return objCategoryList;
        }

        #endregion

        #region UpdateCategory

        public async Task UpdateCategory(T category)
        {
            dbSet.Update(category);
            await db.SaveChangesAsync();
        }

        #endregion

    }
}
