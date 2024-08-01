
using System.Collections.Generic;
using Exam02_Route.Data.Question;

namespace Exam02_Route.Builder
{
    public class McqQuestionBuilder : IMcqBuilder
    {
        private McqQuestion _question;
        public McqQuestionBuilder()
        {
            _question = new McqQuestion();
        }
        public IMcqBuilder SetBody(string body)
        {
            _question.Body = body;
            return this;
        }
        public IMcqBuilder SetHeader(string header)
        {
            _question.Header = header;
            return this;
        }

        public IMcqBuilder SetId(string id)
        {
            _question.Id = id;
            return this;
        }

        public IMcqBuilder SetMark(float mark)
        {
            _question.Mark = mark;
            return this;
        }

        public IMcqBuilder SetOptions(List<string> options)
        {
            _question.Options =new List<string>(options);
            return this;
        }
        public IMcqBuilder SetCorrectOption(int correctOption)
        {
            _question.CorrectOptionNumper = correctOption;
            return this;
        }
        public IQuestion Build()
        {
            return _question;
        }
    }
}
