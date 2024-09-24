using System;
using System.IdentityModel.Tokens.Jwt;

namespace MeuDinheiro.Identidade.Identity
{
    public interface IIdentidadeTokenService
    {
        public JwtSecurityToken CriarToken(string nome, string email);

        public string GerarToken(JwtSecurityToken tokenCriado);
    }
}
