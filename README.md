# EduTechPlatform

Solução em **C# / .NET 10** com regras de negócio acadêmicas e financeiras de uma plataforma educacional, validadas por testes unitários parametrizados com **xUnit**.

Projeto da disciplina de **Garantia da Qualidade de Software**.

## Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

```bash
dotnet --version
```

## Serviços

### NotaDesempenhoService

- `CalcularMediaPonderada(nota1, nota2, notaProjeto)`: média com pesos 3, 3 e 4 (`((nota1 * 3) + (nota2 * 3) + (notaProjeto * 4)) / 10`).
- `ObterSituacaoAcademica(mediaFinal)`: retorna `APROVADO` (>= 7.0), `RECUPERACAO` (de 5.0 a 6.99) ou `REPROVADO` (< 5.0).

### FrequenciaService

- `CalcularPorcentagemPresenca(aulasTotais, faltas)`: retorna o percentual de presença.
- `AprovadoPorFrequencia(aulasTotais, faltas)`: retorna `true` se a presença for de pelo menos 75%.

### MatriculaFinanceiraService

- `CalcularValorMensalidade(valorBase, diaPagamento, eBolsista)`: bolsista paga 50%; não bolsista paga 90% até o dia 5 e o valor integral depois disso.
- `PodeRealizarRematricula(possuiPendenciaFinanceira, situacaoAcademica)`: retorna `true` apenas sem pendência financeira e com situação diferente de `REPROVADO`.

## Como executar

```bash
git clone https://github.com/<seu-usuario>/edutech-platform-xunit.git
cd edutech-platform-xunit

dotnet restore
dotnet build
dotnet test
```

## Testes

Os testes usam `[Theory]` com `[InlineData]`, executando o mesmo método com vários conjuntos de entrada e resultado esperado. Cada serviço tem sua própria suíte:

- **NotaDesempenhoServiceTests**: médias (7.0 e 8.0) e as três situações acadêmicas.
- **FrequenciaServiceTests**: percentuais (75% e 90%) e o limite de aprovação (20 faltas aprova, 21 reprova em 80 aulas).
- **MatriculaFinanceiraServiceTests**: mensalidade de bolsista, pagamento pontual e pagamento após o dia 5, além dos cenários de rematrícula.

## Licença

Distribuído sob a licença MIT.

## Alunos

Caio Cesar
Caio Menezes
Marlon Bartoli
