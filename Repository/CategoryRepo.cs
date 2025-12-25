using Microsoft.EntityFrameworkCore;
using WebAPI_Repo__UOW_.Models;
using WebAPI_Repo__UOW_.dbcontext;

namespace WebAPI_Repo__UOW_.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ItemCategorydbcontext _context;

        public CategoryRepo(ItemCategorydbcontext context)
        {
            _context = context;
        }

        public void create(Category category)
        {
            _context.Categories.Add(category);
        }

        public IEnumerable<Category> readall()
        {
            return _context.Categories.Include(c => c.Items).ToList();
        }

        public Category readbyid(int id)
        {
            return _context.Categories.Find(id);
        }

        public void update(Category category)
        {
            _context.Categories.Update(category);
        }

        public void delete(Category category)
        {
            _context.Categories.Remove(category);
        }

    }
}
