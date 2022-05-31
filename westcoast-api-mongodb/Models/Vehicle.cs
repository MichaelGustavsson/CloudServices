using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace westcoast_api_mongodb.Models
{
  public class Vehicle
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? RegNo { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
  }
}