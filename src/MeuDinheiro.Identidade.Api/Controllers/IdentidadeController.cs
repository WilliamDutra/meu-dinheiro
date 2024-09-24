using Microsoft.AspNetCore.Mvc;
using MeuDinheiro.Identidade.Login;
using MeuDinheiro.Identidade.Registrar;

namespace MeuDinheiro.Identidade.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentidadeController : ControllerBase
    {
     
        private readonly ILogger<IdentidadeController> _logger;

        private IRegistrarHandler _registrarHandler;

        private ILoginHandler _loginHandler;
        
        public IdentidadeController(ILogger<IdentidadeController> logger, IRegistrarHandler registrarHandler, ILoginHandler loginHandler)
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
            return Ok(resultado);
        }
    }

    
}