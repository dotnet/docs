---
title: Tutorial - Generate images from text using AI in .NET
description: Learn how to use Microsoft.Extensions.AI to generate images from text prompts using AI models in a .NET application.
ms.date: 01/21/2025
ms.topic: tutorial
ai-usage: ai-assisted
zone_pivot_groups: openai-library
# CustomerIntent: As a .NET developer, I want to learn how to generate images from text prompts using Microsoft.Extensions.AI so I can integrate image generation capabilities into my applications.
---

# Generate images from text using AI in .NET

In this tutorial, you learn how to use the `Microsoft.Extensions.AI` library to generate images from text prompts using AI models. The `IImageGenerator` interface provides a unified, extensible API for working with various image generation services, making it easy to integrate text-to-image capabilities into your .NET applications.

## Prerequisites

:::zone target="docs" pivot="openai"

[!INCLUDE [openai-prereqs](../quickstarts/includes/prerequisites-openai.md)]

:::zone-end

:::zone target="docs" pivot="azure-openai"

[!INCLUDE [azure-openai-prereqs](../quickstarts/includes/prerequisites-azure-openai.md)]

:::zone-end

## Understanding IImageGenerator

The <xref:Microsoft.Extensions.AI.IImageGenerator> interface is part of the `Microsoft.Extensions.AI` library and provides a consistent API for generating images from text prompts. The interface supports:

- Text-to-image generation
- Pipeline composition with middleware (logging, telemetry, caching)
- Flexible configuration options
- Support for multiple AI providers

> [!NOTE]
> The `IImageGenerator` interface is currently marked as experimental with the `MEAI001` diagnostic ID. You may need to suppress this warning in your project file or code.

## Create the application

Complete the following steps to create a .NET console application that generates images from text prompts.

1. Create a new console application:

    ```dotnetcli
    dotnet new console -o TextToImageAI
    cd TextToImageAI
    ```

1. Install the required packages:

    :::zone target="docs" pivot="azure-openai"

    ```dotnetcli
    dotnet add package Microsoft.Extensions.AI.OpenAI --prerelease
    dotnet add package Azure.AI.OpenAI
    dotnet add package Azure.Identity
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    ```

    :::zone-end

    :::zone target="docs" pivot="openai"

    ```dotnetcli
    dotnet add package Microsoft.Extensions.AI.OpenAI --prerelease
    dotnet add package OpenAI
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    ```

    :::zone-end

1. Suppress the experimental warning by adding the following to your project file:

    ```xml
    <PropertyGroup>
        <NoWarn>$(NoWarn);MEAI001</NoWarn>
    </PropertyGroup>
    ```

:::zone target="docs" pivot="azure-openai"

[!INCLUDE [create-ai-service](../quickstarts/includes/create-ai-service.md)]

:::zone-end

:::zone target="docs" pivot="openai"

## Configure the application

1. Navigate to the root of your .NET project from a terminal or command prompt.

1. Run the following commands to configure your OpenAI API key as a secret for the application:

    ```dotnetcli
    dotnet user-secrets init
    dotnet user-secrets set OpenAIKey <your-OpenAI-key>
    dotnet user-secrets set ModelName <your-OpenAI-model-name>
    ```

:::zone-end

## Implement basic image generation

Update the `Program.cs` file with the following code to implement basic text-to-image generation:

:::zone target="docs" pivot="azure-openai"

:::code language="csharp" source="snippets/text-to-image/azure-openai/Program.cs" id="BasicGeneration":::

:::zone-end

:::zone target="docs" pivot="openai"

:::code language="csharp" source="snippets/text-to-image/openai/Program.cs" id="BasicGeneration":::

:::zone-end

The preceding code:

- Loads configuration from user secrets.
- Creates an `ImageClient` from the OpenAI SDK.
- Converts the `ImageClient` to an `IImageGenerator` using the `AsIImageGenerator()` extension method.
- Generates an image using the `GenerateImagesAsync` method with a text prompt.
- Outputs the URI of the generated image.

Run the application:

```dotnetcli
dotnet run
```

The application generates an image and outputs its URL. You can open the URL in a browser to view the generated image.

## Configure image generation options

You can customize image generation by providing options such as size, quality, and the number of images to generate. Update your code to include configuration options:

