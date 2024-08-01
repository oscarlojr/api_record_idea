namespace record_idea.Configurations;

public class DatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string CategoriesCollectionName { get; set; } = null!;
}