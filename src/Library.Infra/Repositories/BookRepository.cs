using Library.Domain.Abstractions;
using Library.Domain.Models;
using Library.Infra.Data;

using Microsoft.EntityFrameworkCore;

namespace Library.Infra.Repositories;

public class BookRepository(LibraryDbContext ctx) : IBookRepository
{
	public async Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken)
	{
		var books = await ctx.Books.ToListAsync(cancellationToken);
		return books;
	}

	public async Task<Book?> GetByIdAsync(int id)
	{
		return await ctx.Books.FirstOrDefaultAsync(b => b.Id == id);
	}

	public async Task<Book?> GetByTitleAsync(string title, CancellationToken cancellationToken)
	{
		return await ctx.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Title == title, cancellationToken) ?? null;
	}

	public async Task Remove(int id)
	{
		var book = await GetByIdAsync(id);
		if (book is not null)
		{
			ctx.Books.Remove(book);
			await ctx.SaveChangesAsync();
		}
	}

	public async Task AddAsync(Book book, CancellationToken cancellationToken)
	{
		await ctx.Books.AddAsync(book, cancellationToken);
		await ctx.SaveChangesAsync(cancellationToken);
	}

	public async Task UpdateAsync(Book book, CancellationToken cancellationToken)
	{
		var bookToUpdate = await ctx.Books.FindAsync([book.Id], cancellationToken);
		if (bookToUpdate is null)
			throw new Exception("Book not found");

		bookToUpdate.Title = book.Title;
		bookToUpdate.Author = book.Author;
		bookToUpdate.PublishedDate = book.PublishedDate;
		bookToUpdate.BookCover = book.BookCover;
		bookToUpdate.Publisher = book.Publisher;
		bookToUpdate.Category = book.Category;

		ctx.Books.Update(bookToUpdate);
		await ctx.SaveChangesAsync(cancellationToken);
	}
}