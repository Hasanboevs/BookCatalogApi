using Appication.Abstractions;
using Appication.Repositories;
using Domain.Entities;
using System.Linq.Expressions;

namespace Infrastructure.Services;

public class BookRepository : IBookRepository
{
	private readonly IBookCatalogDbContext _bookCatalogDbContext;

	public BookRepository(IBookCatalogDbContext bookCatalogDbContext)
	{
		_bookCatalogDbContext = bookCatalogDbContext;
	}

	public async Task<Book?> AddAsync(Book book)
	{
		_bookCatalogDbContext.Books.Attach(book);
		int result = await _bookCatalogDbContext.SaveChangesAsync();
		if (result > 0)
		{
			return book;
		}
		return null;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var book = await _bookCatalogDbContext.Books.FindAsync(id);

		if (book == null)
		{
			return false;
		}
		_bookCatalogDbContext.Books.Remove(book);
		await _bookCatalogDbContext.SaveChangesAsync();
		return true;
	}

	public Task<IQueryable<Book>> GetAync(Expression<Func<Book, bool>> predicate)
	{
		return Task.FromResult(_bookCatalogDbContext.Books.Where(predicate));
	}


	public async Task<Book?> GetByAsync(int Id)
	{
		return await _bookCatalogDbContext.Books.FindAsync(Id);
	}

	public async Task<IEnumerable<Book>?> GetRangeAsync(IEnumerable<Book> books)
	{
		_bookCatalogDbContext.Books.AttachRange(books);
		var result = await _bookCatalogDbContext.SaveChangesAsync();
		if (result > 0)
		{
			return books;
		}

		return null;
	}

	public async Task<Book?> UpdateAsync(Book book)
	{
		_bookCatalogDbContext.Books.Update(book);

		var res = await _bookCatalogDbContext.SaveChangesAsync();
		if (res > 0)
		{
			return book;
		}

		return null;
	}


}
