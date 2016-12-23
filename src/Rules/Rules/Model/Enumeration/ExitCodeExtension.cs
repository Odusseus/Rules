namespace Odusseus.Rules.Model.Enumeration
{
    using Odusseus.Rules.Model.Enumeration;

    public static class ExitCodeExtension
    {
        public static int Code(this ExitCode code)
        {
            int value = (int)code;
            return value;
        }

    }
}
