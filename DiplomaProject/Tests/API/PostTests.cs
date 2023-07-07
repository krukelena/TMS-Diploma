using RestSharp;

namespace DiplomaProject.Tests.API
{
    public class PostTests : BaseApiTest
    {

        [Test]
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
