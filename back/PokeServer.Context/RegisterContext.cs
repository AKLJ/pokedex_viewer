using Microsoft.Extensions.DependencyInjection;
using PokeServer.Context.Repositories;
using PokeServer.Context.Repositories.Interfaces.Pokemon;
using PokeServer.Context.Repositories.Interfaces.User;
using PokeServer.Context.Repositories.Pokemon;
using PokeServer.Context.Repositories.User;

namespace PokeServer.Context
{
    public static class RegisterContext
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IPokemonCachingRepository, PokemonCachingRepository>();
            serviceCollection.AddTransient<IPokemonDatabaseRepository, PokemonDatabaseRepository>();
            serviceCollection.AddTransient<IPokemonApiRepository, PokemonApiRepository>();
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
