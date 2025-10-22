// <SnippetConfigClient>
using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;

using Microsoft.Extensions.Configuration;
using System.Drawing;
IConfigurationRoot config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

string endpoint = config["AZURE_OPENAI_ENDPOINT"];
string apiKey = config["AZURE_OPENAI_API_KEY"];
string model = config["AZURE_OPENAI_GPT_NAME"];

// Create the Azure OpenAI client and convert to IImageGenerator.
AzureOpenAIClient azureClient = new(
    new Uri(endpoint),
    new AzureKeyCredential(apiKey));

var imageClient = azureClient.GetImageClient(model);
#pragma warning disable MEAI001 // Type is for evaluation purposes only.
IImageGenerator generator = imageClient.AsIImageGenerator();
// </SnippetConfigClient>

// <SnippetGenerateImage>
// Generate an image from a text prompt
var prompt = "A tennis court in a jungle";
var response = await generator.GenerateImagesAsync(prompt);

// Save the image to a file.
var dataContent = response.Contents.OfType<DataContent>().First();
string fileName = SaveImage(dataContent, "jungle-tennis");
Console.WriteLine($"Image saved to file: {fileName}");

static string SaveImage(DataContent content, string name)
{
    string userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    var extension = content.MediaType.Split(@"/")[1];
    var path = Path.Combine(userDirectory, $"{name}.{extension}");
    File.WriteAllBytes(path, content.Data.ToArray());
    return Path.GetFullPath(path);
}
// </SnippetGenerateImage>

// <SnippetWithOptions>
var options = new ImageGenerationOptions
{
    ImageSize = new Size(1024, 1536),
    Count = 2
};

var promptWithOptions = "A futuristic cityscape with flying cars and neon lights";
response = await generator.GenerateImagesAsync(promptWithOptions, options);
Console.WriteLine($"Successfully generated {response.Contents.Count} image(s)");
// </SnippetWithOptions>

// <SnippetWithErrorHandling>
try
{
    response = await generator.GenerateImagesAsync(
        "An abstract representation of technology and nature in harmony",
        new ImageGenerationOptions { ImageSize = new Size(512, 512) });

    if (response.Contents.Count == 0)
    {
        Console.WriteLine("No images were generated");
    }
    else
    {
        Console.WriteLine($"Generated an image with no errors.");
    }
}
catch (System.ClientModel.ClientResultException ex)
{
    Console.WriteLine(ex.Message);

    /* HTTP 400 (invalid_request_error: invalid_value)
       Parameter: size
       Invalid value: '512x512'.Supported values are: '1024x1024', '1024x1536', '1536x1024', and 'auto'.
    */
}
// </SnippetWithErrorHandling>
