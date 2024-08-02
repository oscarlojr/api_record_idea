using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace record_idea.Models;

public class Category
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; } = null!; // Não inicializar aqui

    public string Name { get; set; } = null!;
    public string Description { get; set; }
}
