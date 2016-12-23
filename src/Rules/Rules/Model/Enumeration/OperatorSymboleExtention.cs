namespace Odusseus.Rules.Model.Enumeration
    {
        using Odusseus.Rules.Model.Enumeration;
    
        public static class OperatorSymboleExtention
        {
            public static string getCode(this OperatorSymbole value)
            {
                switch (value)
                {
                    case OperatorSymbole.And:
                        return Common.Constants.AND;
                    case OperatorSymbole.Or:
                        return Common.Constants.OR;
                    case OperatorSymbole.Not:
                        return Common.Constants.NOT;
                    case OperatorSymbole.Leftparentheses:
                        return Common.Constants.Leftparentheses;
                    case OperatorSymbole.Rightparentheses:
                        return Common.Constants.Rightparentheses;
                    case OperatorSymbole.True:
                        return Common.Constants.TRUE;
                    case OperatorSymbole.False:
                        return Common.Constants.FALSE;
                    default:
                        return string.Empty;
                }
            }

        public static int getValue(this OperatorSymbole value)
        {
            switch (value)
            {
                case OperatorSymbole.And:
                    return (int) OperatorSymbole.And;
                case OperatorSymbole.Or:
                    return (int)OperatorSymbole.Or;
                case OperatorSymbole.Not:
                    return (int)OperatorSymbole.Not;
                case OperatorSymbole.Leftparentheses:
                    return (int)OperatorSymbole.Leftparentheses;
                case OperatorSymbole.Rightparentheses:
                    return (int)OperatorSymbole.Rightparentheses;
                case OperatorSymbole.True:
                    return (int)OperatorSymbole.True;
                case OperatorSymbole.False:
                    return (int)OperatorSymbole.False;
                default:
                    return (int)OperatorSymbole.Undefined;
            }
        }

        public static OperatorSymbole getOperatorSymbole(this string value)
            {
                switch (value)
                {
                    case Common.Constants.AND:
                        return OperatorSymbole.And;
                    case Common.Constants.OR:
                        return OperatorSymbole.Or;
                    case Common.Constants.NOT:
                        return OperatorSymbole.Not;
                    case Common.Constants.Leftparentheses:
                        return OperatorSymbole.Leftparentheses;
                    case Common.Constants.Rightparentheses:
                        return OperatorSymbole.Rightparentheses;
                    default:
                        return OperatorSymbole.Undefined;
                }
            }

        public static Answer getAnswer(this OperatorSymbole value)
        {
            switch (value)
            {
                case OperatorSymbole.True:
                    return Answer.Yes;
                case OperatorSymbole.False:
                    return Answer.No;
                case OperatorSymbole.DoNotKnow:
                    return Answer.DoNotKnow;
                case OperatorSymbole.Undefined:
                default:
                    return Answer.Unknown;
            }
        }

        public static bool IsTrue(this OperatorSymbole value)
        {
            if(value == OperatorSymbole.True)
            {
                return true;
            }

            return false;

        }

        public static bool IsFalse(this OperatorSymbole value)
        {
            if (value == OperatorSymbole.False)
            {
                return true;
            }

            return false;
        }
    }
    }
