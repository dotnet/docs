---
title: Quickstart - Build an AI chat app with .NET
description: Create a simple AI powered chat app using Microsoft.Extensions.AI and the OpenAI or Azure OpenAI SDKs
ms.date: 04/09/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
zone_pivot_groups: openai-library
# CustomerIntent: As a .NET developer new to AI, I want deploy and use sample code to interact to learn from the sample code.
---

# Build an AI chat app with .NET

In this quickstart, you learn how to create a conversational .NET console chat app using an OpenAI or Azure OpenAI model. The app uses the <xref:Microsoft.Extensions.AI> library so you can write code using AI abstractions rather than a specific SDK. AI abstractions enable you to change the underlying AI model with minimal code changes.

> [!NOTE]
> The [`Microsoft.Extensions.AI`](https://www.nuget.org/packages/Microsoft.Extensions.AI/) library is currently in Preview.

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
    dotnet new console -o ChatAppAI
    ```

1. Change directory into the app folder:

    ```dotnetcli
    cd ChatAppAI
    ```

1. Install the required packages:

    :::zone target="docs" pivot="azure-openai"

    ```bash
    dotnet add package Azure.Identity
    dotnet add package Azure.AI.OpenAI
    dotnet add package Microsoft.Extensions.AI.OpenAI --prerelease
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    ```

    :::zone-end

    :::zone target="docs" pivot="openai"

    ```bash
    dotnet add package OpenAI
    dotnet add package Microsoft.Extensions.AI.OpenAI --prerelease
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    ```

    :::zone-end

1. Open the app in Visual Studio Code (or your editor of choice).

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

This app uses the [`Microsoft.Extensions.AI`](https://www.nuget.org/packages/Microsoft.Extensions.AI/) package to send and receive requests to the AI model. The app provides users with information about hiking trails.

1. In the `Program.cs` file, add the following code to connect and authenticate to the AI model.

    :::zone target="docs" pivot="azure-openai"

    :::code language="csharp" source="snippets/build-chat-app/azure-openai/program.cs" id="GetChatClient":::

    > [!NOTE]
    > <xref:Azure.Identity.DefaultAzureCredential> searches for authentication credentials from your local tooling. If you aren't using the `azd` template to provision the Azure OpenAI resource, you'll need to assign the `Azure AI Developer` role to the account you used to sign in to Visual Studio or the Azure CLI. For more information, see [Authenticate to Azure AI services with .NET](../azure-ai-services-authentication.md).

    :::zone-end

    :::zone target="docs" pivot="openai"

    :::code language="csharp" source="snippets/build-chat-app/openai/program.cs" id="GetChatClient":::

    :::zone-end

1. Create a system prompt to provide the AI model with initial role context and instructions about hiking recommendations:

    :::code language="csharp" source="snippets/build-chat-app/openai/program.cs" id="FirstMessage":::

1. Create a conversational loop that accepts an input prompt from the user, sends the prompt to the model, and prints the response completion:

    :::code language="csharp" source="snippets/build-chat-app/openai/program.cs" id="ChatLoop":::

1. Use the `dotnet run` command to run the app:

    ```dotnetcli
    dotnet run
    ```

    The app prints out the completion response from the AI model. Send additional follow up prompts and ask other questions to experiment with the AI chat functionality.

:::zone target="docs" pivot="azure-openai"

## Clean up resources

If you no longer need them, delete the Azure OpenAI resource and GPT-4 model deployment.

1. In the [Azure Portal](https://aka.ms/azureportal), navigate to the Azure OpenAI resource.
1. Select the Azure OpenAI resource, and then select **Delete**.

:::zone-end

## Next steps

- [Quickstart - Chat with a local AI model](chat-local-model.md)
- [Generate images using AI with .NET](generate-images.md)
