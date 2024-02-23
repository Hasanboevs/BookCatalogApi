using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Appication.Abstractions;

public interface IBookCatalogDbContext
{
	public DbSet<Author> Authors { get; set; }
	public DbSet<Book> Books { get; set; }
	public Task<int> SaveChangesAsync(CancellationToken cancellationToken=default);

}
