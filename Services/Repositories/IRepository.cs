using System.Linq.Expressions;

namespace Appication.Repositories;

public interface IRepository<T>
{
	public Task<IQueryable<T>> GetAync(Expression<Func<T, bool>> predicate);

	public Task<T> GetByAsync(int Id);
	public Task<T> AddAsync(T snyc);

	public Task<IEnumerable<T>> GetRangeAsync(IEnumerable<T> sync);
	public Task<T> UpdateAsync(T snyc);
	public Task<bool> DeleteAsync(int id);
}
