// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#pragma warning disable MEAI001 // Type is for evaluation purposes only

using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenAI;
using OpenAI.Images;
using System.Net.Http;

// Load configuration
var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

string key = config["OpenAIKey"] ?? throw new InvalidOperationException("OpenAI key not found");
string modelName = config["ModelName"] ?? "dall-e-3";

// <BasicGeneration>
// Create the OpenAI client and convert to IImageGenerator
var openAIClient = new OpenAIClient(key);
var imageClient = openAIClient.GetImageClient(modelName);
IImageGenerator generator = imageClient.AsIImageGenerator();

// Generate an image from a text prompt
var prompt = "A serene mountain landscape at sunset with a small cabin near a lake";
var response = await generator.GenerateImagesAsync(prompt);

// Display the generated image URL
if (response.Contents.Count > 0 && response.Contents[0] is UriContent uriContent)
{
    Console.WriteLine($"Generated image URL: {uriContent.Uri}");
}
// </BasicGeneration>

Console.WriteLine("\n--- With Options ---\n");

// <WithOptions>
// Configure image generation options
var options = new Microsoft.Extensions.AI.ImageGenerationOptions
{
    ImageSize = new System.Drawing.Size(1024, 1024),
    Count = 2,
    ResponseFormat = Microsoft.Extensions.AI.ImageGenerationResponseFormat.Uri
};

var promptWithOptions = "A futuristic cityscape with flying cars and neon lights";
var responseWithOptions = await generator.GenerateImagesAsync(promptWithOptions, options);

// Display all generated images
foreach (var content in responseWithOptions.Contents)
{
    if (content is UriContent imageUri)
    {
        Console.WriteLine($"Generated image URL: {imageUri.Uri}");
    }
}
// </WithOptions>

Console.WriteLine("\n--- With Telemetry ---\n");

// <WithTelemetry>
using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
    builder.SetMinimumLevel(LogLevel.Information);
});

// Build a pipeline with telemetry
var generatorWithTelemetry = new ImageGeneratorBuilder(imageClient.AsIImageGenerator())
    .UseOpenTelemetry(loggerFactory)
    .Build();

var telemetryPrompt = "A vintage bicycle in front of a colorful flower shop";
var telemetryResponse = await generatorWithTelemetry.GenerateImagesAsync(telemetryPrompt);

if (telemetryResponse.Contents.Count > 0 && telemetryResponse.Contents[0] is UriContent telemetryUri)
{
    Console.WriteLine($"Generated image with telemetry: {telemetryUri.Uri}");
}
// </WithTelemetry>

Console.WriteLine("\n--- With Error Handling ---\n");

// <WithErrorHandling>
try
{
    var errorPrompt = "An abstract representation of technology and nature in harmony";
    var errorResponse = await generator.GenerateImagesAsync(
        errorPrompt,
        new Microsoft.Extensions.AI.ImageGenerationOptions { ImageSize = new System.Drawing.Size(1024, 1024) });
    
    if (errorResponse.Contents.Count == 0)
    {
        Console.WriteLine("No images were generated");
    }
    else
    {
        Console.WriteLine($"Successfully generated {errorResponse.Contents.Count} image(s)");
        foreach (var content in errorResponse.Contents)
        {
            if (content is UriContent uri)
            {
                Console.WriteLine($"Image URL: {uri.Uri}");
            }
        }
    }
}
catch (HttpRequestException ex) when (ex.Message.Contains("429"))
{
    Console.WriteLine("Rate limit exceeded. Please wait and try again.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error generating image: {ex.Message}");
}
// </WithErrorHandling>

Console.WriteLine("\n--- Save Locally ---\n");

// <SaveLocally>
var savePrompt = "A cozy coffee shop interior with warm lighting and comfortable seating";
var saveResponse = await generator.GenerateImagesAsync(savePrompt);

if (saveResponse.Contents.Count > 0 && saveResponse.Contents[0] is UriContent saveUri)
{
    using var httpClient = new HttpClient();
    var imageBytes = await httpClient.GetByteArrayAsync(saveUri.Uri);
    
    var fileName = $"generated-image-{DateTime.Now:yyyyMMdd-HHmmss}.png";
    await File.WriteAllBytesAsync(fileName, imageBytes);
    
    Console.WriteLine($"Image saved to: {Path.GetFullPath(fileName)}");
}
// </SaveLocally>
