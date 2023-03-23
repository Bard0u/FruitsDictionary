using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frutas.Models
{
    public class Fruta
    {
        public int Numero { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<string> Tipo { get; set; }
        public string Imagem { get; set; }

        public Fruta()
        {
            Tipo = new List<string>();
        }
    }
}