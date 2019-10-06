using Microsoft.Extensions.Options;
using PokeServer.Models.Configuration;
using PokeServer.Models.PokeApi;
using PokeServer.Models.Pokemon;
using PokeServer.PokeApi.Interfaces;
using PokeServer.Services.Interfaces;
using PokeServer.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PokeServer.PokeApi
{
    public class PokeApiETL : IPokeApiETL
    {
        private readonly IRestService<PokemonEvolutionResponseModel> _restServiceEvolution;
        private readonly IRestService<PokemonSpeciesResponseModel> _restServiceSpecies;
        private readonly IOptions<EnvConfig> _envConfig;

        public PokeApiETL(IRestService<PokemonEvolutionResponseModel> restServiceEvolution, 
            IRestService<PokemonSpeciesResponseModel> restServiceSpecies,
            IOptions<EnvConfig> config)
        {
            _restServiceSpecies = restServiceSpecies;
            _restServiceEvolution = restServiceEvolution;
            _envConfig = config;
        }
        public Models.Pokemon.Pokemon Transform(PokemonResponseModel pokemonResponseModel)
        {
            Models.Pokemon.Pokemon pokemon = TransformApiPokemonToPokeServerEvolutionlessPokemon(pokemonResponseModel);

            var species = _restServiceSpecies.Request(_envConfig.Value.PokeApi.SpeciesAPI.APIUriFormatter(pokemon.Name), "GET");
            pokemon.Description = species.flavor_text_entries.FirstOrDefault(f => f.language.name == CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToLower())?.flavor_text;

            pokemon.Evolutions = ExtractEvolutions(pokemon, species).ToArray();


            return pokemon;
        }

        private List<string> ExtractEvolutions(Models.Pokemon.Pokemon pokemon, PokemonSpeciesResponseModel species)
        {
            var evolutionInfo = _restServiceEvolution.Request(species.evolution_chain.url, "GET");

            List<string> relatedPokemons = new List<string>();

            if (evolutionInfo.chain.species.name != pokemon.Name)
            {
                relatedPokemons.Add(evolutionInfo.chain.species.name);
            }

            if (evolutionInfo.chain.evolves_to !=null && evolutionInfo.chain.evolves_to.Any())
            {
                ResolveEvolutionTree(pokemon, evolutionInfo.chain.evolves_to, relatedPokemons);
            }

            return relatedPokemons;
        }

        private void ResolveEvolutionTree(Models.Pokemon.Pokemon pokemon, IEnumerable<EvolvesTo> evolutionInfo, List<string> relatedPokemons)
        {
            foreach (var evolveInfo in evolutionInfo)
            {
                if (evolveInfo.species.name != pokemon.Name)
                {
                    relatedPokemons.Add(evolveInfo.species.name);
                }

                if (evolveInfo.evolves_to != null && evolveInfo.evolves_to.Any())
                {
                    ResolveEvolutionTree(pokemon, evolveInfo.evolves_to, relatedPokemons);
                }
            }
        }

        private Models.Pokemon.Pokemon TransformApiPokemonToPokeServerEvolutionlessPokemon(PokemonResponseModel pokemonResponseModel)
        {
            return new Models.Pokemon.Pokemon()
            {
                Abilities = pokemonResponseModel.abilities.Select(a => a.ability.name).ToArray(),
                BaseExperience = pokemonResponseModel.base_experience,
                Height = pokemonResponseModel.height * 0.1,
                Identifier = pokemonResponseModel.id,
                Image = new Uri(pokemonResponseModel.sprites.front_default),
                Moves = pokemonResponseModel.moves.Select(m => new Models.Pokemon.Move()
                {
                    Name = m.move.name,
                    LearningMethod = string.Join(',', m.version_group_details.Select(vgd => vgd.move_learn_method.name))
                }).ToArray(),
                Name = pokemonResponseModel.name,
                PokemonTypes = pokemonResponseModel.types.Select(t => Enum.Parse<PokemonType>(t.type.name.ToLower()).ToString()).ToArray(),
                Stats = pokemonResponseModel.stats.Select(s => new Models.Pokemon.Stat()
                {

                }).ToArray(),
                Weight = pokemonResponseModel.weight * 0.1,
            };
        }
    }
}
