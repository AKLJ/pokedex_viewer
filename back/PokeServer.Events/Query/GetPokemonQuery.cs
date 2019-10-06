using MediatR;
using PokeServer.Events.GenericQueryCommand;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeServer.Events.Query
{
    public class GetPokemonQuery : IRequest<Models.Pokemon.Pokemon>, IGenericQueryCommand
    {
        public GetPokemonQuery()
        {
            RequestId = Guid.NewGuid();
        }
        public Guid RequestId { get; set; }
        public object Identifier { get; set; }

        public override string ToString()
        {
            if(Identifier is int)
            {
                return "#" + Identifier.ToString();
            }
            return Identifier.ToString();
        }
    }
}
