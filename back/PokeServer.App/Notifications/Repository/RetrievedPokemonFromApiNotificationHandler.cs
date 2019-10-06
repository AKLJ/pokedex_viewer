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
    public class RetrievedPokemonFromApiNotificationHandler : INotificationHandler<RetrievedPokemonFromApiNotification>
    {
        private readonly IPokemonDatabaseRepository _pokemonDatabaseRepository = null;
        private readonly IPokemonCachingRepository _pokemonCachingRepository = null;
        public RetrievedPokemonFromApiNotificationHandler(IPokemonDatabaseRepository pokemonDatabaseRepository, IPokemonCachingRepository pokemonCachingRepository)
        {
            _pokemonDatabaseRepository = pokemonDatabaseRepository;
            _pokemonCachingRepository = pokemonCachingRepository;
        }
        public Task Handle(RetrievedPokemonFromApiNotification notification, CancellationToken cancellationToken)
        {
            _pokemonDatabaseRepository.Add(notification.Pokemon);
            _pokemonCachingRepository.Add(notification.Pokemon);
            return Task.CompletedTask;
        }
    }
}
