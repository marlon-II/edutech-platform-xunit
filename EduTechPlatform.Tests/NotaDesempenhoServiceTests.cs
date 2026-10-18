namespace NotaDesempenhoServiceTests;
using NotaDesempenhoService;
using Xunit;

public class NotaDesempenhoServiceTests
{
    [Theory]

    [InlineData(7.0, 7.0, 7.0, 7.0)]
    [InlineData(10.0, 10.0, 5.0, 8.0)] // ( (30 + 30 + 20) / 10 = 8.0 )
    public void CalcularMediaPonderada(decimal nota1, decimal nota2, decimal nota3, decimal notaProjetoEsperado)
    {
        var service = new CalculoNota();
        var notaProjetoObtida = service.CalcularMediaPonderada(nota1, nota2, nota3);

        Assert.Equal(notaProjetoEsperado, notaProjetoObtida);
    }

    [Theory]

    [InlineData(8.5, "APROVADO")]
    [InlineData(6.0, "RECUPERACAO")]
    [InlineData(4.2, "REPROVADO")]
    public void ObterSituacaoAcademica(decimal mediaFinal, string situacaoAprovacao)
    {
        var service = new CalculoNota();
        var situacaoObtida = service.ObterSituacaoAcademica(mediaFinal);
    
        Assert.Equal(situacaoAprovacao, situacaoObtida);
    }
}
