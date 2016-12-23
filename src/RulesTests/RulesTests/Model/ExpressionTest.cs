namespace Odusseus.RulesTests.Model
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;

    using Odusseus.Rules.Model;
    using Odusseus.Rules.Model.Enumeration;
    using System;

    [TestClass]
    public class ExpressionTest
    {
        #region Empty
        [TestMethod]
        public void Empty_Should_Retrun_False_When_Left_Is_Not_Empty()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left = new ExpressionElement
            {
                Not = OperatorSymbole.True
            };

            // Act
            bool result = expression.IsNew();

            //Assert
            result.Should().BeFalse("Left is not empty");
        }

        [TestMethod]
        public void Empty_Should_Retrun_False_When_Operator_Is_Not_Empty()
        {
            // Arrange
            Expression expression = new Expression();
            expression.OperatorElement = new ExpressionElement
            {
                Element = OperatorSymbole.True
            };

            // Act
            bool result = expression.IsNew();

            //Assert
            result.Should().BeFalse("Operator is not empty");
        }

        [TestMethod]
        public void Empty_Should_Retrun_False_When_Right_Is_Not_Empty()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Right = new ExpressionElement
            {
                Element = OperatorSymbole.True
            };

            // Act
            bool result = expression.IsNew();

            //Assert
            result.Should().BeFalse("right is not empty");
        }

        [TestMethod]
        public void Empty_Should_Retrun_False_When_Result_Is_Not_Empty()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Result = new ExpressionElement
            {
                Element = OperatorSymbole.True
            };

            // Act
            bool result = expression.IsNew();

            //Assert
            result.Should().BeFalse("result is not empty");
        }

        [TestMethod]
        public void Empty_Should_Retrun_True_When_All_Elements_Are_Empty()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Result = new ExpressionElement();

            // Act
            bool result = expression.IsNew();

            //Assert
            result.Should().BeTrue("all elements are empty");
        }
        #endregion Empty

        #region setOperatorElement Not

        [TestMethod]
        public void setOperatorElement_Should_Set_Left_Not_True_When_Left_Is_Not_Set()
        {
            // Arrange
            Expression expression = new Expression();
            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.Not
            };

            // Act
            expression.setOperatorElement(operatorElement);
            OperatorSymbole result = expression.Left.Not;

            //Assert
            result.Should().Be(OperatorSymbole.True);
        }

        [TestMethod]
        public void setOperatorElement_Should_Set_Right_Not_True_When_Left_Is_Set_And_Right_Not()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left = new ExpressionElement
            {
                Element = OperatorSymbole.True
            };
            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.Not
            };

            // Act
            expression.setOperatorElement(operatorElement);
            OperatorSymbole result = expression.Right.Not;

            //Assert
            result.Should().Be(OperatorSymbole.True);
        }

        [TestMethod]
        public void setOperatorElement_Should_Throw_A_Expection_When_Right_And_Left_Are_Set()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left = new ExpressionElement
            {
                Element = OperatorSymbole.True
            };
            expression.Right = new ExpressionElement
            {
                Element = OperatorSymbole.True
            };

            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.Not
            };

            // Act
            Action result = () => expression.setOperatorElement(operatorElement);
            
            //Assert
            result.ShouldThrow<Exception>().WithMessage("Not is al set.");
            
        }
        #endregion setOperatorElement Not

        #region setOperatorElement Left and Right

        [TestMethod]
        public void setOperatorElement_Should_Set_Left_True_When_Left_Is_Not_Set()
        {
            // Arrange
            Expression expression = new Expression();
            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.True
            };

            // Act
            expression.setOperatorElement(operatorElement);
            OperatorSymbole result = expression.Left.Element;

            //Assert
            result.Should().Be(OperatorSymbole.True);
        }

        [TestMethod]
        public void setOperatorElement_Should_Set_Right_True_When_Left_Element_Is_Set_And_Right_Not()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left.Element = OperatorSymbole.True;

            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.True
            };

            // Act
            expression.setOperatorElement(operatorElement);
            OperatorSymbole result = expression.Right.Element;

            //Assert
            result.Should().Be(OperatorSymbole.True);
        }

        [TestMethod]
        public void setOperatorElement_Should_Throw_A_Exception_When_Left_And_Right_Are_Set()
        {
            // Arrange
            Expression expression = new Expression();

            expression.Left.Element = OperatorSymbole.True;
            expression.Right.Element = OperatorSymbole.True;

            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.True
            };

            // Act
            Action result = () => expression.setOperatorElement(operatorElement);

            //Assert
            result.ShouldThrow<Exception>().WithMessage("elements left and right are al set.");

        }
        #endregion setOperatorElement Left and Right
        
        #region setOperatorElement OperatorElement

        [TestMethod]
        public void setOperatorElement_Should_Set_OperatorElement_And_When_OperatorElement_Is_Not_Set()
        {
            // Arrange
            Expression expression = new Expression();
            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.And
            };

            // Act
            expression.setOperatorElement(operatorElement);
            OperatorSymbole result = expression.OperatorElement.Element;

            //Assert
            result.Should().Be(OperatorSymbole.And);
        }

        [TestMethod]
        public void setOperatorElement_Should_Set_OperatorElement_Or_When_OperatorElement_Is_Not_Set()
        {
            // Arrange
            Expression expression = new Expression();
            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.Or
            };

            // Act
            expression.setOperatorElement(operatorElement);
            OperatorSymbole result = expression.OperatorElement.Element;

            //Assert
            result.Should().Be(OperatorSymbole.Or);
        }

        [TestMethod]
        public void setOperatorElement_Throw_A_Exception_When_OperatorElement_Is_Al_Set()
        {
            // Arrange
            Expression expression = new Expression();
            expression.OperatorElement = new ExpressionElement
            {
                Element = OperatorSymbole.And
            };

            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.Or
            };

            // Act
            Action result = () => expression.setOperatorElement(operatorElement);

            //Assert
            result.ShouldThrow<Exception>().WithMessage("Operator is al set.");
        }

        #endregion setOperatorElement 

        #region setOperatorElement parenthese

        [TestMethod]
        public void setOperatorElement_Should_Set_Left_Parenthese_Left_When_Left_Is_Not_Set()
        {
            // Arrange
            Expression expression = new Expression();
            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.Leftparentheses
            };

            // Act
            expression.setOperatorElement(operatorElement);
            OperatorSymbole result = expression.Left.Element;

            //Assert
            result.Should().Be(OperatorSymbole.Leftparentheses);
        }

        [TestMethod]
        public void setOperatorElement_Should_Set_Right_Parenthese_Right_When_Right_Is_Not_Set()
        {
            // Arrange
            Expression expression = new Expression();
            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.Rightparentheses
            };

            // Act
            expression.setOperatorElement(operatorElement);
            OperatorSymbole result = expression.Right.Element;

            //Assert
            result.Should().Be(OperatorSymbole.Rightparentheses);
        }

        [TestMethod]
        public void setOperatorElement_Throws_A_Exception_When_Rightparentheses_Is_Given_And_Right_Is_Al_Set()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Right = new ExpressionElement
            {
                Element = OperatorSymbole.True
            };

            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.Rightparentheses
            };

            // Act
            Action result = () => expression.setOperatorElement(operatorElement);

            //Assert
            result.ShouldThrow<Exception>().WithMessage("element right is al set.");
        }

        [TestMethod]
        public void setOperatorElement_Throws_A_Exception_When_Leftparentheses_Is_Given_And_Left_Is_Al_Set()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left = new ExpressionElement
            {
                Element = OperatorSymbole.True
            };

            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.Leftparentheses
            };

            // Act
            Action result = () => expression.setOperatorElement(operatorElement);

            //Assert
            result.ShouldThrow<Exception>().WithMessage("element left is al set.");
        }
        #endregion setOperatorElement 

        #region Evaluate new expression
        [TestMethod]
        public void Evaluate_New_Expression_Should_Let_Left_Result_Undefined()
        {
            // Arrange
            Expression expression = new Expression();

            // Act
            expression.Evaluate();

            // Assert
            expression.Left.EndValue.Should().Be(OperatorSymbole.New);
        }

        [TestMethod]
        public void Evaluate_New_Expression_Should_Let_Right_Result_Undefined()
        {
            // Arrange
            Expression expression = new Expression();

            // Act
            expression.Evaluate();

            // Assert
            expression.Right.EndValue.Should().Be(OperatorSymbole.New);
        }


        [TestMethod]
        public void Evaluate_New_Expression_Should_Let_Result_Result_Undefined()
        {
            // Arrange
            Expression expression = new Expression();

            // Act
            expression.Evaluate();

            // Assert
            expression.Result.EndValue.Should().Be(OperatorSymbole.New);
        }

        #endregion Evaluate new expression

        #region Evaluate Left
        [TestMethod]
        public void Evaluate_Expression_With_Left_Is_True_Should_Set_Right_Result_To_True()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left.Element = OperatorSymbole.True;

            // Act
            expression.Evaluate();

            // Assert
            expression.Left.EndValue.Should().Be(OperatorSymbole.True);
        }

        [TestMethod]
        public void Evaluate_Expression_With_Left_Is_Not_True_Should_Set_Right_Result_To_True()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left.Element = OperatorSymbole.True;
            expression.Left.Not = OperatorSymbole.True;

            // Act
            expression.Evaluate();

            // Assert
            expression.Left.EndValue.Should().Be(OperatorSymbole.False);
        }

        [TestMethod]
        public void Evaluate_Expression_With_Left_Is_False_Should_Set_Right_Result_To_False()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left.Element = OperatorSymbole.False;

            // Act
            expression.Evaluate();

            // Assert
            expression.Left.EndValue.Should().Be(OperatorSymbole.False);
        }

        [TestMethod]
        public void Evaluate_Expression_With_Left_Is_Not_False_Should_Set_Right_Result_To_False()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left.Element = OperatorSymbole.False;
            expression.Left.Not = OperatorSymbole.True;

            // Act
            expression.Evaluate();

            // Assert
            expression.Left.EndValue.Should().Be(OperatorSymbole.True);
        }
        #endregion Evaluate Left
        
        #region Evaluate Left is True Operator is And Right

        [TestMethod]
        public void Evaluate_Expression_With_Left_Is_True_And_Right_Is_True_Should_Set_Right_Result_To_True()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left.Element = OperatorSymbole.True;
            expression.OperatorElement.Element = OperatorSymbole.And;
            expression.Right.Element = OperatorSymbole.True;

            // Act
            expression.Evaluate();

            // Assert
            expression.Right.EndValue.Should().Be(OperatorSymbole.True);
        }

        [TestMethod]
        public void Evaluate_Expression_With_Left_Is_True_And_Right_Is_Not_True_Should_Set_Right_Result_To_True()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left.Element = OperatorSymbole.True;
            expression.OperatorElement.Element = OperatorSymbole.And;
            expression.Right.Element = OperatorSymbole.True;
            expression.Right.Not = OperatorSymbole.True;

            // Act
            expression.Evaluate();

            // Assert
            expression.Right.EndValue.Should().Be(OperatorSymbole.False);
        }

        [TestMethod]
        public void Evaluate_Expression_With_Left_Is_True_And_Right_Is_False_Should_Set_Right_Result_To_False()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left.Element = OperatorSymbole.True;
            expression.OperatorElement.Element = OperatorSymbole.And;
            expression.Right.Element = OperatorSymbole.False;

            // Act
            expression.Evaluate();

            // Assert
            expression.Right.EndValue.Should().Be(OperatorSymbole.False);
        }

        [TestMethod]
        public void Evaluate_Expression_With_Left_Is_True_And_Right_Is_Not_False_Should_Set_Right_Result_To_False()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left.Element = OperatorSymbole.True;
            expression.OperatorElement.Element = OperatorSymbole.And;
            expression.Right.Element = OperatorSymbole.False;
            expression.Right.Not = OperatorSymbole.True;

            // Act
            expression.Evaluate();

            // Assert
            expression.Right.EndValue.Should().Be(OperatorSymbole.True);
        }
        #endregion Evaluate Left is True Operator is And Right

        #region Evaluate Left is True Operator is Or Right
        [TestMethod]
        public void Evaluate_Expression_With_Left_Is_True_Or_Operator_Right_Is_True_Should_Set_Result_Result_To_True()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left.Element = OperatorSymbole.True;
            expression.OperatorElement.Element = OperatorSymbole.Or;
            expression.Right.Element = OperatorSymbole.True;

            // Act
            expression.Evaluate();

            // Assert
            expression.Result.EndValue.Should().Be(OperatorSymbole.True);
        }

        [TestMethod]
        public void Evaluate_Expression_With_Left_Is_True_Or_Operator_Right_Is_False_Should_Set_Result_Result_To_True()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left.Element = OperatorSymbole.True;
            expression.OperatorElement.Element = OperatorSymbole.Or;
            expression.Right.Element = OperatorSymbole.False;

            // Act
            expression.Evaluate();

            // Assert
            expression.Result.EndValue.Should().Be(OperatorSymbole.True);
        }

        [TestMethod]
        public void Evaluate_Expression_With_Left_Is_True_Or_Operator_Right_Is_Not_True_Should_Set_Result_Result_To_True()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left.Element = OperatorSymbole.True;
            expression.OperatorElement.Element = OperatorSymbole.Or;
            expression.Right.Element = OperatorSymbole.True;
            expression.Right.Not = OperatorSymbole.True;

            // Act
            expression.Evaluate();

            // Assert
            expression.Result.EndValue.Should().Be(OperatorSymbole.True);
        }

        [TestMethod]
        public void Evaluate_Expression_With_Left_Is_Not_True_Or_Operator_Right_Is_True_Should_Set_Result_Result_To_True()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left.Not = OperatorSymbole.True;
            expression.Left.Element = OperatorSymbole.True;

            expression.OperatorElement.Element = OperatorSymbole.Or;
            expression.Right.Element = OperatorSymbole.True;

            // Act
            expression.Evaluate();

            // Assert
            expression.Result.EndValue.Should().Be(OperatorSymbole.True);
        }

        [TestMethod]
        public void Evaluate_Expression_With_Left_Is_False_Or_Operator_Right_Is_False_Should_Set_Result_Result_To_False()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left.Element = OperatorSymbole.False;

            expression.OperatorElement.Element = OperatorSymbole.Or;
            expression.Right.Element = OperatorSymbole.False;

            // Act
            expression.Evaluate();

            // Assert
            expression.Result.EndValue.Should().Be(OperatorSymbole.False);
        }

        [TestMethod]
        public void Evaluate_Expression_With_Left_Is_Not_True_Or_Operator_Right_Is_Not_True_Should_Set_Result_Result_To_False()
        {
            // Arrange
            Expression expression = new Expression();
            expression.Left.Not = OperatorSymbole.True;
            expression.Left.Element = OperatorSymbole.True;

            expression.OperatorElement.Element = OperatorSymbole.Or;
            expression.Right.Not = OperatorSymbole.True;
            expression.Right.Element = OperatorSymbole.True;

            // Act
            expression.Evaluate();

            // Assert
            expression.Result.EndValue.Should().Be(OperatorSymbole.False);
        }
        #endregion Evaluate Left is True Operator is Or Right

    }
}
