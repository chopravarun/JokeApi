public interface JokeRetriever{
    Joke getRandomJoke();

    JokeSearchResponse searchJoke(JokeSearchRequest request);
}