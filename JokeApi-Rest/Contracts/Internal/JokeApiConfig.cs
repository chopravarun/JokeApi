public class JokeApiConfig{

    IConfiguration _config;

    public JokeApiConfig(IConfiguration config){
        _config = config;
    }

    public String getResponseType(){
        return  _config["jokeApi:responseType"] ?? "application/json";
    }

    public String getBaseUrl(){
        return _config["jokeApi:baseUrl"] ?? String.Empty;
    }

    public String getSearchUri(){
        return _config["jokeApi:searchUri"] ?? String.Empty;
    }

    public String getSearchQueryParamTerm() {
        return  _config["jokeApi:queryParamTerm"] ?? String.Empty;
    }

    public String getSearchQueryParamLimit() {
        return  _config["jokeApi:queryParamLimit"] ?? String.Empty;
    }

    public String getSearchQueryParamPage() {
        return  _config["jokeApi:queryParamPage"] ?? String.Empty;
    }



}