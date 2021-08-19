using ControleEstoqueProduto.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoqueProduto.DAL.Repository
{
	public class ProdutoRepository : IProdutoRepository
	{
		private readonly Contexto _context;

		public ProdutoRepository(Contexto context)
		{
			_context = context;
		}

		public async Task<ActionResult<IEnumerable<Produto>>> GetAll()
		{
			return await _context.Produtos.Where(p => p.Delete == false).ToListAsync();
		}

		public async Task<Produto> Get(int id)
		{
			return await _context.Produtos.Where(p => p.Delete == false).FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task Update(Produto produto)
		{
			_context.Entry(produto).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task Add(Produto produto)
		{
			_context.Produtos.Add(produto);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Produto produto)
		{
			produto.Delete = true;
			await _context.SaveChangesAsync();
		}

		public bool ProdutoExists(int id)
		{
			return _context.Produtos.Any(e => e.Id == id);
		}

		public bool ProdutoDeleteExists(int id)
		{
			return _context.Produtos.Where(p => p.Delete == true).Any(e => e.Id == id);
		}
	}
}
