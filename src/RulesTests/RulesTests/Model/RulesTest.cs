namespace RulesTests.Model
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Odusseus.Rules.Model;
    using Odusseus.Rules.Model.Enumeration;

    [TestClass]
    public class RulesTest
    {
        #region GetRule

        [TestMethod]
        public void GetRule_Should_Return_Null_When_Rules_Has_Ho_Rows()
        {
            // arrange
            Rules rules = new Rules();

            // act
            Rule rule = rules.GetRule("Test");

            // assert
            rule.Should().BeNull("Rules has no rows");
        }

        [TestMethod]
        public void GetRule_Should_Return_Rule_With_Assert_Name_Name2_When_It_Is_In_The_List()
        {
            // arrange
            string assertName = "Name2";

            Rules rules = new Rules
            {
                Rows = {
                            new Rule
                            {
                                Name = "Name1"
                            },
                            new Rule
                            {
                                Name = assertName
                            },
                            new Rule
                            {
                                Name = "Name3"
                            }
                       }
            };

            // act
            Rule rule = rules.GetRule(assertName);

            // assert
            rule.Name.Should().Be(assertName,$"Rule with assert name {assertName} is in the list");
        }
        #endregion GetRule

        #region GetRulesByAnswer
        [TestMethod]
        public void GetRulesByAnswer_Should_Return_Empty_List_When_No_Is_Found()
        {
            // arrange
            Rules rules = new Rules();

            // act
            var result = rules.GetRulesByAnswer(Answer.Unknown);

            // assert
            result.Count.Should().Be(0,"Rules has no rule");
        }

        [TestMethod]
        public void GetRulesByAnswer_Is_Unknown_Return_2_Rules_When_2_Rules_Are_Unknown()
        {
            // arrange
            Rules rules = new Rules
            {
                Rows = new List<Rule>
                {
                    new Rule
                    {
                        Name = "R1",
                        Consequent = new Consequent
                        {
                            Answer = Answer.Unknown
                        }
                    },
                    new Rule
                    {
                        Name = "R2",
                        Consequent = new Consequent
                        {
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Name = "R3",
                        Consequent = new Consequent
                        {
                            Answer = Answer.Unknown
                        }
                    }
                }
            };

            // act
            var result = rules.GetRulesByAnswer(Answer.Unknown);

            // assert
            result.Count.Should().Be(2,"two rules are unknown");
        }

        #endregion GetRulesByAnswer

        #region SetAnswer
        public void SetAnwer_Should_Not_Set_Answer_When_No_Rule_Is_Found()
        {
            // arrange
            Rules rules = new Rules();

            // act
            int result = rules.SetAnswer("R1", Answer.Yes);

            // assert
            result.Should().Be(0, "no rule is update");
        }

        [TestMethod]
        public void SetAnwer_Should_Set_Answer_For_The_Given_Rule()
        {
            // arrange
            Rules rules = new Rules
            {
                Rows = new List<Rule>
                {
                    new Rule
                    {
                        Name = "R1",
                        Consequent = new Consequent
                                         {
                                            Answer = Answer.Unknown
                                         }
                    }
                }
            };

            // act
            int result = rules.SetAnswer("R1", Answer.Yes);

            // assert
            result.Should().Be(1, "1 rule is updated");
            rules.GetRule("R1").Consequent.Answer.Should().Be(Answer.Yes, "Answer is set to Yes");
        }

        [TestMethod]
        public void SetAnwer_Should_Set_Answer_To_Multiple_Rules_For_The_Given_Rule_When_There_Twice()
        {
            // arrange
            Rules rules = new Rules
            {
                Rows = new List<Rule>
                {
                    new Rule
                    {
                        Name = "R1",
                        Consequent = new Consequent
                                         {
                                            Answer = Answer.Unknown
                                         }
                    },
                    new Rule
                    {
                        Name = "R2",
                        Consequent = new Consequent
                                         {
                                            Answer = Answer.Unknown
                                         }
                    },
                    new Rule
                    {
                        Name = "R1",
                        Consequent = new Consequent
                                         {
                                            Answer = Answer.Unknown
                                         }
                    },
                }
            };

            // act
            int result = rules.SetAnswer("R1", Answer.Yes);

            // assert
            result.Should().Be(2, "1 rule is updated");
        }
        #endregion SetAnswer
    }
}
