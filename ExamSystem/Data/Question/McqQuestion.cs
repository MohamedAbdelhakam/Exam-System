
using System.Collections.Generic;
using Exam02_Route.Data.Answer;

namespace Exam02_Route.Data.Question
{
    public class McqQuestion : IQuestion
    {
        public List<string> Options { get; set; }
        public int CorrectOptionNumper { get; set; }
        public string Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public float Mark { get; set; }

        Type IQuestion.AnswerType => typeof(McqAnswer);

        public bool IsCorrectAnswer(IAnswer answer)
        {
            return answer is McqAnswer mcqAnswer && mcqAnswer.OptionNumber == CorrectOptionNumper;
        }
        public override string ToString()
        {
            var options = Options.Aggregate((x,y)=>x+"\n"+y);
            return $"{Header} Mark [{Mark}]\n" +
                $"Question Body:{Body}\n{options}";
        }
    }
}
