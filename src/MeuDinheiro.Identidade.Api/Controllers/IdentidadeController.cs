using Microsoft.AspNetCore.Mvc;
using MeuDinheiro.Identidade.Api.Identidade.Registrar;
using MeuDinheiro.Identidade.Api.Identidade.Login;

namespace MeuDinheiro.Identidade.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentidadeController : ControllerBase
    {
     
        private readonly ILogger<IdentidadeController> _logger;

        private RegistrarCommandHandler _registrarHandler;

        private LoginCommandHandler _loginHandler;
        
        public IdentidadeController(ILogger<IdentidadeController> logger, RegistrarCommandHandler registrarHandler, LoginCommandHandler loginHandler)
        {
            _logger = logger;
            _registrarHandler = registrarHandler;
            _loginHandler = loginHandler;
        }

        [HttpPost]
        [Route("registrar")]
        public IActionResult Cadastrar(RegistrarCommand command)
        {
            var resultado = _registrarHandler.Handle(command);
            if (!resultado.IsSuccess)
                return BadRequest(resultado.Message);
            return Ok(resultado.Message);
        }

        [HttpPost]
        [Route("entrar")]
        public IActionResult Cadastrar(LoginCommand command)
        {
            var resultado = _loginHandler.Handle(command);
            if (!resultado.IsSuccess)
                return BadRequest(resultado.Message);
            return Ok(resultado.Message);
        }
    }

    
}