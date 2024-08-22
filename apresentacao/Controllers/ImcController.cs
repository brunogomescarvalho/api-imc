using dominio;
using Microsoft.AspNetCore.Mvc;

namespace apresentacao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImcController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetImc(double peso, double altura)
        {

            var imc = new CalculoImc(peso, altura);

            var resultado = imc.Calcular();

            if (resultado.IsFailed)
            {
                return BadRequest(new
                {
                    sucesso = false,
                    erros = resultado.Reasons.Select(x => x.Message)
                });
            }

            return Ok(new
            {
                sucesso = true,
                dados = resultado.Value
            });
        }
    }
}