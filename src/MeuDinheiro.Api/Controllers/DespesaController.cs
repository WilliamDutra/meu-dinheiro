using Microsoft.AspNetCore.Mvc;
using MeuDinheiro.Aplicacao.Despesa.LancarDespesa;

namespace MeuDinheiro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        private LancarDespesaCommandHandler _lancarDespesaHandler;

        public DespesaController(LancarDespesaCommandHandler lancarDespesaHandler)
        {
            _lancarDespesaHandler = lancarDespesaHandler;
        }

        [HttpPost]
        public IActionResult IncluirLancamento(LancarDespesaCommand command)
        {
            var handler = _lancarDespesaHandler.Handle(command);
            if (!handler.IsSuccess)
                return BadRequest(handler.Message);
            return Ok(handler.Message);
        }
    }
}
