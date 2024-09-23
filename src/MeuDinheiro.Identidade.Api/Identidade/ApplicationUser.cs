using Microsoft.AspNetCore.Identity;

namespace MeuDinheiro.Identidade.Api.Identidade
{
    public class ApplicationUser : IdentityUser<long>
    {
        public List<IdentityRole<long>>? Roles { get; set; }
    }
}
