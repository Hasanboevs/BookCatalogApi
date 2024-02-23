using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Services;

public static class RegisterService
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddFluentValidation(opt =>
		opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
		return services;
	}
}
