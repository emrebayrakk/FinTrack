using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FinTrack.Data.Entities
{
    public class BorsaHisse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Kod { get; set; } = default!;
        public string Ad { get; set; } = default!;
        public string Tip { get; set; } = default!;
    }
}
