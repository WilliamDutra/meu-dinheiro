using MeuDinheiro.Identidade.Identity.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeuDinheiro.Identidade.Identity
{
    public class IdentidadeDbContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long, IdentityUserClaim<long>, IdentityUserRole<long>, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        
        public IdentidadeDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new IdentityRoleClaimMapping());
            builder.ApplyConfiguration(new IdentityRoleMapping());
            builder.ApplyConfiguration(new IdentityUserMapping());
            builder.ApplyConfiguration(new IdentityUserRoleMapping());
            builder.ApplyConfiguration(new IdentityUserLoginMapping());
            builder.ApplyConfiguration(new IdentityUserTokenMapping());
            builder.ApplyConfiguration(new IdentityUserClaimMapping());
        }

    }
}
