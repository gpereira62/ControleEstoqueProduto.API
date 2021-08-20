using ControleEstoqueProduto.API.Controllers;
using ControleEstoqueProduto.BLL.Models;
using ControleEstoqueProduto.DAL;
using ControleEstoqueProduto.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace TestProjectProdutoController
{
	public class UnitTest1
	{

		[Fact(DisplayName = "Cadastrar um produto com sucesso")]
		public async void CadastrarNovoProduto()
		{
			var options = new DbContextOptionsBuilder<Contexto>()
								  .UseInMemoryDatabase(databaseName: "MockDB")
								  .Options;

			var context = new Contexto(options);
			var produtoRepository = new ProdutoRepository(context);

			var produtoEsperado = new Produto { Id = 1, Nome = "produto teste" };
			await produtoRepository.Add(produtoEsperado);

			var resultado = produtoRepository.Get(1);

			Assert.Equal(produtoEsperado.Id, resultado.Result.Id);
		}

		[Fact(DisplayName = "Deve obter um produto pelo id informado")]
		public void TestProdutoControllerGet()
		{
			// Arrange
			var produtoRepository = Substitute.For<IProdutoRepository>();
			var produtosController = new ProdutosController(produtoRepository);
			produtoRepository.Get(1).Returns(Task.FromResult(new Produto { Id = 1, Nome = "produto teste" }));

			// Act
			var resultado = produtosController.GetProduto(1);

			// Assert
			Assert.Equal(1, resultado.Result.Value.Id);
		}




	}
}
