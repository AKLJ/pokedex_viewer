using Microsoft.Extensions.Options;
using PokeServer.Context.Repositories.Interfaces.Pokemon;
using PokeServer.Models.Configuration;
using PokeServer.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace PokeServer.Context.Repositories.Pokemon
{
    public class PokemonCachingRepository : IPokemonCachingRepository
    {
        private readonly ICachingService<Models.Pokemon.Pokemon> _cachingService = null;

        public PokemonCachingRepository(ICachingService<Models.Pokemon.Pokemon> cachingService)
        {
            _cachingService = cachingService;
        }

        public Task Add(Models.Pokemon.Pokemon pokemon)
        {
            return _cachingService.Save(pokemon);
        }

        public Task<Models.Pokemon.Pokemon> Get(int number) => throw new NotImplementedException();

        public Task<Models.Pokemon.Pokemon> Get(string name)
        {
           return _cachingService.Load(name);
        }

        public Task Update(Models.Pokemon.Pokemon pokemon)
        {
            return _cachingService.Save(pokemon);
        }
    }
}
