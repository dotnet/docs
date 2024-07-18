---
title: Quickstart - Generate images using AI with .NET
description: Create a simple app using OpenAI to generate postal card images.
ms.date: 07/17/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
zone_pivot_groups: openai-library
# CustomerIntent: As a .NET developer new to Azure OpenAI, I want deploy and use sample code to interact to learn how to generate images from the sample code.
---

# Generate images using AI with .NET

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="openai"
<!-- markdownlint-enable MD044 -->

Get started with AI by creating a simple .NET 8 console chat application. The application will run locally and use the OpenAI `dall-e-3` model to generate postal card images so you can invite your friends for a hike! Follow these steps to get access to OpenAI and learn how to use Semantic Kernel.

[!INCLUDE [download-alert](includes/prerequisites-openai.md)]

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="azure-openai"
<!-- markdownlint-enable MD044 -->

Get started with AI by creating a simple .NET 8 console chat application. The application will run locally and use the OpenAI `dall-e-3` model to generate postal card images so you can invite your friends for a hike! Follow these steps to provision Azure OpenAI and learn how to use the .NET Azure OpenAI SDK.

[!INCLUDE [download-alert](includes/prerequisites-azure-openai.md)]

:::zone-end

## Get the sample project

[!INCLUDE [clone-sample-repo](includes/clone-sample-repo.md)]

:::zone target="docs" pivot="azure-openai"

[!INCLUDE [deploy-azd](includes/deploy-azd.md)]

:::zone-end

## Try the the Hiking Images sample

<!-- markdownlint-disable MD029 MD044 -->
:::zone target="docs" pivot="openai"

1. Clone the repository: [dotnet/ai-samples](https://github.com/dotnet/ai-samples)

1. Run the following commands to configure your OpenAI API key as a secret for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set OpenAIKey <your-openai-key>
    ```

1. Use the `dotnet run` command to run the app:

    ```dotnetcli
    dotnet run
    ```

:::zone-end

:::zone target="docs" pivot="azure-openai"

1. From a terminal or command prompt, navigate to the `azure-openai\05-HikeImages` directory.

2. Use the `dotnet run` command to run the app:

    ```dotnetcli
    dotnet run
    ```

    > [!TIP]
    > If you get an error message, the Azure OpenAI resources may not have finished deploying. Wait a couple of minutes and try again.

:::zone-end
<!-- markdownlint-enable MD029 MD044  -->

## Explore the code

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="openai"
The application uses the [`Microsoft.SemanticKernel`](https://www.nuget.org/packages/Microsoft.SemanticKernel) package to send and receive requests to the OpenAI service.

The entire application is contained within the **Program.cs** file. The first several lines of code set configuration values and gets the OpenAI Key that was previously set using the `dotnet user-secrets` command.

```csharp
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string key = config["OpenAIKey"];
```

The `OpenAITextToImageService` service facilitates the requests and responses.

```csharp
OpenAITextToImageService textToImageService = new(key, null);
```

:::zone-end

:::zone target="docs" pivot="azure-openai"
<!-- markdownlint-enable MD044 -->
The application uses the [`Microsoft.SemanticKernel`](https://www.nuget.org/packages/Microsoft.SemanticKernel) package to send and receive requests to the Azure OpenAI service.

The entire application is contained within the _Program.cs_ file. The first several lines of code load secrets and configuration values that were set in the `dotnet user-secrets` for you during the application provisioning.

```csharp
// == Retrieve the local secrets saved during the Azure deployment ==========
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string endpoint = config["AZURE_OPENAI_ENDPOINT"];
string deployment = config["AZURE_OPENAI_GPT_NAME"];
string key = config["AZURE_OPENAI_KEY"];
```

The `AzureOpenAITextToImageService` service facilitates the requests and responses.

```csharp
AzureOpenAITextToImageService textToImageService = new(deployment, endpoint, key, null);
```

:::zone-end

Once the `textToImageService` service is created, provide more context to the model by adding a system prompt. A good prompt to generate images requires a clear description: what is in the images, specific color to use, style (drawing, painting, realistic or cartoony). The model will use this prompt to generate the image. To have the model generate a response based off the user request, use the `GenerateImageAsync` function, and specify the size and quality.

```csharp
// Generate the image
string imageUrl = await textToImageService.GenerateImageAsync("""
    A postal card with an happy hiker waving and a beautiful mountain in the background.
    There is a trail visible in the foreground.
    The postal card has text in red saying: 'You are invited for a hike!'
    """, 1024, 1024);
Console.WriteLine($"The generated image is ready at:\n{imageUrl}");
```

Customize the prompt to personalize the images generated by the model.

:::zone target="docs" pivot="azure-openai"

## Clean up resources

When you no longer need the sample application or resources, remove the corresponding deployment and all resources.

```azdeveloper
azd down
```

[!INCLUDE [troubleshoot](includes/troubleshoot.md)]

:::zone-end

## Next steps

- [Quickstart - Summarize text using an AI chat app with .NET](quickstart-openai-summarize-text.md)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
