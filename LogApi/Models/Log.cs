using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LogApi.Models
{
    public class Log
    {
        public Log()
        {
            ProcessName = string.Empty;
            Timestamp = new DateTime();
            Message = string.Empty;
            Details = string.Empty;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ProcessName { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}