using System.Threading.Tasks;

namespace PokeServer.Context.Repositories.Interfaces.Pokemon
{
    public interface IPokemonRepository
    {
        public Task Add(Models.Pokemon.Pokemon pokemon);
        public Task Update(Models.Pokemon.Pokemon pokemon);
        public Task<Models.Pokemon.Pokemon> Get(int number);
        public Task<Models.Pokemon.Pokemon> Get(string name);
    }
}
