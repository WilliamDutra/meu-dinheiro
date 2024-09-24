using System;
using System.Text;
using MeuDinheiro.Identidade.Identity;
using Microsoft.EntityFrameworkCore;

namespace MeuDinheiro.Identidade.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddIdentitdadeContext(builder.Configuration);
            builder.Services.AddIdentidadeJWT(builder.Configuration);
            builder.Services.AddIdentidade();
            builder.Services.AddHandlers();

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