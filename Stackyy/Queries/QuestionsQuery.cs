using Stackyy.Entities;
using Stackyy.Repositories;

namespace Stackyy.Queries
{
    [ExtendObjectType("Query")]
    public class QuestionsQuery
    {
        private readonly QuestionsRepository _questionsRepository; 
        public QuestionsQuery(QuestionsRepository questionsRepository) 
        {
            _questionsRepository = questionsRepository;
        } 
        public IEnumerable<Questions> GetQuestions()
        {
            return _questionsRepository.GetAllQuestions();
        }
        public Questions GetQuestionById(string id) 
        {
            return _questionsRepository.GetQuestionById(id);
        }
        public IEnumerable<Answers> GetAnswers()
        {
            return _questionsRepository.GetAllAnswers();
        }
        public Answers GetAnswerById(string id)
        {
            return _questionsRepository.GetAnswerById(id);
        }
        public List<Answers> GetAnswerByQuestionId(string questionid)
        {
            return _questionsRepository.GetAnswerByQuestionId(questionid);
        }
    }
}
