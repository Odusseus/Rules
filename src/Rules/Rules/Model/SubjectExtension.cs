namespace Odusseus.Rules.Model.Enumeration
{
    using System.Collections.Generic;

    public static class SubjectExtension
    {
        public static Dictionary<string, Answer> Reset(this Dictionary<string, Answer> answers)
        {
            var newAnswers = new Dictionary<string, Answer>();

            foreach (var key in answers.Keys)
            {
                newAnswers.Add(key, Answer.Unknown);
            }

            return newAnswers;
        }

    }
}
