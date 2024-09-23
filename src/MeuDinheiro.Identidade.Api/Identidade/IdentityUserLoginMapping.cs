using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuDinheiro.Identidade.Api.Identidade
{
    public class IdentityUserLoginMapping : IEntityTypeConfiguration<IdentityUserLogin<long>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<long>> builder)
        {
            builder.HasKey(l => new { l.LoginProvider, l.ProviderKey });
            builder.Property(l => l.LoginProvider).HasMaxLength(128);
            builder.Property(l => l.ProviderKey).HasMaxLength(128);
            builder.Property(u => u.ProviderDisplayName).HasMaxLength(255);
        }
    }
}
