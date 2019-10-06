using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PokeServer.Models.Database;
using System;
using System.Collections.Generic;

namespace PokeServer.Models.Pokemon
{
    [Serializable]
    public class Pokemon : IEntities
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Abilities { get; set; }
        public string[] PokemonTypes { get; set; }
        public string[] Evolutions { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int BaseExperience { get; set; }
        public Stat[] Stats { get; set; }
        public Move[] Moves { get; set; }
        public Uri Image { get; set; }
        public object Identifier { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public enum EvolutionType
    {
        From,
        To
    }

    public enum PokemonType
    {
        normal,
        fighting,
        flying,
        poison,
        ground,
        rock,
        bug,
        ghost,
        steel,
        fire,
        water,
        grass,
        electric,
        psychic,
        ice,
        dragon,
        dark,
        fairy,
        unknown
    }
}
