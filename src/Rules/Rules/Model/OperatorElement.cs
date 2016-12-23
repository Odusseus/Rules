namespace Odusseus.Rules.Model
{
    using Odusseus.Rules.Model.Enumeration;

    public class OperatorElement : IOperation
    {
        public int Id { get; set; }
        public OperatorSymbole Symbole { get; set; }

        public override string ToString()
        {
            return $"Operator {this.Symbole.getCode()}";
        }
    }
}
