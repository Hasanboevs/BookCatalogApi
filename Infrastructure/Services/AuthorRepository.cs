using Appication.Abstractions;
using Appication.Repositories;
using Domain.Entities;
using System.Linq.Expressions;

namespace Infrastructure.Services;

public class AuthorRepository : IAuthorRepository
{
	private readonly IBookCatalogDbContext _bookCatalogDbContext;

	public AuthorRepository(IBookCatalogDbContext bookCatalogDbContext)
	{
		_bookCatalogDbContext = bookCatalogDbContext;
	}

	public async Task<Author?> AddAsync(Author author)
	{
		_bookCatalogDbContext.Authors.Attach(author);
		int result = await _bookCatalogDbContext.SaveChangesAsync();
		if(result > 0)
		{
			return author;
		}
		return null;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var author = await _bookCatalogDbContext.Authors.FindAsync(id);

		if(author == null)
		{
			return false;
		}
		_bookCatalogDbContext.Authors.Remove(author);
		await _bookCatalogDbContext.SaveChangesAsync();
		return true;
	}

	public Task<IQueryable<Author>> GetAync(Expression<Func<Author, bool>> predicate)
	{
		return Task.FromResult(_bookCatalogDbContext.Authors.Where(predicate));
	}


	public async Task<Author?> GetByAsync(int Id)
	{
		return await _bookCatalogDbContext.Authors.FindAsync(Id);
	}

	public async Task<IEnumerable<Author>?> GetRangeAsync(IEnumerable<Author> authors)
	{
		_bookCatalogDbContext.Authors.AttachRange(authors);
		var result = await _bookCatalogDbContext.SaveChangesAsync();
		if(result > 0 )
		{
			return authors;
		}

		return null;
	}

	public async Task<Author?> UpdateAsync(Author author)
	{
		_bookCatalogDbContext.Authors.Update(author);

		var res = await _bookCatalogDbContext.SaveChangesAsync();
		if(res > 0)
		{
			return author;
		}

		return null;
	}


}
