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
        List<Personagem> Personagens = GetPersonagens();
        List<Categoria> categorias = GetCategorias();
        ViewData["Categorias"] = categorias;        
        return View(Personagens);
    }

    public IActionResult Details(int id)
    {
        List<Personagem> Personagens = GetPersonagens();
        List<Categoria> categorias = GetCategorias();
        DetailsVM details = new(){
            Categorias = categorias,
            Atual = Personagens.FirstOrDefault(p => p.Id == id),
            Anterior = Personagens.OrderByDescending(p => p.Id == id).FirstOrDefault(p => p.Id < id),
            Proximo = Personagens.OrderBy(p => p.Id == id).FirstOrDefault(p => p.Id > id),
        };
        return View(details);
    }

    private List<Personagem> GetPersonagens()
    {
        using (StreamReader leitor = new("Data\\Personagens.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Personagem>>(dados);
        }
    }

    private List<Categoria> GetCategorias()
    {
        using (StreamReader leitor = new("Data\\Categorias.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Categoria>>(dados);
        }
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
