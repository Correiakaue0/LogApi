using LogApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LogApi.Context
{
    public class MongoDbContext : IDisposable
    {
        public IMongoDatabase _database { get; set; }
        public IMongoClient _client { get; set; }

        public MongoDbContext(IOptions<Settings> settings)
        {
            _client = new MongoClient(settings.Value.ConnectionString);
            if (_client != null)
            {
                _database = _client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<Log> Logs { get { return _database.GetCollection<Log>("log"); } }

        public void Dispose()
        {
            _database = null;
            _client = null;
        }
    }
}