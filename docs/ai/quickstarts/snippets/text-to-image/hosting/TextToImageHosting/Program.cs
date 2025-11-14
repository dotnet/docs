// <SnippetSetup>
using Microsoft.Extensions.AI;
using OpenAI;

var builder = WebApplication.CreateBuilder(args);

// Add the Azure OpenAI client using hosting integration
var openai = builder.AddAzureOpenAIClient("openai");
// </SnippetSetup>

// <SnippetAddImageGenerator>
// Register the image generator with dependency injection
builder.Services.AddImageGenerator(services =>
{
    var openAiClient = services.GetRequiredService<OpenAIClient>();
    var imageClient = openAiClient.GetImageClient("gpt-image-1");
    #pragma warning disable MEAI001 // Type is for evaluation purposes only.
    return imageClient.AsIImageGenerator();
    #pragma warning restore MEAI001
});
// </SnippetAddImageGenerator>

var app = builder.Build();

// <SnippetUseImageGenerator>
// Use the image generator in an endpoint
app.MapPost("/generate-image", async (IImageGenerator generator, string prompt) =>
{
    var options = new ImageGenerationOptions
    {
        MediaType = "image/png"
    };

    var response = await generator.GenerateImagesAsync(prompt, options);
    var dataContent = response.Contents.OfType<DataContent>().First();
    
    return Results.File(dataContent.Data.ToArray(), "image/png");
});
// </SnippetUseImageGenerator>

app.Run();
