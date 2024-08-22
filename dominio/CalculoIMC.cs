using FluentResults;

namespace dominio;
public class CalculoImc
{
    public double Peso { get; private set; }
    public double Altura { get; private set; }

    public CalculoImc(double peso, double altura)
    {
        this.Altura = altura;
        this.Peso = peso;
    }

    public Result<ClassificadorImc> Calcular()
    {
        var validador = new Validador();

        var result = validador.Validate(this);

        if (!result.IsValid)
        {
            return Result.Fail(result.Errors.ToList().Select(x => x.ErrorMessage));
        }

        var resultadoCalculo = CalcularIMC();

        return Result.Ok(ClassificarIMC(resultadoCalculo));
    }

    private double CalcularIMC()
    {
        return Math.Round(Peso / (Altura * Altura), 2);
    }

    private static ClassificadorImc ClassificarIMC(double result)
    {
        return new(result);
    }
}
