using MediatR;
using PokeServer.Business.Interfaces;
using PokeServer.Context.Repositories.Interfaces.Pokemon;
using PokeServer.Events.Notifications.Repository;
using PokeServer.Models.Pokemon;
using PokeServer.Models.Services;
using Serilog;
using System;

namespace PokeServer.Business
{
    public class PokemonSearch : IPokemonSearch
    {
        private readonly IPokemonCachingRepository _pokemonCachingRepository;
        private readonly IPokemonDatabaseRepository _pokemonDatabaseRepository;
        private readonly IPokemonApiRepository _pokemonApiRepository;
        private readonly IMediator _mediator;

        public PokemonSearch(IPokemonCachingRepository pokemonCachingRepository, IPokemonDatabaseRepository pokemonDatabaseRepository, IPokemonApiRepository pokemonApiRepository,
            IMediator mediator)
        {
            _pokemonCachingRepository = pokemonCachingRepository;
            _pokemonDatabaseRepository = pokemonDatabaseRepository;
            _pokemonApiRepository = pokemonApiRepository;
            _mediator = mediator;
        }

        public Pokemon GetPokemon(object identifier)
        {
            var length = Enum.GetNames(typeof(QueryLevel)).Length;
            Pokemon pokemon = null;

            for (int i = 0; i < length; i++)
            {
                var queryLevel = (QueryLevel)i;

                pokemon = queryLevel switch
                {
                    QueryLevel.API => identifier is int ? _pokemonApiRepository.Get((int)identifier).Result : _pokemonApiRepository.Get(((string)identifier).ToLower()).Result,
                    QueryLevel.Cache => identifier is int ? null : _pokemonCachingRepository.Get(((string)identifier).ToLower()).Result,
                    QueryLevel.Database => identifier is int ? _pokemonDatabaseRepository.Get((int)identifier).Result : _pokemonDatabaseRepository.Get(((string)identifier).ToLower()).Result,
                    _ => throw new ArgumentException("Invalid Query Level enum"),
                };


                if (pokemon != null)
                {
                    _ = (queryLevel switch
                    {
                        QueryLevel.API => _mediator.Publish(new RetrievedPokemonFromApiNotification() { Pokemon = pokemon }),
                        QueryLevel.Cache => _mediator.Publish(new RetrievedPokemonFromCacheNotification() { Pokemon = pokemon }),
                        QueryLevel.Database => _mediator.Publish(new RetrievedPokemonFromDatabaseNotification() { Pokemon = pokemon }),
                        _ => throw new ArgumentException("Invalid Query Level enum"),
                    });

                    return pokemon;
                }
            }

            return pokemon;
        }

        public void TraceLog()
        {
            throw new NotImplementedException();
        }
    }
}
