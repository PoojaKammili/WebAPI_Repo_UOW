using WebAPI_Repo__UOW_.UnitOfWork;
using WebAPI_Repo__UOW_.dbcontext;
using WebAPI_Repo_UOW.UnitOfWork;
using WebAPI_Repo__UOW_.Repository;

namespace WebAPI_Repo__UOW_.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ItemCategorydbcontext _context;
        public IItemRepo Items { get; private set; }
        public ICategoryRepo Category { get; private set; }
        public UnitOfWork(ItemCategorydbcontext context)
        { 

            _context = context;
            Items = new ItemRepo(_context);
            Category = new CategoryRepo(_context);

        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
