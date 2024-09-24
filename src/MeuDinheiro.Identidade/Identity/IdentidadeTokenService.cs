using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;


namespace MeuDinheiro.Identidade.Identity
{
    public class IdentidadeTokenService : IIdentidadeTokenService
    {
        public JwtSecurityToken CriarToken(string nome, string email)
        {
            var token = new JwtSecurityToken(claims: new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Name , nome)
            });

            return token;
        }

        public string GerarToken(JwtSecurityToken tokenCriado)
        {
            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(tokenCriado);
        }
    }
}
