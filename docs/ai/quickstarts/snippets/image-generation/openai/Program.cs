﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
using Microsoft.Extensions.Configuration;
using OpenAI.Images;
// Retrieve the local secrets that were set from the command line, using:
// dotnet user-secrets init
// dotnet user-secrets set OpenAIKey <your-openai-key>
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string key = config["OpenAIKey"];
string modelName = config["ModelName"];

// Create the OpenAI ImageClient
ImageClient client = new(modelName, key);

// Generate the image
GeneratedImage generatedImage = await client.GenerateImageAsync("""
    A postal card with a happy hiker waving and a beautiful mountain in the background.
    There is a trail visible in the foreground.
    The postal card has text in red saying: 'You are invited for a hike!'
    """,
    new ImageGenerationOptions 
    {
        Size = GeneratedImageSize.W1024xH1024 
    });

Console.WriteLine($"The generated image is ready at:\n{generatedImage.ImageUri}");