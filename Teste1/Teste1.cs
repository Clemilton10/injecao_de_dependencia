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