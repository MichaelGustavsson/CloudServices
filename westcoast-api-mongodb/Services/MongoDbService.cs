using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using westcoast_api_mongodb.Models;
namespace westcoast_api_mongodb.Services
{
  public class MongoDbService
  {
    private readonly IMongoCollection<Vehicle> _vehicleListCollection;

    public MongoDbService(IOptions<MongoDbSettings> settings)
    {
      MongoClient client = new MongoClient(settings.Value.ConnectionUri);
      IMongoDatabase database = client.GetDatabase(settings.Value.DatabaseName);

      _vehicleListCollection = database.GetCollection<Vehicle>(settings.Value.CollectionName);
    }
  }
}