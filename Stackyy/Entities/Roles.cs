using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Stackyy.Entities
{
    public class Roles
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? RoleId { get; set; }
        public string? RoleType { get; set; }
    }
}