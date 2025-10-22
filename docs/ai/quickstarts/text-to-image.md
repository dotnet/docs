---
title: Quickstart - Generate images from text using AI
description: Learn how to use Microsoft.Extensions.AI to generate images from text prompts using AI models in a .NET application.
ms.date: 10/21/2025
ms.topic: quickstart
ai-usage: ai-assisted
---

# Generate images from text using AI

In this quickstart, you learn how to use the <xref:Microsoft.Extensions.AI> library to generate images from text prompts using AI models.

The <xref:Microsoft.Extensions.AI.IImageGenerator> interface provides a unified, extensible API for working with various image generation services, making it easy to integrate text-to-image capabilities into your .NET apps. The interface supports:

- Text-to-image generation.
- Pipeline composition with middleware (logging, telemetry, caching).
- Flexible configuration options.
- Support for multiple AI providers.

> [!NOTE]
> The `IImageGenerator` interface is currently marked as experimental with the `MEAI001` diagnostic ID. You might need to suppress this warning in your project file or code.

<!--Prereqs-->
[!INCLUDE [azure-openai-prereqs](../quickstarts/includes/prerequisites-azure-openai.md)]

## Configure the AI service

To provision an Azure OpenAI service and model using the Azure portal, complete the steps in the [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource?pivots=web-portal) article. In the "Deploy a model" step, select the `gpt-image-1` model.

## Create the application

Complete the following steps to create a .NET console application that generates images from text prompts.

1. Create a new console application:

    ```dotnetcli
    dotnet new console -o TextToImageAI
    ```

1. Navigate to the `TextToImageAI` directory, and add the necessary packages to your app:

    ```dotnetcli
    dotnet add package Azure.AI.OpenAI
    dotnet add package Microsoft.Extensions.AI.OpenAI --prerelease
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    ```

1. Run the following commands to add [app secrets](/aspnet/core/security/app-secrets) for your Azure OpenAI endpoint, model name, and API key:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set AZURE_OPENAI_ENDPOINT <your-Azure-OpenAI-endpoint>
    dotnet user-secrets set AZURE_OPENAI_GPT_NAME gpt-image-1
    dotnet user-secrets set AZURE_OPENAI_API_KEY <your-azure-openai-api-key>
    ```

1. Open the new app in your editor of choice (for example, Visual Studio).

## Implement basic image generation

1. Update the `Program.cs` file with the following code to get the configuration data and create the <xref:Azure.AI.OpenAI.AzureOpenAIClient>:

   :::code language="csharp" source="snippets/text-to-image/azure-openai/Program.cs" id="ConfigClient":::

   The preceding code:

   - Loads configuration from user secrets.
   - Creates an `ImageClient` from the OpenAI SDK.
   - Converts the `ImageClient` to an `IImageGenerator` using the <xref:Microsoft.Extensions.AI.OpenAIClientExtensions.AsIImageGenerator(OpenAI.Images.ImageClient)> extension method.

1. Add the following code to implement basic text-to-image generation:

   :::code language="csharp" source="snippets/text-to-image/azure-openai/Program.cs" id="GenerateImage":::

   The preceding code:

   - Generates an image using the <xref:Microsoft.Extensions.AI.ImageGeneratorExtensions.GenerateImagesAsync(Microsoft.Extensions.AI.IImageGenerator,System.String,Microsoft.Extensions.AI.ImageGenerationOptions,System.Threading.CancellationToken)> method with a text prompt.
   - Saves the generated image to a file in the local user directory.

1. Run the application, either through the IDE or using `dotnet run`.

   The application generates an image and outputs the file path to the image. You can open the file to view the generated image. The following image shows one example of a generated image.

   :::image type="content" source="media/text-to-image/jungle-tennis.png" alt-text="AI-generated image of a tennis court in a jungle.":::

## Configure image generation options

You can customize image generation by providing options such as size, response format, and number of images to generate. The <xref:Microsoft.Extensions.AI.ImageGenerationOptions> class allows you to specify:

- <xref:Microsoft.Extensions.AI.ImageGenerationOptions.ImageSize>: The dimensions of the generated image as a `System.Drawing.Size`.
- <xref:Microsoft.Extensions.AI.ImageGenerationOptions.Count>: The number of images to generate (1-10).
- <xref:Microsoft.Extensions.AI.ImageGenerationOptions.ResponseFormat>: Whether to return a URL or base64-encoded data.
- <xref:Microsoft.Extensions.AI.ImageGenerationOptions.MediaType>: The media type (MIME type) of the generated image.
- <xref:Microsoft.Extensions.AI.ImageGenerationOptions.ModelId>: The model ID.
- <xref:Microsoft.Extensions.AI.ImageGenerationOptions.AdditionalProperties>: Provider-specific options.

Update your code to include configuration options:

:::code language="csharp" source="snippets/text-to-image/azure-openai/Program.cs" id="WithOptions":::

## Handle errors and edge cases

When working with image generation, it's important to handle potential errors such as content filtering, rate limiting, or invalid prompts. Add error handling to your application:

:::code language="csharp" source="snippets/text-to-image/azure-openai/Program.cs" id="WithErrorHandling":::

Common errors to handle include:

- **Content filtering**: The prompt might be rejected due to content safety policies.
- **Rate limiting**: Too many requests in a short time period.
- **Invalid parameters**: Unsupported image sizes or formats.
- **Service availability**: Temporary service outages or maintenance.

## Best practices

When implementing text-to-image generation in your applications, consider these best practices:

- **Prompt engineering**: Write clear, detailed prompts that describe the desired image. Include specific details about style, composition, colors, and elements.
- **Cost management**: Image generation can be expensive. Cache results when possible and implement rate limiting to control costs.
- **Content safety**: Always review generated images for appropriate content, especially in production applications. Consider implementing content filtering and moderation.
- **User experience**: Image generation can take several seconds. Provide progress indicators and handle timeouts gracefully.
- **Legal considerations**: Be aware of licensing and usage rights for generated images. Review the terms of service for your AI provider.
- **Quality validation**: Not all generated images meet quality standards. Consider implementing validation logic or allowing users to regenerate images.

## Clean up resources

When you no longer need the Azure OpenAI resource, delete it to avoid incurring charges:

1. In the [Azure Portal](https://portal.azure.com), navigate to your Azure OpenAI resource.
1. Select the resource and then select **Delete**.

## Next steps

- [Quickstart: Generate images using AI with .NET](../quickstarts/generate-images.md)
- [Explore text-to-image capabilities in .NET (blog post)](https://devblogs.microsoft.com/dotnet/explore-text-to-image-dotnet/)
- [Microsoft.Extensions.AI library overview](../microsoft-extensions-ai.md)
- [Quickstart: Build an AI chat app with .NET](../quickstarts/build-chat-app.md)
