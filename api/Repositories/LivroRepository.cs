using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
	public class LivroRepository : ILivroRepository
	{
		private readonly AppDbContext _context;
		public LivroRepository(AppDbContext context)
		{
			_context = context;
		}
		public async Task<Livro>? OneRead(int Id)
		{
			return await _context.Livros.FindAsync(Id);
		}
		public async Task<IEnumerable<Livro>> Read()
		{
			return await _context.Livros.ToListAsync();
		}
		public async Task Create(Livro livro)
		{
			_context.Livros.Add(livro);
			await _context.SaveChangesAsync();
		}
		public async Task Delete(int Id)
		{
			var livro = _context.Livros.Find(Id);
			_context.Entry(livro).State = EntityState.Deleted;
			await _context.SaveChangesAsync();
		}
		public async Task Update(Livro livro)
		{
			var _livro = _context.Livros.Find(livro.Id);
			_livro.Titulo = livro.Titulo;
			_livro.Autor = livro.Autor;
			_livro.AnoPublicacao = livro.AnoPublicacao;
			_livro.Preco = livro.Preco;
			_context.Entry(_livro).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}