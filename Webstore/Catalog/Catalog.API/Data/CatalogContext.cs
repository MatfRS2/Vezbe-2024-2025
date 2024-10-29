using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data;

public class CatalogContext: ICatalogContext
{
    public IMongoCollection<Product> Products { get; }

    public CatalogContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DataBaseSettings:ConnectionString"));
        var database = client.GetDatabase("CatalogDB");
        
        Products = database.GetCollection<Product>("Products");
        CatalogContextSeed.SeedData(Products);
    }
}