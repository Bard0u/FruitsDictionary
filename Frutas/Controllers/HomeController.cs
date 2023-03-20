using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Frutas.Models;
using Frutas.Services;

namespace Frutas.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFruitServices _fruitService;

    public HomeController(ILogger<HomeController> logger, IFruitServices fruitService)
    {
        _logger = logger;
        _fruitService = fruitService;
    }

    public IActionResult Index(string tipo)
    {
        var anm = _fruitService.GetDicionarioDto();
        ViewData["filter"] = string.IsNullOrEmpty(tipo) ? "all" : tipo;
        return View(anm);
    }

        public IActionResult Details(int Numero)
    {
        var frutas = _fruitService.GetDetailedFruits(Numero);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
