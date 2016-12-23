namespace Odusseus.Rules.Model
{
    using System;
    using System.Collections.Generic;
    using Enumeration;

    public class OperatorElements
    {
        public List<OperatorElement> Rows = new List<OperatorElement>();

        public OperatorElements()
        {
            this.LoadOperators();
        }

        private void LoadOperators()
        {
            this.Rows = new List<OperatorElement>()
                        {
                            new OperatorElement
                            {
                                Id = OperatorSymbole.Not.getValue(),
                                Symbole = OperatorSymbole.Not
                            },
                            new OperatorElement
                            {
                                Id = OperatorSymbole.And.getValue(),
                                Symbole = OperatorSymbole.And
                            },
                            new OperatorElement
                            {
                                Id = OperatorSymbole.Or.getValue(),
                                Symbole = OperatorSymbole.Or
                            },
                           new OperatorElement
                           {
                               Id = OperatorSymbole.Leftparentheses.getValue(),
                               Symbole = OperatorSymbole.Leftparentheses
                           },
                           new OperatorElement
                           {
                               Id = OperatorSymbole.Rightparentheses.getValue(),
                               Symbole = OperatorSymbole.Rightparentheses
                           }};
        }

//private List<OperatorElement> List(OperatorElement operatorElement)
//        {
//            throw new NotImplementedException();
//        }
    }
}
