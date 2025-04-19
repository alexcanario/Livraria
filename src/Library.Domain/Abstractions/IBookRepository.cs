using Library.Domain.Models;

namespace Library.Domain.Abstractions;

public interface IBookRepository
{
	Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken);
	Task<Book?> GetByIdAsync(int id, CancellationToken cancellationToken);
	Task<Book?> GetByTitleAsync(string title, CancellationToken cancellationToken);
	Task Remove(int id);
	Task AddAsync(Book book, CancellationToken cancellationToken);
	Task UpdateAsync(Book book, CancellationToken cancellationToken);
}