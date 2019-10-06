using MediatR;
using PokeServer.Events.Notifications.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokeServer.App.Notifications.Repository
{
    public class RetrievedPokemonFromCacheNotificationHandler : INotificationHandler<RetrievedPokemonFromCacheNotification>
    {
        public Task Handle(RetrievedPokemonFromCacheNotification notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
