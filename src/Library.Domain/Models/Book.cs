using System.ComponentModel.DataAnnotations;
using Library.Domain.Enums;

namespace Library.Domain.Models;

public sealed class Book(
	int id,
	string title,
	string author,
	DateTime publishedDate,
	string bookCover,
	EPublisher publisher,
	ECategory category)
{
	[Key]
	public int Id { get; set; } = id;
	
	[Required(ErrorMessage = "Informe o título do livro")]
	[StringLength(100, ErrorMessage = "Minomo de {2} e máximo de {1}", MinimumLength = 10)]
	public string Title { get; set; } = title;

	[Required(ErrorMessage = "Informe o autor do livro")]
	[StringLength(100)]
	public string Author { get; set; } = author;

	[Required(ErrorMessage = "Informe a data de publicação do livro")]
	public DateTime PublishedDate { get; set; } = publishedDate;

	[Required(ErrorMessage = "Informe a capa do livro")]
	public string BookCover { get; set; } = bookCover;

	[Required]
	[EnumDataType(typeof(EPublisher), ErrorMessage = "Informe uma editora válida")]
	public EPublisher Publisher { get; set; } = publisher;

	[Required]
	[EnumDataType(typeof(ECategory), ErrorMessage = "Informe uma categoria válida")]
	public ECategory Category { get; set; } = category;
}