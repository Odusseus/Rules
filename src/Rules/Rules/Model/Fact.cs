namespace Odusseus.Rules.Model
{
    using System;
    using Odusseus.Rules.Model.Enumeration;

    public class Fact : IOperation
    {
        private static int MaxId { get; set; }

        private int id;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if(value == 0)
                {
                    MaxId++;
                    this.id = MaxId;
                }
                else if (value < MaxId)
                {
                    MaxId = value;
                    this.id = value;
                }
                else
                {
                    this.id = value;
                }
            }
        }

        public string Name { get; set; }
        public string Question { get; set; }
        public Answer Answer { get; set; }

        public Fact()
        {
            this.Id = 0;
        }

        public static int ResetMaxId()
        {
            MaxId = 0;
            return MaxId;
        }

        public void Reset()
        {
            this.Answer = Answer.Unknown;
        }

        public override string ToString()
        {
            return $"Fact {this.Name} Answer = {this.Answer.GetCode()}";
        }
    }
}
