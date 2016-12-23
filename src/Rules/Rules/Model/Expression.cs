namespace Odusseus.Rules.Model
{
    using System;
    using Odusseus.Rules.Model.Enumeration;

    public class Expression
    {
        public ExpressionElement Left;

        public BasicExpressionElement OperatorElement;

        public ExpressionElement Right;

        public BasicExpressionElement Result;

        public Expression()
        {
            this.Left = new ExpressionElement();

            this.OperatorElement = new BasicExpressionElement();

            this.Right = new ExpressionElement();

            this.Result = new BasicExpressionElement();
        }

        public Expression(ExpressionElement left,
                          BasicExpressionElement operatorElement,
                          ExpressionElement right)
        {
            this.Left = left;

            this.OperatorElement = operatorElement;

            this.Right = right;

            this.Result = new ExpressionElement();
    }


        public bool IsNew()
        {
            if (!Left.IsNew()
                || !OperatorElement.IsNew()
                || !Right.IsNew()
                || !Result.IsNew())
            {
                return false;
            }

            return true;
        }

        internal void setOperatorElement(OperatorElement operatorElement)
        {
            if (operatorElement.Symbole == OperatorSymbole.New)
            {
                return;
            }

            if (operatorElement.Symbole == OperatorSymbole.Not)
            {
                if (this.Left.IsNew())
                {
                    this.Left.Not = OperatorSymbole.True;
                }
                else
                {
                    if (this.Left.Element == OperatorSymbole.New)
                    {
                        this.Left.Not = OperatorSymbole.True;
                    }
                    else
                    {
                        if (this.Right.IsNew())
                        {
                            this.Right.Not = OperatorSymbole.True;
                        }
                        else
                        {
                            if (this.Right.Element == OperatorSymbole.New)
                            {
                                this.Right.Not = OperatorSymbole.True;
                            }
                            else
                            {
                                throw new Exception("Not is al set.");
                            }
                        }
                    }
                }
            }
            else if (operatorElement.Symbole == OperatorSymbole.And
                     || operatorElement.Symbole == OperatorSymbole.Or)
            {
                if (this.OperatorElement.Element == OperatorSymbole.New)
                {
                    this.OperatorElement.Element = operatorElement.Symbole;
                }
                else
                {
                    throw new Exception("Operator is al set.");
                }
            }
            else if (operatorElement.Symbole == OperatorSymbole.True
                || operatorElement.Symbole == OperatorSymbole.False
                || operatorElement.Symbole == OperatorSymbole.DoNotKnow
                || operatorElement.Symbole == OperatorSymbole.Undefined)
            {
                if (this.Left.Element == OperatorSymbole.New)
                {
                    this.Left.Element = operatorElement.Symbole;
                }
                else if (this.Right.Element == OperatorSymbole.New)
                {
                    this.Right.Element = operatorElement.Symbole;
                }
                else
                {
                    throw new Exception("elements left and right are al set.");
                }
            }
            else if (operatorElement.Symbole == OperatorSymbole.Leftparentheses)
            {
                if (this.Left.Element == OperatorSymbole.New)
                {
                    this.Left.Element = operatorElement.Symbole;
                }
                else
                {
                    throw new Exception("element left is al set.");
                }
            }
            else if (operatorElement.Symbole == OperatorSymbole.Rightparentheses)
            {
                if (this.Right.Element == OperatorSymbole.New)
                {
                    this.Right.Element = operatorElement.Symbole;
                }
                else
                {
                    throw new Exception("element right is al set.");
                }
            }
            else
            {
                throw new Exception("element is al set.");
            }
        }

        internal void Evaluate()
        {
            if(this.OperatorElement.Element == OperatorSymbole.And)
            {
                if(this.Left.EndValue.IsTrue()
                   && this.Right.EndValue.IsTrue())
                {
                    this.Result.Element = OperatorSymbole.True;
                }
                else
                {
                    if (this.Left.IsTrueOrFalse()
                        && this.Right.IsTrueOrFalse())
                    {
                        this.Result.Element = OperatorSymbole.False;
                    }
                    else
                    {
                        if (this.Left.IsDoNotKnow())
                        {
                            this.Result.Element = OperatorSymbole.DoNotKnow;
                        }
                        else
                        {
                            if (this.Left.Element == OperatorSymbole.Undefined)
                            {
                                 this.Result.Element = OperatorSymbole.Undefined;
                            }
                            else
                            {
                               if (this.Left.IsTrueOrFalse()
                                   && this.Right.IsDoNotKnow())
                                {
                                    this.Result.Element = OperatorSymbole.DoNotKnow;
                                } 
                               else
                                {
                                    if (this.Left.IsTrueOrFalse()
                                        && this.Right.Element == OperatorSymbole.Undefined)
                                        {
                                            this.Result.Element = OperatorSymbole.Undefined;
                                        }
                                }
                            }
                        }
                    }
                }
            }
            else if(this.OperatorElement.Element == OperatorSymbole.Or)
            {
                if ((this.Left.EndValue.IsTrue()
                     || this.Right.EndValue.IsTrue())
                    && (this.Left.IsTrueOrFalse()
                        || this.Left.IsDoNotKnow()
                        || this.Left.Element == OperatorSymbole.Undefined)
                        && (this.Right.IsTrueOrFalse()
                        || this.Right.IsDoNotKnow()
                        || this.Right.Element == OperatorSymbole.Undefined))
                {
                    this.Result.Element = OperatorSymbole.True;
                }
                else
                {
                    if(this.Left.IsDoNotKnow()
                        && this.Right.IsDoNotKnow())
                    {
                        this.Result.Element = OperatorSymbole.DoNotKnow;
                    }
                    else
                    {
                            if (this.Left.Element == OperatorSymbole.Undefined
                                && this.Right.Element == OperatorSymbole.Undefined)
                            {
                                this.Result.Element = OperatorSymbole.Undefined;
                            }
                            else
                            {
                                if (this.Left.EndValue.IsFalse()
                                   && this.Right.EndValue.IsFalse())
                                {
                                    this.Result.Element = OperatorSymbole.False;
                                }

                            }
                    }
                }
            }
        }

        internal void EndEvaluate()
        {
            if (this.Result.IsNew()
                && !this.Left.IsNew()
                && this.Right.IsNew())
            {
                this.Result.Element = this.Left.EndValue;
            }
        }
        }
}
