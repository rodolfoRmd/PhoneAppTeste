using ApiPhone.DAL.Contexto;
using ApiPhone.DAL.Repositorio;
using ApiPhone.DomainLayer;
using ApiPhone.Models.AutoMapper;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ApiPhone.CrossCutting
{
    public static class Cointainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //CHAMADA DOS METODOS ABAIXO
            services.AddDataBases();
            services.RegisterServices();
            services.AddMapper();
            return services;
        }
        private static void AddDataBases(this IServiceCollection services)
        {
            //DATABASE
            var serviceProvider = services.BuildServiceProvider();
            services.AddDbContext<DAL.Contexto.ContextPhone>(options =>
                 options.UseSqlServer(serviceProvider.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection"))
             );
        }

        private static void RegisterServices(this IServiceCollection services)
        {
            //Registro de serviços
          
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContexto, ContextPhone>();
            services.AddScoped<IPersonPhoneService, PersonPhoneService>();
            services.AddScoped<IPhoneTypeService, PhoneTypeService>();

        }

        private static void AddMapper(this IServiceCollection services)
        {
            //AutoMapper
            IMapper Mapper;
            var config = new MapperConfiguration((mapper) =>
            {
                mapper.AddProfile<PersonPhoneMapping>();
                mapper.AddProfile<PhoneNumberTypeMapping>();
                
            });

            Mapper = config.CreateMapper();

            services.AddSingleton(Mapper);

        }
    }

}
