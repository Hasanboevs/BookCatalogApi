using Appication.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistencep;
public class BookCatalogDbContext : DbContext, IBookCatalogDbContext
{

    public BookCatalogDbContext(DbContextOptions<BookCatalogDbContext> options): base(options)
    {
    }

	public DbSet<Author> Authors { get ; set ; }
	public DbSet<Book> Books { get ; set ; }


}
