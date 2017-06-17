namespace Odusseus.RulesTests.Model
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;
    using Odusseus.Rules.Model;
    using Rules.Model.Enumeration;

    [TestClass]
    public class RuleTest
    {
        [TestMethod]
        public void Format_Should_Format_Symboles_String()
        {
            // arrange
            string input = "!(true)";
            string assert = "! ( true )";
            // act
            string result = Rule.Format(input);

            //assert
            result.Should().Be(assert, "input is formated");

        }

        [TestMethod]
        public void Format_Should_Format_Symboles_Complexe_String()
        {
            // arrange
            string input = "!(true)&&(false||(!!!))";
            string assert = "! ( true ) && ( false || ( ! ! ! ) )";
            // act
            string result = Rule.Format(input);

            //assert
            result.Should().Be(assert, "input is formated");

        }

        [TestMethod]
        public void ConvertLogicToCondition_Should_Find_A_Fact_Condition()
        {
            // Arrange
            Rules rules = null;

            OperatorElements operatorElements = new OperatorElements();

            Facts facts = new Facts
            {
                Rows =
                {
                    new Fact
                    {
                        Name = "Fact1"
                    },
                    new Fact
                    {
                        Name = "Fact2"
                    }
                }
            };

            Rule rule = new Rule
            {
                Logic = "Fact1",
                Answer = Answer.Unknown
            };

            Subject group = new Subject
            {
                Facts = facts,
                Rules = rules
            };

            // Act
            rule.ConvertLogicToConditions(operatorElements, group);

            // Assert
            rule.Conditions.Rows.Count.Should().Be(1);

            Condition condition = rule.Conditions.Rows[0];
            condition.Id.Should().Be(0);
            condition.OrderId.Should().Be(0);
            condition.Operation.As<Fact>().Name.Should().Be("Fact1");
        }

        [TestMethod]
        public void ConvertLogicToCondition_Should_Not_Find_A_Fact_Condition()
        {
            // Arrange
            Rules rules = null;
            OperatorElements operatorElements = new OperatorElements();

            Facts facts = new Facts
            {
                Rows =
                {
                    new Fact
                    {
                        Name = "Fact1"
                    },
                    new Fact
                    {
                        Name = "Fact2"
                    }
                }
            };

            Rule rule = new Rule
            {
                Logic = "Fact3"
            };

            Subject group = new Subject
            {
                Facts = facts,
                Rules = rules
            };

            // Act
            rule.ConvertLogicToConditions(operatorElements, group);

            // Assert
            rule.Conditions.Rows.Count.Should().Be(0);
            rule.Messages.Count.Should().Be(1);
            rule.Messages[0].Should().Contain("Fact3");
        }

        [TestMethod]
        public void ConvertLogicToCondition_Should_Find_A_Operator_Condition()
        {
            // Arrange
            Rules rules = null;
            OperatorElements operatorElements = new OperatorElements();

            Facts facts = new Facts
            {
                Rows =
                    {
                        new Fact
                        {
                            Name = "Fact1"
                        },
                        new Fact
                        {
                            Name = "Fact2"
                        }
                    }
            };

            Rule rule = new Rule
            {
                Logic = "&&"
            };

            Subject group = new Subject
            {
                Facts = facts,
                Rules = rules
            };

            // Act
            rule.ConvertLogicToConditions(operatorElements, group);

            // Assert
            rule.Conditions.Rows.Count.Should().Be(1);

            Condition condition = rule.Conditions.Rows[0];
            condition.Id.Should().Be(0);
            condition.OrderId.Should().Be(0);
            condition.Operation.As<OperatorElement>().Symbole.Should().Be(OperatorSymbole.And);
        }

        [TestMethod]
        public void ConvertLogicToCondition_Should_Not_Find_A_Facts_And_Operator_Condition()
        {
            // Arrange
            Rules rules = null;
            OperatorElements operatorElements = new OperatorElements();

            Facts facts = new Facts
            {
                Rows =
                    {
                        new Fact
                        {
                            Name = "Fact1"
                        },
                        new Fact
                        {
                            Name = "Fact2"
                        },
                        new Fact
                        {
                            Name = "Fact3"
                        }
                    }
            };

            Rule rule = new Rule
            {
                Logic = "Fact1 && Fact2 || Fact3",
                Answer = Answer.Unknown
            };

            Subject group = new Subject
            {
                Facts = facts,
                Rules = rules
            };

            // Act
            rule.ConvertLogicToConditions(operatorElements, group);

            // Assert
            rule.Conditions.Rows.Count.Should().Be(5);
        }

        [TestMethod]
        public void ConvertLogicToCondition_Should_Not_Find_A_Facts_And_Operator_Condition_Complex()
        {
            // Arrange
            Rules rules = null;
            OperatorElements operatorElements = new OperatorElements();

            Facts facts = new Facts
            {
                Rows =
                    {
                        new Fact
                        {
                            Name = "Fact1"
                        },
                        new Fact
                        {
                            Name = "Fact2"
                        },
                        new Fact
                        {
                            Name = "Fact3"
                        }
                    }
            };

            Rule rule = new Rule
            {
                Logic = "! ( Fact1 && Fact2 ) || Fact3",
                Answer = Answer.Unknown
            };

            Subject group = new Subject
            {
                Facts = facts,
                Rules = rules
            };

            // Act
            rule.ConvertLogicToConditions(operatorElements, group);

            // Assert
            rule.Conditions.Rows.Count.Should().Be(8);
        }
    }
}
