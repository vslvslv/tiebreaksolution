using System.Net;

namespace ServiceTests
{
    public class DiscoverMovieTests
    {
        public MyApiClient client = new MyApiClient(Properties.Resources.baseUrl);

        [Test]
        public void VerifyDiscoverMovieSuccess()
        {
            var response = client.DiscoverMovie();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(response.Data?.results);
            Assert.That(response.Data.page, Is.EqualTo(1));
        }

        [Test]
        public void VerifyDiscoverMovieUnauthorized()
        {
            var response = client.DiscoverMovie(_token: false);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [Test]
        public void VerifyDiscoverMovieIncludeVideo()
        {
            var response = client.DiscoverMovie(includeVideo: false);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            response.Data?.results.ForEach(result =>
            {
                Assert.That(result.video, Is.EqualTo(false));
            });
        }
    }
}