:::zone target="docs" pivot="azure-openai"

:::code language="csharp" source="snippets/text-to-image/azure-openai/Program.cs" id="WithOptions":::

:::zone-end

:::zone target="docs" pivot="openai"

:::code language="csharp" source="snippets/text-to-image/openai/Program.cs" id="WithOptions":::

:::zone-end

The `ImageGenerationOptions` class allows you to specify:

- **ImageSize**: The dimensions of the generated image as a `System.Drawing.Size`.
- **Count**: The number of images to generate (1-10).
- **ResponseFormat**: Whether to return a URL or base64-encoded data.
- **MediaType**: The media type (MIME type) of the generated image.
- **ModelId**: Override the model ID for specific requests.
- **AdditionalProperties**: Provider-specific options.

## Add telemetry and logging

The `Microsoft.Extensions.AI` library supports middleware patterns for adding cross-cutting concerns like logging and telemetry. Add OpenTelemetry support to track image generation operations:

:::zone target="docs" pivot="azure-openai"

:::code language="csharp" source="snippets/text-to-image/azure-openai/Program.cs" id="WithTelemetry":::

:::zone-end

:::zone target="docs" pivot="openai"

:::code language="csharp" source="snippets/text-to-image/openai/Program.cs" id="WithTelemetry":::

:::zone-end

The `ImageGeneratorBuilder` class enables you to compose a pipeline of middleware around your image generator. The `UseOpenTelemetry()` method adds telemetry tracking to capture metrics and traces for image generation operations.

## Handle errors and edge cases

When working with image generation, it's important to handle potential errors such as content filtering, rate limiting, or invalid prompts. Add error handling to your application:

:::zone target="docs" pivot="azure-openai"

:::code language="csharp" source="snippets/text-to-image/azure-openai/Program.cs" id="WithErrorHandling":::

:::zone-end

:::zone target="docs" pivot="openai"

:::code language="csharp" source="snippets/text-to-image/openai/Program.cs" id="WithErrorHandling":::

:::zone-end

Common errors to handle include:

- **Content filtering**: The prompt may be rejected due to content safety policies.
- **Rate limiting**: Too many requests in a short time period.
- **Invalid parameters**: Unsupported image sizes or formats.
- **Service availability**: Temporary service outages or maintenance.

## Save generated images locally

Instead of just displaying the URL, you might want to download and save the generated images locally:

:::zone target="docs" pivot="azure-openai"

:::code language="csharp" source="snippets/text-to-image/azure-openai/Program.cs" id="SaveLocally":::

:::zone-end

:::zone target="docs" pivot="openai"

:::code language="csharp" source="snippets/text-to-image/openai/Program.cs" id="SaveLocally":::

:::zone-end

This code downloads the generated image from the URL and saves it to a local file with a timestamped filename.

## Best practices

When implementing text-to-image generation in your applications, consider these best practices:

1. **Prompt engineering**: Write clear, detailed prompts that describe the desired image. Include specific details about style, composition, colors, and elements.

1. **Cost management**: Image generation can be expensive. Cache results when possible and implement rate limiting to control costs.

1. **Content safety**: Always review generated images for appropriate content, especially in production applications. Consider implementing content filtering and moderation.

1. **User experience**: Image generation can take several seconds. Provide progress indicators and handle timeouts gracefully.

1. **Legal considerations**: Be aware of licensing and usage rights for generated images. Review the terms of service for your AI provider.

1. **Quality validation**: Not all generated images meet quality standards. Consider implementing validation logic or allowing users to regenerate images.

:::zone target="docs" pivot="azure-openai"

## Clean up resources

When you no longer need the Azure OpenAI resource, delete it to avoid incurring charges:

1. In the [Azure Portal](https://portal.azure.com), navigate to your Azure OpenAI resource.
1. Select the resource and then select **Delete**.

:::zone-end

## Next steps

- [Quickstart: Generate images using AI with .NET](../quickstarts/generate-images.md)
- [Microsoft.Extensions.AI library overview](../microsoft-extensions-ai.md)
- [Build an AI chat app with .NET](../quickstarts/build-chat-app.md)
- [Explore the image generation blog post](https://devblogs.microsoft.com/dotnet/explore-text-to-image-dotnet/)
