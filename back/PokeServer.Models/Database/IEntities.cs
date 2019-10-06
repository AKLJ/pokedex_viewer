using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PokeServer.Models.Database
{
    public interface IEntities
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public object Identifier { get; set; }

    }
}
