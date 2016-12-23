namespace Odusseus.RulesTests.Model.Enumeration
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;
    using Odusseus.Rules.Model.Enumeration;

    /// <summary>
    /// Summary description for AnswerTest
    /// </summary>
    [TestClass]
    public class AnswerTest
    {
        [TestMethod]
        public void Answer_DoNotKnow_Value_Should_Be_3_Test()
        {
            int result = (int)Answer.DoNotKnow;

            // Assert
            result.ShouldBeEquivalentTo(1);
        }

        [TestMethod]
        public void Answer_No_Value_Should_Be_2_Test()
        {
            int result = (int)Answer.No;

            // Assert
            result.ShouldBeEquivalentTo(2);
        }

        [TestMethod]
        public void Answer_Unknow_Value_Should_Be_0_Test()
        {
            int result = (int)Answer.Unknown;

            // Assert
            result.ShouldBeEquivalentTo(0);
        }

        [TestMethod]
        public void Answer_No_Value_Should_Be_1_Test()
        {
            int result = (int)Answer.Yes;

            // Assert
            result.ShouldBeEquivalentTo(3);
        }

        [TestMethod]
        public void Answer_GetBoolean_Should_Return_True_When_Is_Yes_Test()
        {
            // Arrange
            Answer answer = Answer.Yes;

            // Act
            OperatorSymbole result = answer.GetCode();

            // Assert
            result.Should().Be(OperatorSymbole.True);
        }

        [TestMethod]
        public void Answer_GetBoolean_Should_Return_True_When_Is_No_Test()
        {
            // Arrange
            Answer answer = Answer.No;

            // Act
            OperatorSymbole result = answer.GetCode();

            // Assert
            result.Should().Be(OperatorSymbole.False);
        }

        [TestMethod]
        public void Answer_GetBoolean_Should_Return_Null_When_Is_DoNotKnow_Test()
        {
            // Arrange
            Answer answer = Answer.DoNotKnow;

            // Act
            OperatorSymbole result = answer.GetCode();

            // Assert
            result.Should().Be(OperatorSymbole.DoNotKnow);
        }

        [TestMethod]
        public void Answer_GetBoolean_Should_Return_Null_When_Is_Unknown_Test()
        {
            // Arrange
            Answer answer = Answer.Unknown;

            // Act
            OperatorSymbole result = answer.GetCode();

            // Assert
            result.Should().Be(OperatorSymbole.Undefined);
        }
    }
     
}
