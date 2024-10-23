using Core.Models.OrderAggregate;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T>  where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetBySpecAsync(ISpecifications<T> spec);
        Task<IReadOnlyList<T>> GetWithIncludesAsync(ISpecifications<T> spec);
        Task <int > CountAsync(ISpecifications<T> spec);
        void Add(T item);
        void Remove(T item);
        void Update(T item);
    }
}
