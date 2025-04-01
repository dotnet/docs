using Microsoft.Extensions.Configuration;
using OpenAI.Images;
using System.ClientModel;
using Azure.AI.OpenAI;
using Azure.Identity;

// Retrieve the local secrets saved during the Azure deployment. If you skipped the deployment
// because you already have an Azure OpenAI available, edit the following lines to use your information,
// e.g. string openAIEndpoint = "https://cog-demo123.openai.azure.com/";
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string endpoint = config["AZURE_OPENAI_ENDPOINT"];
string deployment = config["AZURE_OPENAI_DALLE_NAME"];

// Create the Azure OpenAI ImageClient
ImageClient client =
    new AzureOpenAIClient(new Uri(endpoint), new DefaultAzureCredential())
        .GetImageClient(deployment);

// Generate the image
GeneratedImage generatedImage = await client.GenerateImageAsync("""
    A postal card with an happy hiker waving and a beautiful mountain in the background.
    There is a trail visible in the foreground.
    The postal card has text in red saying: 'You are invited for a hike!'
    """, new ImageGenerationOptions { Size = GeneratedImageSize.W1024xH1024 });

Console.WriteLine($"The generated image is ready at:\n{generatedImage.ImageUri}");
