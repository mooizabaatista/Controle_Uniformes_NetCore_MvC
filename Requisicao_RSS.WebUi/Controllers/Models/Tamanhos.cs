using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requisicao_RSS.WebUi.Models
{
    public class Tamanhos
    {
        public string Valor { get; set; }
        public string Texto { get; set; }


        public List<Tamanhos> GetTamanhos()
        {
            List<Tamanhos> lista = new List<Tamanhos>();
            lista.Add(new Tamanhos { Texto = "P", Valor = "P" });
            lista.Add(new Tamanhos { Texto = "M", Valor = "M" });
            lista.Add(new Tamanhos { Texto = "G", Valor = "G" });
            lista.Add(new Tamanhos { Texto = "GG", Valor = "GG" });
            lista.Add(new Tamanhos { Texto = "XG", Valor = "XG" });

            return lista;
        }
    }
}
