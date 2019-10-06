using MediatR;
using PokeServer.Events.Notifications.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokeServer.App.Notifications
{
    public class LogRetrievedPokemonNotification<TNotification> : INotificationHandler<TNotification> where TNotification : IPokemonRetrievedNotification
    {
        private readonly ILogger _logger;

        public LogRetrievedPokemonNotification(ILogger logger)
        {
            _logger = logger;
        }

        public Task Handle(TNotification notification, CancellationToken cancellationToken)
        {
            _logger.Information(notification.ToString());
            return Task.CompletedTask;
        }
    }
}

