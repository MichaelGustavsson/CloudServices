using Microsoft.Extensions.Options;
using MongoDB.Bson;
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

        public async Task<List<Vehicle>> GetVehiclesAsync()
        {
            return await _vehicleListCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task CreateVehicleAsync(Vehicle vehicle)
        {
            await _vehicleListCollection.InsertOneAsync(vehicle);
        }
    }
}