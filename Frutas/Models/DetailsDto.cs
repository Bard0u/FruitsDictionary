using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frutas.Models
{
    public class DetailsDto
    {
        public Fruta Prior { get; set; }
        public Fruta Current { get; set; }
        public Fruta Next { get; set; }
    }
}