using MongoDB.Driver;
using PokeServer.Models.Configuration;
using PokeServer.Models.Database;
using PokeServer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeServer.Services
{
    public class MongoService<T> : IMongoService<T> where T : IEntities
    {
        private readonly IMongoCollection<T> _objs;

        public MongoService(IPokeServerDatabase pokeServerDatabase)
        {
            var client = new MongoClient(pokeServerDatabase.ConnectionString);
            var database = client.GetDatabase(pokeServerDatabase.DatabaseName);

            _objs = database.GetCollection<T>(typeof(T).Name);
        }

        public List<T> Get() => _objs.Find(obj => true).ToList();

        public T Get(string id) => _objs.Find(obj=>obj.Id == id).FirstOrDefault();

        public T GetByIdentifier(object obj) => _objs.Find(o => o.Identifier == obj).FirstOrDefault();

        public T GetByName(string name) => _objs.Find(obj=> obj.Name == name).FirstOrDefault();


        public T Insert(T t)
        {
            _objs.InsertOne(t);
            return t;
        }

        public void Remove(T t) =>_objs.DeleteOne(obj => obj.Id == t.Id);

        public void Remove(string id) => _objs.DeleteOne(obj => obj.Id == id);


        public void Update(string id, T t) => _objs.ReplaceOne(obj => obj.Id == t.Id, t);
    }
}
