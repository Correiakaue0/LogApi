using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LogApi.Models
{
    public class Log
    {
        public Log(string processName, string message, string details)
        {
            ProcessName = processName;
            Timestamp = DateTime.Now;
            Message = message;
            Details = details;
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