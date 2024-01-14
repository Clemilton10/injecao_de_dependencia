# Injeção de Dependência

## AddTransient

Uma nova instância a cada solicitação.

## AddScoped

Uma instância por solicitação HTTP.

## Add Singleton

Uma instância única compartilhada entre todas as solicitações.

```csharp
// Interface
public interface ICalculator
{
	int Sum(int a, int b);
	int Subtract(int a, int b);
	int Multiply(int a, int b);
}

// Serviço que extende à interface
public class Calculator : ICalculator
{
	public int Sum(int a, int b)
	{
		return a + b;
	}

	public int Subtract(int a, int b)
	{
		return a - b;
	}

	public int Multiply(int a, int b)
	{
		return a * b;
	}
}
```

```csharp
public class CalculatorTest
{
	private readonly ICalculator _calculator;

	public CalculatorTest()
	{
		var service = new ServiceCollection();
		service.AddTransient<ICalculator, Calculator>();

		var provider = service.BuildServiceProvider();
		_calculator = provider.GetService<ICalculator>();
	}

	[Fact]
	public void Test_Sum()
	{
		var result = _calculator.Sum(2, 3);
		Assert.Equal(5, result);
	}

	[Fact]
	public void Test_Subtract()
	{
		var result = _calculator.Subtract(2, 3);
		Assert.Equal(-1, result);
	}

	[Fact]
	public void Test_Multiply()
	{
		var result = _calculator.Multiply(3, 2);
		Assert.Equal(6, result);
	}
}
```

# Dotnet

```sh
# Listar pacotes
dotnet list package

# instalar pacotes pelo XML
dotnet restore

# Adicionar pacotes
dotnet add package nome

# Remover pacotes
dotnet remove package nome

# Limpar
dotnet clean

# Executar
dotnet run
dotnet run --urls "https://localhost:5000"
dotnet watch run

# Criar o executável
dotnet build

dotnet --version
dotnet --list-sdks
dotnet --list-runtimes
```

# Api

[https://github.com/Clemilton10/Modelos](https://github.com/Clemilton10/Modelos)

![](./vs.svg) API Web do ASP.NET Core

![](./swagger.svg)

```sh
dotnet new webapi -f net6.0 -n api
dotnet sln add api
```

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

📝 api\appsettings.json

```json
{
	"ConnectionStrings": {
		"WebApiDatabase": "Data Source=Livros.db"
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

```sh
# Instalando
dotnet tool install --global dotnet-ef

# Drop-Database migrationName
dotnet ef database drop migrationName

# Remove-Migration migrationName
dotnet ef migrations remove migrationName

# Add-Migration InitialCreate migrationName
dotnet ef migrations add migrationName

# update-database migrationName
dotnet ef database update migrationName

# Get-Migration
dotnet ef migrations list
```
