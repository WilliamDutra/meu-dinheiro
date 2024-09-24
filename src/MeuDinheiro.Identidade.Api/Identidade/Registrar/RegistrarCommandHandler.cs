using MeuDinheiro.Shared;
using Microsoft.AspNetCore.Identity;

namespace MeuDinheiro.Identidade.Api.Identidade.Registrar
{
    public class RegistrarCommandHandler : ICommandHandler<RegistrarCommand, CommandResult>
    {
        private UserManager<ApplicationUser> _userManager;

        public RegistrarCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public CommandResult Handle(RegistrarCommand command)
        {
            command.Validate();

            if (!command.IsValid)
                return new CommandResult(false, string.Join(",", command.Errors));

            var currenUser = new ApplicationUser();
            currenUser.Email = command.Email;
            currenUser.UserName = command.Nome;
            
            var userCreated = _userManager.CreateAsync(currenUser, command.Senha);
            userCreated.Wait();

            if (!userCreated.Result.Succeeded)
                return new CommandResult(false, string.Join(",", userCreated.Result.Errors.Select(x => x.Description)));

            return new CommandResult(true, "usuário cadastrado com sucesso!");
        }
    }
}
