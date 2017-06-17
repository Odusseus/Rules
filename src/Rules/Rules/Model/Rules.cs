namespace Odusseus.Rules.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enumeration;

    public class Rules
    {
        public List<Rule> Rows = new List<Rule>();

        public Rule GetRule(string name)
        {
            return this.Rows.FirstOrDefault<Rule>(r => r.Name.Equals(name));
        }

        public List<Rule> GetRulesByAnswer(Answer answer)
        {
            List<Rule> rules = this.Rows.FindAll(r => r.Answer == answer);

            return rules;
        }

        public void Reset()
        {
            foreach (Rule rule in Rows)
            {
                rule.Reset();
            }
        }

        public int SetAnswer(string name, Answer answer)
        {
            int set = 0;

            List<Rule> rules = this.Rows.FindAll(r => r.Name == name);
            foreach(Rule rule in rules)
            {
                set++;
                rule.Answer = answer;
            }

            return set;
        }
    }
}
