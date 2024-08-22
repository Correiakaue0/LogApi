using LogApi.Context;
using LogApi.Models;
using LogApi.Repositories.IRepositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace LogApi.Repositories
{
    public class LogRepository : ILogRepository
    {
        public readonly MongoDbContext _context = null;

        public LogRepository(IOptions<Settings> settings)
        {
            _context = new MongoDbContext(settings);
        }

        public IEnumerable<Log> GetAll()
        {
            return _context.Logs.Find(x => true).ToList();
        }

        public Log GetById(string id)
        {
            return _context.Logs
                .Find(x => x.Id.Equals(id))
                .FirstOrDefault();
        }

        public void Create(Log log)
        {
            _context.Logs.InsertOneAsync(log);
        }

        public bool Update(string id, Log item)
        {
            IMongoCollection<Log> listLog = _context.Logs;
            Expression<Func<Log, bool>> filter = x => x.Id.Equals(id);
            Log log = listLog.Find(filter).FirstOrDefault();

            if (log != null)
            {
                log.Message = item.Message;
                log.Details = item.Details;
                ReplaceOneResult result = listLog.ReplaceOne(filter, log);
                return result.IsAcknowledged && result.ModifiedCount > 0;
            }
            return false;
        }

        public bool Delete(string id)
        {
            DeleteResult result = _context.Logs.DeleteMany(x => x.Id.Equals(id));
            return result.IsAcknowledged
                && result.DeletedCount > 0;
        }
    }
}