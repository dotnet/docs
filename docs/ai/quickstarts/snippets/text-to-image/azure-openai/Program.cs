// <SnippetConfigClient>
using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;

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
var options = new ImageGenerationOptions
{
    MediaType = "image/png"
};
string prompt = "A tennis court in a jungle";
var response = await generator.GenerateImagesAsync(prompt, options);

// Save the image to a file.
var dataContent = response.Contents.OfType<DataContent>().First();
string fileName = SaveImage(dataContent, "jungle-tennis.png");
Console.WriteLine($"Image saved to file: {fileName}");

static string SaveImage(DataContent content, string fileName)
{
    string userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    var path = Path.Combine(userDirectory, fileName);
    File.WriteAllBytes(path, content.Data.ToArray());
    return Path.GetFullPath(path);
}
// </SnippetGenerateImage>
