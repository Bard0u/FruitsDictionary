using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frutas.Models;

namespace Frutas.Services
{
    public interface IFruitServices
    {
        List<Fruta> GetFrutas();
        List<Tipo> GetTipos();
        Fruta GetAkuma(int Numero);
        DicionarioDto GetDicionarioDto();
        DetailsDto GetDetailedFruits(int Numero);
        Tipo GetTipo(string Nome);
    }
}