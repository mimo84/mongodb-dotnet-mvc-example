using System;
using System.Collections.Generic;
using MongoDB.Driver;
using mongodb_driver_example.Models;
using System.Threading.Tasks;

namespace mongodb_driver_example.Services
{
  public class ExampleService
  {
    private readonly IMongoCollection<Example> _example;

    public ExampleService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _example = database.GetCollection<Example>(settings.CollectionName);
    }

    public List<Example> FetchAll()
    {
      return _example.Find(x => true).ToList();
    }

    public async Task<Example> CreateAsync(Example example)
    {

      Console.WriteLine($"Example: {example.Name} siblings: {example.SiblingCount}");
      await _example.InsertOneAsync(example);
      return example;
    }

  }
}
