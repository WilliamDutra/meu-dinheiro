using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeuDinheiro.Identidade.Api.Identidade
{
    public class IdentidadeDbContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long, IdentityUserClaim<long>, IdentityUserRole<long>, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public IdentidadeDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
