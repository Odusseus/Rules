namespace Odusseus.Rules.Model
{
    using System;
    using System.Collections.Generic;
    using Odusseus.Rules.Model.Enumeration;

    public class Expressions
    {
        public List<Expression> Rows = new List<Expression>();
        public ExpressionElement Result = new ExpressionElement();

        internal void Evaluate()
        {
            //foreach(Expression expression in this.Rows)
            //{
            //    if (!expression.Left.IsNew()
            //        && expression.Right.IsNew()
            //        && expression.Result.IsNew())
            //    {
            //        expression.Result.Element = expression.Left.Value;
            //    }
            //}

            if (this.Rows.Count > 1)
            {
                bool isSimplified;

                do
                {
                    isSimplified = false;

                    while (this.SimplifyGroup())
                    {
                        isSimplified = true;
                    };

                    while (this.SimplifyNot())
                    {
                        isSimplified = true;
                    };

                    while (this.SimplifyOperator())
                    {
                        isSimplified = true;
                    };
                    
                    while (this.EvaluateRows())
                    {
                        isSimplified = true;
                    };

                    if( this.Rows.Count == 1)
                    {
                        isSimplified = false;
                    }
                } while (isSimplified);
            }

            if (this.Rows.Count == 1)
            {
                Rows[0].Evaluate();
                Result.Element = Rows[0].Result.EndValue;
            }
            else
            {

            }
        }

        internal bool SimplifyGroup()
        {
            bool isSimplified = false;
            List<Expression> newRows = new List<Expression>();

            for(int i = 0, j = 1, k = 2; i < Rows.Count; i++, j++, k++)
            {
                if(k < Rows.Count)
                {
                    if(Rows[i].Result.EndValue == OperatorSymbole.Leftparentheses
                        && (Rows[j].Result.EndValue == OperatorSymbole.True
                            || Rows[j].Result.EndValue == OperatorSymbole.False)
                        && Rows[k].Result.EndValue == OperatorSymbole.Rightparentheses)
                    {
                        isSimplified = true;
                        newRows.Add(Rows[j]);
                        i = k;
                        j = i + 1;
                        k = i + 2;
                    } else
                    {
                        newRows.Add(Rows[i]);
                    }

                } else
                {
                    newRows.Add(Rows[i]);
                }
            }


            if (isSimplified)
            {
                this.Rows = newRows;
            }

            return isSimplified;
        }

        internal bool SimplifyOperator()
        {
            bool isSimplified = false;
            List<Expression> newRows = new List<Expression>();

            for (int i = 0, j = 1, k = 2; i < Rows.Count; i++, j++, k++)
            {
                if (k < Rows.Count)
                {
                    if (Rows[i].Result.IsTrueOrFalse()
                        && Rows[j].Result.EndValue == OperatorSymbole.New
                        && ( Rows[j].OperatorElement.EndValue == OperatorSymbole.And
                             || Rows[j].OperatorElement.EndValue == OperatorSymbole.Or)
                        && (Rows[k].Left.IsTrueOrFalse()
                             && Rows[k].Result.EndValue == OperatorSymbole.New))
                    {
                        isSimplified = true;
                        Expression expression = new Expression();

                        expression.Left.Element = Rows[i].Result.EndValue;
                        expression.OperatorElement = Rows[j].OperatorElement;
                        expression.Right.Element = Rows[k].Result.EndValue;

                        expression.Evaluate();
                        newRows.Add(expression);
                        i = k;
                        j = i + 1;
                        k = i + 2;
                    }
                    else
                    {
                        newRows.Add(Rows[i]);
                    }

                }
                else
                {
                    newRows.Add(Rows[i]);
                }
            }

            if (isSimplified)
            {
                this.Rows = newRows;
            }

            return isSimplified;
        }

        internal bool SimplifyNot()
        {
            bool isSimplified = false;
            List<Expression> newRows = new List<Expression>();

            for (int i = 0, j = 1; i < Rows.Count; i++, j++)
            {
                if (j < Rows.Count)
                {
                    if (Rows[i].OperatorElement.EndValue == OperatorSymbole.Not
                        && (Rows[j].Result.EndValue == OperatorSymbole.True
                            || Rows[j].Result.EndValue == OperatorSymbole.False))
                    {
                        isSimplified = true;
                        if (Rows[j].Result.Element.IsTrue())
                        {
                            Rows[j].Result.Element = OperatorSymbole.False;
                        }
                        else
                        {
                            Rows[j].Result.Element = OperatorSymbole.True;
                        }

                        newRows.Add(Rows[j]);
                        i = j;
                        j = i + 1;
                    }
                    else
                    {
                        newRows.Add(Rows[i]);
                    }
                }
                else
                {
                    newRows.Add(Rows[i]);
                }
            }

            if (isSimplified)
            {
                this.Rows = newRows;
            }

            return isSimplified;
        }

        internal bool EvaluateRows()
        {
            bool isSimplified = false;
            List<Expression> newRows = new List<Expression>();
            
            //foreach(Expression expression in Rows)
            //{
            //    expression.Evaluate(true);
            //}

            for (int i = 0, j = 1, k = 2; i < Rows.Count; i++, j++, k++)
            {
                if (k < Rows.Count)
                {
                    if ((Rows[i].Result.EndValue == OperatorSymbole.True
                        || Rows[i].Result.EndValue == OperatorSymbole.False)
                        && (Rows[j].OperatorElement.EndValue == OperatorSymbole.And
                            || Rows[j].OperatorElement.EndValue == OperatorSymbole.Or)
                        && ( Rows[k].Result.EndValue == OperatorSymbole.True
                             || Rows[k].Result.EndValue == OperatorSymbole.False))
                    {
                        isSimplified = true;
                        Expression newExpression = new Expression();
                        newExpression.Left.Element = Rows[i].Result.EndValue;
                        newExpression.OperatorElement = Rows[j].OperatorElement;
                        newExpression.Right.Element = Rows[k].Result.EndValue;

                        newExpression.Evaluate();

                        newRows.Add(newExpression);
                        i = k;
                        j = i + 1;
                        k = i + 2;
                    }
                    else
                    {
                        newRows.Add(Rows[i]);
                    }

                }
                else
                {
                    newRows.Add(Rows[i]);
                }
            }

            if (isSimplified)
            {
                this.Rows = newRows;
            }

            return isSimplified;
        }

        public Answer Answer
        {
            get
            {
                return this.Result.EndValue.getAnswer();
            }

            internal set
            {

            }
        }
    }
}
