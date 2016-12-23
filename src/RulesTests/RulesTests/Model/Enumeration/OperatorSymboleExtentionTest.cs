namespace Odusseus.RulesTests.Model.Enumeration
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;
    using Rules.Model.Enumeration;

    [TestClass]
    public class OperatorSymboleExtentionTest
    {
        #region isTrue
        [TestMethod]
        public void isTrue_Should_Return_True_When_Operator_Is_True()
        {
            // Arrange
            OperatorSymbole operatorSymbole = OperatorSymbole.True;

            // Act
            bool result = operatorSymbole.IsTrue();

            // Assert
            result.Should().BeTrue("operator is true");
        }

        [TestMethod]
        public void isTrue_Should_Return_False_When_Operator_Is_False()
        {
            // Arrange
            OperatorSymbole operatorSymbole = OperatorSymbole.False;

            // Act
            bool result = operatorSymbole.IsTrue();

            // Assert
            result.Should().BeFalse("operator is false");
        }

        [TestMethod]
        public void isTrue_Should_Return_False_When_Operator_Is_Undifined()
        {
            // Arrange
            OperatorSymbole operatorSymbole = OperatorSymbole.Undefined;

            // Act
            bool result = operatorSymbole.IsTrue();

            // Assert
            result.Should().BeFalse("operator is false");
        }
        #endregion isTrue

        #region isFalse
        [TestMethod]
        public void isFalse_Should_Return_True_When_Operator_Is_False()
        {
            // Arrange
            OperatorSymbole operatorSymbole = OperatorSymbole.False;

            // Act
            bool result = operatorSymbole.IsFalse();

            // Assert
            result.Should().BeTrue("operator is false");
        }

        [TestMethod]
        public void isFalse_Should_Return_False_When_Operator_Is_True()
        {
            // Arrange
            OperatorSymbole operatorSymbole = OperatorSymbole.True;

            // Act
            bool result = operatorSymbole.IsFalse();

            // Assert
            result.Should().BeFalse("operator is true");
        }

        [TestMethod]
        public void isFalse_Should_Return_False_When_Operator_Is_Undifined()
        {
            // Arrange
            OperatorSymbole operatorSymbole = OperatorSymbole.Undefined;

            // Act
            bool result = operatorSymbole.IsFalse();

            // Assert
            result.Should().BeFalse("operator is false");
        }
        #endregion isFalse
    }
}
