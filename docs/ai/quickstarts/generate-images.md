---
title: Quickstart - Generate images using AI with .NET
description: Create a simple app using to generate images using .NET and the OpenAI or Azure OpenAI models.
ms.date: 04/09/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
zone_pivot_groups: openai-library
# CustomerIntent: As a .NET developer new to OpenAI, I want deploy and use sample code to interact to learn from the sample code to generate images.
---

# Generate images using AI with .NET

In this quickstart, you learn how to create a .NET console app to generate images using an OpenAI or Azure OpenAI DALLe AI model, which are specifically designed to generate images based on text prompts.

:::zone target="docs" pivot="openai"

[!INCLUDE [openai-prereqs](includes/prerequisites-openai.md)]

:::zone-end

:::zone target="docs" pivot="azure-openai"

[!INCLUDE [azure-openai-prereqs](includes/prerequisites-azure-openai.md)]

:::zone-end

[!INCLUDE [semantic-kernel](includes/semantic-kernel.md)]

## Create the app

Complete the following steps to create a .NET console app to connect to an AI model.

1. In an empty directory on your computer, use the `dotnet new` command to create a new console app:

    ```dotnetcli
    dotnet new console -o ImagesAI
    ```

1. Change directory into the app folder:

    ```dotnetcli
    cd ImagesAI
    ```

1. Install the required packages:

    :::zone target="docs" pivot="azure-openai"

    ```bash
    dotnet add package Azure.AI.OpenAI
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    ```

    :::zone-end

    :::zone target="docs" pivot="openai"

    ```bash
    dotnet add package OpenAI
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    ```

    :::zone-end

1. Open the app in Visual Studio Code or your editor of choice.

    ```bash
    code .
    ```

:::zone target="docs" pivot="azure-openai"

[!INCLUDE [create-ai-service](includes/create-ai-service.md)]

:::zone-end

:::zone target="docs" pivot="openai"

## Configure the app

1. Navigate to the root of your .NET project from a terminal or command prompt.

1. Run the following commands to configure your OpenAI API key as a secret for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set OpenAIKey <your-OpenAI-key>
    dotnet user-secrets set ModelName <your-OpenAI-model-name>
    ```

:::zone-end

## Add the app code

1. In the `Program.cs` file, add the following code to connect and authenticate to the AI model.

    :::zone target="docs" pivot="azure-openai"

    :::code language="csharp" source="snippets/image-generation/azure-openai/program.cs" :::

    > [!NOTE]
    > <xref:Azure.Identity.DefaultAzureCredential> searches for authentication credentials from your local tooling. If you aren't using the `azd` template to provision the Azure OpenAI resource, you'll need to assign the `Azure AI Developer` role to the account you used to sign-in to Visual Studio or the Azure CLI. For more information, see [Authenticate to Azure AI services with .NET](../azure-ai-services-authentication.md).

    :::zone-end

    :::zone target="docs" pivot="openai"

    :::code language="csharp" source="snippets/image-generation/openai/program.cs" :::

    :::zone-end

    The preceding code:

    - Reads essential configuration values from the project user secrets to connect to the AI model.
    - Creates an `OpenAI.Images.ImageClient` to connect to the AI model.
    - Sends a prompt to the model that describes the desired image.
    - Prints the URL of the generated image to the console output.

1. Run the app:

    ```dotnetcli
    dotnet run
    ```

    Navigate to the image URL in the console output to view the generated image. Customize the text content of the prompt to create new images or modify the original.

:::zone target="docs" pivot="azure-openai"

## Clean up resources

If you no longer need them, delete the Azure OpenAI resource and GPT-4 model deployment.

1. In the [Azure Portal](https://aka.ms/azureportal), navigate to the Azure OpenAI resource.
1. Select the Azure OpenAI resource, and then select **Delete**.

:::zone-end

## Next steps

- [Quickstart - Build an AI chat app with .NET](build-chat-app.md)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
