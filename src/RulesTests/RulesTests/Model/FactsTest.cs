namespace Odusseus.RulesTests.Model
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;
    using Odusseus.Rules.Model;
    using Odusseus.Rules.Model.Enumeration;
    using System.Collections.Generic;

    [TestClass]
    public class FactsTest
    {
        [TestMethod]
        public void Facts_Should_Return_Empty_List_When_Is_List_Is_Empty()
        {
            Facts facts = new Facts();

            //Assert
            facts.Rows.Should().BeEmpty();
        }

        [TestMethod]
        public void Facts_Should_Return_List_When_Is_Not_Empty()
        {
            // Arrange
            Facts facts = new Facts();

            // Act
            facts.Rows.Add(
                        new Fact
                        {
                            Answer = Answer.DoNotKnow,
                            Id = 1,
                            Name = "Test 1",
                            Question = "Was I a question?"
                        });
            facts.Rows.Add(
                        new Fact
                        {
                            Answer = Answer.No,
                            Id = 2,
                            Name = "Test 2",
                            Question = "Are You a question?"
                        });
            // Assert
            facts.Rows.Count.ShouldBeEquivalentTo(2);
        }


        #region GetFactsByAnswer
        [TestMethod]
        public void GetFactsByAnswer_Should_Return_Empty_List_When_No_Is_Found()
        {
            // arrange
            Facts facts = new Facts();

            // act
            var result = facts.GetFactsByAnswer(Answer.Unknown);

            // assert
            result.Count.Should().Be(0, "Facts has no fact");
        }

        [TestMethod]
        public void GetFactsByAnswer_Is_Unknown_Return_2_Facts_When_2_Facts_Are_Unknown()
        {
            // arrange
            Facts facts = new Facts
            {
                Rows = new List<Fact>
                {
                    new Fact
                    {
                        Name = "F1",
                        Answer = Answer.Unknown
                    },
                new Fact
                    {
                        Name = "F2",
                        Answer = Answer.Yes
                    },
                new Fact
                    {
                        Name = "F3",
                        Answer = Answer.Unknown
                    }
                }
            };

            // act
            var result = facts.GetFactsByAnswer(Answer.Unknown);

            // assert
            result.Count.Should().Be(2, "two facts are unknown");
        }

        #endregion GetFactsByAnswer

        #region GetFact
        [TestMethod]

        public void GetFact_Return_Null_When_Fact_Is_Not_Found()
        {
            // arrange
            Facts facts = new Facts();

            // act
            Fact result = facts.GetFact("XX");

            // assert
            result.Should().BeNull("Fact is not found");
        }

        public void GetFact_Return_The_Search_Fact()
        {
            // arrange
            Facts facts = new Facts
            {
                Rows = new List<Fact>
                {
                    new Fact
                    {
                        Name = "F1"
                    },
                    new Fact
                    {
                        Name = "F2"
                    },
                    new Fact
                    {
                        Name = "F3"
                    },
                }
            };

            // act
            Fact result = facts.GetFact("F2");

            // assert
            result.Name.Should().Be("F2", "Fact is the list");
        }

        #endregion GetAnswer

        #region SetAnswer
        public void SetAnwer_Should_Not_Set_Answer_When_No_Fact_Is_Found()
        {
            // arrange
            Facts facts = new Facts();

            // act
            int result = facts.SetAnswer("F1", Answer.Yes);

            // assert
            result.Should().Be(0, "no Fact is update");
        }

        [TestMethod]
        public void SetAnwer_Should_Set_Answer_For_The_Given_Fact()
        {
            // arrange
            Facts facts = new Facts
            {
                Rows = new List<Fact>
                {
                    new Fact
                    {
                        Name = "F1",
                        Answer = Answer.Unknown
                    }
                }
            };

            // act
            int result = facts.SetAnswer("F1", Answer.Yes);

            // assert
            result.Should().Be(1, "1 fact is updated");
            facts.GetFact("F1").Answer.Should().Be(Answer.Yes, "Answer is set to Yes");
        }

        [TestMethod]
        public void SetAnwer_Should_Set_Answer_To_Multiple_Fact_For_The_Given_Fact_When_There_Twice()
        {
            // arrange
            Facts facts = new Facts
            {
                Rows = new List<Fact>
                {
                    new Fact
                    {
                        Name = "F1",
                        Answer = Answer.Unknown
                    },
                    new Fact
                    {
                        Name = "F2",
                        Answer = Answer.Unknown
                    },
                    new Fact
                    {
                        Name = "F1",
                        Answer = Answer.Unknown
                    },
                }
            };

            // act
            int result = facts.SetAnswer("F1", Answer.Yes);

            // assert
            result.Should().Be(2, "2 facts are updated");
        }
        #endregion SetAnswer
    }
}
