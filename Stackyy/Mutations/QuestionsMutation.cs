using Stackyy.Entities;
using Stackyy.Repositories;

namespace Stackyy.Mutations
{
    [ExtendObjectType("Mutation")]
    public class QuestionsMutation
    {
        private readonly QuestionsRepository _repository;
        public QuestionsMutation(QuestionsRepository repository)
        {
            _repository = repository;
        }

        [GraphQLDescription("Add a new question")]
        public Questions AddQuestion(Questions question)
        {
            return _repository.AddQuestion(question);
        }
        [GraphQLDescription("Updating the question")]
        public Questions UpdateQuestion(string id, Questions updatequestion)
        {
            return _repository.UpdateQuestion(id, updatequestion);
        }
        public bool DeleteQuestionById(string id)
        {
            return _repository.DeleteQuestionById(id);
        }

        [GraphQLDescription("Add a new answer")]
        public Answers AddAnswer(Answers answer)
        {
            return _repository.AddAnswer(answer);
        }
        [GraphQLDescription("Updating the answer")]
        public Answers UpdateAnswer(string id, Answers updateanswer)
        {
            return _repository.UpdateAnswer(id, updateanswer);
        }
        public bool DeleteAnswerById(string id)
        {
            return _repository.DeleteAnswerById(id);
        }
    }
}
