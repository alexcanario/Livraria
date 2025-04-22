using Library.Domain.Models;

namespace Library.Domain.Abstractions;

public interface IBookRepository
{
	Task<IEnumerable<Book>> GetAllAsync();
	Task<Book?> GetByIdAsync(int id);
	Task<Book?> GetByTitleAsync(string title, CancellationToken cancellationToken);
	Task Remove(int id);
	Task AddAsync(Book book);
	Task UpdateAsync(Book book);
}