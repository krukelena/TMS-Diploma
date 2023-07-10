using Allure.Commons;
using NUnit.Allure.Attributes;
using RestSharp;

namespace DiplomaProject.Tests.API
{
    public class PostTests : BaseApiTest
    {

        [Test, Category("NFE")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("POST_API")]
        [AllureIssue(name: "ID_API_5")]
        [AllureTag("Smoke")]
        [AllureLink("https://elenkakruk.testmo.net")]
        [Description("Запуск автоматизации для проекта ID_79")]
        public void PostAutomationRun()
        {
            var projectId = 79;
            var request = new RestRequest($"/api/v1/projects/{projectId}/automation/runs", Method.Post);
            AddAuthorizationHeader(request);

            var jsonContent = File.ReadAllText("Tests/Data/AutomationRun.json");

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(jsonContent);

            AssertResponse(_client.Execute(request));
        }
    }
}
