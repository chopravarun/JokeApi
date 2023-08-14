public class JokeServiceImpl : JokeService
{
    private readonly ILogger<JokeServiceImpl> _logger;

    private readonly JokeRetriever _jokeRetriever;

    private readonly ContentAdapterAndHighLighter _adapterAndHighLighter;
    public JokeServiceImpl(ILogger<JokeServiceImpl> logger,
                            JokeRetriever jokeRetriever,
                            ContentAdapterAndHighLighter adapterAndHighLighter){
        _logger = logger;
        _jokeRetriever = jokeRetriever;
        _adapterAndHighLighter = adapterAndHighLighter;
    }

    public JokeExternal randomJoke()
    {
        _logger.LogInformation("finding random joke");
        Joke joke = _jokeRetriever.getRandomJoke();
        return new JokeExternal(joke.joke);
    }

    public JokeSearchResponseExternal searchJoke(JokeSearchRequest request)
    {
        _logger.LogInformation("search request query : {}", request);
        JokeSearchResponse internalResponse = _jokeRetriever.searchJoke(request);
        JokeSearchResponseExternal jokeResponse =
        _adapterAndHighLighter.updateInternalResponse(internalResponse)
                            .highlightContent()
                            .divideAsPerSize()
                            .getFinalResponse();
        return jokeResponse;
    }
}