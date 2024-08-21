namespace dominio;
public class CalculoIMC
{
    private double Peso { get; set; }
    private double Altura { get; set; }

    private readonly string Normal = "Parabéns, você está no seu peso ideal, continue mantendo este estilo!";
    private readonly string Abaixo = "Atenção, você está abaixo do peso ideal!.";
    private readonly string Sobrepeso = "Estamos quase lá! Faça alguns ajustes para ficar no peso ideal!";
    private readonly string Obesidade = "Atenção, você está em um nível de obesidade.";

    public CalculoIMC(double peso, double altura)
    {
        this.Altura = altura;
        this.Peso = peso;
    }

    public ResultadoImc ProcessarResultado()
    {
        if (Peso <= 0 || Altura <= 0)
            throw new Exception("Informe o peso e a altura com valor maior que zero para efetuar o cálculo");

        var result = CalcularIMC();

        return ClassificarIMC(result);
    }

    private double CalcularIMC()
    {
        return Math.Round(Peso / (Altura * Altura), 2);
    }

    private ResultadoImc ClassificarIMC(double result)
    {
        var (mensagem, resultado) = result switch
        {
            < 18.5 => (Abaixo, "Abaixo do peso"),
            >= 18.5 and <= 24.99 => (Normal, "Peso ideal"),
            >= 25 and <= 29.99 => (Sobrepeso, "Sobrepeso"),
            _ => (Obesidade, "Obesidade")
        };

        return new ResultadoImc(result, resultado, mensagem);
    }
}
