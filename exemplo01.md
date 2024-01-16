# Exemplo 01

> [Início](./README.md)

## Criando a biblioteca

![](https://raw.githubusercontent.com/Clemilton10/icons/409d6f8e4996b306276f8c31332e2574ce7b019e/vs.svg) Biblioteca de Classes

```sh
dotnet new classlib -f net6.0 -n biblioteca
dotnet sln add biblioteca
```

📝 biblioteca\Calculator.cs

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

## Criando o ambiente de teste

![](https://raw.githubusercontent.com/Clemilton10/icons/409d6f8e4996b306276f8c31332e2574ce7b019e/vs.svg) Projeto de Teste do xUnit

```sh
dotnet new xunit -n teste
dotnet sln add teste
```

## Vinculando a biblioteca no ambiente de teste

Clique com ![](https://raw.githubusercontent.com/Clemilton10/icons/409d6f8e4996b306276f8c31332e2574ce7b019e/bt_right.svg) na solução ➔ Adicionar ➔ Referência de Projeto

✅ biblioteca

```sh
dotnet add api reference biblioteca
```

## Código do ambiente de teste

📝 teste\teste.csproj

```xml
<Project Sdk="Microsoft.NET.Sdk">
	<PropertyGroup>
		<TargetFramework>net6.0</TargetFramework>
		<ImplicitUsings>enable</ImplicitUsings>
		<Nullable>enable</Nullable>
		<IsPackable>false</IsPackable>
	</PropertyGroup>
	<ItemGroup>
		<PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="6.0.1" />
		<PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.1.0" />
		<PackageReference Include="xunit" Version="2.4.1" />
		<PackageReference Include="xunit.runner.visualstudio" Version="2.4.3">
			<IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
			<PrivateAssets>all</PrivateAssets>
		</PackageReference>
		<PackageReference Include="coverlet.collector" Version="3.1.2">
			<IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
			<PrivateAssets>all</PrivateAssets>
		</PackageReference>
	</ItemGroup>
	<ItemGroup>
		<ProjectReference Include="..\biblioteca\biblioteca.csproj" />
	</ItemGroup>
</Project>
```

📝 teste\teste.cs

```csharp
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Testes
{
	public class Teste
	{
		private readonly ICalculator _calculator;

		public Teste()
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
}
```

> [Início](./README.md)
