using MeuDinheiro.Data;
using MeuDinheiro.Aplicacao.Conta.Cadastar;
using MeuDinheiro.Aplicacao.Despesa.LancarDespesa;
using MeuDinheiro.Dominio.Repositorios;

namespace MeuDinheiro.Api.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            var str = configuration.GetConnectionString("Default");
            services.AddScoped<MeuDinheiroContext>(c => new MeuDinheiroContext(str));
            services.AddScoped<IContaRepositorio, ContaRepositorio>();
            return services;
        }

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<CadastrarContaCommandHandler>();
            services.AddScoped<LancarDespesaCommandHandler>();
            return services;
        }

    }
}
