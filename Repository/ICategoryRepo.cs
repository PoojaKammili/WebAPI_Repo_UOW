using WebAPI_Repo__UOW_.Models;

namespace WebAPI_Repo__UOW_.Repository
{
    public interface ICategoryRepo
    {
        void create(Category category);
        IEnumerable<Category> readall();
        Category readbyid(int id);
        void update(Category category);
        void delete(Category category);
    }
}
