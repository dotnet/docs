---
title: Quickstart - Connect to and prompt an AI model with .NET
description: Create a simple chat app using Microsoft.Extensions.AI to summarize a text.
ms.date: 05/02/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
zone_pivot_groups: openai-library
# CustomerIntent: As a .NET developer new to OpenAI, I want deploy and use sample code to interact to learn from the sample code to summarize text.
---

# Connect to and prompt an AI model

In this quickstart, you learn how to create a .NET console chat app to connect to and prompt an OpenAI or Azure OpenAI model. The app uses the <xref:Microsoft.Extensions.AI> library so you can write code using AI abstractions rather than a specific SDK. AI abstractions enable you to change the underlying AI model with minimal code changes.

> [!NOTE]
> The <xref:Microsoft.Extensions.AI> library is currently in Preview.

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
    dotnet new console -o ExtensionsAI
    ```

1. Change directory into the app folder:

    ```dotnetcli
    cd ExtensionsAI
    ```

1. Install the required packages:

    :::zone target="docs" pivot="azure-openai"

    ```bash
    dotnet add package Azure.AI.OpenAI
    dotnet add package Azure.Identity
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

1. Open the app in Visual Studio Code or your editor of choice.

:::zone target="docs" pivot="azure-openai"

[!INCLUDE [create-ai-service](includes/create-ai-service.md)]

:::zone-end

:::zone target="docs" pivot="openai"

## Configure the app

1. Navigate to the root of your .NET project from a terminal or command prompt.

1. Run the following commands to configure your OpenAI API key as a secret for the sample app:

   ```bash
   dotnet user-secrets init
   dotnet user-secrets set OpenAIKey <your-openai-key>
   dotnet user-secrets set ModelName <your-openai-model-name>
   ```

:::zone-end

## Add the app code

The app uses the [`Microsoft.Extensions.AI`](https://www.nuget.org/packages/Microsoft.Extensions.AI/) package to send and receive requests to the AI model.

1. Copy the [benefits.md](https://raw.githubusercontent.com/dotnet/docs/refs/heads/main/docs/ai/quickstarts/snippets/prompt-completion/azure-openai/benefits.md) file to your project directory. Configure the project to copy this file to the output directory. If you're using Visual Studio, right-click on the file in Solution Explorer, select **Properties**, and then set **Copy to Output Directory** to **Copy if newer**.

1. In the `Program.cs` file, add the following code to connect and authenticate to the AI model.

   :::zone target="docs" pivot="azure-openai"

   :::code language="csharp" source="snippets/prompt-completion/azure-openai/program.cs" id="CreateChatClient":::

   > [!NOTE]
   > <xref:Azure.Identity.DefaultAzureCredential> searches for authentication credentials from your local tooling. If you aren't using the `azd` template to provision the Azure OpenAI resource, you'll need to assign the `Azure AI Developer` role to the account you used to sign-in to Visual Studio or the Azure CLI. For more information, see [Authenticate to Azure AI services with .NET](../azure-ai-services-authentication.md).

   :::zone-end

   :::zone target="docs" pivot="openai"

   :::code language="csharp" source="snippets/prompt-completion/openai/program.cs" id="CreateChatClient":::

   :::zone-end

1. Add code to read the `benefits.md` file content and then create a prompt for the model. The prompt instructs the model to summarize the file's text content in 20 words or less.

   :::code language="csharp" source="snippets/prompt-completion/openai/program.cs" id="CreatePrompt":::

1. Call the `GetResponseAsync` method to send the prompt to the model to generate a response.

   :::code language="csharp" source="snippets/prompt-completion/openai/program.cs" id="GetResponse":::

1. Run the app:

   ```dotnetcli
   dotnet run
   ```

   The app prints out the completion response from the AI model. Customize the text content of the `benefits.md` file or the length of the summary to see the differences in the responses.

:::zone target="docs" pivot="azure-openai"

## Clean up resources

If you no longer need them, delete the Azure OpenAI resource and GPT-4 model deployment.

1. In the [Azure Portal](https://aka.ms/azureportal), navigate to the Azure OpenAI resource.
1. Select the Azure OpenAI resource, and then select **Delete**.

:::zone-end

## Next steps

- [Quickstart - Build an AI chat app with .NET](build-chat-app.md)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
