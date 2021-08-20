using ControleEstoqueProduto.API.Controllers;
using ControleEstoqueProduto.BLL.Models;
using ControleEstoqueProduto.DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestProjectProdutoController
{
	public class UnitTestController
	{
		private IProdutoRepository produtoRepository;
		private ProdutosController produtosController;

		public UnitTestController()
		{
			produtoRepository = Substitute.For<IProdutoRepository>();
			produtosController = new ProdutosController(produtoRepository);
		}

		[Fact(DisplayName = "Cadastrar um produto com sucesso")]
		public async void TestProdutoControllerPostProduto()
		{
			// Arrange
			var produto = new Produto { Id = 1, Nome = "produto teste" };

			// Act
			var resultado = await produtosController.PostProduto(produto);

			// Assert
			Assert.IsType<CreatedAtActionResult>(resultado.Result);
		}

		[Fact(DisplayName = "Consultar produtos com sucesso")]
		public void TestProdutoControllerGetProdutos()
		{
			// Arrange
			List<Produto> listProdutos = new List<Produto>();
			listProdutos.Add(new Produto { Id = 1, Nome = "produto teste 1" });
			listProdutos.Add(new Produto { Id = 2, Nome = "produto teste 2" });
			listProdutos.Add(new Produto { Id = 3, Nome = "produto teste 3" });
			ActionResult<IEnumerable<Produto>> Produtos = listProdutos;
			produtoRepository.GetAll().Returns(Task.FromResult(Produtos));

			// Act
			var resultado = produtosController.GetProdutos();

			// Assert
			Assert.Equal(Produtos.Value.Where(p => p.Id == 1 && p.Nome.Equals("produto teste 1")), 
				resultado.Result.Value.Where(p => p.Id == 1 && p.Nome.Equals("produto teste 1")));
			Assert.Equal(Produtos.Value.Where(p => p.Id == 2 && p.Nome.Equals("produto teste 2")), 
				resultado.Result.Value.Where(p => p.Id == 2 && p.Nome.Equals("produto teste 2")));
			Assert.Equal(Produtos.Value.Where(p => p.Id == 3 && p.Nome.Equals("produto teste 3")), 
				resultado.Result.Value.Where(p => p.Id == 3 && p.Nome.Equals("produto teste 3")));
			Assert.Equal(Produtos.Value.Count(), resultado.Result.Value.Count());
			Assert.IsType<ActionResult<IEnumerable<Produto>>>(resultado.Result);
		}

		[Fact(DisplayName = "Consultar um produto por Id com sucesso")]
		public void TestProdutoControllerGetProduto()
		{
			// Arrange
			produtoRepository.Get(1).Returns(Task.FromResult(new Produto { Id = 1, Nome = "produto teste" }));

			// Act
			var resultado = produtosController.GetProduto(1);

			// Assert
			Assert.Equal(1, resultado.Result.Value.Id);
		}

		[Fact(DisplayName = "Alterar um produto com sucesso")]
		public async void TestProdutoControllerPutProduto()
		{
			// Arrange
			produtoRepository.ProdutoExists(1).Returns(true);
			produtoRepository.ProdutoDeleteExists(1).Returns(false);
			var produto = new Produto { Id = 1, Nome = "produto teste" };
			int id = 1;

			// Act
			var resultado = await produtosController.PutProduto(id, produto);

			// Assert
			Assert.IsType<NoContentResult>(resultado);
		}

		[Fact(DisplayName = "Deletar um produto com sucesso")]
		public async void TestProdutoControllerDeleteProduto()
		{
			// Arrange
			produtoRepository.Get(1).Returns(Task.FromResult(new Produto { Id = 1, Nome = "produto teste" }));

			// Act
			var resultado = await produtosController.DeleteProduto(1);

			// Assert
			Assert.IsType<NoContentResult>(resultado);
		}

	}
}
