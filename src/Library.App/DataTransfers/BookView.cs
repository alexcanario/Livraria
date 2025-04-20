using System.ComponentModel.DataAnnotations;

using Library.Domain.Enums;

namespace Library.App.DataTransfers;

public class BookView(
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
	[StringLength(50, ErrorMessage = "Mínimo de {2} e máximo de {1}", MinimumLength = 5)]
	public string Title { get; set; } = title;

	[Required(ErrorMessage = "Informe o autor do livro")]
	[StringLength(50)]
	public string Author { get; set; } = author;

	[Required(ErrorMessage = "Informe a data de publicação do livro")]
	public DateTime PublishedDate { get; set; } = publishedDate;

	[Required(ErrorMessage = "Informe uma capa válida")]
	[StringLength(200)]
	public string BookCover { get; set; } = bookCover;

	[Required]
	[EnumDataType(typeof(EPublisher), ErrorMessage = "Informe uma editora válida")]
	public EPublisher Publisher { get; set; } = publisher;

	[Required]
	[EnumDataType(typeof(ECategory), ErrorMessage = "Informe uma categoria válida")]
	public ECategory Category { get; set; } = category;
}