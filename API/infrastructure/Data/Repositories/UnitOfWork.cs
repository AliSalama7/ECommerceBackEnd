using Core.Interfaces;
using Core.Models;
using System.Collections;

namespace Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _storeContext;
        private Hashtable _repositories;
        public UnitOfWork(StoreContext storeContext) 
        {
            _storeContext = storeContext;
        }

        public async Task<int> Complete()
        {
            return await _storeContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _storeContext.Dispose();
        }

        public IGenericRepository<T> Repository<T>() where T : BaseModel
        {
            if (_repositories == null) { _repositories = new Hashtable(); }
            var type = typeof(T).Name;
            if (!_repositories.ContainsKey(type)) 
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)),_storeContext);
                _repositories[type] = repositoryInstance;
            }
            return (IGenericRepository<T>) _repositories[type];
        }
    }
}
