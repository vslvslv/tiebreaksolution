using DummyClient.Models.Request;
using DummyClient.Models.Response;
using RestSharp;

public class MyApiClient : BaseRestClient
{
    public MyApiClient(string baseUrl) : base(baseUrl)
    {
    }

    public RestResponse<T> CreateRequestToken<T>(bool _token = true) where T : new()
    {
        var relativePath = $"/3/authentication/token/new";
        var request = CreateRequest(relativePath, Method.Get);

        if (_token)
            AddToken(request);

        var response = Execute<T>(request);

        return response;
    }

    public RestResponse CreateSession(CreateSessionRequestDto requestBody, bool _token = true) {
        var relativePath = $"/3/authentication/session/new";
        var request = CreateRequest(relativePath, Method.Post);

        if (_token)
            AddToken(request);

        request.AddBody(requestBody);
        var response = Execute<object>(request);

        return response;
    }

    public RestResponse<PopularResponseDto> GetMoviePopular<T>(bool _token = true, string lang = "en-US", int page = 1) where T : new()
    {
        var relativePath = $"/3/movie/popular?language={lang}&page={page}";
        var request = CreateRequest(relativePath, Method.Get);

        if (_token)
            AddToken(request);

        var response = Execute<PopularResponseDto>(request);

        return response;
    }

    public RestResponse<DiscoverMovieResponseDto> DiscoverMovie<T>(bool _token = true, string lang = "en-US", int page = 1, bool includeVideo = true) where T : new()
    {
        var relativePath = $"3/discover/movie?language={lang}&page={page}&include_video={includeVideo}";
        var request = CreateRequest(relativePath, Method.Get);

        if (_token)
            AddToken(request);

        var response = Execute<DiscoverMovieResponseDto>(request);

        return response;
    }

    public RestResponse<T> FindByExternalId<T>(string external_id, string externalsSources, bool _token = true) where T : new()
    {
        var relativePath = $"/3/find/{external_id}?external_source={externalsSources}";
        var request = CreateRequest(relativePath, Method.Get);

        if (_token)
            AddToken(request);

        var response = Execute<T>(request);

        return response;
    }
}