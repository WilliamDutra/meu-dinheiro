using System;
using MeuDinheiro.Shared;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using MeuDinheiro.Identidade.Identity;

namespace MeuDinheiro.Identidade.Login
{
    public class LoginCommandHandler : ILoginHandler
    {
        private UserManager<ApplicationUser> _userManager;

        private IIdentidadeTokenService _tokenService;

        public LoginCommandHandler(UserManager<ApplicationUser> userManager, IIdentidadeTokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
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

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var descriptor = new SecurityTokenDescriptor();
            //descriptor.Subject = new ClaimsIdentity(new[]
            //{
            //    new Claim(ClaimTypes.Email, usuarioEncontrado.Result.Email),
            //});

            //var securityToken = tokenHandler.CreateToken(descriptor);
            //var token = tokenHandler.WriteToken(securityToken);

            var tokenCriado =_tokenService.CriarToken(usuarioEncontrado.Result.Email, usuarioEncontrado.Result.Nome);
            var token = _tokenService.GerarToken(tokenCriado);

            return new CommandResult(true, "usuário autenticado com sucesso!", token);
        }
    }
}
