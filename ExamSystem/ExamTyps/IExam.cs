
using System.Collections.Generic;
using Exam02_Route.Data;
using Exam02_Route.Data.Answer;
using Exam02_Route.Data.Question;

namespace Exam02_Route.ExamTyps
{
    public interface IExam
    {
        public List<IQuestion> Questions { get; set; }
        public List<IAnswer> Answers { get; set; }
        public float TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public Subject Subject { get; set; }
        public float TotalMark { get; set; }
        public List<IAnswer> GetCorrectAnswers();
    }
}
