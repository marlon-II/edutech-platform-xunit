namespace MatriculaFinanceiraService;
using Xunit;

public class MatriculaFinanceiraService
{
    [Theory]

    [InlineData(1000.00, 10, true, 500.00)] // (Bolsista -> 50% off)
    [InlineData(1000.00, 4, false, 900.00)] // (Não bolsista, paga dia 4 -> 10% off)
    [InlineData(1000.00, 10, false, 1000.00)] // (Não bolsista, paga dia 10 -> sem desconto)

    public void CalcularValorMensalidade(decimal valorBase, int diaPagamento, bool eBolsista, decimal descontoEsperado)
    {
        var service = new CalculoMensalidade();
        var descontoObtido = service.CalcularValorMensalidade(valorBase, diaPagamento, eBolsista);
    
        Assert.Equal(descontoEsperado, descontoObtido);
    }

    [Theory]

    [InlineData(false, "APROVADO", true)] // (Sem pendência + Aprovado - > Permite)
    [InlineData(true, "APROVADO", false)] // (Com pendência + Aprovado -> Bloqueia)
    [InlineData(false, "REPROVADO", false)] // (Sem pendência + Reprovado -> Bloqueia)

    public void PodeRealizarRematricula(bool possuiPendenciaFinanceira, string situacaoAcademica, bool permissaoMatriculaEsperado)
    {
        var service = new CalculoMensalidade();
        var permissaoMatriculaObtido = service.PodeRealizarRematricula(possuiPendenciaFinanceira, situacaoAcademica);

        Assert.Equal(permissaoMatriculaEsperado, permissaoMatriculaObtido);
    }
}