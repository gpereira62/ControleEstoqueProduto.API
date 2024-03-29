﻿using ControleEstoqueProduto.BLL.Models;
using ControleEstoqueProduto.DAL;
using ControleEstoqueProduto.DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace TestProjectProdutoController
{
	public class UnitTestRepository
	{

		private DbContextOptions<Contexto> options;
		private Contexto context;
		private ProdutoRepository produtoRepository;

		public UnitTestRepository()
		{
			options = new DbContextOptionsBuilder<Contexto>()
							  .UseInMemoryDatabase(databaseName: "MockDB")
							  .Options;
			context = new Contexto(options);
			produtoRepository = new ProdutoRepository(context);
		}

		[Fact(DisplayName = "Consultar produtos com sucesso")]
		public async void TestProdutoRepositoryGetAll()
		{
			// Arrange
			context.Produtos.RemoveRange(context.Produtos);
			var produto1 = new Produto { Id = 1, Nome = "produto 1" };
			var produto2 = new Produto { Id = 2, Nome = "produto 2" };
			var produto3 = new Produto { Id = 3, Nome = "produto 3" };
			await produtoRepository.Add(produto1);
			await produtoRepository.Add(produto2);
			await produtoRepository.Add(produto3);


			// Act
			var resultado = produtoRepository.GetAll();

			// Assert
			Assert.Equal(3, resultado.Result.Value.Count());
			Assert.Equal(produto1, resultado.Result.Value.Where(p => p.Id == 1).FirstOrDefault());
			Assert.Equal(produto2, resultado.Result.Value.Where(p => p.Id == 2).FirstOrDefault());
			Assert.Equal(produto3, resultado.Result.Value.Where(p => p.Id == 3).FirstOrDefault());
		}

		[Fact(DisplayName = "Consultar um produto por Id com sucesso")]
		public async void TestProdutoRepositoryGet()
		{
			// Arrange
			context.Produtos.RemoveRange(context.Produtos);
			var produto = new Produto { Id = 1, Nome = "produto 1" };
			await produtoRepository.Add(produto);


			// Act
			var resultado = produtoRepository.Get(1);

			// Assert
			Assert.Equal(produto, resultado.Result);
			Assert.Equal(produto.Id, resultado.Result.Id);
		}

		[Fact(DisplayName = "Alterar um produto com sucesso")]
		public async void TestProdutoRepositoryUpdate()
		{
			// Arrange
			var produto = new Produto { Id = 1, Nome = "produto 1" };
			await produtoRepository.Add(produto);
			produto.Nome = "produto alterado";

			// Act
			await produtoRepository.Update(produto);

			// Assert
			Assert.Equal(1, produtoRepository.Get(1).Result.Id);
			Assert.NotEqual("produto 1", produtoRepository.Get(1).Result.Nome);
			Assert.Equal("produto alterado", produtoRepository.Get(1).Result.Nome);
		}

		[Fact(DisplayName = "Cadastrar um produto com sucesso")]
		public async void TestProdutoRepositoryAdd()
		{
			// Arrange
			context.Produtos.RemoveRange(context.Produtos);
			var produtoEsperado = new Produto { Id = 1, Nome = "produto teste" };

			// Act
			await produtoRepository.Add(produtoEsperado);

			// Assert
			var resultado = produtoRepository.Get(1);
			Assert.Equal(produtoEsperado.Id, resultado.Result.Id);
		}

		[Fact(DisplayName = "Deletar um produto com sucesso")]
		public async void TestProdutoRepositoryDelete()
		{
			// Arrange
			context.Produtos.RemoveRange(context.Produtos);
			var produtoDeletado = new Produto { Id = 1, Nome = "produto teste" };
			await produtoRepository.Add(produtoDeletado);

			// Act
			await produtoRepository.Delete(produtoDeletado);

			// Assert
			var resultado = await produtoRepository.Get(1);
			Assert.Null(resultado);
		}

	}
}
