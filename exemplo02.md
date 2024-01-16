# Exemplo 02

> [Início](./README.md)

## Criando a biblioteca

![](https://raw.githubusercontent.com/Clemilton10/icons/409d6f8e4996b306276f8c31332e2574ce7b019e/vs.svg) Biblioteca de Classes

```sh
dotnet new classlib -f net6.0 -n biblioteca
dotnet sln add biblioteca
```

📝 biblioteca\Calculos.cs

```csharp
namespace Biblioteca
{
	public static class Calculos
	{
		public static double Somar(double numero1, double numero2)
		{
			return (numero1 + numero2);
		}
		public static double Subtrair(double numero1, double numero2)
		{
			return (numero1 - numero2);
		}
		public static double Multiplicar(double numero1, double numero2)
		{
			return (numero1 * numero2);
		}
		public static double Dividir(double numero1, double numero2)
		{
			return (numero1 / numero2);
		}
		public static bool IsNumeroPar(int numero)
		{
			return numero % 2 == 0;
		}
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
using Biblioteca;
using Xunit;

namespace Testes
{
	public class Teste1
	{
		[Fact]
		public void Teste()
		{
			// Arrange
			var num1 = 2.9;
			var num2 = 3.1;
			var valorEsperado = 6;

			// Act
			var soma = Calculos.Somar(num1, num2);

			// Assert
			Assert.Equal(valorEsperado, soma);
		}
	}
}
```

> [Início](./README.md)
