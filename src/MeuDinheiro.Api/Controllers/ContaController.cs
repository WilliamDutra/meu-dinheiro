using MeuDinheiro.Aplicacao.Conta.Cadastar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeuDinheiro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private CadastrarContaCommandHandler _cadastrarContaHandler;

        public ContaController(CadastrarContaCommandHandler cadastrarContaHandler)
        {
            _cadastrarContaHandler = cadastrarContaHandler;
        }

        [HttpPost]
        public IActionResult Salvar(CadastrarContaCommand command)
        {
            var handler = _cadastrarContaHandler.Handle(command);
            if(!handler.IsSuccess)
                return BadRequest(handler.Message);
            return Ok(handler.Message);
        }

    }
}
