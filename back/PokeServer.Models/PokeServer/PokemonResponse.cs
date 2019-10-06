using System;
using System.Collections.Generic;
using System.Text;

namespace PokeServer.Models.PokeServer
{
    public class PokemonResponse
    {
        public Guid RequestId { get; set; }
        public Pokemon.Pokemon Pokemon {get;set;}
    }
}
