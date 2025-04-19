using Library.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infra.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
	public void Configure(EntityTypeBuilder<Book> builder)
	{
		builder.ToTable("Books");

		builder.HasKey(b => b.Id);
		builder.Property(p => p.Author).HasMaxLength(50).IsRequired();
		builder.Property(p => p.Title).HasMaxLength(50).IsRequired();
		builder.Property(p => p.PublishedDate).IsRequired();
		builder.Property(p => p.BookCover).HasMaxLength(200);
	}
}