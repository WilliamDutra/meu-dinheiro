using MeuDinheiro.Identidade.Api.Identidade;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MeuDinheiro.Identidade.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentidadeController : ControllerBase
    {
     
        private readonly ILogger<IdentidadeController> _logger;

        private UserManager<ApplicationUser> _userManager;

        public IdentidadeController(ILogger<IdentidadeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(RegisterCommand command)
        {
            var user = await _userManager.CreateAsync(new ApplicationUser { UserName =command.Email,  Email = command.Email, PasswordHash = command.Password });
            if (!user.Succeeded)
                return BadRequest(user.Errors);
            return Ok(user);
        }
    }

    public class RegisterCommand
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}