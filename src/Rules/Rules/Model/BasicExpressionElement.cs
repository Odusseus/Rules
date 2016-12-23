namespace Odusseus.Rules.Model
{
    using Odusseus.Rules.Model.Enumeration;

    public class BasicExpressionElement
    {
        private OperatorSymbole element = OperatorSymbole.New;

        public OperatorSymbole Element
        {
            get
            {
                return this.element;
            }
            set
            {
                this.element = value;
            }
        }

        public virtual OperatorSymbole EndValue
        {
            get
            {
                return this.Element;
            }

            set
            {
                this.Element = value;
            }
        }

        public virtual bool IsNew()
        {
            if (this.Element == OperatorSymbole.New)
            {
                return true;
            }

            return false;
        }

        public virtual bool IsDoNotKnow()
        {
            if (this.Element == OperatorSymbole.DoNotKnow)
            {
                return true;
            }

            return false;
        }

        public virtual bool IsUndefined()
        {
            if (this.Element == OperatorSymbole.Undefined)
            {
                return true;
            }

            return false;
        }
        public bool IsTrueOrFalse()
        {
            if (this.Element.IsTrue()
                || this.Element.IsFalse())
            {
                return true;
            }

            return false;
        }
    }
}
