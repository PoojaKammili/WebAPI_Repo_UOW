using WebAPI_Repo__UOW_.Repository;

namespace WebAPI_Repo_UOW.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepo Category { get; }
        IItemRepo Items { get; }
        int Complete();
    }
}
