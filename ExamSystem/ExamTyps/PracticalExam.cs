using System.Collections.Generic;
using Exam02_Route.Data;
using Exam02_Route.Data.Answer;
using Exam02_Route.Data.Question;

namespace Exam02_Route.ExamTyps
{
    public class PracticalExam : IExam
    {
        public PracticalExam()
        {
            
            Questions = new List<IQuestion>();
            Answers = new List<IAnswer>();
        }
        public PracticalExam(List<IQuestion> questions)
        {
            Questions=questions;
            Answers = new List<IAnswer>();

        }
        public List<IQuestion> Questions { get; set; }
        public List<IAnswer> Answers { get; set; }
        public float TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public Subject Subject { get; set;}
        public float TotalMark { get; set; }

        public List<IAnswer> GetCorrectAnswers()
        {
            var answers = new List<IAnswer>();
                foreach (var Question in Questions) 
                {
                    IAnswer Answer = null;
                    if (Question is McqQuestion mcqQuestion)
                    {
                        Answer= new McqAnswer 
                        {
                         QuestionId=mcqQuestion.Id,
                         OptionNumber=mcqQuestion.CorrectOptionNumper
                        ,TimeOfSolve=DateTime.MinValue
                        };//handel Time later on 
                    }
                    else if (Question is TrueFalseQuestion TrueFalseQuestion) 
                    {
                        Answer = new TrueFalseAnswer
                        {
                            QuestionId = TrueFalseQuestion.Id,
                            Answer = TrueFalseQuestion.CorrectAnswer,
                            TimeOfSolve=DateTime.MinValue
                        };//handel Time Later On     
                    }
                    Answers.Add(Answer);
                }
            return answers;
        }
    }
}
