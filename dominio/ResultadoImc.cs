using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dominio
{
    public class ResultadoImc
    {
         
        public string Mensagem { get; set; }
        public string Resultado { get; set; }
        public string Data { get; set; }
        public CalculoIMC Calculo { get; set; }

        public ResultadoImc(CalculoIMC calculo, string resultado, string mensagem)
        {
            Mensagem = mensagem;
            Resultado = resultado;
            Data = DateTime.Now.ToLongDateString();
            Calculo = calculo;
        }

    }
}