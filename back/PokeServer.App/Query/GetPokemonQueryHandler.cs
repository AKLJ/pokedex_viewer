using MediatR;
using PokeServer.Business.Interfaces;
using PokeServer.Context.Repositories.Interfaces.Pokemon;
using PokeServer.Events.Query;
using PokeServer.Models.Pokemon;
using PokeServer.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokeServer.App.Query
{
    public class GetPokemonQueryHandler : IRequestHandler<GetPokemonQuery, Models.Pokemon.Pokemon>
    {
        private readonly IPokemonSearch _pokemonSearch;

        public GetPokemonQueryHandler(IPokemonSearch pokemonSearch)
        {
            _pokemonSearch = pokemonSearch;
        }

        public async Task<Pokemon> Handle(GetPokemonQuery request, CancellationToken cancellationToken)
        {
            Pokemon pokemon = null;
            pokemon = await Task.Run(()=> _pokemonSearch.GetPokemon(request.Identifier));
            return pokemon;
        }

    }
}
