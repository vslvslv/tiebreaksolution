using System.Net;
using DummyClient.Models.Request;

namespace ServiceTests
{
    public class CreateSessionTests
    {
        public MyApiClient client = new MyApiClient(Properties.Resources.baseUrl);

        [Test]
        public void CreateRequestTokenSuccessfully()
        {
            var response = client.CreateRequestToken();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void CreateRequestTokenUnauthorized()
        {
            var response = client.CreateRequestToken(_token: false);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [Test]
        public void CreateSessionSuccessfully()
        {
            var response = client.CreateRequestToken();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var result = client.CreateSession(requestBody: new CreateSessionRequestDto()
            {
                request_token = response.Data.request_token,
            });
            //Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
