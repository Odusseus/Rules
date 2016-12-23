namespace Odusseus.Rules.Model.Enumeration
{
    public static class AnswerExtension
    {
        public static OperatorSymbole GetCode(this Answer answer)
        {
            switch(answer)
            {
                case Answer.Yes:
                    return OperatorSymbole.True;
                case Answer.No:
                    return OperatorSymbole.False;
                case Answer.DoNotKnow:
                    return OperatorSymbole.DoNotKnow;
                case Answer.Unknown:
                default:
                    return OperatorSymbole.Undefined;
            }
        }
    }
}
