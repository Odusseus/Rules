namespace Odusseus.Rules.Model
{
    using Odusseus.Rules.Model.Enumeration;

    public class ExpressionElement: BasicExpressionElement
    {
        private OperatorSymbole not = OperatorSymbole.New;
        
        public OperatorSymbole Not
        {
            get
            {
                return this.not;
            }
            set
            {
                if (value == OperatorSymbole.True)
                {
                    if(this.not == OperatorSymbole.True)
                    {
                        this.not = OperatorSymbole.False;
                    }
                    else
                    {
                        this.not = OperatorSymbole.True;
                    }
                }
                else
                {
                    this.not = value;
                }
            }
        }

        public override OperatorSymbole EndValue
        {
            get
            {
                if (this.Element.IsTrue())
                {
                    if (this.Not.IsTrue())
                    {
                        return OperatorSymbole.False;
                    }
                    else
                    {
                        return OperatorSymbole.True;
                    }
                }
                else if (this.Element.IsFalse())
                {
                    if (this.Not.IsTrue())
                    {
                        return OperatorSymbole.True;
                    }
                    else
                    {
                        return OperatorSymbole.False;
                    }
                }

                return this.Element;
            }
        }

        public override bool IsNew()
        {
            if (this.Not == OperatorSymbole.New
                && this.Element == OperatorSymbole.New)
            {
                return true;
            }

            return false;
        }
    }
}
