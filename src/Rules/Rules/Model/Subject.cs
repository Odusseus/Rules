namespace Odusseus.Rules.Model
{
    using System.Collections.Generic;
    using Odusseus.Rules.Model.Enumeration;

    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        public Dictionary<string, Answer> Answers { get; set; }

        public Facts Facts { get; set; }
        public Rules Rules { get; set; }

    }
}
