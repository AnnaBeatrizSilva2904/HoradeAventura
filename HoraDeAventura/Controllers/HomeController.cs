using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using HoraDeAventura.Models;

namespace HoraDeAventura.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Personagem> Personagens = [];
        using (StreamReader leitor = new("Data\\Personagens.json"))
        {
            string dados = leitor.ReadToEnd();
            Personagens = JsonSerializer.Deserialize<List<Personagem>>(dados);
        }
        return View(Personagens);
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
