using DiplomaProject.Models;
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

        public User User
        {
            get
            {
                var user = new User();
                var child = Configuration.GetSection("User");

                user.Login = child["Login"];
                user.Password = child["Password"];

                return user;
            }
        }

        public string Browser => Configuration["Browser"] ?? "";


        private IConfiguration BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }
}
