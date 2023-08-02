using Allure.Commons;
using NLog;
using NUnit.Allure.Attributes;
using RestSharp;

namespace DiplomaProject.Tests.API
{
    public class GetTests : BaseApiTest
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();


        [Test, Category("NFE")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("GET_API")]
        [AllureIssue(name: "ID_API_1")]
        [AllureTag("Smoke")]
        [AllureLink("https://elenkakruk.testmo.net")]
        [Description("Получить проекты")]
        public void GetProjects()
        {
            _logger.Info("Test GetProducts started!");

            var request = new RestRequest("/api/v1/projects", Method.Get);
            AddAuthorizationHeader(request);

            AssertResponse(_client.Execute(request));

            _logger.Info("Test GetProducts finished!");
        }

        [Test, Category("NFE")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("GET_API")]
        [AllureIssue(name: "ID_API_2")]
        [AllureTag("Smoke")]
        [AllureLink("https://elenkakruk.testmo.net")]
        [Description("Получить роли на проекте")]
        public void GetRoles()
        {
            _logger.Info("Test GetRoles started!");

            var request = new RestRequest("/api/v1/roles/2", Method.Get);
            AddAuthorizationHeader(request);

            AssertResponse(_client.Execute(request));

            _logger.Info("Test GetRoles finished!");
        }

        [Test, Category("NFE")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("GET_API")]
        [AllureIssue(name: "ID_API_3")]
        [AllureTag("Smoke")]
        [AllureLink("https://elenkakruk.testmo.net")]
        [Description("Получить группы проекта")]
        public void GetGroups()
        {
            _logger.Info("Test GetGroups started!");

            var request = new RestRequest("/api/v1/groups", Method.Get);
            AddAuthorizationHeader(request);

            AssertResponse(_client.Execute(request));

            _logger.Info("Test GetGroups finished!");
        }
        
        [Test, Category("AFE")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("GET_API")]
        [AllureIssue(name: "ID_API_4")]
        [AllureTag("Smoke")]
        [AllureLink("https://elenkakruk.testmo.net")]
        [Description("Получить пользователяб которого нет на проекте")]
        public void GetUsers2()
        {
            _logger.Info("Test GetUsers2 started!");

            var request = new RestRequest("/api/v1/users/2", Method.Get);
            AddAuthorizationHeader(request);

            Assert.IsFalse(_client.Execute(request).IsSuccessful);

            _logger.Info("Test GetUsers2 started!");
        }
    }
}
