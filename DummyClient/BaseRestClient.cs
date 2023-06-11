using RestSharp;

public class BaseRestClient
{
    private readonly string _baseUrl;
    private readonly RestClient _restClient;
    private readonly string token = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwYmVlMWY2YTc0Mjc5ZGQ2NzRlNjVlOTg2NWU4ZWQ5MSIsInN1YiI6IjY0ODQ4N2Y3OTkyNTljMDBhY2NjYTE0MSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ._rIbvRCuSotNpHS2lwHgrv-n_AEPHidKQPnKKY2dfD8";

    public BaseRestClient(string baseUrl)
    {
        _baseUrl = baseUrl;
        _restClient = new RestClient(_baseUrl);
    }

    public RestResponse<T> Execute<T>(RestRequest request) where T : new()
    {
        var response = _restClient.Execute<T>(request);
        return response;
    }

    public RestRequest CreateRequest(string resource, Method method)
    {
        var request = new RestRequest(resource, method);
        request.AddHeader("accept", "application/json");

        return request;
    }


    public void AddToken(RestRequest request)
    {
        request.AddHeader("Authorization", $"Bearer {token}");
    }
}
