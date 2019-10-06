using MongoDB.Driver;
using PokeServer.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeServer.Services.Interfaces
{
    public interface IMongoService<T> 
    {
        List<T> Get();

        T Get(string id);

        T GetByName(string name);

        T GetByIdentifier(object obj);

        T Insert(T obj);

        void Update(string id, T obj);

        void Remove(T obj);

        void Remove(string id);
    }
}
