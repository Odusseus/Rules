namespace Odusseus.Rules.Model.Enumeration
{
    using Odusseus.Rules.Model.Enumeration;

    public static class LevelExtension
    {
        public static Level getLevel(this string value)
        {
            switch (value)
            {
                case Common.Constants.DEBUG:
                    return Level.Debug;
                case Common.Constants.ERROR:
                    return Level.Error;
                case Common.Constants.INFO:
                    return Level.Info;
                case Common.Constants.QUIET:
                    return Level.Quiet;
                case Common.Constants.TRACE:
                    return Level.Trace;
                case Common.Constants.WARNING:
                    return Level.Warning;
                default:
                    return Level.Error;
            }
        }

        public static int getValue(this Level value)
        {
            switch (value)
            {
                case Level.Debug:
                    return (int)Level.Debug;
                case Level.Error:
                    return (int)Level.Error;
                case Level.Info:
                    return (int)Level.Info;
                case Level.Quiet:
                    return (int)Level.Quiet;
                case Level.Trace:
                    return (int)Level.Trace;
                case Level.Warning:
                    return (int)Level.Warning;
                default:
                    return (int)Level.Quiet;
            }
        }
    }
}
