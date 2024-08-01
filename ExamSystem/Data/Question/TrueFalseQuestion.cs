using Exam02_Route.Data.Answer;

namespace Exam02_Route.Data.Question
{
    public class TrueFalseQuestion : IQuestion
    {
        public bool CorrectAnswer { get; set; }
        public string Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public float Mark { get; set; }

        Type IQuestion.AnswerType =>typeof(TrueFalseAnswer);

        public bool IsCorrectAnswer(IAnswer answer)
        {
            return answer is TrueFalseAnswer TFAnswer && TFAnswer.Answer == CorrectAnswer;
        }
        public override string ToString()
        {
            return $"{Header} Mark: [{Mark}] {Body}\n [True] \n [False]";
        }
    }
}
