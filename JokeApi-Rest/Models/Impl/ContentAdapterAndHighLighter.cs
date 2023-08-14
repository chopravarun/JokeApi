public class ContentAdapterAndHighLighter{

    private JokeSearchResponse _internalResponse;

    private JokeSearchResponseExternal _externalResponse;

    private readonly JokeResponseConfig _responseConfig;



    public ContentAdapterAndHighLighter(JokeResponseConfig responseConfig){
        this._responseConfig = responseConfig;
    }

    public ContentAdapterAndHighLighter updateInternalResponse(JokeSearchResponse internalResponse){
        this._internalResponse = internalResponse;
        return this;
    }

    public ContentAdapterAndHighLighter highlightContent(){
        String searchTerm = _internalResponse.search_term;
        _internalResponse.results.ForEach(joke=>joke.joke = joke.joke.Replace(searchTerm, $"<em>{searchTerm}</em>"));
        return this;
    }

    public ContentAdapterAndHighLighter divideAsPerSize(){
        List<Joke> jokes = _internalResponse.results;
        JokeSearchResponseExternal externalResponse = new JokeSearchResponseExternal();

        for(int i=0;i<jokes.Count;i++){
            if(jokes[i].joke.Length <= _responseConfig.getShort()){
                externalResponse.small.Add(new JokeExternal(jokes[i].joke));
            }
            if(jokes[i].joke.Length <= _responseConfig.getMedium()){
                externalResponse.medium.Add(new JokeExternal(jokes[i].joke));
            }
            if(jokes[i].joke.Length > _responseConfig.getLarge()){
                externalResponse.large.Add(new JokeExternal(jokes[i].joke));
            }
        }
        this._externalResponse = externalResponse;
        return this;
    }

    public JokeSearchResponseExternal getFinalResponse(){
        return this._externalResponse;
    }
}