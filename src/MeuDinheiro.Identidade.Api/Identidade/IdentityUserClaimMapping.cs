﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuDinheiro.Identidade.Api.Identidade
{
    public class IdentityUserClaimMapping : IEntityTypeConfiguration<IdentityUserClaim<long>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<long>> builder)
        {
            builder.HasKey(uc => uc.Id);
            builder.Property(u => u.ClaimType).HasMaxLength(255);
            builder.Property(u => u.ClaimValue).HasMaxLength(255);
        }
    }
}
