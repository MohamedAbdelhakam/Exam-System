using System;
using System.Collections.Generic;
using Exam02_Route.Data;
using Exam02_Route.Builder;
using Exam02_Route.ExamTyps;
using Exam02_Route.Data.Answer;
using Exam02_Route.Data.Question;

using ExamSystem.Builder;
using ExamSystem.ExamTyps;

namespace ExamSystem
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.WriteLine("ExamSystem...");
            Console.Write("Please Enter Subject: ");
            var SubjectName = Console.ReadLine();
            Console.Write($"Enter Id of {SubjectName}: ");
            var SubjectId = Console.ReadLine();
            Console.Write("What Type Of Exam \n [1] Practical \n [2] Final\n: ");
            var ExamType = int.Parse(Console.ReadLine());

            Console.Write("What Time You Want in minutes: ");
            var ExamTime = float.Parse(Console.ReadLine());
            Console.Write("Enter Number of Questions: ");
            var NumberOfQuestions = int.Parse(Console.ReadLine());

            IExam Exam;
            List<IQuestion> questions = new List<IQuestion>();

            for (int i = 1; i <= NumberOfQuestions; i++)
            {
                Console.WriteLine($"[ Create Question {i} ]");
                Console.WriteLine("Type Of Questions Available...");
                Console.WriteLine("[1] True False ");
                Console.WriteLine("[2] MCQ ");
                Console.Write($"Type of Question {i} is: ");
                var TypeOfQuestion = int.Parse(Console.ReadLine());

                Console.Write("Enter Id Of Question: ");
                var Id = Console.ReadLine();
                Console.Write("Enter Header of Question: ");
                var Header = Console.ReadLine();
                Console.Write("Enter Body of Question: ");
                var Body = Console.ReadLine();
                Console.Write("Enter Mark Of Question: ");
                var Mark = float.Parse(Console.ReadLine());

                if (TypeOfQuestion == 1) //TF
                {
                    Console.Write("Is Answer [1]True [2] False: ");
                    var AnswerType = int.Parse(Console.ReadLine());
                    bool Answer;
                    if (AnswerType == 1) { Answer = true; }
                    else { Answer = false; }
                    var QuestionBuilder = new TrueFalseQuestionBuilder().SetId(Id)
                        .SetHeader(Header)
                        .SetHeader(Body).
                        SetMark(Mark).
                        SetAnswer(Answer);
                    var Question = QuestionBuilder.Build() as TrueFalseQuestion;
                    questions?.Add(Question);

                }
                else if (TypeOfQuestion == 2)//MCQ
                {
                    Console.Write("What Number of Options: ");
                    var NumberOfOptions = int.Parse(Console.ReadLine());
                    var options = new List<string>();
                    for (int j = 1; j <= NumberOfOptions; j++)
                    {
                        Console.Write($"Enter Option {j}: ");
                        var option = Console.ReadLine();
                        options.Add(option);
                    }
                    Console.Write("What is Correct Option Number: ");
                    var CorrectOptionNumber = int.Parse(Console.ReadLine());

                    var QuestionBuilder = new McqQuestionBuilder().SetId(Id)
                    .SetHeader(Header)
                    .SetHeader(Body).
                    SetMark(Mark).SetOptions(options).
                    SetCorrectOption(CorrectOptionNumber);

                    var Question = QuestionBuilder.Build() as McqQuestion;
                    questions?.Add(Question);
                }
            }
            float totalExamMark = 0;
            foreach (var Question in questions)
            {
                totalExamMark += Question.Mark;
            }
            if (ExamType == 1)//practical
            {
                var ExamBuilder = new PracticalExamBuilder().SetTime(ExamTime).
                    SetNumberOfQuestions(NumberOfQuestions).SetQuestions(questions).SetTotalMark(totalExamMark).
                    SetSubject(new Subject { Id = SubjectId, SubjectName = SubjectName });
                Exam = ExamBuilder.Build() as PracticalExam;

            }
            else if (ExamType == 2)//Final
            {
                var ExamBuilder = new FinalExamBuilder().SetTime(ExamTime).
                SetNumberOfQuestions(NumberOfQuestions).SetQuestions(questions).SetTotalMark(totalExamMark).
                SetSubject(new Subject { Id = SubjectId, SubjectName = SubjectName });
                Exam = ExamBuilder.Build() as FinalExam;
            }
            else
            {
                Exam = null;
            }
            Console.Clear();
            Console.WriteLine("Exam System...");
            Console.WriteLine("press Any key to start Exam: ");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Exam System...");
            foreach (var Q in Exam.Questions)
            {
                Console.WriteLine(Q);
                if (Q is TrueFalseQuestion)
                {
                    Console.WriteLine("what is your Answer [1]True 2[False]:");
                    var choice = int.Parse(Console.ReadLine());
                    bool Answer;
                    if (choice == 1)
                    {
                        Answer = true;
                    }
                    else
                    {
                        Answer = false;
                    }
                    Exam.Answers.Add(new TrueFalseAnswer { QuestionId = Q.Id, TimeOfSolve = DateTime.Now, Answer = Answer });
                }
                else if (Q is McqQuestion)
                {
                    Console.WriteLine("What is Your Chosen option number : ");
                    var option = int.Parse(Console.ReadLine());
                    Exam.Answers.Add(new McqAnswer { QuestionId = Q.Id, TimeOfSolve = DateTime.Now, OptionNumber = option });
                }
            }
            if (Exam is PracticalExam practicalExam) 
            {
                Console.Clear();
                Console.WriteLine("Your Answers...");
                Thread.Sleep(300);

                var Answers =practicalExam.GetCorrectAnswers();
                var result = new ExamResult();
                var StudentMark = result.GetResult(Exam);
                foreach (var answer in Answers) 
                {
                    Console.WriteLine(answer);
                }
                Console.WriteLine($"Your Total Mark is {StudentMark}");
            }
            else if (Exam is FinalExam Final)
            {
                Console.Clear();
                Console.WriteLine("Your Answers...");
                Thread.Sleep(300);

                var Answers = Final.GetCorrectAnswers();
                var result = new ExamResult();
                var StudentMark = result.GetResult(Exam);
                foreach (var answer in Answers)
                {
                    Console.WriteLine(answer);
                }
                Console.WriteLine($"Your Total Mark is {StudentMark}");
            }
        }
    }
}