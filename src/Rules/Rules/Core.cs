namespace Odusseus.Rules
{
    using Model;
    using System.Linq;
    using Odusseus.Rules.Model.Enumeration;
    using Common;

    public class Core
    {
        public OperatorElements operatorElements { get; set; }
        public Facts facts { get; set; }
        public Rules rules { get; set; }

        public Core(OperatorElements operatorElements, Facts facts, Rules rules)
        {
            this.operatorElements = operatorElements;
            this.facts = facts;
            this.rules = rules;
        }

        public void ConvertConditionsToAnswer()
        {
            Log.Write(Level.Info, "Begin ConvertConditionsToAnswer");

            foreach (Rule rule in this.rules.Rows)
            {
                Log.Write(Level.Info, $"Rule={rule.Name} Answer={rule.Consequent.Answer}");

                if (rule.Consequent.Answer != Answer.Unknown)
                {
                    continue;
                }

                Expressions expressions = new Expressions();
                Expression expression = null;

                for (int i = 0, j = 1; i < rule.Conditions.Rows.Count; i++, j++)
                {
                   Log.Write(Level.Info, $"Row={i} {rule.Conditions.Rows[i].Operation.ToString()}");

                   Condition condition = rule.Conditions.Rows[i];
                   Condition conditionNext = null;

                   if (j < rule.Conditions.Rows.Count)
                   {
                        conditionNext = rule.Conditions.Rows[j];
                   }

                    if (expression == null)
                    {
                        expression = new Expression();
                    }

                    if (condition.Operation is OperatorElement)
                    {
                        OperatorElement operatorElement = condition.Operation as OperatorElement;
                        OperatorElement operatorElementNext = conditionNext?.Operation as OperatorElement;

                        if (operatorElement != null
                            && operatorElement.Symbole.getCode() != string.Empty)
                        {
                            if (IsGroup(expressions, expression, operatorElement, operatorElementNext))
                            {
                                expression = new Expression();
                                continue;
                            }
                            else
                            {
                                expression.setOperatorElement(operatorElement);
                                expression.Evaluate();

                                if (expression.Result.IsTrueOrFalse()
                                    || (expression.Left.IsNew()
                                         && ( expression.OperatorElement.Element == OperatorSymbole.And
                                              || expression.OperatorElement.Element == OperatorSymbole.Or)))
                                {
                                    expressions.Rows.Add(expression);
                                    expression = new Expression();
                                }

                                continue;
                            }
                        }
                    }

                    if (condition.Operation is Fact)
                    {
                        Fact fact = condition.Operation as Fact;

                        if (fact != null)
                        {
                            if (fact.Answer.GetCode() == OperatorSymbole.Undefined)
                            {
                                var evaluateRule = rules.Rows.Where(r => r.Name == fact.Name && r.Consequent.Answer.GetCode() != OperatorSymbole.Undefined);
                                //fact.Answer = evaluateRule.Consequent.Answer;
                            }

                            OperatorElement factAnswer = new OperatorElement
                            {
                                Symbole = fact.Answer.GetCode()
                            };

                            expression.setOperatorElement(factAnswer);
                            expression.Evaluate();

                            if (expression.Result.EndValue.IsTrue()
                               || expression.Result.EndValue.IsFalse())
                            {
                                expressions.Rows.Add(expression);
                                expression = new Expression();
                            }
                            continue;
                        }
                    }

                    if (condition.Operation is Rule)
                        {
                            Rule conditionRule = condition.Operation as Rule;

                            if (conditionRule != null)
                            {
                                OperatorElement factAnswer = new OperatorElement
                                {
                                    Symbole = conditionRule.Consequent.Answer.GetCode()
                                };

                                expression.setOperatorElement(factAnswer);
                                expression.Evaluate();

                                if (expression.Result.IsTrueOrFalse()
                                   || expression.Result.IsDoNotKnow()
                                   || expression.Result.IsUndefined())
                                {
                                    expressions.Rows.Add(expression);
                                    expression = new Expression();
                                }
                                continue;
                            }
                        }
                }

                if (!expression.Left.IsNew()
                    && expression.OperatorElement.IsNew()
                    && expression.Right.IsNew())
                {
                    expressions.Rows.Add(expression);
                    expression = new Expression();
                }

                foreach (Expression _expression in expressions.Rows)
                {
                    if (!_expression.Left.IsNew()
                        && _expression.Right.IsNew()
                        && _expression.Result.IsNew())
                    {
                        _expression.Result.Element = _expression.Left.EndValue;
                    }
                }

                expressions.Evaluate();
                rule.Consequent = new Consequent
                {
                    Answer = expressions.Answer
                };

            }
        }

        internal static bool IsGroup(Expressions expressions, Expression expression, OperatorElement operatorElement, OperatorElement operatorElementNext)
        {
            if (operatorElement == null
                || operatorElement.Symbole.getCode() == string.Empty)
            {
                return false;
            }

            if (operatorElement.Symbole == OperatorSymbole.Leftparentheses
                || operatorElement.Symbole == OperatorSymbole.Rightparentheses)
            {
                if (!expression.IsNew())
                {
                    expression.Evaluate();
                    expression.EndEvaluate();
                    expressions.Rows.Add(expression);
                }

                expression = new Expression();
                expression.Result = new BasicExpressionElement
                {
                    Element = operatorElement.Symbole
                };
                
                expressions.Rows.Add(expression);
                return true;
            }
            
            if (operatorElement.Symbole == OperatorSymbole.Not
                    && operatorElementNext?.Symbole == OperatorSymbole.Leftparentheses)
            {
                if (!expression.IsNew())
                {
                    expression.Evaluate();
                    expressions.Rows.Add(expression);
                }

                expression = new Expression();
                expression.OperatorElement = new BasicExpressionElement
                {
                    Element = OperatorSymbole.Not
                };

                expression.Evaluate();
                expressions.Rows.Add(expression);
                return true;
            }

            if (( operatorElement.Symbole == OperatorSymbole.Or
                  || operatorElement.Symbole == OperatorSymbole.And)
                   && operatorElementNext?.Symbole == OperatorSymbole.Leftparentheses)
            {
                if (!expression.IsNew())
                {
                    expression.Evaluate();
                    expression.EndEvaluate();
                    expressions.Rows.Add(expression);
                }

                expression = new Expression();
                expression.OperatorElement = new BasicExpressionElement
                {
                    Element = operatorElement.Symbole
                };
                expressions.Rows.Add(expression);

                return true;
            }
            return false;
        }

        public int Evaluate()
        {
            foreach(Rule rule in this.rules.Rows)
            {
                rule.ConvertLogicToConditions(this.operatorElements,this.rules, this.facts);
            }

            this.ConvertConditionsToAnswer();

            return 0;
        }

    }
}
