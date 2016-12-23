namespace Odusseus.RulesTests.Model.Enumeration
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;
    using Odusseus.Rules.Model.Enumeration;

    [TestClass]
    public class ExitCodeTest
    {
        [TestMethod]
        public void ExitCode_NothingSucceeded_Should_Return_Code_100_Test()
        {
            // Arrange

            // Act
            int result = ExitCode.NothingSucceeded.Code();

            // Assert
            result.Should().Be(100);
        }

        [TestMethod]
        public void ExitCode_Success_Should_Return_Code_0_Test()
        {
            // Arrange

            // Act
            int result = ExitCode.Success.Code();

            // Assert
            result.Should().Be(0);
        }
    }
}
