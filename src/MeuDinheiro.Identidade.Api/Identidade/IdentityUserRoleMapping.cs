using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuDinheiro.Identidade.Api.Identidade
{
    public class IdentityUserRoleMapping : IEntityTypeConfiguration<IdentityUserRole<long>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<long>> builder)
        {
            builder.HasKey(r => new { r.UserId, r.RoleId });
        }
    }
}
