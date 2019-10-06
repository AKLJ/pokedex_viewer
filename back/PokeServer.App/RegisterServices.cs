using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PokeServer.App
{
    public static class RegisterServices
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(Behaviors.Logging.LoggingBehavior<,>));
        }
    }
}
