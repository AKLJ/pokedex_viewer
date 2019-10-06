using PokeServer.Context.Repositories.Interfaces.Pokemon;
using PokeServer.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace PokeServer.Context.Repositories
{
    public class PokemonDatabaseRepository : IPokemonDatabaseRepository
    {
        private readonly IMongoService<Models.Pokemon.Pokemon> _mongoService;

        public PokemonDatabaseRepository(IMongoService<Models.Pokemon.Pokemon> mongoService)
        {
            _mongoService = mongoService;
        }
        public Task Add(Models.Pokemon.Pokemon pokemon)
        {
            return Task.Run(()=>_mongoService.Insert(pokemon));
        }

        public Task<Models.Pokemon.Pokemon> Get(int number)
        {
            return Task.Run(() => _mongoService.GetByIdentifier(number));
        }

        public Task<Models.Pokemon.Pokemon> Get(string name)
        {
            return Task.Run(() => _mongoService.GetByName(name));
        }

        public Task Update(Models.Pokemon.Pokemon pokemon)
        {
            return Task.Run(() => _mongoService.Update(pokemon.Id,pokemon));
        }
    }
}
