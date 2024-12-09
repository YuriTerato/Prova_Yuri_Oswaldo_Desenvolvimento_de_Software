using System;

namespace API.Models;

public class Imc
{
    public int ImcId { get; set; }
    public float NumeroImc { get; set; }
    public string Classificacao { get; set; }
    public int GrauObesidade { get; set; }
}
