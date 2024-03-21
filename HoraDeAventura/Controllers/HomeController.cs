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
        List<Categoria> Categorias = [];
        using (StreamReader leitor = new("Data\\Categorias.json"))
        {
            string dados = leitor.ReadToEnd();
            Categorias = JsonSerializer.Deserialize<List<Categoria>>(dados);
        }
        ViewData["Categorias"] = Categorias;
        return View(Personagens);
    }

    public IActionResult Details(int id)
    {
        List<Personagem> Personagens = [];
        using (StreamReader leitor = new("Data\\Personagens.json"))
        {
            string dados = leitor.ReadToEnd();
            Personagens = JsonSerializer.Deserialize<List<Personagem>>(dados);
        }
        List<Categoria> Categorias = [];
        using (StreamReader leitor = new("Data\\Categorias.json"))
        {
            string dados = leitor.ReadToEnd();
            Categorias = JsonSerializer.Deserialize<List<Categoria>>(dados);
        }
        ViewData["Categorias"] = Categorias;
        var Personagem = Personagens
            .where(p => p.Numero == id)
            .FirstOrDefault();
        return View(Personagem);
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
