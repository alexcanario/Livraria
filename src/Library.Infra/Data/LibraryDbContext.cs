using Library.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Library.Infra.Data;

public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options)
{
	public DbSet<Book> Books { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);
	}
}