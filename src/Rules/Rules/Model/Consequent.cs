namespace Odusseus.Rules.Model
{
    using Odusseus.Rules.Model.Enumeration;

    public class Consequent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public Answer Answer { get; set; }

        public void Reset()
        {
            this.Answer = Answer.Unknown;
        }
    }
}