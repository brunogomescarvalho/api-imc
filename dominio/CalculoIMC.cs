namespace dominio;
public class CalculoIMC
{
    private double Peso { get; set; }
    private double Altura { get; set; }

    public CalculoIMC(double peso, double altura)
    {
        this.Altura = altura;
        this.Peso = peso;
    }

    public ClassificadorImc Calcular()
    {
        if (Peso <= 0 || Altura <= 0)
        {
            throw new Exception("Informe o peso e a altura com valor maior que zero para efetuar o cálculo");
        }

        var result = CalcularIMC();

        return ClassificarIMC(result);
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
