using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data;

public class CatalogContext: ICatalogContext
{
    public IMongoCollection<Product> Products { get; }

    public CatalogContext(IConfiguration configuration)
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("CatalogDB");
        
        Products = database.GetCollection<Product>("Products");
        CatalogContextSeed.SeedData(Products);
    }
}