using MeuDinheiro.Shared;
using Microsoft.AspNetCore.Identity;

namespace MeuDinheiro.Identidade.Api.Identidade.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, CommandResult>
    {
        private UserManager<ApplicationUser> _userManager;

        public LoginCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public CommandResult Handle(LoginCommand command)
        {

            command.Validate();

            if(!command.IsValid)
                return new CommandResult(false, string.Join(", ", command.Errors));

            var usuarioEncontrado = _userManager.FindByEmailAsync(command.Email);
            usuarioEncontrado.Wait();

            if (usuarioEncontrado.Result == null)
                return new CommandResult(false, "usuário/e ou senha inválidos!");

            var senhaValida = _userManager.CheckPasswordAsync(usuarioEncontrado.Result, command.Senha);
            senhaValida.Wait();

            if(!senhaValida.Result)
                return new CommandResult(false, "usuário/e ou senha inválidos!");

            return new CommandResult(true, "usuário autenticado com sucesso!");
        }
    }
}
