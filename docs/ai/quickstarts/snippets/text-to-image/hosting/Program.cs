// <SnippetSetup>
using Aspire.Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using OpenAI;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add the Azure OpenAI client using hosting integration.
AspireAzureOpenAIClientBuilder openai = builder.AddAzureOpenAIClient("openai");
// </SnippetSetup>

// <SnippetAddImageGenerator>
// Register the image generator with dependency injection.
ImageGeneratorBuilder imageBuilder = builder.Services.AddImageGenerator(services =>
{
    OpenAIClient openAiClient = services.GetRequiredService<OpenAIClient>();
    OpenAI.Images.ImageClient imageClient = openAiClient.GetImageClient("gpt-image-1");
    #pragma warning disable MEAI001 // Type is for evaluation purposes only.
    return imageClient.AsIImageGenerator();
    #pragma warning restore MEAI001
});
// </SnippetAddImageGenerator>

// <SnippetConfigureOptions>
imageBuilder.ConfigureOptions(options =>
{
    options.MediaType = "image/png";
}).UseLogging();
// </SnippetConfigureOptions>

WebApplication app = builder.Build();

// <SnippetUseImageGenerator>
// Use the image generator in an endpoint.
app.MapPost("/generate-image", async (IImageGenerator generator, string prompt) =>
{
    ImageGenerationResponse response = await generator.GenerateImagesAsync(prompt);
    DataContent dataContent = response.Contents.OfType<DataContent>().First();

    return Results.File(dataContent.Data.ToArray(), "image/png");
});
// </SnippetUseImageGenerator>

app.Run();
