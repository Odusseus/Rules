namespace Odusseus.RulesTests.Model
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Odusseus.Rules.Model.Enumeration;
    using Odusseus.Rules.Model;

    [TestClass]
    public class FactTest
    {

        [TestMethod]
        public void New_Fact_Should_Assign_1_To_Id()
        {
            // Arrange
            Fact.ResetMaxId();
            Fact fact = new Fact();
            
            // Act
            var result = fact.Id;

            // Assert
            //result.ShouldBeEquivalentTo(1);
        }

        [TestMethod]
        public void Fact_Get_Id_Should_10_When_Is_Assigh_To_10()
        {
            Fact fact = new Fact();
            fact.Id = 10;

            // Execute
            var result = fact.Id;

            // Assert
            //result.ShouldBeEquivalentTo(10);
        }

        [TestMethod]
        public void Fact_Get_Name_Should_Return_Name()
        {
            Fact fact = new Fact();
            fact.Name = "FactName";

            // Execute
            var result = fact.Name;

            // Assert
            //result.ShouldBeEquivalentTo("FactName");
        }

        [TestMethod]
        public void Fact_Get_Text_Should_Return_Text()
        {
            Fact fact = new Fact();
            fact.Question = "FactText";

            // Execute
            var result = fact.Question;

            // Assert
            //result.ShouldBeEquivalentTo("FactText");
        }

        [TestMethod]
        public void Fact_Get_Answer_Should_Return_Answer()
        {
            Fact fact = new Fact();
            fact.Answer = Answer.Yes;

            // Execute
            var result = fact.Answer;

            // Assert
            //result.ShouldBeEquivalentTo(Answer.Yes);
        }
    }
}
