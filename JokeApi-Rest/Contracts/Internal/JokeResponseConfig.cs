public class JokeResponseConfig{
    
    IConfiguration _config;

    public JokeResponseConfig(IConfiguration config){
        _config = config;
    }

    public int getShort(){
        String shortJoke = _config["jokeResponse:short"] ?? "10";
        return int.Parse(shortJoke);
    }

    public int getMedium(){
        String medium = _config["jokeResponse:medium"] ?? "20";
        return int.Parse(medium);
    }

    public int getLarge(){
        String large = _config["jokeResponse:long"] ?? "20";
        return int.Parse(large);
    }
}