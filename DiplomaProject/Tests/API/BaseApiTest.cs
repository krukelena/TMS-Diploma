using Allure.Commons;
using DiplomaProject.Utilities.Configuration;
using NLog;
using RestSharp;

namespace DiplomaProject.Tests.API
{
    public abstract class BaseApiTest : BaseTest
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        protected AppSettings _appSettings;
        protected RestClient _client;
        private AllureLifecycle _allure;


        [SetUp]
        public void Setup()
        {

            _logger.Trace("Сообщение уровня Trace");
            _logger.Debug("Сообщение уровня Debag");
            _logger.Info("Сообщение уровня Info");
            _logger.Warn("Сообщение уровня Warn");
            _logger.Error("Сообщение уровня Error");
            _logger.Fatal("Сообщение уровня Fatal");

            _allure = AllureLifecycle.Instance;
            _logger.Trace("Setup");

            _appSettings = Configurator.Instance.AppSettings;
            if (_appSettings == null)
                throw new Exception("Cannot read App Settings configuration!");

            _client = new RestClient(baseUrl: _appSettings.URL);

            var request = new RestRequest("api/v1/user", Method.Get);
            AddAuthorizationHeader(request);

            _client.Execute(request);
        }

        [TearDown]
        public void Teardown() 
        {
            _logger.Trace("Teardown");
        }


        protected void AddAuthorizationHeader(RestRequest request)
        {
            request.AddHeader("Authorization", _appSettings.BearerToken);
        }

        protected void AssertResponse(RestResponse response)
        {
            Assert.IsTrue(response.IsSuccessful);
        }
    }
}
