using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Services;
using Data;
using Data.Interfaces;
using Mappers;
using Business.Mappers;

namespace Services
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGameRepository, GameRepository>();

            services.AddVideoGamesAutoMapper(new VideoGamesProfile());
            return services;
        }

        public static IServiceCollection RegisterExternalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddVideoGamesAutoMapper(new VideoGamesProfile());
            return services;
        }
    }
}
