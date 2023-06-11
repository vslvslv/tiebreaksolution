using DummyClient.Models.Request;
using DummyClient.Models.Response;
using RestSharp;

public class MyApiClient : BaseRestClient
{
    public MyApiClient(string baseUrl) : base(baseUrl)
    {
    }

    public RestResponse<CreateRequestTokenResponseDto> CreateRequestToken(bool _token = true)
    {
        var relativePath = $"/3/authentication/token/new";
        var request = CreateRequest(relativePath, Method.Get);

        if (_token)
            AddToken(request);

        var response = Execute<CreateRequestTokenResponseDto>(request);

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

    public RestResponse<PopularResponseDto> GetMoviePopular(bool _token = true, string lang = "en-US", int page = 1)
    {
        var relativePath = $"/3/movie/popular?language={lang}&page={page}";
        var request = CreateRequest(relativePath, Method.Get);

        if (_token)
            AddToken(request);

        var response = Execute<PopularResponseDto>(request);

        return response;
    }
}