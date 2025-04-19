using Library.Domain.Enums;

namespace Library.Domain.Models;

public sealed class Book
{
    public Book(int id, string title, string author, DateTime publishedDate, string bookCover, EPublisher publisher, ECategory category)
    {
        Title = title;
        Author = author;
        PublishedDate = publishedDate;
        BookCover = bookCover;
        Publisher = publisher;
        Category = category;
    }
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public string BookCover { get; set; } = string.Empty;
    public EPublisher Publisher { get; set; } = EPublisher.Other;
    public ECategory Category { get; set; } = ECategory.Other;
}