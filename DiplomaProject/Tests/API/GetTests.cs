using RestSharp;

namespace DiplomaProject.Tests.API
{
    public class GetTests : BaseApiTest
    {

        [Test, Category("NFE")]
        public void GetProducts()
        {
            var request = new RestRequest("/api/v1/projects", Method.Get);
            AddAuthorizationHeader(request);

            AssertResponse(_client.Execute(request));
        }


        [Test, Category("NFE")]
        public void GetRoles()
        {
            var request = new RestRequest("/api/v1/roles/2", Method.Get);
            AddAuthorizationHeader(request);

            AssertResponse(_client.Execute(request));
        }



        [Test, Category("NFE")]
        public void GetGroups()
        {
            var request = new RestRequest("/api/v1/groups", Method.Get);
            AddAuthorizationHeader(request);

            AssertResponse(_client.Execute(request));
        }



        [Test, Category("AFE")]
        public void GetUsers2()
        {
            var request = new RestRequest("/api/v1/users/2", Method.Get);
            AddAuthorizationHeader(request);

            Assert.IsFalse(_client.Execute(request).IsSuccessful);
        }
    }
}
