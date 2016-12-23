namespace Odusseus.Rules.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Odusseus.Rules.Model.Enumeration;
    using System.Text.RegularExpressions;

    public class Rule : IOperation
    {
        private string logic;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Logic {
            get
            {
                return this.logic;
            }
            set
            {
                this.logic = Format(value);
            }
        }

        internal static string Format(string value)
        {
            foreach(OperatorSymbole symbole in Enum.GetValues(typeof(OperatorSymbole)).Cast<OperatorSymbole>())
            {
                if(symbole.getCode() != string.Empty)
                {
                    value = value.Replace(symbole.getCode(), $" {symbole.getCode()} ");
                }
            }

            value = Regex.Replace(value, @"\s+", " ");

            value = value.Trim();

            return value;
        }

        public Conditions Conditions { get; set; }
        public Consequent Consequent { get; set; }
        public List<string> Messages = new List<string>();

        public void ConvertLogicToConditions(OperatorElements operatorElements, Rules rules, Facts facts)
        {
            string[] elements = this.Logic.Split();

            if(this.Conditions == null)
            {
                this.Conditions = new Conditions();
            }

            int id = 0;
            int OrderId = 0;

            foreach (string element in elements)
            {
                    IOperation operation = facts?.Rows.FirstOrDefault<Fact>(x => x.Name == element) as IOperation;

                    if (operation == null)
                    {
                        operation = rules?.Rows.FirstOrDefault<Rule>(x => x.Name == element) as IOperation;
                    }

                    if (operation == null)
                    {
                        operation = operatorElements.Rows.FirstOrDefault<OperatorElement>(x => x.Symbole == element.getOperatorSymbole()) as IOperation;
                    }

                    if (operation == null)
                    {
                        Messages.Add($"Fact {element} is not found.");
                    }
                    else
                    {
                        Condition condition = new Condition
                        {
                            Id = id++,
                            OrderId = OrderId++,
                            Operation = operation
                        };

                        this.Conditions.Rows.Add(condition);
                    }
                }
        }

        public void Reset()
        {
            this.Conditions.Reset();
            this.Consequent.Reset();
        }

        public override string ToString()
        {
            return $"Rule {this.Name} Answer = {this.Consequent.Answer.ToString()}";
        }
    }
}

