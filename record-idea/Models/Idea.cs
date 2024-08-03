using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace record_idea.Models;

public class Idea
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Title { get; set; } = null!;
    public string Description { get; set; }
    public string CategoryId { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

