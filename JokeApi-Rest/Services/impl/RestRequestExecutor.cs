

public class RestRequestExecutor<R>{

    ILogger<RestRequestExecutor<R>> _logger;

    public RestRequestExecutor(ILogger<RestRequestExecutor<R>> logger){
        _logger = logger;
    }


    public async Task<R> sendGet(HttpClient client, Uri uri) {
        try{
            HttpResponseMessage response = await client.GetAsync(uri);
            if(response.IsSuccessStatusCode){
                return await response.Content.ReadFromJsonAsync<R>();
            }
            _logger.LogError("unexpected statusCode : {}",response.StatusCode);
        } catch(HttpRequestException e){
            _logger.LogError("Error occurred when sending get request {}",e);
            throw e;
        } catch(AggregateException e){
            _logger.LogError("Get request end up in problem {}", e);
            throw e;
        } finally { 
            client.Dispose();
        }
        throw new HttpRequestException("unexpected response code");

    }
}