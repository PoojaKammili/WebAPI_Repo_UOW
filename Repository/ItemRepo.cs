using Microsoft.EntityFrameworkCore;
using WebAPI_Repo__UOW_.Models;
using WebAPI_Repo__UOW_.dbcontext;

namespace WebAPI_Repo__UOW_.Repository
{
    public class ItemRepo : IItemRepo
    {
        private readonly ItemCategorydbcontext _context;

        public ItemRepo(ItemCategorydbcontext context)
        {
            _context = context;
        }

        public void create(Item item)
        {
            _context.Items.Add(item);
        }

        public List<Item> readall()
        {
            return _context.Items.Include(i => i.Category).ToList();
        }

        public Item readbyid(int id)
        {
            return _context.Items.Find(id);
        }

        public void update(Item item)
        {
            _context.Items.Update(item);
        }

        public void delete(Item item)
        {
            _context.Items.Remove(item);
        }
    }
}
