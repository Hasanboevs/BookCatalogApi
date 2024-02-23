using Appication.Abstractions;
using Appication.Repositories;
using Infrastructure.Persistencep;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class RegisterServices
{
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<IBookCatalogDbContext, BookCatalogDbContext>(options => 
			
			options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
		);

		services.AddScoped<IBookRepository, BookRepository>().Reverse();
		services.AddScoped<IAuthorRepository, AuthorRepository>().Reverse();
		return services;
	}
}
