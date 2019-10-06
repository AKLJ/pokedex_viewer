using MediatR;
using PokeServer.Context.Repositories.Interfaces.Pokemon;
using PokeServer.Events.Notifications.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokeServer.App.Notifications.Repository
{
    public class RetrievedPokemonFromDatabaseNotificationHandler : INotificationHandler<RetrievedPokemonFromDatabaseNotification>
    {
        private readonly IPokemonCachingRepository _pokemonCachingRepository = null;
        public RetrievedPokemonFromDatabaseNotificationHandler(IPokemonCachingRepository pokemonCachingRepository)
        {
            _pokemonCachingRepository = pokemonCachingRepository;
        }

        public Task Handle(RetrievedPokemonFromDatabaseNotification notification, CancellationToken cancellationToken)
        {
            _pokemonCachingRepository.Add(notification.Pokemon);
            return Task.CompletedTask;
        }
    }
}
