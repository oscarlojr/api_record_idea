namespace record_idea.Models;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Category {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;
    public string Description { get; set; }
}
