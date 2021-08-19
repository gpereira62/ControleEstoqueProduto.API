using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControleEstoqueProduto.BLL.Models
{
	public class Produto
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "O nome do produto é obrigatório")]
		[MaxLength(50, ErrorMessage = "Nome do produto muito grande, máximo 50 caracteres!")]
		public string Nome { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Campo qtde tem que ser maior que zero!")]
		public int Qtde { get; set; }

		public bool Ativo { get; set; }

		[JsonIgnore]
		public bool Delete { get; set; }

		[JsonIgnore]
		public DateTime DataInclusao { get; set; }

		[JsonIgnore]
		public DateTime DataAlteracao { get; set; }
	}
}
