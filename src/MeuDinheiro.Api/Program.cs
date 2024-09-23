using MeuDinheiro.Api.Configurations;

namespace MeuDinheiro.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var config = builder.Configuration;

            builder.Services.AddControllers();
            builder.Services.AddInfra(config);
            builder.Services.AddHandlers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}