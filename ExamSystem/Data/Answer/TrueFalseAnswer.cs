namespace Exam02_Route.Data.Answer
{
    public class TrueFalseAnswer : IAnswer
    {
        public string QuestionId { get; set; }
        public DateTime TimeOfSolve { get; set; }
        public bool Answer { get; set; }
        public override string ToString()
        {
            return $"Question Id :{QuestionId} ... Time of solve[{TimeOfSolve}] \n Correct Answer :{Answer}";
        }
    }
}
