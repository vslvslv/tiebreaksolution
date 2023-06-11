using System.Net;

namespace ServiceTests
{
    public class MoviePopularTests
    {
        // add authentication and use baseUrl from env properties
        static string baseUrl = "https://api.themoviedb.org";
        string token = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwYmVlMWY2YTc0Mjc5ZGQ2NzRlNjVlOTg2NWU4ZWQ5MSIsInN1YiI6IjY0ODQ4N2Y3OTkyNTljMDBhY2NjYTE0MSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ._rIbvRCuSotNpHS2lwHgrv-n_AEPHidKQPnKKY2dfD8";
        public MyApiClient client = new MyApiClient(baseUrl);

        [Test]
        public void VerifyTvPopularSuccess()
        {
            var response = client.GetMoviePopular();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(response.Data?.results);
            Assert.That(response.Data.page, Is.EqualTo(2));
        }

        [Test]
        public void VerifyTvPopularUnauthorized()
        {
            var response = client.GetMoviePopular(_token: false);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [Test]
        public void VerifyTvPopularPagesQueryParam()
        {
            var response = client.GetMoviePopular(page: 2);
            Assert.AreEqual(2, response.Data?.page);
        }
    }
}