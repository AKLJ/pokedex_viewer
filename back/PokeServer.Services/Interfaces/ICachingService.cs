using PokeServer.Models.Pokemon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokeServer.Services.Interfaces
{
    public interface ICachingService<T>
    {
        Task Save(T obj);
        Task<T> Load(string name);
    }
}
