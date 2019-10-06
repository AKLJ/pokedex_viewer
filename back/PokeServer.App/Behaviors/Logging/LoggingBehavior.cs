using MediatR;
using PokeServer.Events.GenericQueryCommand;
using PokeServer.Events.Query;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokeServer.App.Behaviors.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IGenericQueryCommand
    {
        private readonly ILogger _logger = null;
        public LoggingBehavior(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = default(TResponse);
            if (request != null)
            {
                _logger.Information("{Name} - {RequestId} - {Identifier}", typeof(TRequest).Name, request.RequestId, request.ToString());
            }

            try
            {
                response = await next();
            }
            catch(Exception e)
            {
                _logger.Error("{RequestId} - {Message}",request.RequestId,e.Message);
            }

            _logger.Information("{Name} - {RequestId} - {Identifier} - COMPLETED", typeof(TRequest).Name, request.RequestId, request.ToString());
            return response;
        }
    }
}
