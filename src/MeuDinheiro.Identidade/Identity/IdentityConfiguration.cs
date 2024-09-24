using System;
using System.Text;
using MeuDinheiro.Identidade.Login;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MeuDinheiro.Identidade.Registrar;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace MeuDinheiro.Identidade.Identity
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection AddIdentidade(this IServiceCollection services)
        {
            services.AddIdentityCore<ApplicationUser>()
                   .AddRoles<IdentityRole<long>>()
                   .AddEntityFrameworkStores<IdentidadeDbContext>();

            return services;
        }

        public static IServiceCollection AddIdentidadeJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtKey = Encoding.UTF8.GetBytes(configuration.GetSection("jwt-key").Value);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(options =>
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = false,
                                ValidateAudience = false,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = new SymmetricSecurityKey(jwtKey),
                                ClockSkew = TimeSpan.Zero
                            });
            return services;
        }

        public static IServiceCollection AddIdentitdadeContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentidadeDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Default")));
            return services;
        }

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<IIdentidadeTokenService, IdentidadeTokenService>();
            services.AddScoped<IRegistrarHandler, RegistrarCommandHandler>();
            services.AddScoped<ILoginHandler, LoginCommandHandler>();
            return services;
        }

    }
}
