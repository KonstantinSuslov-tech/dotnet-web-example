using ExampleWeb.Domain.MongoDocuments;
using ExampleWeb.Infrastracture.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ExampleWeb.Infrastracture.Contexts
{
    public class MongoContex
    {
        private readonly IMongoDatabase? _database;

        public MongoContex(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<UserDocument> UserDocuments
        {
            get
            {
                return _database!.GetCollection<UserDocument>("userDocuments");
            }
        }
    }
}
