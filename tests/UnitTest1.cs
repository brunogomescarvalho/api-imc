using dominio;
using FluentAssertions;

namespace tests;

public class Tests
{

    [Test]
    public void DeveCalcularCorretamentePesoNormal()
    {
        var imc = new CalculoImc(60, 1.70);

        var resultado = imc.Calcular();

        resultado.Value.Resultado.Should().Be(20.76);
        resultado.Value.Mensagem.Should().Be("Parabéns, você está no seu peso ideal, continue mantendo este estilo!");
        resultado.Value.Classificacao.Should().Be("Peso ideal");
        resultado.Value.Data.Should().Be(DateTime.Now.ToLongDateString());
    }

    [Test]
    public void DeveCalcularCorretamentePesoAbaixo()
    {
        var imc = new CalculoImc(50, 1.70);

        var resultado = imc.Calcular();

        resultado.Value.Resultado.Should().Be(17.3);
        resultado.Value.Mensagem.Should().Be("Atenção, você está abaixo do peso ideal!.");
        resultado.Value.Classificacao.Should().Be("Abaixo do peso");
        resultado.Value.Data.Should().Be(DateTime.Now.ToLongDateString());
    }

    [Test]
    public void DeveCalcularCorretamenteSobrePeso()
    {
        var imc = new CalculoImc(80, 1.70);

        var resultado = imc.Calcular();

        resultado.Value.Resultado.Should().Be(27.68);
        resultado.Value.Mensagem.Should().Be("Estamos quase lá! Faça alguns ajustes para ficar no peso ideal!");
        resultado.Value.Classificacao.Should().Be("Sobrepeso");
        resultado.Value.Data.Should().Be(DateTime.Now.ToLongDateString());
    }

    [Test]
    public void DeveCalcularCorretamenteObesidade()
    {
        var imc = new CalculoImc(100, 1.70);

        var resultado = imc.Calcular();

        resultado.Value.Resultado.Should().Be(34.6);
        resultado.Value.Mensagem.Should().Be("Atenção, você está em um nível de obesidade.");
        resultado.Value.Classificacao.Should().Be("Obesidade");
        resultado.Value.Data.Should().Be(DateTime.Now.ToLongDateString());
    }

    [Test]
    public void DeveRetornarErro_AoInformarValores_MenoresqueZero()
    {
        var imc = new CalculoImc(0, -1);

        var resultado = imc.Calcular();

        resultado.IsFailed.Should().BeTrue();
    }
}