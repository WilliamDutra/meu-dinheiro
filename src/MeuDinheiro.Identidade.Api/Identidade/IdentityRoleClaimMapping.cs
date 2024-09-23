﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MeuDinheiro.Identidade.Api.Identidade
{
    public class IdentityRoleClaimMapping: IEntityTypeConfiguration<IdentityRoleClaim<long>>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<long>> builder)
        {
            builder.HasKey(rc => rc.Id);
            builder.Property(u => u.ClaimType).HasMaxLength(255);
            builder.Property(u => u.ClaimValue).HasMaxLength(255);
        }
    }
}
