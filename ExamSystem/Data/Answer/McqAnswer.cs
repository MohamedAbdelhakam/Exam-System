namespace Exam02_Route.Data.Answer
{
    public class McqAnswer : IAnswer
    {
        public string QuestionId { get; set; }
        public DateTime TimeOfSolve { get; set; }
        public int OptionNumber { get; set; }
        public override string ToString()
        {
            return $"Question Id :{QuestionId} ... Time of solve[{TimeOfSolve}] \n Correct OPtion Number :{OptionNumber}";
        }
    }
}
