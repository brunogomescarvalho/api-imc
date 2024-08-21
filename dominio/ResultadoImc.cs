using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominio
{
    public class ResultadoImc
    {

        public double Calculo { get; set; }
        public string Mensagem { get; set; }
        public string Resultado { get; set; }
        public string Data { get; set; }

        public ResultadoImc(double calculo, string resultado, string mensagem)
        {
            Calculo = calculo;
            Mensagem = mensagem;
            Resultado = resultado;
            Data = DateTime.Now.ToLongDateString();
        }

    }
}