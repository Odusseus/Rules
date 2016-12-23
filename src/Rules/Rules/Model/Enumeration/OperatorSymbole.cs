namespace Odusseus.Rules.Model.Enumeration
{
    using System.ComponentModel.DataAnnotations;

    public enum OperatorSymbole
    {
        New = -1,
        Undefined = 0,
        DoNotKnow = 1,
        True = 2,
        False = 3,
        Not = 4,
        And = 5,
        Or = 6,
        Rightparentheses = 7,
        Leftparentheses = 8
    }
}