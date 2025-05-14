using Microsoft.EntityFrameworkCore;
using TesteConhecimentoApi.Context;
using TesteConhecimentoApi.Repositories.Interfaces;
using TesteConhecimentoApi.Repositories.Repository;
using TesteConhecimentoApi.Services.Interfaces;
using TesteConhecimentoApi.Services.Service;

namespace TesteConhecimentoApi.Dependencies
{
    public static class Dependencies
    {
        public static void InjecaoDeDependencias(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DBTesteConhecimento"),
                    assembly => assembly.MigrationsAssembly(typeof(DBContext).Assembly.FullName));
            });


            #region //Services

            services.AddScoped<IContatoServices, ContatoServices>();

            #endregion


            #region //Repositories

            services.AddScoped<IContatoRepository, ContatoRepository>();

            #endregion


        }
    }
}
