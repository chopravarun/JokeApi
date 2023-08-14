var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional:false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

    var serviceCollection = new ServiceCollection();
    serviceCollection.AddLogging();
    var serviceProvider = serviceCollection.BuildServiceProvider();
    var _loggerJokeSearchResponse = serviceProvider.GetRequiredService<ILogger<RestRequestExecutor<JokeSearchResponse>>>();
    var _loggerRandomJokeResponse = serviceProvider.GetRequiredService<ILogger<RestRequestExecutor<Joke>>>();

    RestRequestExecutor<JokeSearchResponse> jokeSearch = new RestRequestExecutor<JokeSearchResponse>(_loggerJokeSearchResponse);
    RestRequestExecutor<Joke> randomJoke = new RestRequestExecutor<Joke>(_loggerRandomJokeResponse);
    JokeApiConfig jokeApiConfig = new JokeApiConfig(config);
    JokeResponseConfig jokeResponseConfig = new JokeResponseConfig(config);


    builder.Services.AddSingleton(jokeApiConfig);
    builder.Services.AddSingleton(jokeResponseConfig);
    builder.Services.AddSingleton(randomJoke);
    builder.Services.AddSingleton(jokeSearch);
    builder.Services.AddScoped<JokeRetriever, JokeRetrieverImpl>();
    builder.Services.AddScoped<JokeService, JokeServiceImpl>();
    builder.Services.AddScoped<ContentAdapterAndHighLighter, ContentAdapterAndHighLighter>();
    
}



var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseSwagger();
    app.UseSwaggerUI(c=>{
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Joke api v1");
    });
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}


