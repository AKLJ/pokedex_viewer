using Microsoft.Extensions.DependencyInjection;
using PokeServer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeServer.Services
{
    public static class RegisterServices
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(ICachingService<>), typeof(CachingService<>));
            serviceCollection.AddTransient(typeof(IMongoService<>), typeof(MongoService<>));
            serviceCollection.AddTransient(typeof(IRestService<>), typeof(RestService<>));
        }
    }
}
