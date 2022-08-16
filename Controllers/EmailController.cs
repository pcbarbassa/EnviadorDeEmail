using Microsoft.AspNetCore.Mvc;
using PCB.EnviadorDeEmail.Domain.Commands;
using PCB.EnviadorDeEmail.Domain.Handlers;

namespace PCB.EnviadorDeEmail.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<RespostaGenericaCommandResult>> Post(
            [FromBody] EnviarEmailCommand command,
            [FromServices] ManipuladorDeEmail handler)
        {
            var resultado = (RespostaGenericaCommandResult)handler.Manipular(command);            

            return resultado.Sucesso ? Ok(resultado) : BadRequest(resultado);
        }
    }
}
