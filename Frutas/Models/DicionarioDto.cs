using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frutas.Models
{
    public class DicionarioDto
    {

        public List<Tipo> Tipos { get; set; }
        public List<Fruta> Frutas { get; set; }
    }
}