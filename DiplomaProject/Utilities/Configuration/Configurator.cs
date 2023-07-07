using Microsoft.Extensions.Configuration;

namespace DiplomaProject.Utilities.Configuration
{
    public static class Configurator
    {
        static Configurator()
        {
            _configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }


        private static readonly Lazy<IConfiguration> _configuration;

        public static IConfiguration Configuration => _configuration.Value;

        public static AppSettings AppSettings
        {
            get
            {
                var appSettings = new AppSettings();
                var child = Configuration.GetSection("AppSettings");

                appSettings.URL = child["URL"];
                appSettings.BearerToken = child["BearerToken"];

                return appSettings;
            }
        }

        public static string? Browser => Configuration["Browser"];


        private static IConfiguration BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }
}
