using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Mappers
{
    [ExcludeFromCodeCoverage]
    public static class CollectionExtensions
    {
        public static IServiceCollection AddVideoGamesAutoMapper(this IServiceCollection services, params Profile[] profiles)
        {
            return services.AddAutoMapper(x =>
            {
                foreach (var profile in profiles)
                    x.AddProfile(profile);
            });
        }
    }
}
