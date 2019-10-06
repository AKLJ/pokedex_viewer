using PokeServer.Models.Pokemon;

namespace PokeServer.Business.Interfaces
{
    public interface IPokemonSearch
    {
        Pokemon GetPokemon(object identifier);

        void TraceLog();
    }
}
