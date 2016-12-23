using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Odusseus.Rules.Model;
using Odusseus.Rules.Model.Enumeration;

namespace RulesTests.Model
{
    [TestClass]
    public class ExpressionsTest
    {
        #region Evaluate 1 Row
        [TestMethod]
        public void Evaluate_With_Empty_List_Let_Result_On_Undefined_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();

            // Act
            expressions.Evaluate();

            // Assert
            expressions.Result.EndValue.Should().Be(OperatorSymbole.New);
        }

        [TestMethod]
        public void Evaluate_With_One_True_Expression_Should_Return_Result_As_True_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();
            Expression expression = new Expression
                {
                    Result = new ExpressionElement{ Element = OperatorSymbole.True}
                };

            expressions.Rows.Add(expression);

            // Act
            expressions.Evaluate();

            // Assert
            expressions.Result.EndValue.Should().Be(OperatorSymbole.True);
        }

        [TestMethod]
        public void Evaluate_With_One_Not_True_Expression_Should_Return_Result_As_False_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();
            Expression expression = new Expression
            {
                Result = new ExpressionElement
                {
                    Element = OperatorSymbole.True,
                    Not = OperatorSymbole.True,
                }
            };

            expressions.Rows.Add(expression);

            // Act
            expressions.Evaluate();

            // Assert
            expressions.Result.EndValue.Should().Be(OperatorSymbole.False);
        }

        [TestMethod]
        public void Evaluate_With_One_False_Expression_Should_Return_Result_As_False_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();
            Expression expression = new Expression
            {
                Result = new ExpressionElement { Element = OperatorSymbole.False }
            };

            expressions.Rows.Add(expression);

            // Act
            expressions.Evaluate();

            // Assert
            expressions.Result.EndValue.Should().Be(OperatorSymbole.False);
        }

        [TestMethod]
        public void Evaluate_With_One_Not_False_Expression_Should_Return_Result_As_True_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();
            Expression expression = new Expression
            {
                Result = new ExpressionElement {
                    Element = OperatorSymbole.False,
                    Not = OperatorSymbole.True
                }
            };

            expressions.Rows.Add(expression);

            // Act
            expressions.Evaluate();

            // Assert
            expressions.Result.EndValue.Should().Be(OperatorSymbole.True);
        }

        [TestMethod]
        public void Evaluate_With_One_UnDefined_Expression_Should_Return_Result_Value_As_Undefined_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();
            Expression expression = new Expression
            {
                Result = new ExpressionElement
                {
                    Element = OperatorSymbole.Undefined,
                }
            };

            expressions.Rows.Add(expression);

            // Act
            expressions.Evaluate();

            // Assert
            expressions.Result.EndValue.Should().Be(OperatorSymbole.Undefined);
        }

        [TestMethod]
        public void Evaluate_With_One_Not_UnDefined_Expression_Should_Return_Result_Value_As_Undefined_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();
            Expression expression = new Expression
            {
                Result = new ExpressionElement
                {
                    Element = OperatorSymbole.Undefined,
                    Not = OperatorSymbole.Undefined
                }
            };

            expressions.Rows.Add(expression);

            // Act
            expressions.Evaluate();

            // Assert
            expressions.Result.EndValue.Should().Be(OperatorSymbole.Undefined);
        }
        #endregion Evaluate 1 Row

        #region Evaluate 2 Row

        /// <summary>
        /// ( True ) => True
        /// </summary>
        [TestMethod]
        public void Evaluate_1_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();
            Expression expression1 = new Expression
            {
                Result = new ExpressionElement
                {
                    Element = OperatorSymbole.Leftparentheses
                }
            };

            Expression expression2 = new Expression
            {
                Result = new ExpressionElement
                {
                    Element = OperatorSymbole.True
                }
            };

            Expression expression3 = new Expression
            {
                Result = new ExpressionElement
                {
                    Element = OperatorSymbole.Rightparentheses
                }
            };
            expressions.Rows.Add(expression1);
            expressions.Rows.Add(expression2);
            expressions.Rows.Add(expression3);

            // Act
            expressions.Evaluate();

            // Assert
            expressions.Result.EndValue.Should().Be(OperatorSymbole.True);
        }

        /// <summary>
        /// ! ( True ) => True
        /// </summary>
        [TestMethod]
        public void Evaluate_2_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();

            Expression expression1 = new Expression
            {
                OperatorElement = new BasicExpressionElement
                {
                    Element = OperatorSymbole.Not
                }
            };

            Expression expression2 = new Expression
            {
                Result = new ExpressionElement
                {
                    Element = OperatorSymbole.Leftparentheses
                }
            };

            Expression expression3 = new Expression
            {
                Result = new ExpressionElement
                {
                    Element = OperatorSymbole.True
                }
            };

            Expression expression4 = new Expression
            {
                Result = new ExpressionElement
                {
                    Element = OperatorSymbole.Rightparentheses
                }
            };
            expressions.Rows.Add(expression1);
            expressions.Rows.Add(expression2);
            expressions.Rows.Add(expression3);
            expressions.Rows.Add(expression4);

            // Act
            expressions.Evaluate();

            // Assert
            expressions.Rows.Count.Should().Be(1, "all rows are simplified");
            expressions.Result.EndValue.Should().Be(OperatorSymbole.False, "! ( True) = False");
        }

        /// <summary>
        /// ( ( True ) )=> True
        /// </summary>
        [TestMethod]
        public void Evaluate_3_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();

            this.AddResult(expressions, not : OperatorSymbole.Undefined, element : OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, not : OperatorSymbole.Undefined, element : OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, not: OperatorSymbole.Undefined, element: OperatorSymbole.True);
            this.AddResult(expressions, not: OperatorSymbole.Undefined, element: OperatorSymbole.Rightparentheses);
            this.AddResult(expressions, not: OperatorSymbole.Undefined, element: OperatorSymbole.Rightparentheses);


            // Act
            expressions.Evaluate();

            // Assert
            expressions.Rows.Count.Should().Be(1, "all rows are simplified");
            expressions.Result.EndValue.Should().Be(OperatorSymbole.True, "( ( True ) ) = True");
        }

        /// <summary>
        /// ( ! ( True ) )=> False
        /// </summary>
        [TestMethod]
        public void Evaluate_4_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();

            this.AddResult(expressions, not: OperatorSymbole.New, element: OperatorSymbole.Leftparentheses);
            this.AddOperator(expressions,OperatorSymbole.Not);
            this.AddResult(expressions, not: OperatorSymbole.New, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, not: OperatorSymbole.New, element: OperatorSymbole.True);
            this.AddResult(expressions, not: OperatorSymbole.New, element: OperatorSymbole.Rightparentheses);
            this.AddResult(expressions, not: OperatorSymbole.New, element: OperatorSymbole.Rightparentheses);


            // Act
            expressions.Evaluate();

            // Assert
            expressions.Rows.Count.Should().Be(1, "all rows are simplified");
            expressions.Result.EndValue.Should().Be(OperatorSymbole.False, "( ! ( True ) ) = False");
        }

        /// <summary>
        /// ! ( ! ( True ) )=> True
        /// </summary>
        [TestMethod]
        public void Evaluate_5_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();

            this.AddOperator(expressions, OperatorSymbole.Not);
            this.AddResult(expressions, not: OperatorSymbole.New, element: OperatorSymbole.Leftparentheses);
            this.AddOperator(expressions, OperatorSymbole.Not);
            this.AddResult(expressions, not: OperatorSymbole.New, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, not: OperatorSymbole.New, element: OperatorSymbole.True);
            this.AddResult(expressions, not: OperatorSymbole.New, element: OperatorSymbole.Rightparentheses);
            this.AddResult(expressions, not: OperatorSymbole.New, element: OperatorSymbole.Rightparentheses);
            
            // Act
            expressions.Evaluate();

            // Assert
            expressions.Rows.Count.Should().Be(1, "all rows are simplified");
            expressions.Result.EndValue.Should().Be(OperatorSymbole.True, "! ( ! ( True ) )=> True");
        }

        /// <summary>
        /// ( True ) And ( True )=> True
        /// </summary>
        [TestMethod]
        public void Evaluate_6_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();
                        
            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.True);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);
            this.AddOperator(expressions, OperatorSymbole.And);
            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.True);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);


            // Act
            expressions.Evaluate();

            // Assert
            expressions.Rows.Count.Should().Be(1, "all rows are simplified");
            expressions.Result.EndValue.Should().Be(OperatorSymbole.True, "( True ) And ( True )=> True");
        }

        /// <summary>
        /// ( True ) And ( False )=> False
        /// </summary>
        [TestMethod]
        public void Evaluate_7_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();

            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.True);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);
            this.AddOperator(expressions, OperatorSymbole.And);
            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.False);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);


            // Act
            expressions.Evaluate();

            // Assert
            expressions.Rows.Count.Should().Be(1, "all rows are simplified");
            expressions.Result.EndValue.Should().Be(OperatorSymbole.False, "( True ) And ( False )=> False");
        }

        /// <summary>
        /// ( False ) And ( True )=> False
        /// </summary>
        [TestMethod]
        public void Evaluate_8_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();

            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.False);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);
            this.AddOperator(expressions, OperatorSymbole.And);
            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.True);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);


            // Act
            expressions.Evaluate();

            // Assert
            expressions.Rows.Count.Should().Be(1, "all rows are simplified");
            expressions.Result.EndValue.Should().Be(OperatorSymbole.False, "( False ) And ( True )=> False");
        }

        /// <summary>
        /// ! ( True ) And ! ( False )=> False
        /// </summary>
        [TestMethod]
        public void Evaluate_9_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();

            this.AddOperator(expressions, OperatorSymbole.Not);
            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.True);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);
            this.AddOperator(expressions, OperatorSymbole.And);
            this.AddOperator(expressions, OperatorSymbole.Not);
            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.False);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);


            // Act
            expressions.Evaluate();

            // Assert
            expressions.Rows.Count.Should().Be(1, "all rows are simplified");
            expressions.Result.EndValue.Should().Be(OperatorSymbole.False, "! ( True ) And ! ( False )=> False");
        }

        /// <summary>
        /// ! ( False ) And ! ( True )=> False
        /// </summary>
        [TestMethod]
        public void Evaluate_11_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();

            this.AddOperator(expressions,OperatorSymbole.Not);
            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.False);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);
            this.AddOperator(expressions, OperatorSymbole.And);
            this.AddOperator(expressions, OperatorSymbole.Not);
            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.True);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);
            
            // Act
            expressions.Evaluate();

            // Assert
            expressions.Rows.Count.Should().Be(1, "all rows are simplified");
            expressions.Result.EndValue.Should().Be(OperatorSymbole.False, "! ( False ) And ! ( True )=> False");
        }

        #endregion Evaluate 2 Row

        #region Evaluate 3 Row OR

        /// <summary>
        /// ( True ) Or ( True )=> True
        /// </summary>
        [TestMethod]
        public void Evaluate_3_1_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();

            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.True);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);
            this.AddOperator(expressions, OperatorSymbole.Or);
            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.True);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);


            // Act
            expressions.Evaluate();

            // Assert
            expressions.Rows.Count.Should().Be(1, "all rows are simplified");
            expressions.Result.EndValue.Should().Be(OperatorSymbole.True, "( True ) Or ( True )=> True");
        }

        /// <summary>
        /// ( True ) Or ( False )=> True
        /// </summary>
        [TestMethod]
        public void Evaluate_3_2_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();

            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.True);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);
            this.AddOperator(expressions, OperatorSymbole.Or);
            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.False);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);


            // Act
            expressions.Evaluate();

            // Assert
            expressions.Rows.Count.Should().Be(1, "all rows are simplified");
            expressions.Result.EndValue.Should().Be(OperatorSymbole.True, "( True ) Or ( False )=> True");
        }

        /// <summary>
        /// ( False ) Or ( True )=> True
        /// </summary>
        [TestMethod]
        public void Evaluate_3_3_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();

            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.False);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);
            this.AddOperator(expressions, OperatorSymbole.Or);
            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.True);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);


            // Act
            expressions.Evaluate();

            // Assert
            expressions.Rows.Count.Should().Be(1, "all rows are simplified");
            expressions.Result.EndValue.Should().Be(OperatorSymbole.True, "( False ) Or ( True )=> True");
        }

        /// <summary>
        /// ! ( True ) Or ! ( False )=> True
        /// </summary>
        [TestMethod]
        public void Evaluate_3_4_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();

            this.AddOperator(expressions, OperatorSymbole.Not);
            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.True);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);
            this.AddOperator(expressions, OperatorSymbole.Or);
            this.AddOperator(expressions, OperatorSymbole.Not);
            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.False);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);


            // Act
            expressions.Evaluate();

            // Assert
            expressions.Rows.Count.Should().Be(1, "all rows are simplified");
            expressions.Result.EndValue.Should().Be(OperatorSymbole.True, " ! ( True ) Or ! ( False )=> False");
        }

        /// <summary>
        /// ! ( False ) Or ! ( True )=> True
        /// </summary>
        [TestMethod]
        public void Evaluate_3_5_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();

            this.AddOperator(expressions, OperatorSymbole.Not);
            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.False);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);
            this.AddOperator(expressions, OperatorSymbole.Or);
            this.AddOperator(expressions, OperatorSymbole.Not);
            this.AddResult(expressions, element: OperatorSymbole.Leftparentheses);
            this.AddResult(expressions, element: OperatorSymbole.True);
            this.AddResult(expressions, element: OperatorSymbole.Rightparentheses);

            // Act
            expressions.Evaluate();

            // Assert
            expressions.Rows.Count.Should().Be(1, "all rows are simplified");
            expressions.Result.EndValue.Should().Be(OperatorSymbole.True, " ! ( True ) Or ! ( False )=> False");
        }

        #endregion Evaluate 3 Row OR


        #region SimplifyGroup
        /// <summary>
        /// Test 1
        /// (true) => true
        /// </summary>
        [TestMethod]
        public void SimplifyGroup_1_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();
            Expression expression1 = new Expression
            {
                Result = new ExpressionElement
                {
                    Element = OperatorSymbole.Leftparentheses
                }
            };

            Expression expression2 = new Expression
            {
                Result = new ExpressionElement
                {
                    Element = OperatorSymbole.True
                }
            };

            Expression expression3 = new Expression
            {
                Result = new ExpressionElement
                {
                    Element = OperatorSymbole.Rightparentheses
                }
            };
            expressions.Rows.Add(expression1);
            expressions.Rows.Add(expression2);
            expressions.Rows.Add(expression3);

            // Act
            expressions.SimplifyGroup();

            // Assert
            expressions.Rows.Count.Should().Be(1,"the 3 rows are simplified");
            expressions.Rows[0].Result.EndValue.Should().Be(OperatorSymbole.True, "the result is true");
        }

        /// <summary>
        /// Test 3
        /// (false) => false
        /// </summary>
        [TestMethod]
        public void SimplifyGroup_3_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();
            Expression expression1 = new Expression
            {
                Result = new ExpressionElement
                {
                    Element = OperatorSymbole.Leftparentheses
                }
            };

            Expression expression2 = new Expression
            {
                Result = new ExpressionElement
                {
                    Element = OperatorSymbole.False
                }
            };

            Expression expression3 = new Expression
            {
                Result = new ExpressionElement
                {
                    Element = OperatorSymbole.Rightparentheses
                }
            };
            expressions.Rows.Add(expression1);
            expressions.Rows.Add(expression2);
            expressions.Rows.Add(expression3);

            // Act
            expressions.SimplifyGroup();

            // Assert
            expressions.Rows.Count.Should().Be(1, "the 3 rows are simplified");
            expressions.Rows[0].Result.EndValue.Should().Be(OperatorSymbole.False, "the result is false");
        }

        #endregion SimplifyGroup

        #region SimplifyNot
        /// <summary>
        /// Test 1
        /// ! true => false
        /// </summary>
        [TestMethod]
        public void SimplifyNot_1_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();
            Expression expression1 = new Expression
            {
                OperatorElement = new BasicExpressionElement
                {
                    Element = OperatorSymbole.Not
                }
            };

            Expression expression2 = new Expression
            {
                Result = new ExpressionElement
                {
                    Element = OperatorSymbole.True
                }
            };
                        
            expressions.Rows.Add(expression1);
            expressions.Rows.Add(expression2);

            // Act
            expressions.SimplifyNot();

            // Assert
            expressions.Rows.Count.Should().Be(1, "the 2 rows are simplified");
            expressions.Rows[0].Result.EndValue.Should().Be(OperatorSymbole.False, "the result is Not true");
        }

        /// <summary>
        /// Test 2
        /// ! false => true
        /// </summary>
        [TestMethod]
        public void SimplifyNot_2_Test()
        {
            // Arrange
            Expressions expressions = new Expressions();
            Expression expression1 = new Expression
            {
                OperatorElement = new BasicExpressionElement
                {
                    Element = OperatorSymbole.Not
                }
            };

            Expression expression2 = new Expression
            {
                Result = new ExpressionElement
                {
                    Element = OperatorSymbole.False
                }
            };

            expressions.Rows.Add(expression1);
            expressions.Rows.Add(expression2);

            // Act
            expressions.SimplifyNot();

            // Assert
            expressions.Rows.Count.Should().Be(1, "the 2 rows are simplified");
            expressions.Rows[0].Result.EndValue.Should().Be(OperatorSymbole.True, "the result is Not false");
        }
        #endregion SimplifyNot

        #region private
        private void AddResult(Expressions expressions, OperatorSymbole element = OperatorSymbole.New, OperatorSymbole not = OperatorSymbole.New)
        {
            Expression expression = new Expression
            {
                Result = new ExpressionElement
                {
                    Element = element,
                    Not = not
                }
            };
            expressions.Rows.Add(expression);
        }

        private void AddOperator(Expressions expressions, OperatorSymbole element)
        {
            Expression expression = new Expression
            {
                OperatorElement = new BasicExpressionElement
                {
                    Element = element
                }
            };
            expressions.Rows.Add(expression);
        }
        #endregion private
    }
}