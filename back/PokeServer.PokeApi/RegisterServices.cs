using Microsoft.Extensions.DependencyInjection;
using PokeServer.PokeApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeServer.PokeApi
{
    public static class RegisterServices
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IPokeApiETL, PokeApiETL>();
        }
    }
}
