using System;
using System.Collections.Generic;
using System.Text;

namespace PokeServer.Models.Pokemon
{
    [Serializable]
    public class Move
    {
        public string Name { get; set; }
        public string LearningMethod { get; set; }
    }
}
