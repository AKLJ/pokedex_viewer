using System;
using System.Collections.Generic;
using System.Text;

namespace PokeServer.PokeApi.Interfaces
{
    public interface IPokeApiETL
    {
        Models.Pokemon.Pokemon Transform(Models.PokeApi.PokemonResponseModel pokemonResponseModel);
    }
}
