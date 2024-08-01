
using System;

namespace Exam02_Route.Data.Answer
{
    public interface IAnswer
    {
        public string QuestionId { get; set; }
        public DateTime TimeOfSolve { get; set; }
    }
}
