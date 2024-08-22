namespace dominio
{
    public class ClassificadorImc
    {
        public double Resultado { get; set; }
        public string? Classificacao { get; set; }
        public string? Mensagem { get; set; }
        public string? Data { get; set; }

        public ClassificadorImc(double resultado)
        {
            Resultado = resultado;

            ClassificarImc();
        }


        private void ClassificarImc()
        {
            var resultado = Resultado switch
            {
                < 18.5 => Abaixo,
                >= 18.5 and <= 24.99 => Normal,
                >= 25 and <= 29.99 => Sobrepeso,
                _ => Obesidade
            };

            Classificacao = resultado[0];
            Mensagem = resultado[1];
            Data = DateTime.Now.ToLongDateString();

        }

        private readonly string[] Normal = new[]
        {
            "Peso ideal",
            "Parabéns, você está no seu peso ideal, continue mantendo este estilo!"
        };

        private readonly string[] Abaixo = new[]
        {
            "Abaixo do peso",
            "Atenção, você está abaixo do peso ideal!."
        };

        private readonly string[] Sobrepeso = new[]
        {
            "Sobrepeso",
            "Estamos quase lá! Faça alguns ajustes para ficar no peso ideal!"
        };

        private readonly string[] Obesidade = new[]
        {
            "Obesidade",
            "Atenção, você está em um nível de obesidade."
        };

    }
}