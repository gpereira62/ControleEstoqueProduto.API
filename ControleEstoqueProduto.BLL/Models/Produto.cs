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

		[Required(AllowEmptyStrings = false)]
		[MaxLength(50)]
		public string Nome { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Qtde { get; set; }

		[Required]
		public bool Ativo { get; set; }

		[Required]
		[DefaultValue(false)]
		[JsonIgnore]
		public bool Delete { get; set; }

		[JsonIgnore]
		public DateTime DataInclusao { get; set; }

		[JsonIgnore]
		public DateTime DataAlteracao { get; set; }
	}
}
