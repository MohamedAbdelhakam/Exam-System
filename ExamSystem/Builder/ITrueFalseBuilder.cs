using Exam02_Route.Data.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02_Route.Builder
{
    public interface ITrueFalseBuilder
    {

        ITrueFalseBuilder SetId(string id);
        ITrueFalseBuilder SetHeader(string header);
        ITrueFalseBuilder SetBody(string body);
        ITrueFalseBuilder SetMark(float mark);
        ITrueFalseBuilder SetAnswer(bool CorrectAnswer);
        IQuestion Build();
    }
}
