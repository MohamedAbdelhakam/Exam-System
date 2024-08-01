using Exam02_Route.Data.Answer;

namespace Exam02_Route.Data.Question
{
    public interface IQuestion
    {
        public string Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public float Mark { get; set; }
        public Type AnswerType { get; }
        public bool IsCorrectAnswer(IAnswer answer);
    }
}