using ControleEstoqueProduto.BLL.Models;
using ControleEstoqueProduto.DAL.Mapeamento;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoqueProduto.DAL
{
	public class Contexto : IdentityDbContext
	{
		public DbSet<Produto> Produtos { get; set; }

		public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new ProdutoMap());
		}
	}
}
