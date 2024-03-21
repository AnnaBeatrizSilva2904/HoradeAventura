namespace HoraDeAventura.Models;

public class Personagem
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public List<string> Categoria { get; set; } = [];
    public string Imagem { get; set; }
}
