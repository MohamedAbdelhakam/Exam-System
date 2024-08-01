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
        public interface IExamBuilder
        {
            IExamBuilder SetQuestions(List<IQuestion> questions);
            IExamBuilder SetTime(float Minutes);
            IExamBuilder SetSubject(Subject subject);
            IExamBuilder SetNumberOfQuestions(int numberOfQuestions);
            IExamBuilder SetTotalMark(float Mark);
            IExam Build();
        }
}
