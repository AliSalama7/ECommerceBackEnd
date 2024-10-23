using Core.Models;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseModel;
        Task<int> Complete();
    }
}
