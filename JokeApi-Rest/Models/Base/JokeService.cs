public interface JokeService{
    JokeSearchResponseExternal searchJoke(JokeSearchRequest request);

    JokeExternal randomJoke();
}