using DummyClient.Models.Response;
using System.Net;

namespace ServiceTests
{
    public class MoviePopularTests
    {
        public MyApiClient client = new MyApiClient(Properties.Resources.baseUrl);

        [Test]
        public void VerifyMoviePopularSuccess()
        {
            var response = client.GetMoviePopular<PopularResponseDto>();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(response.Data?.results);
            Assert.That(response.Data.page, Is.EqualTo(1));
        }

        [Test]
        public void VerifyMoviePopularUnauthorized()
        {
            var response = client.GetMoviePopular<DefaultErrorResponseDto>(_token: false);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [Test]
        public void VerifyMoviePopularPagesQueryParam()
        {
            var response = client.GetMoviePopular<PopularResponseDto>(page: 2);
            Assert.That(response.Data?.page, Is.EqualTo(2));
        }
    }
}