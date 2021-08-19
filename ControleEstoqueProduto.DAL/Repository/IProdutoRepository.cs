using ControleEstoqueProduto.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoqueProduto.DAL.Repository
{
	public interface IProdutoRepository
	{
		Task<ActionResult<IEnumerable<Produto>>> GetAll();
		Task<Produto> Get(int id);
		Task Update(Produto produto);
		Task Add(Produto produto);
		Task Delete(Produto produto);
		bool ProdutoExists(int id);
		bool ProdutoDeleteExists(int id);
	}
}
