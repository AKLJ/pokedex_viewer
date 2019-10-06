using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeServer.Events.Notifications.Repository
{
    public interface IPokemonRetrievedNotification : INotification
    { 
       Models.Pokemon.Pokemon Pokemon { get; set; }
    }
}
