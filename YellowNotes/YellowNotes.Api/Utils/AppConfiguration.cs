using System.Configuration;

namespace YellowNotes.Api.Utils
{
    internal class AppConfiguration
    {
        public static int AccessTokenExpireTimeInMin = GetInt("AccessTokenExpireTimeInMin", 5);

        public static int RefreshTokenExpireTimeInMin = GetInt("RefreshTokenExpireTimeInMin", 15);

        public static string CorsPolicyOrigins = GetString("CorsPolicy.Origins", "*");

        protected static string GetString(string key, string defaultValue)
        {
            var value = ConfigurationManager.AppSettings[key];
            return value ?? defaultValue;
        }

        protected static int GetInt(string key, int defaultValue)
        {
            return int.Parse(GetString(key, defaultValue.ToString()));
        }
    }
}