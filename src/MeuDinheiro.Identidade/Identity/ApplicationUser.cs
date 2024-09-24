using Microsoft.AspNetCore.Identity;
using System;

namespace MeuDinheiro.Identidade.Identity
{
    public class ApplicationUser : IdentityUser<long>
    {
        public string Nome { get; set; }

        public string Apelido { get; set; }

        public List<IdentityRole<long>>? Roles { get; set; }
    }
}
