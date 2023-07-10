using Microsoft.Extensions.Configuration;

namespace DiplomaProject.Utilities.Configuration
{
    public class Configurator
    {
        private static object _lockObject = new object();
        private static Configurator _instance;

       
        public static Configurator Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_lockObject)
                    {
                        if(_instance == null)
                        {
                            _instance = new Configurator();
                        }
                    }
                }

                return _instance;
            }
        }


        // тут как и раньше, только те
        private Configurator()
        {
            _configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private readonly Lazy<IConfiguration> _configuration;
        public IConfiguration Configuration => _configuration.Value;



        public AppSettings AppSettings
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

        public string? Browser => Configuration["Browser"];


        private IConfiguration BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }
}
