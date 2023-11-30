var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ExampleHandler>();
var app = builder.Build();
var handler = app.Services.GetRequiredService<ExampleHandler>();
app.MapGet("/", handler.HandleRequest);
app.Run();

partial class ExampleHandler(ILogger<ExampleHandler> logger)
{
    public string HandleRequest()
    {
        LogHandleRequest(logger);
        return "Hello World";
    }

    [LoggerMessage(LogLevel.Information, "ExampleHandler.HandleRequest was called")]
    public static partial void LogHandleRequest(ILogger logger);
}
