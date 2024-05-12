using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repository.Interfaces;

namespace BulkyBookWeb.Repository.Services
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDbContext db;

        public CategoryService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void RemoveCategory(Category category)
        {
            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public Category FindCategoryById(int id)
        {
            var category = db.Categories.Find(id);
            return category;
        }

        public IEnumerable<Category> GetALL()
        {
            IEnumerable<Category> objCategoryList = db.Categories.ToList();
            return objCategoryList;
        }

        public void UpdateCategory(Category category)
        {
            db.Categories.Update(category);
            db.SaveChanges();
        }
    }
}
