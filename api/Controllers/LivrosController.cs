using Api.Models;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("livros")]
	[ApiController]
	public class LivroController : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> Read([FromServices] ILivroRepository repository)
		{
			var livros = await repository.Read();
			if (livros == null || livros.Count() == 0)
			{
				return NotFound();//404
			}
			return Ok(livros);//200
		}

		[HttpGet("{Id}")]
		public async Task<IActionResult> OneRead(int Id, [FromServices] ILivroRepository repository)
		{
			if (!ModelState.IsValid)
				return BadRequest();//400

			var livro = await repository.OneRead(Id);

			if (livro == null)
				return NotFound();//404

			return Ok(livro);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] Livro livro, [FromServices] ILivroRepository repository)
		{
			if (!ModelState.IsValid)
				return BadRequest();//400

			Livro l = new Livro();
			l.Titulo = livro.Titulo;
			l.Autor = livro.Autor;
			l.AnoPublicacao = livro.AnoPublicacao;
			l.Preco = livro.Preco;
			await repository.Create(l);
			return Ok(l);//201
		}

		[HttpPut("{Id}")]
		public async Task<IActionResult> Update(int Id, [FromBody] Livro livro, [FromServices] ILivroRepository repository)
		{
			if (!ModelState.IsValid)
				return BadRequest();//400

			var UsuarioId = Convert.ToInt32(User.Identity.Name);
			Livro l = new Livro();
			l.Id = Id;
			l.Titulo = livro.Titulo;
			l.Autor = livro.Autor;
			l.AnoPublicacao = livro.AnoPublicacao;
			l.Preco = livro.Preco;
			await repository.Update(l);
			return Ok(l);//200
		}

		[HttpDelete("{Id}")]
		public async Task<IActionResult> Delete(int Id, [FromServices] ILivroRepository repository)
		{
			await repository.Delete(Id);
			return NoContent();//204
		}
	}
}