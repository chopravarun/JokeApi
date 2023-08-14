
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/[controller]")]
public class JokeController : ControllerBase { 

    private readonly ILogger<JokeController> _logger;

    private readonly JokeService _jokeService;

    public JokeController(ILogger<JokeController> logger,
                            JokeService jokeService){
        this._logger = logger;
        this._jokeService = jokeService;
    }

    [HttpGet("s/{term}/p/{page}/l/{limit}")]
    public ActionResult<JokeSearchResponseExternal> searchJoke(String term, int page, int limit){
        return search(term, page, limit);
    }


    [HttpGet("s/{term}")]
    public ActionResult<JokeSearchResponseExternal> searchJoke(String term){
        return search(term, 0, 0);
    }

    private ActionResult<JokeSearchResponseExternal> search(String term, int page, int limit){
        JokeSearchRequest request = new JokeSearchRequest(term, page, limit);
        _logger.LogInformation("search request recieved : {}", request);

        JokeSearchResponseExternal response = _jokeService.searchJoke(request);
        _logger.LogInformation("joke response has : {}", response);

        if(response.hasJokes()){
            return Ok(response);
        } 
        return NotFound();
    }

    [HttpGet]
    public ActionResult<JokeExternal> randomJoke(){
        JokeExternal joke = _jokeService.randomJoke();
        if(joke.hasJoke()){
            return Ok(joke);
        }
        return NotFound();
    }

}