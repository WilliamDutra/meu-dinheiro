using MeuDinheiro.Identidade.Api.Identidade;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace MeuDinheiro.Identidade.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
                            .AddIdentityCookies();

            builder.Services.AddDbContext<IdentidadeDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

            builder.Services
                   .AddIdentityCore<ApplicationUser>()
                   .AddRoles<IdentityRole<long>>()
                   .AddEntityFrameworkStores<IdentidadeDbContext>();

            builder.Services.AddAuthorization();


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}