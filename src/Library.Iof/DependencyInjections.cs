using Library.Domain.Abstractions;
using Library.Infra.Data;
using Library.Infra.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Iof;

public static class DependencyInjections
{
	public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("SqlLiteConnection");
		services.AddDbContext<LibraryDbContext>(opt => opt.UseSqlite(connectionString));

		services.AddScoped<IBookRepository, BookRepository>();

		return services;
	}
}