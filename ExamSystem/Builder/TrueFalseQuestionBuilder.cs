using Exam02_Route.Builder;
using Exam02_Route.Data.Question;

namespace ExamSystem.Builder
{
    public class TrueFalseQuestionBuilder : ITrueFalseBuilder
    {
        private TrueFalseQuestion _question;
        public TrueFalseQuestionBuilder()
        {
            _question = new TrueFalseQuestion();
        }
        public ITrueFalseBuilder SetBody(string body)
        {
            _question.Body = body;
            return this;
        }

        public ITrueFalseBuilder SetHeader(string header)
        {
            _question.Header = header;
            return this;
        }

        public ITrueFalseBuilder SetId(string id)
        {
            _question.Id = id;
            return this;
        }

        public ITrueFalseBuilder SetMark(float mark)
        {
            _question.Mark = mark;
            return this;
        }


        public ITrueFalseBuilder SetAnswer(bool Answer)
        {
            _question.CorrectAnswer = Answer;
            return this;
        }
        public IQuestion Build()
        {
            return _question;
        }
    }
}
