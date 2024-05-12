using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BulkyBookWeb.Repository.Services
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDbContext db;

        public CategoryService(ApplicationDbContext db)
        {
            this.db = db;
        }

        #region AddCategory

        public async Task AddCategory(Category category)
        {
            await db.Categories.AddAsync(category);
            await db.SaveChangesAsync();
        }

        #endregion

        #region RemoveCategory

        public async Task RemoveCategory(int id)
        {
            var category = this.FindCategoyByID(id);
            db.Categories.Remove(await category);
            await db.SaveChangesAsync();
        }

        #endregion

        #region FindCategoryByID

        public async Task<Category> FindCategoyByID(int id)
        {
            var category = await db.Categories.FindAsync(id);

            return category;
        }

        #endregion

        #region GetAll

        public async Task<IEnumerable<ICategory>> GetAll()
        {
            IEnumerable<ICategory> data = (IEnumerable<ICategory>)await db.Categories.ToListAsync();

            return data;
        }

        #endregion

        #region UpdateCategory

        public async Task UpdateCategory(Category category)
        {
            db.Categories.Update(category);
            await db.SaveChangesAsync();
        }

        #endregion

    }
}
