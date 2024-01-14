using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

public class Livro
{
	public int? Id { get; set; }

	// TEXT // VARCHAR(50) //
	[Column(TypeName = "VARCHAR(50)")]
	public string? Titulo { get; set; } = string.Empty;

	// TEXT // VARCHAR(50) //
	[Column(TypeName = "VARCHAR(50)")]
	public string? Autor { get; set; } = string.Empty;

	// INTEGER // INT //
	[Column(TypeName = "INT")]
	public int? AnoPublicacao { get; set; } = 0;

	// REAL // DECIMAL(20) //
	[Column(TypeName = "DECIMAL(20)")]
	public double? Preco { get; set; } = 0;
}
