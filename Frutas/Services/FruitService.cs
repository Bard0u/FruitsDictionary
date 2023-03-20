using System.Text.Json;
using Frutas.Models;

namespace Frutas.Services
{
    public class FruitService: IFruitServices
    {
        private readonly IHttpContextAccessor _session;
        private readonly string frutasFile = @"Data\Frutas.json";
        private readonly string tiposFile = @"Data\tipos.json";
        public FruitService(IHttpContextAccessor session)
        {
            _session = session;
            PopularSessao();
        }
        public List<Fruta> GetFrutas()
        {
            PopularSessao();
            var fruta = JsonSerializer.Deserialize<List<Fruta>>
            (_session.HttpContext.Session.GetString("Frutas"));
            return fruta;
        }
        public List<Tipo> GetTipos()
        {
            PopularSessao();
            var tipos = JsonSerializer.Deserialize<List<Tipo>>
            (_session.HttpContext.Session.GetString("Tipos"));
            return tipos;
        }
        public Fruta GetAkuma(int Numero)
        {
            var frutas = GetFrutas();
            return frutas.Where(p => p.Numero == Numero).FirstOrDefault();
        }
        public DicionarioDto GetDicionarioDto()
        {
            var anm = new DicionarioDto()
            {
                Frutas = GetFrutas(),
                Tipos = GetTipos()
            };
            return anm;
        }
        public DetailsDto GetDetailedFruits(int Numero)
        {
            var frutas = GetFrutas();
            var anm = new DetailsDto()
            {
                Current = frutas.Where(p => p.Numero == Numero)
            .FirstOrDefault(),
                Prior = frutas.OrderByDescending(p => p.Numero)
            .FirstOrDefault(p => p.Numero < Numero),
                Next = frutas.OrderBy(p => p.Numero)
            .FirstOrDefault(p => p.Numero > Numero),
            };
            return anm;
        }
        public Tipo GetTipo(string Nome)
        {
            var tipos = GetTipos();
            return tipos.Where(t => t.Nome == Nome).FirstOrDefault();
        }
        private void PopularSessao()
        {
            if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Tipos")))
            {
                _session.HttpContext.Session
                .SetString("Frutas", LerArquivo(frutasFile));
                _session.HttpContext.Session
                .SetString("Tipos", LerArquivo(tiposFile));
            }
        }
        private string LerArquivo(string fileName)
        {
            using (StreamReader leitor = new StreamReader(fileName))
            {
                string dados = leitor.ReadToEnd();
                return dados;
            }
        }
    }
}