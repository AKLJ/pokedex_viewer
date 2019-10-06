using System;
using System.Collections.Generic;
using System.Text;

namespace PokeServer.Models.Configuration
{
    public class EnvConfig
    {
        public PokeApi PokeApi { get; set; }
        public PokeServerDatabase PokeServerDatabase { get; set; }
        public PokeServerCache PokeServerCache { get; set; }
        public Serilog Serilog { get; set; }
    }

    #region Cache
    public class PokeServerCache
    {
        public string Url { get; set; }
        public string InstanceName { get; set; }
    }
    #endregion

    #region Api
    public class PokeApi
    {
        public string Url { get; set; }
        public string EvolutionAPI { get; set; }
        public string PokemonAPI { get; set; }
        public string SpeciesAPI { get; set; }
    }
    #endregion

    #region Serilog
    public class Override
    {
        public string Microsoft { get; set; }
        public string System { get; set; }
    }

    public class MinimumLevel
    {
        public string Default { get; set; }
        public Override Override { get; set; }
    }

    public class WriteTo
    {
        public string Name { get; set; }
    }

    public class Properties
    {
        public string Application { get; set; }
    }

    public class Serilog
    {
        public List<string> Using { get; set; }
        public MinimumLevel MinimumLevel { get; set; }
        public List<string> Enrich { get; set; }
        public List<WriteTo> WriteTo { get; set; }
        public Properties Properties { get; set; }
    }
    #endregion

    #region Database
    public class PokeServerDatabase : IPokeServerDatabase
    {
        public string PokemonCollectionName { get; set; }
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPokeServerDatabase
    {
        string PokemonCollectionName { get; set; }
        string UserCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
    #endregion
}
