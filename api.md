# Exemplo API

> [Início](./README.md)

[https://github.com/Clemilton10/Modelos](https://github.com/Clemilton10/Modelos)

![](https://raw.githubusercontent.com/Clemilton10/icons/409d6f8e4996b306276f8c31332e2574ce7b019e/vs.svg) API Web do ASP.NET Core

![](https://raw.githubusercontent.com/Clemilton10/icons/409d6f8e4996b306276f8c31332e2574ce7b019e/swagger.svg)

```sh
dotnet new webapi -f net6.0 -n api
dotnet sln add api
```

### Pacotes

📝 api\api.csproj

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
	<PropertyGroup>
		<TargetFramework>net6.0</TargetFramework>
		<Nullable>enable</Nullable>
		<ImplicitUsings>enable</ImplicitUsings>
	</PropertyGroup>
	<ItemGroup>
		<PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />
		<PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />
		<PackageReference Include="Microsoft.EntityFrameworkCore" Version="7.0.13" />
		<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="7.0.13">
			<IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
			<PrivateAssets>all</PrivateAssets>
		</PackageReference>
		<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="7.0.13" />
		<PackageReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.3" />
		<PackageReference Include="Swashbuckle.AspNetCore.Annotations" Version="6.5.0" />
		<PackageReference Include="System.Linq.Dynamic.Core" Version="1.3.5" />
	</ItemGroup>
</Project>
```

### Servidor e portas

📝 api\Properties\launchSettings.json

```json
{
	"$schema": "https://json.schemastore.org/launchsettings.json",
	"profiles": {
		"api": {
			"commandName": "Project",
			"dotnetRunMessages": true,
			"launchBrowser": true,
			"launchUrl": "swagger",
			"applicationUrl": "https://localhost:5001;http://localhost:5000",
			"environmentVariables": {
				"ASPNETCORE_ENVIRONMENT": "Development"
			}
		}
	}
}
```

### Configuração do banco de dados

📝 api\appsettings.json

```json
{
	"ConnectionStrings": {
		"sqliteDb": "Data Source=Livros.db",
		"sqlServerDb": "Server=(LocalDb)\\MSSQLLocalDB;Database=livros;Trusted_Connection=True;TrustServerCertificate=True;"
	},
	"Logging": {
		"LogLevel": {
			"Default": "Information",
			"Microsoft.AspNetCore": "Warning"
		}
	},
	"AllowedHosts": "*"
}
```

### Configuração do Prettier

📝 api\.prettierrc.json

```json
{
	"trailingComma": "none",
	"tabWidth": 4,
	"semi": true,
	"singleQuote": true,
	"useTabs": true
}
```

### Modelo

📝 api\Models\Livros.cs

```csharp
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
```

### Controle

📝 api\Controllers\LivrosController.cs

```csharp
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
```

### Contexto

📝 api\Repositories\DataContext.cs

```csharp
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
```

### Interface

📝 api\Repositories\ILivroRepository.cs

```csharp
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
```

> [Início](./README.md)
