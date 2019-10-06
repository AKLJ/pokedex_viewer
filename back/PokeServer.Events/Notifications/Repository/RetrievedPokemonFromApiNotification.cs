using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PokeServer.Models.Pokemon;

namespace PokeServer.Events.Notifications.Repository
{
    public class RetrievedPokemonFromApiNotification : IPokemonRetrievedNotification
    {
        public Pokemon Pokemon { get; set; }

        public override string ToString()
        {
            return string.Format("Retrieved from API : Pokemon #{0} - {1}", Pokemon.Identifier, Pokemon.Name);
        }
    }
}
