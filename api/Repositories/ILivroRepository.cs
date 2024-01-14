using Api.Models;

namespace Api.Repositories
{
	public interface ILivroRepository
	{
		Task<Livro>? OneRead(int Id);
		Task<IEnumerable<Livro>> Read();
		Task Create(Livro livro);
		Task Delete(int Id);
		Task Update(Livro livro);
	}
}