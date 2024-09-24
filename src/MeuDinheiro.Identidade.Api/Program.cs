using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MeuDinheiro.Identidade.Api.Identidade;
using MeuDinheiro.Identidade.Api.Identidade.Login;
using MeuDinheiro.Identidade.Api.Identidade.Registrar;

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

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("cors", (opt) =>
                {
                    opt.WithOrigins("https://localhost:7122")
                       .AllowCredentials()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
                });
            });

            builder.Services.AddScoped<RegistrarCommandHandler>();
            builder.Services.AddScoped<LoginCommandHandler>();

            builder.Services
                   .AddIdentityCore<ApplicationUser>()
                   .AddRoles<IdentityRole<long>>()
                   .AddEntityFrameworkStores<IdentidadeDbContext>();

            builder.Services.AddAuthorization();


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseCors("cors");

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}