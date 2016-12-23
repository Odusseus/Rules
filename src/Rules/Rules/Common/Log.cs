namespace Odusseus.Rules.Common
{
    using System.Diagnostics;
    using Odusseus.Rules.Model.Enumeration;

    public static class Log
    {
        public static void Write(Level level, string text)
        {
            Output output = Output.Debug; // TODO Only 1 output in now available

            if (level.getValue() > Tools.GetConfig(Constants.DEFAULTLEVEL).getLevel().getValue())
            {
                return;
            }

            if(output == Output.Debug)
            {
                Debug.WriteLine(text);
                return;
            }
        }
    }
}
