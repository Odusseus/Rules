namespace Odusseus.Rules.Common
{
    public static class Tools
    {
        public static string GetConfig(string key)
        {   // TODO http://stackoverflow.com/questions/34271032/how-to-read-an-appsettings-key

            //string LogDefaultLevel = AppSettings.Get("Log.DefaultLevel");

            if (key == "Log.DefaultLevel")
            {
                return Constants.LOGMINLEVEL;
            }

            return string.Empty;
        }

    }
}
