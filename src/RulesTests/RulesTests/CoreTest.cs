namespace Odusseus.RulesTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;
    using Odusseus.Rules;
    using Odusseus.Rules.Model;
    using Rules.Model.Enumeration;

    [TestClass]
    public class CoreTest
    {
        #region Evaluate

        /// R1 && R2 
        /// True && True => True
        [TestMethod]
        public void Evaluate_1()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDataset1();

            Core core = new Core(operatorElements ,facts, rules);

            // Act
            core.Evaluate();
            
            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.Yes, "True && True => Yes");
        }

        /// ! R1 && R2 
        /// ! True && True => False
        [TestMethod]
        public void Evaluate_1A()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDataset1A();

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.Evaluate();

            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.No, "! True && True => No");
        }

        /// R1 && ! R2 
        /// True && ! True => False
        [TestMethod]
        public void Evaluate_1B()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDataset1B();

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.Evaluate();

            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.No, "True && ! True => No");
        }

        /// ! R1 && ! R2 
        /// ! True && ! True => False
        [TestMethod]
        public void Evaluate_1C()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDataset1C();

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.Evaluate();

            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.No, "! True && ! True => False");
        }

        /// R1 || R2 
        /// True || True => True
        [TestMethod]
        public void Evaluate_2()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDataset2();

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.Evaluate();

            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.Yes, "True || True => Yes");
        }

        /// R1 && R2 
        /// False && True => False
        [TestMethod]
        public void Evaluate_3()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDataset3();

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.Evaluate();

            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.No, "False && True => False");
        }

        /// R1 || R2 
        /// False || True => True
        [TestMethod]
        public void Evaluate_4()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDataset4();

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.Evaluate();

            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.Yes, "False || True => True");
        }

        /// R1 || R2
        /// False || False => False
        [TestMethod]
        public void Evaluate_5()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDataset5();

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.Evaluate();

            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.No, "False || False => False");
        }

        /// ( R1 && R2 ) && R3
        /// True && True && True=> True
        [TestMethod]
        public void Evaluate_6()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDataset6();

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.Evaluate();

            // Assert
            core.rules.GetRule("R4").Consequent.Answer.Should().Be(Answer.Yes, "True && True && True=> True");
        }

        /// ( R1 && R2 ) && R3
        /// True && True && False => False
        [TestMethod]
        public void Evaluate_7()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDataset7();

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.Evaluate();

            // Assert
            core.rules.GetRule("R4").Consequent.Answer.Should().Be(Answer.No, "True && True && False => False");
        }

        /// ( R1 && R2 ) && R3
        /// True && False && False => False
        [TestMethod]
        public void Evaluate_8()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDataset7();

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.Evaluate();

            // Assert
            core.rules.GetRule("R4").Consequent.Answer.Should().Be(Answer.No, "True && False && False => False");
        }
        #endregion Evaluate

        #region Level 5
        // (R1 && R2) => R3  ( R3 && R4 ) => R5
        // (True && True) => True 
        // R5 = ( True && True ) => True
        [TestMethod]
        public void Evaluate_L0501()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetL0501();

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.Evaluate();

            // Assert
            core.rules.GetRule("R5").Consequent.Answer.Should().Be(Answer.Yes, "(True && True) => True ( True && True ) => True");
        }

        // (R1 && R2) => R3  ( R3 && R4 ) => R5
        // (True && False) => False
        // R5 = ( False && True ) => False
        [TestMethod]
        public void Evaluate_L0502()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetL0502();

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.Evaluate();

            // Assert
            core.rules.GetRule("R5").Consequent.Answer.Should().Be(Answer.No, "(True && False) => False ( False && True ) => False");
        }



        // (R1 && R2) => R3  ( R3 && R4 ) => R5
        // (True && False) => False
        // R5 = ( False && True ) => False
        [TestMethod]
        public void Evaluate_L0503()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetL0503();

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.Evaluate();

            // Assert
            core.rules.GetRule("R5").Consequent.Answer.Should().Be(Answer.No, "(True && False) => False ( False && True ) => False");
        }

        // R1 = (R2 && R3) => True
        // R5 = ( R1 && R4 ) => True
        // R7 = ( R5 && R6) => True
        [TestMethod]
        public void Evaluate_L0504()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetL0504();

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.Evaluate();

            // Assert
            core.rules.GetRule("R7").Consequent.Answer.Should().Be(Answer.Yes, "R1 && R5 && R7 => True");
        }
        
        // R1 = (R2 && R3) => True
        // R5 = ( R1 && R4 ) => False
        // R7 = ( R5 && R6) => True
        [TestMethod]
        public void Evaluate_L0505()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetL0505();

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.Evaluate();

            // Assert
            core.rules.GetRule("R7").Consequent.Answer.Should().Be(Answer.No, "R1 && R5 && R7 => False");
        }
        #endregion Level 5

        #region IsGroup 

        [TestMethod]
        public void IsGroup_Should_Return_False_When_Is_Not_A_Not_Operator()
        {
            // Arrange
            Expressions expressions = new Expressions();

            Expression expression = null;

            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.And
            };

            OperatorElement operatorElementNext = null;

            // Act
            bool result = Core.IsGroup(expressions, expression, operatorElement, operatorElementNext);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void IsGroup_Should_Return_True_When_Is_A_Not_Operator_And_Next_Operator_Is_Letparenthese()
        {
            // Arrange
            Expressions expressions = new Expressions();

            Expression expression = new Expression();

            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.Not
            };

            OperatorElement operatorElementNext = new OperatorElement
            {
                Symbole = OperatorSymbole.Leftparentheses
            };

            // Act
            bool result = Core.IsGroup(expressions, expression, operatorElement, operatorElementNext);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void IsGroup_Should_Return_False_When_Is_A_Not_Operator_And_Next_Operator_Is_False()
        {
            // Arrange
            Expressions expressions = new Expressions();

            Expression expression = null;

            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.Not
            };

            OperatorElement operatorElementNext = new OperatorElement
            {
                Symbole = OperatorSymbole.False
            };

            // Act
            bool result = Core.IsGroup(expressions, expression, operatorElement, operatorElementNext);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void IsGroup_Should_Return_False_When_Is_A_Not_Operator_And_Next_Operator_Is_True()
        {
            // Arrange
            Expressions expressions = new Expressions();

            Expression expression = null;

            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.Not
            };

            OperatorElement operatorElementNext = new OperatorElement
            {
                Symbole = OperatorSymbole.True
            };

            // Act
            bool result = Core.IsGroup(expressions, expression, operatorElement, operatorElementNext);

            // Assert
            result.Should().BeFalse();
        }
        
        [TestMethod]
        public void IsGroup_Should_Return_True_When_Is_A_LeftParenthese()
        {
            // Arrange
            Expressions expressions = new Expressions();

            Expression expression = new Expression();

            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.Leftparentheses
            };

            OperatorElement operatorElementNext = new OperatorElement
            {
                Symbole = OperatorSymbole.True
            };

            // Act
            bool result = Core.IsGroup(expressions, expression, operatorElement, operatorElementNext);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void IsGroup_Should_Return_True_When_Is_A_RightParenthese()
        {
            // Arrange
            Expressions expressions = new Expressions();

            Expression expression = new Expression();

            OperatorElement operatorElement = new OperatorElement
            {
                Symbole = OperatorSymbole.Leftparentheses
            };

            OperatorElement operatorElementNext = new OperatorElement
            {
                Symbole = OperatorSymbole.True
            };

            // Act
            bool result = Core.IsGroup(expressions, expression, operatorElement, operatorElementNext);

            // Assert
            result.Should().BeTrue();
        }

        #endregion IsGroup

        #region private

        private Facts FactsDataSet()
        {
            Facts facts = new Facts
            {
                Name = "Arbeids- en ontslagrecht",
                Rows =
                {
                    new Fact
                    {
                        Id = 1,
                        Name = "F1",
                        Question = "Is er voor betrokkene sprake van een arbeidsovereenkomst voor onbepaalde tijd?"
                     },
                    new Fact
                    {
                        Id = 2,
                        Name = "F2",
                        Question = "Is er sprake van een arbeidsovereenkomst tussen betrokkene en zijn/haar werkgever?"
                    },
                    new Fact
                    {
                        Id = 3,
                        Name = "F3",
                        Question = "Is het moment van eindigen van de arbeidsovereenkomst bepaald?"
                    },
                    new Fact
                    {
                        Id = 4,
                        Name = "F4",
                        Question = "a?"
                    },
                    new Fact
                    {
                        Id = 5,
                        Name = "F5",
                        Question = "b?"
                    }
                }
            };
            return facts;
        }

        // R1 && R2 
        // True && True => True
        private Rules RulesDataset1()
        {
            Rules rules = new Rules
            {
                Name = "R1",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "F1",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "R1 && R2",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // ! R1 && R2 
        // True && True => False
        private Rules RulesDataset1A()
        {
            Rules rules = new Rules
            {
                Name = "R1",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "F1",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "! R1 && R2",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // R1 && ! R2 
        // True && ! True => False
        private Rules RulesDataset1B()
        {
            Rules rules = new Rules
            {
                Name = "R1",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "F1",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "R1 && ! R2",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // ! R1 && ! R2 
        // ! True && ! True => False
        private Rules RulesDataset1C()
        {
            Rules rules = new Rules
            {
                Name = "R1",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "F1",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "! R1 && ! R2",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // R1 || R2 
        // True || True => True
        private Rules RulesDataset2()
        {
            Rules rules = new Rules
            {
                Name = "R1",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "F1",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "R1 || R2",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // R1 && R2 
        // False && True => False
        private Rules RulesDataset3()
        {
            Rules rules = new Rules
            {
                Name = "R1",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "F1",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.No
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "R1 && R2",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // R1 || R2 
        // False || True => True
        private Rules RulesDataset4()
        {
            Rules rules = new Rules
            {
                Name = "R1",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "F1",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.No
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "R1 || R2",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // R1 || R2 
        // False || False => False
        private Rules RulesDataset5()
        {
            Rules rules = new Rules
            {
                Name = "R1",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "F1",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.No
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.No
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "R1 || R2",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // R1 && R2 && R3
        // True && True && True => True
        private Rules RulesDataset6()
        {
            Rules rules = new Rules
            {
                Name = "R1",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "F1",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "F3",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 4,
                        Name = "R4",
                        Logic = "( R1 && R2 ) && R3",
                        Consequent = new Consequent()
                        {
                            Id = 4,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // R1 && R2 && R3
        // True && True && False => False
        private Rules RulesDataset7()
        {
            Rules rules = new Rules
            {
                Name = "R1",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "F1",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "F3",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.No
                        }
                    },
                    new Rule
                    {
                        Id = 4,
                        Name = "R4",
                        Logic = "( R1 && R2 ) && R3",
                        Consequent = new Consequent()
                        {
                            Id = 4,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // R1 && R2 && R3
        // True && False && False => False
        private Rules RulesDataset8()
        {
            Rules rules = new Rules
            {
                Name = "R1",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "F1",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.No
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "F3",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.No
                        }
                    },
                    new Rule
                    {
                        Id = 4,
                        Name = "R4",
                        Logic = "( R1 && R2 ) && R3",
                        Consequent = new Consequent()
                        {
                            Id = 4,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // R1 && R2 && R3
        // True && True && True => True
        private Rules RulesDataset0201()
        {
            Rules rules = new Rules
            {
                Name = "R1",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "F1",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "F3",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 4,
                        Name = "R4",
                        Logic = "( R1 && R2 ) && R3",
                        Consequent = new Consequent()
                        {
                            Id = 4,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // R1 && R2 && R3
        // True && ( True && True )=> True
        private Rules RulesDataset020102()
        {
            Rules rules = new Rules
            {
                Name = "R1",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "F1",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "F3",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 4,
                        Name = "R4",
                        Logic = "R1 && ( R2 && R3 )",
                        Consequent = new Consequent()
                        {
                            Id = 4,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // R1 && R2 && R3
        // True && True && False => False
        private Rules RulesDataset0202()
        {
            Rules rules = new Rules
            {
                Name = "R1",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "F1",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "F3",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.No
                        }
                    },
                    new Rule
                    {
                        Id = 4,
                        Name = "R4",
                        Logic = "( R1 && R2 ) && R3",
                        Consequent = new Consequent()
                        {
                            Id = 4,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // R1 && R2 && R3
        // True && False && True => False
        private Rules RulesDataset0203()
        {
            Rules rules = new Rules
            {
                Name = "R1",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "F1",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.No
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "F3",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 4,
                        Name = "R4",
                        Logic = "( R1 && R2 ) && R3",
                        Consequent = new Consequent()
                        {
                            Id = 4,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // R1 && R2 && R3
        // True && False && True => False
        private Rules RulesDataset0204()
        {
            Rules rules = new Rules
            {
                Name = "R1",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "F1",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.No
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "F3",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 4,
                        Name = "R4",
                        Logic = "( R1 && R2 ) && R3",
                        Consequent = new Consequent()
                        {
                            Id = 4,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }
        #endregion private

        #region 5 Rules

        // (R1 && R2) => R3  ( R3 && R4 ) => R3
        // (True && True) => True 
        // R5 = ( True && True ) => True
        private Rules RulesDatasetL0501()
        {
            Rules rules = new Rules
            {
                Name = "R1",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "F1",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "R1 && R2",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.Unknown
                        }
                    },
                    new Rule
                    {
                        Id = 4,
                        Name = "R4",
                        Logic = "F4",
                        Consequent = new Consequent()
                        {
                            Id = 4,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 5,
                        Name = "R5",
                        Logic = "R3 && R4",
                        Consequent = new Consequent()
                        {
                            Id = 5,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // (R1 && R2) => R3  ( R3 && R4 ) => R3
        // (True && False) => False
        // R5 = ( False && True ) => False
        private Rules RulesDatasetL0502()
        {
            Rules rules = new Rules
            {
                Name = "R1",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "F1",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.No
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "R1 && R2",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.Unknown
                        }
                    },
                    new Rule
                    {
                        Id = 4,
                        Name = "R4",
                        Logic = "F4",
                        Consequent = new Consequent()
                        {
                            Id = 4,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 5,
                        Name = "R5",
                        Logic = "R3 && R4",
                        Consequent = new Consequent()
                        {
                            Id = 5,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // (R1 && R2) => R3  ( R3 && R4 ) => R5
        // (True && False) => False
        // R5 = ( False && True ) => False
        private Rules RulesDatasetL0503()
        {
            Rules rules = new Rules
            {
                Name = "Rules",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "R2 && R3",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.Unknown
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "F3",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.No
                        }
                    },
                    
                    new Rule
                    {
                        Id = 4,
                        Name = "R4",
                        Logic = "F4",
                        Consequent = new Consequent()
                        {
                            Id = 4,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 5,
                        Name = "R5",
                        Logic = "R1 && R4",
                        Consequent = new Consequent()
                        {
                            Id = 5,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // R1 = (R2 && R3) => True
        // R5 = ( R1 && R4 ) => True
        // R7 = ( R5 && R6) => True
        private Rules RulesDatasetL0504()
        {
            Rules rules = new Rules
            {
                Name = "Rules",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "R2 && R3",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.Unknown
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "F3",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 4,
                        Name = "R4",
                        Logic = "F4",
                        Consequent = new Consequent()
                        {
                            Id = 4,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 5,
                        Name = "R5",
                        Logic = "R1 && R4",
                        Consequent = new Consequent()
                        {
                            Id = 5,
                            Answer = Answer.Unknown
                        }
                    },
                    new Rule
                    {
                        Id = 6,
                        Name = "R6",
                        Logic = "F6",
                        Consequent = new Consequent()
                        {
                            Id = 6,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 7,
                        Name = "R7",
                        Logic = "R5 && R6",
                        Consequent = new Consequent()
                        {
                            Id = 7,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }

        // R1 = (R2 && R3) => True
        // R5 = ( R1 && R4 ) => False R4 = False
        // R7 = ( R5 && R6) => True
        private Rules RulesDatasetL0505()
        {
            Rules rules = new Rules
            {
                Name = "Rules",
                Rows = {
                    new Rule
                    {
                        Id = 1,
                        Name = "R1",
                        Logic = "R2 && R3",
                        Consequent = new Consequent()
                        {
                            Id = 1,
                            Answer = Answer.Unknown
                        }
                    },
                    new Rule
                    {
                        Id = 2,
                        Name = "R2",
                        Logic = "F2",
                        Consequent = new Consequent()
                        {
                            Id = 2,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 3,
                        Name = "R3",
                        Logic = "F3",
                        Consequent = new Consequent()
                        {
                            Id = 3,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 4,
                        Name = "R4",
                        Logic = "F4",
                        Consequent = new Consequent()
                        {
                            Id = 4,
                            Answer = Answer.No
                        }
                    },
                    new Rule
                    {
                        Id = 5,
                        Name = "R5",
                        Logic = "R1 && R4",
                        Consequent = new Consequent()
                        {
                            Id = 5,
                            Answer = Answer.Unknown
                        }
                    },
                    new Rule
                    {
                        Id = 6,
                        Name = "R6",
                        Logic = "F6",
                        Consequent = new Consequent()
                        {
                            Id = 6,
                            Answer = Answer.Yes
                        }
                    },
                    new Rule
                    {
                        Id = 7,
                        Name = "R7",
                        Logic = "R5 && R6",
                        Consequent = new Consequent()
                        {
                            Id = 7,
                            Answer = Answer.Unknown
                        }
                    }
                  }
            };
            return rules;
        }
        #endregion 5 Rules
    }
}
