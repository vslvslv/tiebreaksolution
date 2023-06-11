using System.Net;
using DummyClient.Models.Request;
using DummyClient.Models.Response;

namespace ServiceTests
{
    public class CreateSessionTests
    {
        public MyApiClient client = new MyApiClient(Properties.Resources.baseUrl);

        [Test]
        public void CreateRequestTokenSuccessfully()
        {
            var response = client.CreateRequestToken<CreateRequestTokenResponseDto>();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void CreateRequestTokenUnauthorized()
        {
            var response = client.CreateRequestToken<DefaultErrorResponseDto>(_token: false);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(response.Data?.success, Is.False);
        }

        [Test]
        public void CreateSessionSuccessfully()
        {
            var response = client.CreateRequestToken<CreateRequestTokenResponseDto>();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var result = client.CreateSession(requestBody: new CreateSessionRequestDto()
            {
                request_token = response.Data.request_token,
            });
            //Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
