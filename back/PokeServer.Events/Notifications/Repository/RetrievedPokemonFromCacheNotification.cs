using MediatR;
using PokeServer.Models.Pokemon;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeServer.Events.Notifications.Repository
{
    public class RetrievedPokemonFromCacheNotification : IPokemonRetrievedNotification
    {
        public Pokemon Pokemon { get; set; }

        public override string ToString()
        {
            return string.Format("Retrieved from Cache : Pokemon #{0} - {1}", Pokemon.Identifier, Pokemon.Name);
        }
    }
}
