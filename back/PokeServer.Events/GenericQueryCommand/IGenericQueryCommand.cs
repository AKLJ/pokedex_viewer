using System;
using System.Collections.Generic;
using System.Text;

namespace PokeServer.Events.GenericQueryCommand
{
    public interface IGenericQueryCommand
    {
        public Guid RequestId { get; set; }
    }
}
