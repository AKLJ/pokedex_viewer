using System;
using System.Collections.Generic;
using System.Text;

namespace PokeServer.Models.Services
{
    public enum QueryLevel
    {
        Cache = 0,
        Database = 1,
        API = 2
    }
}
