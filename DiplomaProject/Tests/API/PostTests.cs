using Allure.Commons;
using NLog;
using NUnit.Allure.Attributes;
using RestSharp;

namespace DiplomaProject.Tests.API
{
    public class PostTests : BaseApiTest
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        [Test, Category("NFE")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("POST_API")]
        [AllureIssue(name: "ID_API_5")]
        [AllureTag("Smoke")]
        [AllureLink("https://elenkakruk.testmo.net")]
        [Description("Запуск автоматизации для проекта ID_5")]
        public void PostAutomationRun()
        {
            _logger.Info("Test PostAutomationRun started!");

            var projectId = 5;
            var request = new RestRequest(
                $"/api/v1/projects/{projectId}/automation/runs", 
                Method.Post
            );
            AddAuthorizationHeader(request);

            var jsonContent = File.ReadAllText(
                "Tests" + Path.DirectorySeparatorChar
                + "Data" + Path.DirectorySeparatorChar
                + "AutomationRun.json"
            );

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(jsonContent);

            AssertResponse(_client.Execute(request));

            _logger.Info("Test PostAutomationRun finished!");
        }
    }
}
