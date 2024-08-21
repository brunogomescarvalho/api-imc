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

                var resultado = imc.ProcessarResultado();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}