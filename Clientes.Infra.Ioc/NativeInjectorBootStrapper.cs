using AutoMapper;
using Clientes.Application.AutoMapper;
using Clientes.Application.Contracts;
using Clientes.Application.Services;
using Clientes.Domain.ClienteAgregate.Entities;
using Clientes.Domain.Contracts;
using Clientes.Infra.Data.Context;
using Clientes.Infra.Data.Context.Repositories;
using Clientes.Shared.Dtos;
using Clientes.Shared.FiltersModel;
using Clientes.Shared.InputModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Clientes.Infra.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            #region [Configurations]

            var connection = configuration["CONNECTION_STRING:ClientesContext"];
            services.AddDbContext<ClientesContext>(option => option.UseSqlServer(connection));

            services.AddScoped<ClientesContext, ClientesContext>();

            // Configurar Automapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.Load("Clientes.Domain")));

            #endregion

            #region [DI]

            services.AddScoped(typeof(IRepository<,>), typeof(RepositoryBase<,>));
            services.AddScoped<IRepository<Cliente, ClienteFilters>, ClienteRepository>();

            services.AddScoped<IApplicationServices<Cliente, ClienteDto, CreateClienteInput, UpdateClienteInput, ListClienteDto, ClienteFilters>, ClienteApplication>();

            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<ICidadeApplication, CidadeApplication>();

            #endregion

        }
    }
}
