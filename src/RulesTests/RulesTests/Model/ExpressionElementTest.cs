namespace Odusseus.RulesTests.Model
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;
    using Rules.Model;
    using Rules.Model.Enumeration;

    [TestClass]
    public class ExpressionElementTest
    {
        #region Empty
        [TestMethod]
        public void Empty_Should_Return_False_When_Not_Is_True()
        {
            // Arrange
            ExpressionElement element = new ExpressionElement();
            element.Not = OperatorSymbole.True;

            // Act
            bool result = element.IsNew();

            // Assert
            result.Should().BeFalse("element Not is True");
        }

        [TestMethod]
        public void Empty_Should_Return_False_When_Elemet_Is_Not_Undefined()
        {
            // Arrange
            ExpressionElement element = new ExpressionElement();
            element.Element = OperatorSymbole.True;

            // Act
            bool result = element.IsNew();

            // Assert
            result.Should().BeFalse("element is not Undefined");
        }

        [TestMethod]
        public void Empty_Should_Return_False_When_Result_Is_Not_Undefined()
        {
            // Arrange
            ExpressionElement element = new ExpressionElement();
            element.Element = OperatorSymbole.True;

            // Act
            bool result = element.IsNew();

            // Assert
            result.Should().BeFalse("element result is not Undefined");
        }

        [TestMethod]
        public void Empty_Should_Return_True_When_No_Element_Is_Set()
        {
            // Arrange
            ExpressionElement element = new ExpressionElement();
            element.Not = OperatorSymbole.New;
            element.Element = OperatorSymbole.New;

            // Act
            bool result = element.IsNew();

            // Assert
            result.Should().BeTrue("no element is set");
        }
        #endregion empty

        #region SetNot
        
        [TestMethod]
        public void SetNot_Should_Set_Not_True_When_Not_Is_True_And_It_Was_Undefined()
        {
            // Arrange
            ExpressionElement element = new ExpressionElement();
            element.Not = OperatorSymbole.True;

            // Act            
           OperatorSymbole result = element.Not;

            // Assert
            result.Should().Be(OperatorSymbole.True);
        }

        [TestMethod]
        public void SetNot_Should_Set_Not_True_When_Not_Is_True_And_It_Was_False()
        {
            // Arrange
            ExpressionElement element = new ExpressionElement();
            element.Not = OperatorSymbole.False;
            element.Not = OperatorSymbole.True;

            // Act            
            OperatorSymbole result = element.Not;

            // Assert
            result.Should().Be(OperatorSymbole.True);
        }

        [TestMethod]
        public void SetNot_Should_Set_Not_False_When_Not_Is_False_And_It_Was_False()
        {
            // Arrange
            ExpressionElement element = new ExpressionElement();
            element.Not = OperatorSymbole.False;
            element.Not = OperatorSymbole.False;

            // Act            
            OperatorSymbole result = element.Not;

            // Assert
            result.Should().Be(OperatorSymbole.False);
        }

        [TestMethod]
        public void SetNot_Should_Set_Not_False_When_Not_Is_False_And_It_Was_True()
        {
            // Arrange
            ExpressionElement element = new ExpressionElement();
            element.Not = OperatorSymbole.True;
            element.Not = OperatorSymbole.False;

            // Act            
            OperatorSymbole result = element.Not;

            // Assert
            result.Should().Be(OperatorSymbole.False);
        }

        [TestMethod]
        public void SetNot_Should_Set_Not_False_When_Not_Is_True_And_It_Was_True()
        {
            // Arrange
            ExpressionElement element = new ExpressionElement();
            element.Not = OperatorSymbole.True;
            element.Not = OperatorSymbole.True;

            // Act            
            OperatorSymbole result = element.Not;

            // Assert
            result.Should().Be(OperatorSymbole.False);
        }


        #endregion SetNot
    }
}
