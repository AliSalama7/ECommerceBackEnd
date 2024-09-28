using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T>  where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetBySpecAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetWithIncludesAsync(ISpecification<T> spec);
        Task <int > CountAsync(ISpecification<T> spec);
    }
}
