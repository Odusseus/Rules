namespace Odusseus.Rules.Model
{
    using System.Collections.Generic;
    using Enumeration;

    public class Facts
    {
        public string Name { get; set; }
        public List<Fact> Rows = new List<Fact>();

        public Fact GetFact(string name)
        {
            return this.Rows.Find(r => r.Name == name);
        }

        public List<Fact> GetFactsByAnswer(Answer answer)
        {
            List<Fact> facts = this.Rows.FindAll(r => r.Answer == answer);

            return facts;
        }

        public int SetAnswer(string name, Answer answer)
        {
            int set = 0;

            List<Fact> facts = this.Rows.FindAll(r => r.Name == name);
            foreach(Fact fact in facts)
            {
                set++;
                fact.Answer = answer;
            }

            return set;
        }
    }
}
