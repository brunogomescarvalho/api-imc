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
            try
            {
                var imc = new CalculoIMC(peso, altura);

                var resultado = imc.Calcular();

                return Ok(new
                {
                    sucesso = true,
                    dados = resultado
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    sucesso = false,
                    erro = ex.Message
                });
            }
        }
    }
}