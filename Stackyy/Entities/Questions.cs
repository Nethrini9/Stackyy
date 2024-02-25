using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Stackyy.Entities
{
    public class Questions
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? QuestionId { get; set; }
        public string? UserId { get; set; }
        public string? QuestionTitle { get; set; }
        public string? QuestionDescription { get; set; }
        public DateTime? QuestionCreatedDate { get; set; }
        public DateTime? QuestionEditedDate { get; set; }
        public int? UpVotes { get; set; }
        public int? DownVotes { get; set;}
        public string? Comments { get; set; }
        //public List<Answers>? Answers { get; set; }
    }
    public class Answers
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? AnswerId { get; set; }
        public string? UserId { get; set; }
        public string? QuestionId { get; set; }
        public string? Answer { get; set; }
        public DateTime? AnswerCreatedDate { get; set; }
        public DateTime? AsnwerUpdatedDate { get; set; }
        public int? UpVotes { get; set; }
        public int? DownVotes { get; set; }
        public string? Comments { get; set; }
    }
}
