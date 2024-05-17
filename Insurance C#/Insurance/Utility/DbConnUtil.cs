using Microsoft.Extensions.Configuration;

namespace Insurance.Utility
{
    internal class DbConnUtil
    {
        private static IConfiguration _configuration;

        //Create a Constructor
        static DbConnUtil()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json");
            _configuration = builder.Build();
        }

        public static string GetConnectionString()
        {
            return _configuration.GetConnectionString("LocalConnectionString");
        }
    }
}
