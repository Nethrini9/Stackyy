using MongoDB.Driver;
using Stackyy.Entities;

namespace Stackyy.Repositories
{
    public class QuestionsRepository
    {
        private readonly IMongoCollection<Questions> _questionsCollection;
        private readonly IMongoCollection<Answers> _answersCollection;
        public QuestionsRepository(DataBaseService service)
        {
            _questionsCollection = service.GetCollection<Questions>("Questions");
            _answersCollection = service.GetCollection<Answers>("Answers");
        }

        public IEnumerable<Questions> GetAllQuestions()
        {
            return _questionsCollection.Find(x => true).ToList();
        }

        public Questions GetQuestionById(string id)
        { 
            return _questionsCollection.Find(x=>x.QuestionId == id).FirstOrDefault();    
        }
        public Questions AddQuestion(Questions question)
        {
            var questions = new Questions
            {
                UserId = question.UserId,
                QuestionTitle = question.QuestionTitle,
                QuestionDescription = question.QuestionDescription,
                QuestionCreatedDate = DateTime.Now,
                UpVotes = 0,
                DownVotes = 0,
               Comments=question.Comments
            };
            _questionsCollection.InsertOne(questions);
            return question;
        }

        public Questions UpdateQuestion(string id, Questions updatequestion)
        {
            Questions updatedquestion = _questionsCollection.Find(x => x.QuestionId == id).FirstOrDefault();
            updatedquestion.QuestionId = id;
            updatedquestion.QuestionEditedDate = DateTime.Now;
            updatedquestion.Comments = updatequestion.Comments; 
            updatedquestion.QuestionTitle = updatequestion.QuestionTitle;
            updatedquestion.QuestionDescription = updatequestion.QuestionDescription;
            updatedquestion.UpVotes = updatequestion.UpVotes == 1 ? ++updatedquestion.UpVotes : updatedquestion.UpVotes;
            updatedquestion.DownVotes = updatequestion.DownVotes == 1 ? ++updatedquestion.DownVotes : updatedquestion.DownVotes;
            _questionsCollection.ReplaceOne(x => x.QuestionId== id, updatedquestion);
            return updatedquestion;
        }
        public bool DeleteQuestionById(string id)
        {
            var result = _questionsCollection.DeleteOne(x => x.QuestionId == id);
            return result.DeletedCount > 0;
        }
        public IEnumerable<Answers> GetAllAnswers()
        {
            return _answersCollection.Find(x=>true).ToList();
        }
        public Answers GetAnswerById(string id)
        {
            return _answersCollection.Find(x=>x.AnswerId== id).FirstOrDefault();   
        }
        public List<Answers> GetAnswerByQuestionId(string questionid)
        {
            return _answersCollection.Find(x=>x.QuestionId== questionid).ToList();  
        }
        public Answers AddAnswer(Answers answer)
        {
            var answers = new Answers
            {
                QuestionId=answer.QuestionId,
                UserId=answer.UserId,   
                Answer=answer.Answer,
                AnswerCreatedDate=DateTime.Now, 
                Comments=answer.Comments,
                UpVotes=0,
                DownVotes=0
            };
            _answersCollection.InsertOne(answers);  
            return answers;
        }
        public Answers UpdateAnswer(string id, Answers updateanswer)
        {
            Answers updatedanswer=_answersCollection.Find(x => x.AnswerId == id).FirstOrDefault();
            updatedanswer.AnswerId = id;
            var answer = updatedanswer?.Answer??"";
            if(updatedanswer!=null)
            {
                if (!answer.Equals(updateanswer.Answer))
                {
                    updatedanswer.AsnwerUpdatedDate = DateTime.Now;
                }
                updatedanswer.UpVotes = updateanswer.UpVotes == 1 ? ++updatedanswer.UpVotes : updatedanswer.UpVotes;
                updatedanswer.DownVotes = updateanswer.DownVotes == 1 ? ++updatedanswer.DownVotes : updatedanswer.DownVotes;
                updatedanswer.Answer = updateanswer.Answer;
                updateanswer.Comments=updateanswer.Comments;
                _answersCollection.ReplaceOne(x => x.AnswerId == id, updatedanswer);
            }
            return updateanswer;
        }
        public bool DeleteAnswerById(string id)
        {
            var result = _answersCollection.DeleteOne(x => x.AnswerId == id);
            return result.DeletedCount > 0;
        }
    }
}
