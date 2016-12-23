namespace Odusseus.Rules.Model
{
    using System.Collections.Generic;

    public class Conditions
    {
        public List<Condition> Rows = new List<Condition>();

        public void Reset()
        {
            this.Rows = new List<Condition>();
        }
    }
}