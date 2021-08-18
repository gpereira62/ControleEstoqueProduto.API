using ControleEstoqueProduto.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoqueProduto.API
{
	public class Util
	{
        public static bool ProdutoExists(Contexto context, int id)
        {
            return context.Produtos.Any(e => e.Id == id);
        }

        public static bool contemNumeros(string texto)
        {
            if (texto.Where(c => char.IsNumber(c)).Count() > 0)
                return true;
            else
                return false;
        }

        public static bool contemLetras(string texto)
        {
            if (texto.Where(c => char.IsLetter(c)).Count() > 0)
                return true;
            else
                return false;
        }
    }
}
