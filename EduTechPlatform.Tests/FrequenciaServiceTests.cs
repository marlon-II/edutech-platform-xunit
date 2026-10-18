namespace FrequenciaServiceTests;
using Xunit;
using FrequenciaService;

public class FrequenciaServiceTests
{
    [Theory]

    [InlineData(80, 20, 75.0)] // (60 presenças em 80 aulas = 75%)
    [InlineData(100, 10, 90.0)] // (90 presenças em 100 aulas = 90%)

    public void CalcularPorcentagemPresenca(int aulasTotais, int faltas, int presencaEsperada)
    {
        var service = new FrequenciaService();
        var presencaObtida = service.CalcularPorcentagemPresenca(aulasTotais, faltas);

        Assert.Equal(presencaEsperada, presencaObtida);
    }

    [Theory]

    [InlineData(80, 20, true)] // (75% de presença -> Aprovado)
    [InlineData(80, 21, false)] // (Abaixo de 75% -> Reprovado por falta)

    public void AprovadoPorFrequencia(int aulasTotais, int faltas, bool aprovacaoEsperada)
    {
        var service = new FrequenciaService();
        var aprovacaoObtida = service.AprovadoPorFrequencia(aulasTotais, faltas);

        Assert.Equal(aprovacaoEsperada, aprovacaoObtida);
    }
}