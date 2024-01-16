using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		public DbSet<Livro> Livros { get; set; }
	}
}