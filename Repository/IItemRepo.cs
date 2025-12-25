using WebAPI_Repo__UOW_.Models;

namespace WebAPI_Repo__UOW_.Repository
{
    public interface IItemRepo
    {
        void create(Item item);
        List<Item> readall();
        Item readbyid(int id);
        void update(Item item);
        void delete(Item item);
    }
}
