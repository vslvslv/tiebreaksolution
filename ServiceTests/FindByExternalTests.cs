using System.Net;


namespace ServiceTests
{
    public class FindByExternalTests
    {
        public MyApiClient client = new MyApiClient(Properties.Resources.baseUrl);
        string testId = "tt5971474";
        string movieTitle = "The Little Mermaid";

        [Test]
        public void VerifyFindByIdSuccess()
        {
            var response = client.FindByExternalId(external_id: testId, externalsSources: "imdb_id");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(response.Data.movie_results.First(x => x.title == movieTitle));

        }

        [Test]
        public void VerifyFindByIdUnauthorized()
        {
            var response = client.FindByExternalId(external_id: testId, externalsSources: "imdb_id", _token: false);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }
    }
}
