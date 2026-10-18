namespace FrequenciaService;

public class FrequenciaService
{
    public double CalcularPorcentagemPresenca(int aulasTotais, int faltas)
    {
        // O (double) garante que a divisão seja tratada com casas decimais antes de multiplicar por 100
        return ((aulasTotais - faltas) / (double)aulasTotais) * 100;
    }

    public bool AprovadoPorFrequencia(int aulasTotais, int faltas)
    {
        // reutilizando método acima para obter o percentual e validamos se é maior ou igual a 75
        double porcentagem = CalcularPorcentagemPresenca(aulasTotais, faltas);
        
        return porcentagem >= 75.0;
    }
}