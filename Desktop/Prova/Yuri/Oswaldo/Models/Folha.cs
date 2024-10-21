namespace API.Models;
using API.Models;

public class Folha{

    public int folhaId { get; set; }
    public double valor { get; set; }
    public int quantidade { get; set; }
    public int mes { get; set; }
    public int ano { get; set; }
    public double salarioBruto { get; set; }
    public double salarioLiquido { get; set; }
    public double impostoIrrf { get; set; }
    public double impostoInss { get; set; }
    public double impossoFgts { get; set; }
    public int funcionarioId { get; set; }

    public Funcionario funcionario { get; set; }

    public void CalcularImpostos(){
        salarioBruto = valor * quantidade;

        if (salarioBruto < 1903.98){
            impostoIrrf = 0;
        }else if (salarioBruto < 2826.65){
            impostoIrrf = (salarioBruto * 0.075) - 142.80;
        }else if (salarioBruto < 3751.05){
            impostoIrrf = (salarioBruto * 0.15) - 354.80;
        }else if (salarioBruto < 4664.68){
            impostoIrrf = (salarioBruto * 0.225) - 636.13;
        }else{
            impostoIrrf = (salarioBruto * 0.275) - 869.36;
        }

        if(salarioBruto < 1693.72){
            impostoInss = salarioBruto * 0.08;
        }else if (salarioBruto < 2822.90){
            impostoInss = salarioBruto * 0.09;
        }else if (salarioBruto < 5645.80){
            impostoInss = salarioBruto * 0.11;
        }else{
            impostoInss = 621.03;
        }

        impossoFgts = salarioBruto * 0.08;

        salarioLiquido = salarioBruto - (impostoIrrf + impostoInss);

    }
}

