using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleEstoqueProduto.BLL.Models;
using ControleEstoqueProduto.DAL;

namespace ControleEstoqueProduto.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/produtos/")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly Contexto _context;
        private DateTime horarioBrasilia = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public ProdutosController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Produtos/
        /// <summary>
        /// Retorna os produtos cadastrados
        /// </summary>
        /// <returns>Os produtos cadastrados</returns>
        /// <response code="200">Retorna uma lista dos produtos cadastrados</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.Produtos.Where(p => p.Delete == false).ToListAsync();
        }

        // GET: api/Produtos/1
        /// <summary>
        /// Retorna o produto cadastrado pelo id informado
        /// </summary>
        /// <returns>O produto cadastrado pelo id informado</returns>
        /// <response code="200">Retorna o produto pelo id informado</response>
        /// <response code="404">Se o produto não for encontrado pelo id informado</response>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _context.Produtos.Where(p => p.Delete == false).FirstOrDefaultAsync(p => p.Id == id);

            if (produto == null)
                return NotFound(new { message = "Produto não encontrado" } );

            return produto;
        }

        // PUT: api/Produtos/1
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
        ///        "delete": false
        ///     }
        ///
        /// </remarks>
        /// <returns>O produto cadastrado pelo id informado</returns>
        /// <response code="204">Retorna vazio indicando que o produto foi alterado com sucesso</response>
        /// <response code="400">Se o id da url, for diferente do id do produto no request body</response>
        /// <response code="403">Se o campo "nome", for uma string vazia; Se o campo "nome", for somente números</response>
        /// <response code="404">Se o produto não for encontrado pelo id informado</response>
        /// <response code="406">Se o campo "nome", passar de 50 caracteres; Se o campo "qtde", for menor que 1</response>
        /// <response code="422">Se o campo "nome", for inexistente no request body</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
		{
            produto.Nome = produto.Nome.Trim();

            if (_context.Produtos.Any(e => e.Id == id))
            {
                var produtoEncontrado = await _context.Produtos.FindAsync(id);
                if (produtoEncontrado.Delete)
                    return StatusCode(409, "Este produto foi deletado e não é possível altera-lo");
            }

            produto.DataAlteracao = horarioBrasilia;

            _context.Entry(produto).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!_context.Produtos.Any(e => e.Id == id))
                    return NotFound(new { message = "Produto não encontrado." });
                else
					throw;
			}

			return NoContent();
		}

        // POST: api/Produtos
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
        /// <param name="produto">objeto produto</param>
        /// <returns>Um novo produto criado</returns>
        /// <response code="200">Retorna ok indicando que o produto foi criado com sucesso</response>
        /// <response code="403">Se o campo "nome", for uma string vazia; Se o campo "nome", for somente números</response>
        /// <response code="403">Se o campo "nome", for uma string vazia; Se o campo "nome", for somente números</response>
        /// <response code="406">Se o campo "qtde", for menor que 1; Se o campo "nome", passar de 50 caracteres</response>
        /// <response code="422">Se o campo "nome", for inexistente no request body</response>
        [HttpPost]
        //[ProducesResponseType(typeof(ProdutoPostStatus200), StatusCodes.Status200OK)]
        //[SwaggerRequestExample]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            produto.Nome = produto.Nome.Trim();

            produto.DataInclusao = horarioBrasilia;
            produto.DataAlteracao = horarioBrasilia;

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return Ok(produto);
        }

        // DELETE: api/Produtos/1
        /// <summary>
        /// Deleta o produto filtrado pelo id informado(Este delete é somente virtual, garantido que o produto continue no banco caso precise dele para algum reprocesso. 
        /// Existe uma variável no banco de dados chamada "Delete" do tipo boolean, onde somente trocamos está variável para true e não mostramos mais em nenhum Get e 
        /// tambem não será possivel alterar em um Put)
        /// </summary>
        /// <returns>Não é retornado nenhuma informação, indicando que a exclusão foi feita com sucesso</returns>
        /// <response code="204">Não é retornado nenhuma informação, indicando que a exclusão foi feita com sucesso</response>
        /// <response code="404">Se o produto, não for encontrado pelo id informado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                return NotFound(new { message = "Produto não encontrado." });

            produto.DataAlteracao = DateTime.Now;
            produto.Delete = true;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
