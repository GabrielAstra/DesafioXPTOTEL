using Aplicacao.Aplicacoes.Consultas;
using Aplicacao.Aplicacoes.Handlers;
using Dominio.Interfaces;
using Infraestrutura.Autenticacao;
using Infraestrutura.Repositorios;

namespace XPTOTelApi.Servicos
{
    public static class Injecoes
    {
        public static IServiceCollection AdicionarInjecaoDependencia(this IServiceCollection services)
        {
            services.AddSingleton<IPlano, PlanoRepositorio>();
            services.AddSingleton<ITarifa, TarifaRepositorio>();
            services.AddScoped<CriarUsuarioHandler>();
            services.AddScoped<ObterUsuariosHandler>();
            services.AddScoped<ObterCustoHandler>();

            return services;
        }
    }
}
