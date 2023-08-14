public class JokeRetrieverImpl : JokeRetriever
{
    private readonly ILogger<JokeRetrieverImpl> _logger;

    private readonly JokeApiConfig _config;

    private readonly RestRequestExecutor<JokeSearchResponse> _restTemplateForSearch;

    private readonly RestRequestExecutor<Joke> _restTemplateForRandomJoke;


    public JokeRetrieverImpl(ILogger<JokeRetrieverImpl> logger,
                            JokeApiConfig config,
                            RestRequestExecutor<JokeSearchResponse> restTemplateForSearch,
                            RestRequestExecutor<Joke> restTemplateForRandomJoke){
        _logger = logger;
        _config = config;
        _restTemplateForSearch = restTemplateForSearch;
        _restTemplateForRandomJoke = restTemplateForRandomJoke;

    }

    public Joke getRandomJoke()
    {
        HttpClient client = this.GetHttpClient();
        UriBuilder uriBuilder = this.GetUri(false, null);
        if(uriBuilder!=null){
            try{
                return _restTemplateForRandomJoke.sendGet(client, uriBuilder.Uri).Result;
            } catch (HttpRequestException e){
                _logger.LogError("error while searching for random joke {}", e);
            } catch(AggregateException e) { 
                _logger.LogError("error while searching for random joke {}", e);
            }
        }
        return new Joke();
    }

    public JokeSearchResponse searchJoke(JokeSearchRequest request)
    {
        HttpClient client = this.GetHttpClient();
        UriBuilder uriBuilder = this.GetUri(true, request);
        if(uriBuilder!=null){
            try{
                return _restTemplateForSearch.sendGet(client, uriBuilder.Uri).Result;
            } catch(HttpRequestException e) {
                _logger.LogError("error while searching for joke search {} , Exception {}", request.ToString(), e);
            } catch(AggregateException e) {
                _logger.LogError("error while searching for joke search {} , Exception {}", request.ToString(), e);
            }
        }
        return new JokeSearchResponse();
    }

    private HttpClient GetHttpClient(){
        HttpClient client = new HttpClient();
        String responseType = _config.getResponseType();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(responseType));
        return client;
    }

    private UriBuilder? GetUri(bool isSearch, JokeSearchRequest request){
        String apiUrl = _config.getBaseUrl();
        if(String.Empty.Equals(apiUrl)){
            _logger.LogError("Joke api Url not configured");
            return null;
        }
        UriBuilder uriBuilder = new UriBuilder(apiUrl);
        if(!isSearch){
            _logger.LogInformation("final url for random joke : {}", uriBuilder.Uri);
            return uriBuilder;
        }

        uriBuilder.Path = _config.getSearchUri();
        var query = System.Web.HttpUtility.ParseQueryString(String.Empty);
        query[_config.getSearchQueryParamTerm()] = request._term;
        if(request._limit != 0 && request._page != 0){
            query[_config.getSearchQueryParamLimit()] = request._limit.ToString();
            query[_config.getSearchQueryParamPage()] = request._page.ToString();
        }
        
        uriBuilder.Query = query.ToString();
        _logger.LogInformation("final url for joke search : {}", uriBuilder.Uri);
        return uriBuilder;
    }

}