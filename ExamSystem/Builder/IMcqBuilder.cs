
using System.Collections.Generic;
using Exam02_Route.Data;
using Exam02_Route.Data.Question;

namespace Exam02_Route.Builder
{
    public interface IMcqBuilder
    {

        IMcqBuilder SetId(string id);
        IMcqBuilder SetHeader(string header);
        IMcqBuilder SetBody(string body);
        IMcqBuilder SetMark(float mark);
        IMcqBuilder SetOptions(List<string> options);
        IMcqBuilder SetCorrectOption(int correctOption);
        IQuestion Build();
    }
}
