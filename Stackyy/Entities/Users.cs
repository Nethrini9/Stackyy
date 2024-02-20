using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Stackyy.Entities
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }
        public string? RoleId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Profile? UserProfile { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime LastSeen { get; set; }
        public string? Location { get; set; }
    }

    public class Profile
    {
        [BsonElement("Image")]
        public string? Image { get; set; }

        [BsonElement("Bio")]
        public string? Bio { get; set; }
    }
}
