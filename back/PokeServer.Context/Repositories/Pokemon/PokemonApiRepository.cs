using Microsoft.Extensions.Options;
using PokeServer.Context.Repositories.Interfaces.Pokemon;
using PokeServer.Models.Configuration;
using PokeServer.PokeApi.Interfaces;
using PokeServer.Services.Interfaces;
using PokeServer.Utils;
using System;
using System.Threading.Tasks;

namespace PokeServer.Context.Repositories.Pokemon
{
    public class PokemonApiRepository : IPokemonApiRepository
    {
        private readonly IRestService<Models.PokeApi.PokemonResponseModel> _restService = null;
        private readonly IOptions<EnvConfig> _config = null;
        private readonly IPokeApiETL _pokeApiETL = null;

        public PokemonApiRepository(IRestService<Models.PokeApi.PokemonResponseModel> restService, IPokeApiETL pokeApiETL, IOptions<EnvConfig> config)
        {
            _restService = restService;
            _config = config;
            _pokeApiETL = pokeApiETL;
        }
        public Task Add(Models.Pokemon.Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Pokemon.Pokemon> Get(int number)
        {
            return Task.Run(() => {
                var responseModel = _restService.Request(_config.Value.PokeApi.PokemonAPI.APIUriFormatter(number.ToString()), "GET");
                if (responseModel == null)
                    return null;
                return _pokeApiETL.Transform(responseModel);
            });
            
        }

        public Task<Models.Pokemon.Pokemon> Get(string name)
        {
            return Task.Run(() => {
                var responseModel = _restService.Request(_config.Value.PokeApi.PokemonAPI.APIUriFormatter(name), "GET");
                if (responseModel == null)
                    return null;
                return _pokeApiETL.Transform(responseModel);
            });
        }

        public Task Update(Models.Pokemon.Pokemon pokemon)
        {
            throw new NotImplementedException();
        }
    }
}
