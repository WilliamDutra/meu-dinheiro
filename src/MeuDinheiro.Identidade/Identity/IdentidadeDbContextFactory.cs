using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MeuDinheiro.Identidade.Identity
{
    public class IdentidadeDbContextFactory : IDesignTimeDbContextFactory<IdentidadeDbContext>
    {
        public IdentidadeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentidadeDbContext>();
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=root;Database=meudinheiro;");

            return new IdentidadeDbContext(optionsBuilder.Options);
        }
    }
}
