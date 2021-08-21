using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleEstoqueProduto.BLL.Models;
using ControleEstoqueProduto.DAL;
using ControleEstoqueProduto.DAL.Repository;

namespace ControleEstoqueProduto.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/produtos/")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly DateTime _horarioBrasilia;
        private readonly IProdutoRepository _produtoRepository;

		public ProdutosController(IProdutoRepository produtoRepository)
		{
            _produtoRepository = produtoRepository;
            _horarioBrasilia = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
        }

        // GET: api/v1/produtos/
        /// <summary>
        /// Retorna os produtos cadastrados
        /// </summary>
        /// <returns>Os produtos cadastrados</returns>
        /// <response code="200">Retorna uma lista dos produtos cadastrados</response>
        [HttpGet]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _produtoRepository.GetAll();
        }

        // GET: api/v1/produtos/1
        /// <summary>
        /// Retorna o produto cadastrado pelo id informado
        /// </summary>
        /// <returns>O produto cadastrado pelo id informado</returns>
        /// <response code="200">Retorna o produto pelo id informado</response>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _produtoRepository.Get(id);

            if (produto == null)
                return NotFound(new { message = "Produto não encontrado" } );

            return produto;
        }

        // PUT: api/v1/produtos/1
        /// <summary>
        /// Edita o produto pelo id informado
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     api/Produtos
        ///     {
        ///        "id": 1,
        ///        "nome": "Produto 1",
        ///        "qtde": 1,
        ///        "ativo": true,
        ///     }
        ///
        /// </remarks>
        /// <returns>O produto cadastrado pelo id informado</returns>
        /// <response code="204">Retorna vazio indicando que o produto foi alterado com sucesso</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
		{
            if (id != produto.Id)
                return BadRequest(new { message = "Id filtrado é diferente do Id do request body." });

			if (!_produtoRepository.ProdutoExists(id))
                return NotFound(new { message = "Produto não encontrado." });

            produto.Nome = produto.Nome.Trim();

			if (_produtoRepository.ProdutoDeleteExists(id))
				return Conflict("Este produto foi deletado e não é possível alterá-lo");

			produto.DataAlteracao = _horarioBrasilia;
            await _produtoRepository.Update(produto);

            return NoContent();
        }

        // POST: api/v1/produtos/
        /// <summary>
        /// Cria um novo produto
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     api/Produtos
        ///     {
        ///        "id": 1,
        ///        "nome": "Produto 1",
        ///        "qtde": 1,
        ///        "ativo": true,
        ///     }
        ///
        /// </remarks>
        /// <returns>Um novo produto criado</returns>
        /// <response code="201">Retorna o produto indicando que ele foi criado com sucesso</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(201)]
        //[ProducesResponseType(typeof(ProdutoPostStatus200), StatusCodes.Status200OK)]
        //[SwaggerRequestExample]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            produto.Nome = produto.Nome.Trim();

            produto.DataInclusao = _horarioBrasilia;
            produto.DataAlteracao = _horarioBrasilia;

            await _produtoRepository.Add(produto);

            return CreatedAtAction("GetProdutos", new { id = produto.Id }, produto);
        }

        // DELETE: api/v1/produtos/1
        /// <summary>
        /// Deleta o produto filtrado pelo id informado(Este delete é somente virtual, garantido que o produto continue no banco caso precise dele para algum reprocesso. 
        /// Existe uma variável no banco de dados chamada "Delete" do tipo boolean, onde somente trocamos está variável para true e não mostramos mais em nenhum Get e 
        /// tambem não será possivel alterar em um Put)
        /// </summary>
        /// <returns>Não é retornado nenhuma informação, indicando que a exclusão foi feita com sucesso</returns>
        /// <response code="204">Retorna vazio indicando que a exclusão foi feita com sucesso</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _produtoRepository.Get(id);
            if (produto == null)
                return NotFound(new { message = "Produto não encontrado." });

            produto.DataAlteracao = _horarioBrasilia;
            await _produtoRepository.Delete(produto);

            return NoContent();
        }

    }
}
