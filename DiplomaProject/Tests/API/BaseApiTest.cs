using DiplomaProject.Utilities.Configuration;
using RestSharp;

namespace DiplomaProject.Tests.API
{
    public abstract class BaseApiTest : BaseTest
    {
        protected AppSettings _appSettings;
        protected RestClient _client;


        [SetUp]
        public void Setup()
        {
            _appSettings = Configurator.AppSettings;
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
