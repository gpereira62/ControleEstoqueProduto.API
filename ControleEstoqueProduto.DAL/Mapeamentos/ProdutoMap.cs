using ControleEstoqueProduto.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoqueProduto.DAL.Mapeamento
{
	public class ProdutoMap : IEntityTypeConfiguration<Produto>
	{
		public void Configure(EntityTypeBuilder<Produto> builder)
		{
			builder.HasKey(p => p.Id);

			builder.Property(p => p.Nome).IsRequired().HasMaxLength(50);
			builder.HasIndex(p => p.Nome).IsUnique();
				
			builder.Property(p => p.Qtde).IsRequired();

			builder.Property(p => p.Ativo).IsRequired();

			builder.Property(p => p.Delete).IsRequired().HasDefaultValue(false);

			builder.Property(p => p.DataInclusao);
			builder.Property(p => p.DataAlteracao);

			builder.ToTable("Produtos");
		}
	}
}
