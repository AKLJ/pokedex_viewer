using System;
using System.Collections.Generic;
using System.Text;

namespace PokeServer.Models.Pokemon
{
    [Serializable]
    public class Stat
    {
        public string Name { get; set; }
        public int BaseLevel { get; set; }
        public int Effort { get; set; }
    }
}
