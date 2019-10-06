using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PokeServer.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeServer.Models.User
{
    public class User : IEntities
    {

        public string Name { get; set; }
        public Pokemon.Pokemon[] Pokemons { get; set; }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public object Identifier { get; set; }
    }
}
