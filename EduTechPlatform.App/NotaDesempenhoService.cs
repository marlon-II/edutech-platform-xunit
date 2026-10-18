namespace NotaDesempenhoService;

public class CalculoNota
{
    public decimal CalcularMediaPonderada(decimal nota1, decimal nota2, decimal notaProjeto)
    {
        return ((nota1 * 3) + (nota2 * 3) + (notaProjeto * 4)) / 10;
    }

    public string ObterSituacaoAcademica(decimal mediaFinal)
    {
        if (mediaFinal >= 7.0m)
        {
            return "APROVADO";
        }
        else if (mediaFinal >= 5.0m) // Cobre automaticamente a faixa de 5.0m até 6.99m
        {
            return "RECUPERACAO";
        }
        else // Cobre qualquer nota abaixo de 5.0m
        {
            return "REPROVADO";
        }
    }
}