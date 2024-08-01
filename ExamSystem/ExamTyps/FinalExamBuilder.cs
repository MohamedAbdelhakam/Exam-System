using Exam02_Route.Data.Question;
using Exam02_Route.Data;
using Exam02_Route.ExamTyps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.ExamTyps
{
    public class FinalExamBuilder : IExamBuilder
    {
        private FinalExam _exam;
        public FinalExamBuilder()
        {
            _exam = new FinalExam();
        }
        public IExamBuilder SetNumberOfQuestions(int numberOfQuestions)
        {
            _exam.NumberOfQuestions = numberOfQuestions;
            return this;
        }

        public IExamBuilder SetQuestions(List<IQuestion> questions)
        {
            _exam.Questions = questions;
            return this;
        }

        public IExamBuilder SetSubject(Subject subject)
        {

            _exam.Subject = subject;
            return this;
        }

        public IExamBuilder SetTime(float Minutes)
        {
            _exam.TimeOfExam = Minutes;
            return this;
        }

        IExamBuilder IExamBuilder.SetTotalMark(float Mark)
        {
            _exam.TotalMark = Mark;
            return this;
        }
        IExam IExamBuilder.Build()
        {
            return _exam;
        }

    }
}
