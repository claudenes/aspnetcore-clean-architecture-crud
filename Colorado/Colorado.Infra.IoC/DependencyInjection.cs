using Colorado.Application.Interfaces;
using Colorado.Application.Mappings;
using Colorado.Application.Services;
using Colorado.Domain.Interfaces;
using Colorado.Infra.Data.Context;
using Colorado.Infra.Data.Repositories;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Colorado.Infra.IoC
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureEntityFrameWork(services);
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ITipoTelefoneRepository, TipoTelefoneRepository>();

            services.AddAutoMapper(cfg => {
                cfg.AddProfile<DomainToDtoMappingProfile>();
            });

            var myhandlers = AppDomain.CurrentDomain.Load("Colorado.Application");

            return services;
        }
        private static void ConfigureEntityFrameWork(this IServiceCollection services)
        {
            string connectionString = "";

            connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CustomerCrudDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

            services.AddDbContext<ApplicationDbContext>(options =>
            {

                options.UseSqlServer(connectionString,
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)); options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });


        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITelefoneService, TelefoneService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ITipoTelefoneService, TipoTelefoneService>();

            services.AddAutoMapper(cfg => {
                cfg.AddProfile<DomainToDtoMappingProfile>();
            });
            //services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
            return services;
        }
    }
}
