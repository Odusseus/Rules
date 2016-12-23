namespace Odusseus.RulesTests
    {
        using System;
        using System.Linq;
        using Microsoft.VisualStudio.TestTools.UnitTesting;
        using FluentAssertions;
        using Odusseus.Rules;
        using Odusseus.Rules.Model;
        using Rules.Model.Enumeration;
        using System.Collections.Generic;

        [TestClass]
        public class CoreConvertConditionToAnswerTest
        {
            #region ConvertConditionsToAnswer
            // R1 && R2 
            // True && True => True
            [TestMethod]
            public void ConvertConditionsToAnswer_RulesDataset1()
            {
                // Arrange
                OperatorElements operatorElements = new OperatorElements();
                Facts facts = this.FactsDataSet();
                Rules rules = this.RulesDataset1();

                foreach (Rule rule in rules.Rows)
                {
                    rule.ConvertLogicToConditions(operatorElements, rules, facts);
                }

                Core core = new Core(operatorElements, facts, rules);

                // Act
                core.ConvertConditionsToAnswer();

                // Assert
                core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.Yes);
            }

            // R1 || R2 
            // True || True => True
            [TestMethod]
            public void ConvertConditionsToAnswer_RulesDataset2()
            {
                // Arrange
                OperatorElements operatorElements = new OperatorElements();
                Facts facts = this.FactsDataSet();
                Rules rules = this.RulesDataset2();

                foreach (Rule rule in rules.Rows)
                {
                    rule.ConvertLogicToConditions(operatorElements, rules, facts);
                }

                Core core = new Core(operatorElements, facts, rules);

                // Act
                core.ConvertConditionsToAnswer();

                // Assert
                core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.Yes);
            }

            // R1 && R2 
            // False && True => False
            [TestMethod]
            public void ConvertConditionsToAnswer_RulesDataset3()
            {
                // Arrange
                OperatorElements operatorElements = new OperatorElements();
                Facts facts = this.FactsDataSet();
                Rules rules = this.RulesDataset3();

                foreach (Rule rule in rules.Rows)
                {
                    rule.ConvertLogicToConditions(operatorElements, rules, facts);
                }

                Core core = new Core(operatorElements, facts, rules);

                // Act
                core.ConvertConditionsToAnswer();

                // Assert
                core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.No);
            }

            // R1 || R2 
            // False || True => True
            [TestMethod]
            public void ConvertConditionsToAnswer_RulesDataset4()
            {
                // Arrange
                OperatorElements operatorElements = new OperatorElements();
                Facts facts = this.FactsDataSet();
                Rules rules = this.RulesDataset4();

                foreach (Rule rule in rules.Rows)
                {
                    rule.ConvertLogicToConditions(operatorElements, rules, facts);
                }

                Core core = new Core(operatorElements, facts, rules);

                // Act
                core.ConvertConditionsToAnswer();

                // Assert
                core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.Yes);
            }

            // R1 || R2 
            // False || False => False
            [TestMethod]
            public void ConvertConditionsToAnswer_RulesDataset5()
            {
                // Arrange
                OperatorElements operatorElements = new OperatorElements();
                Facts facts = this.FactsDataSet();
                Rules rules = this.RulesDataset5();

                foreach (Rule rule in rules.Rows)
                {
                    rule.ConvertLogicToConditions(operatorElements, rules, facts);
                }

                Core core = new Core(operatorElements, facts, rules);

                // Act
                core.ConvertConditionsToAnswer();

                // Assert
                core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.No);
            }

        #endregion ConvertConditionsToAnswer

            #region ConvertConditionsToAnswer Undefined

            // R1 && R2 
            // True && Undefined => Undefined
            [TestMethod]
            public void ConvertConditionsToAnswer_RulesDatasetUndefined1()
            {
                // Arrange
                OperatorElements operatorElements = new OperatorElements();
                Facts facts = this.FactsDataSet();
                Rules rules = this.RulesDatasetUndefined1();

                foreach (Rule rule in rules.Rows)
                {
                    rule.ConvertLogicToConditions(operatorElements, rules, facts);
                }

                Core core = new Core(operatorElements, facts, rules);

                // Act
                core.ConvertConditionsToAnswer();

                // Assert
                core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.Unknown, "R2 is unknown");
            }

        // R1 && R2 
        // Undefined && True => Undefined
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetUndefined2()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetUndefined2();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.Unknown, "R1 is unknown");
        }

        // R1 && R2 
        // Undefined && Undefined => Undefined
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetUndefined3()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetUndefined3();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.Unknown, "R1 and R2 are unknown");
        }

        // R1 || R2 
        // True || Undefined => True
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetUndefined4()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetUndefined4();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.Yes, "R1 is Yes");
        }

        // R1 || R2 
        // Undefined || True => True
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetUndefined5()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetUndefined5();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.Yes, "R2 is Yes");
        }

        // R1 || R2 
        // Undefined || Undefined => Undefined
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetUndefined6()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetUndefined6();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.Unknown, "R1 and R2 are Unkown");
        }
        #endregion ConvertConditionsToAnswer Undefined

            #region ConvertConditionsToAnswer DoNotKnow

        // R1 && R2 
        // True && DoNotKnow => DoNotKnow
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetDoNotKnow1()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetDoNotKnow1();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.DoNotKnow, "R2 is DoNotKnow");
        }

        // R1 && R2 
        // DoNotKnow && True => DoNotKnow
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetDoNotKnow2()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetDoNotKnow2();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.DoNotKnow, "R1 is unknown");
        }

        // R1 && R2 
        // DoNotKnow && DoNotKnow => DoNotKnow
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetDoNotKnow3()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetDoNotKnow3();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.DoNotKnow, "R1 and R2 are unknown");
        }

        // R1 || R2 
        // True || DoNotKnow => True
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetDoNotKnow4()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetDoNotKnow4();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.Yes, "R1 is Yes");
        }

        // R1 || R2 
        // DoNotKnow || True => True
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetDoNotKnow5()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetDoNotKnow5();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.Yes, "R2 is Yes");
        }

        // R1 || R2 
        // DoNotKnow || DoNotKnow => DoNotKnow
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetDoNotKnow6()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetDoNotKnow6();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R3").Consequent.Answer.Should().Be(Answer.DoNotKnow, "R1 and R2 are Unkown");
        }
        #endregion ConvertConditionsToAnswer DoNotKnow

            #region ConvertConditionsToAnswer Level 3 And

            // ( R1 && R2 ) && R3
            // True && True && True => True
            [TestMethod]
            public void ConvertConditionsToAnswer_RulesDataset0201()
            {
                // Arrange
                OperatorElements operatorElements = new OperatorElements();
                Facts facts = this.FactsDataSet();
                Rules rules = this.RulesDataset0201();

                foreach (Rule rule in rules.Rows)
                {
                    rule.ConvertLogicToConditions(operatorElements, rules, facts);
                }

                Core core = new Core(operatorElements, facts, rules);

                // Act
                core.ConvertConditionsToAnswer();

                // Assert
                core.rules.GetRule("R4").Consequent.Answer.Should().Be(Answer.Yes, "( True && True ) && True => True");
            }

            // R1 && ( R2 && R3 )
            // True && ( True && True )=> True
            [TestMethod]
            public void ConvertConditionsToAnswer_RulesDataset020102()
            {
                // Arrange
                OperatorElements operatorElements = new OperatorElements();
                Facts facts = this.FactsDataSet();
                Rules rules = this.RulesDataset020102();

                foreach (Rule rule in rules.Rows)
                {
                    rule.ConvertLogicToConditions(operatorElements, rules, facts);
                }

                Core core = new Core(operatorElements, facts, rules);

                // Act
                core.ConvertConditionsToAnswer();

                // Assert
                core.rules.GetRule("R4").Consequent.Answer.Should().Be(Answer.Yes, "True && ( True && True ) => True");
            }

            // ( R1 && R2 ) && R3
            // (True && True) && False => False
            [TestMethod]
            public void ConvertConditionsToAnswer_RulesDataset0202()
            {
                // Arrange
                OperatorElements operatorElements = new OperatorElements();
                Facts facts = this.FactsDataSet();
                Rules rules = this.RulesDataset0202();

                foreach (Rule rule in rules.Rows)
                {
                    rule.ConvertLogicToConditions(operatorElements, rules, facts);
                }

                Core core = new Core(operatorElements, facts, rules);

                // Act
                core.ConvertConditionsToAnswer();

                // Assert
                core.rules.GetRule("R4").Consequent.Answer.Should().Be(Answer.No, "(True && True) && False => False");
            }

            // ( R1 && R2 ) && R3
            // ( True && False ) && True => False
            [TestMethod]
            public void ConvertConditionsToAnswer_RulesDataset0203()
            {
                // Arrange
                OperatorElements operatorElements = new OperatorElements();
                Facts facts = this.FactsDataSet();
                Rules rules = this.RulesDataset0203();

                foreach (Rule rule in rules.Rows)
                {
                    rule.ConvertLogicToConditions(operatorElements, rules, facts);
                }

                Core core = new Core(operatorElements, facts, rules);

                // Act
                core.ConvertConditionsToAnswer();

                // Assert
                core.rules.GetRule("R4").Consequent.Answer.Should().Be(Answer.No, "( True && False ) && True => False");
            }

            // (R1 && R2) && R3
            // (False && True) && True => False
            [TestMethod]
            public void ConvertConditionsToAnswer_RulesDataset0204()
            {
                // Arrange
                OperatorElements operatorElements = new OperatorElements();
                Facts facts = this.FactsDataSet();
                Rules rules = this.RulesDataset0204();

                foreach (Rule rule in rules.Rows)
                {
                    rule.ConvertLogicToConditions(operatorElements, rules, facts);
                }

                Core core = new Core(operatorElements, facts, rules);

                // Act
                core.ConvertConditionsToAnswer();

                // Assert
                core.rules.GetRule("R4").Consequent.Answer.Should().Be(Answer.No, "(False && True) && True => False");
            }

        #endregion ConvertConditionsToAnswer Level 3 And

        #region ConvertConditionsToAnswer Level 3 Or

        // ( R1 || R2 ) || R3
        // (True || True) || True => True
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetOr0201()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetOr0201();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R4").Consequent.Answer.Should().Be(Answer.Yes, "(True || True) || True => True");
        }

        // R1 || ( R2 || R3 )
        // True || ( True || True )=> True
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetOr020102()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetOr020102();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R4").Consequent.Answer.Should().Be(Answer.Yes, "True || ( True || True ) => True");
        }

        // ( R1 || R2 ) || R3
        // (True || True) || False => True
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetOr0202()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetOr0202();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R4").Consequent.Answer.Should().Be(Answer.Yes, "(True || True) || False => True");
        }

        // ( R1 || R2 ) || R3
        // ( True || False ) || True => True
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetOr0203()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetOr0203();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R4").Consequent.Answer.Should().Be(Answer.Yes, "( True || False ) || True => True");
        }

        // (R1 || R2) || R3
        // (False || True) || True => True
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetOr0204()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetOr0204();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R4").Consequent.Answer.Should().Be(Answer.Yes, "(False || True) || True => True");
        }

        #endregion ConvertConditionsToAnswer Level 3 Or


        #region ConvertConditionsToAnswer Level 4

        // (R1 || R2) && ( R3 && R4 )
        // (False || True) && ( True && False ) => False
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetL0401()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetOrL0401();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R5").Consequent.Answer.Should().Be(Answer.No, "(R1 || R2) && ( R3 && R4 )");
        }

        // (R1 || R2) && ( R3 && R4 )
        // (False || True) && ( True && True ) => True
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetL0402()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetOrL0402();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R5").Consequent.Answer.Should().Be(Answer.Yes, "(False || True) && ( True && True ) => True");
        }

        // (!R1 || !R2) && ( !R3 && !R4 )
        // (True || False) || ( False && False ) => True
        [TestMethod]
        public void ConvertConditionsToAnswer_RulesDatasetL0403()
        {
            // Arrange
            OperatorElements operatorElements = new OperatorElements();
            Facts facts = this.FactsDataSet();
            Rules rules = this.RulesDatasetOrL0403();

            foreach (Rule rule in rules.Rows)
            {
                rule.ConvertLogicToConditions(operatorElements, rules, facts);
            }

            Core core = new Core(operatorElements, facts, rules);

            // Act
            core.ConvertConditionsToAnswer();

            // Assert
            core.rules.GetRule("R5").Consequent.Answer.Should().Be(Answer.Yes, "(True || False) || ( False && False ) => True");
        }
        #endregion ConvertConditionsToAnswer Level 4

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
                        Question = "x?"
                    },
                    new Fact
                    {
                        Id = 5,
                        Name = "F5",
                        Question = "y?"
                    }
                }
                };
                return facts;
            }
        #endregion private

        #region RulesDataset 2 Rules
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
        // XXXXXXXXXXXXXXXXXX
        // R1 && R2 
        // True && Undefined => Undefined
        private Rules RulesDatasetUndefined1()
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
                            Answer = Answer.Unknown
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

        // R1 && R2 
        // Undefined && True => Undefined
        private Rules RulesDatasetUndefined2()
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

        // R1 && R2 
        // Undefined && Undefined => Undefined
        private Rules RulesDatasetUndefined3()
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
                            Answer = Answer.Unknown
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

        //--------------------

        // R1 || R2 
        // True || Undefined => True
        private Rules RulesDatasetUndefined4()
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
                            Answer = Answer.Unknown
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
        // Undefined || True => True
        private Rules RulesDatasetUndefined5()
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
        // Undefined || Undefined => Undefined
        private Rules RulesDatasetUndefined6()
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
                            Answer = Answer.Unknown
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

        #endregion RulesDataset 2 Rules

        #region DoNotKnow
        // R1 && R2 
        // True && DoNotKnow => DoNotKnow
        private Rules RulesDatasetDoNotKnow1()
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
                            Answer = Answer.DoNotKnow
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

        // R1 && R2 
        // DoNotKnow && True => DoNotKnow
        private Rules RulesDatasetDoNotKnow2()
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
                            Answer = Answer.DoNotKnow
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

        // R1 && R2 
        // DoNotKnow && DoNotKnow => DoNotKnow
        private Rules RulesDatasetDoNotKnow3()
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
                            Answer = Answer.DoNotKnow
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
                            Answer = Answer.DoNotKnow
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

        //--------------------

        // R1 || R2 
        // True || DoNotKnow => True
        private Rules RulesDatasetDoNotKnow4()
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
                            Answer = Answer.DoNotKnow
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
        // DoNotKnow || True => True
        private Rules RulesDatasetDoNotKnow5()
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
                            Answer = Answer.DoNotKnow
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
        // DoNotKnow || DoNotKnow => DoNotKnow
        private Rules RulesDatasetDoNotKnow6()
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
                            Answer = Answer.DoNotKnow
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
                            Answer = Answer.DoNotKnow
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
        #endregion DoNotKnow


        #region 3 Rules
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

            // ( R1 && R2 ) && R3
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

            // ( R1 && R2 ) && R3
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

            // ( R1 && R2 )&& R3
            // ( True && False ) && True => False
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

            // (R1 && R2) && R3
            // (False && True) && True => False
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
        #endregion 3 Rules

        #region 3 Rules Or
        // ( R1 || R2 ) || R3
        // True || True || True => True
        private Rules RulesDatasetOr0201()
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
                        Logic = "( R1 || R2 ) || R3",
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

        // R1 || R2 || R3
        // True || ( True || True )=> True
        private Rules RulesDatasetOr020102()
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
                        Logic = "R1 || ( R2 || R3 )",
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

        // ( R1 || R2 ) || R3
        // True || True || False => False
        private Rules RulesDatasetOr0202()
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
                        Logic = "( R1 || R2 ) || R3",
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

        // ( R1 || R2 )|| R3
        // ( True || False ) || True => False
        private Rules RulesDatasetOr0203()
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
                        Logic = "( R1 || R2 ) || R3",
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

        // (R1 || R2) || R3
        // (False || True) || True => True
        private Rules RulesDatasetOr0204()
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
                        Logic = "( R1 || R2 ) || R3",
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
        #endregion 3 Rules Or

        #region 4 Rules

        // (R1 || R2) && ( R3 && R4 )
        // (False || True) && ( True && False ) => False
        private Rules RulesDatasetOrL0401()
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
                        Logic = "(R1 || R2) && ( R3 && R4 )",
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

        // (R1 || R2) && ( R3 && R4 )
        // (False || True) && ( True && True ) => True
        private Rules RulesDatasetOrL0402()
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
                        Logic = "(R1 || R2) && ( R3 && R4 )",
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

        // (!R1 || !R2) || ( !R3 && !R4 )
        // (False || True) && ( True && True ) => True
        private Rules RulesDatasetOrL0403()
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
                        Logic = "(!R1 || !R2) || ( !R3 && !R4 )",
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

        #endregion 4 Rules

        
    }
}
