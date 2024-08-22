using dominio;
using FluentAssertions;

namespace tests;

public class Tests
{

    [Test]
    public void DeveCalcularCorretamentePesoNormal()
    {
        var imc = new CalculoIMC(60, 1.70);

        var resultado = imc.Calcular();

        resultado.Resultado.Should().Be(20.76);
        resultado.Mensagem.Should().Be("Parabéns, você está no seu peso ideal, continue mantendo este estilo!");
        resultado.Classificacao.Should().Be("Peso ideal");
        resultado.Data.Should().Be(DateTime.Now.ToLongDateString());
    }

    [Test]
    public void DeveCalcularCorretamentePesoAbaixo()
    {
        var imc = new CalculoIMC(50, 1.70);

        var resultado = imc.Calcular();

        resultado.Resultado.Should().Be(17.3);
        resultado.Mensagem.Should().Be("Atenção, você está abaixo do peso ideal!.");
        resultado.Classificacao.Should().Be("Abaixo do peso");
        resultado.Data.Should().Be(DateTime.Now.ToLongDateString());
    }

    [Test]
    public void DeveCalcularCorretamenteSobrePeso()
    {
        var imc = new CalculoIMC(80, 1.70);

        var resultado = imc.Calcular();

        resultado.Resultado.Should().Be(27.68);
        resultado.Mensagem.Should().Be("Estamos quase lá! Faça alguns ajustes para ficar no peso ideal!");
        resultado.Classificacao.Should().Be("Sobrepeso");
        resultado.Data.Should().Be(DateTime.Now.ToLongDateString());
    }

    [Test]
    public void DeveCalcularCorretamenteObesidade()
    {
        var imc = new CalculoIMC(100, 1.70);

        var resultado = imc.Calcular();

        resultado.Resultado.Should().Be(34.6);
        resultado.Mensagem.Should().Be("Atenção, você está em um nível de obesidade.");
        resultado.Classificacao.Should().Be("Obesidade");
        resultado.Data.Should().Be(DateTime.Now.ToLongDateString());
    }

    [Test]
    public void DeveGerarExcessao_AoNaoInformarValores_MaioresQueZero()
    {
        var imc = new CalculoIMC(0, -1);

        Action act = () => imc.Calcular();

        act.Should().Throw<Exception>().WithMessage("Informe o peso e a altura com valor maior que zero para efetuar o cálculo");
    }
}