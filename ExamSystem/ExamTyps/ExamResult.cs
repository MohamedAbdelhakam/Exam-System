namespace Exam02_Route.ExamTyps
{
    public class ExamResult
    {
        private float _studentMark = 0;
        public float GetResult(IExam exam)
        {
            _studentMark = 0;
            var QuestionCount = exam.Questions.Count;
            for (int i = 0; i < QuestionCount ; i++)
            {
                if (exam.Questions[i].IsCorrectAnswer(exam.Answers[i]))
                {
                    _studentMark += exam.Questions[i].Mark;
                }
            }
            return _studentMark;
        }
    }
}
