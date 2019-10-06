using Microsoft.Extensions.DependencyInjection;
using PokeServer.Business.Interfaces;

namespace PokeServer.Business
{
    public static class RegisterServices
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IPokemonSearch, PokemonSearch>();
        }
    }
}
