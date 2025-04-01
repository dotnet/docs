---
title: Quickstart - Summarize text using an AI chat app with .NET
description: Create a simple chat app using Microsoft.Extensions.AI to summarize a text.
ms.date: 07/17/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
zone_pivot_groups: openai-library
# CustomerIntent: As a .NET developer new to OpenAI, I want deploy and use sample code to interact to learn from the sample code to summarize text.
---

# Connect to and prompt an AI model using .NET

In this quickstart, you learn how to create a .NET console chat app to connect to and prompt an OpenAI or Azure OpenAI model. The app uses the <xref:Microsoft.Extensions.AI> library so you can write code using AI abstractions rather than a specific SDK. AI abstractions enable you to change the underlying AI model with minimal code changes.

> [!NOTE]
> The [`Microsoft.Extensions.AI`](https://www.nuget.org/packages/Microsoft.Extensions.AI/) library is currently in Preview.

:::zone target="docs" pivot="openai"

[!INCLUDE [openai-prereqs](includes/prerequisites-openai.md)]

:::zone-end

:::zone target="docs" pivot="azure-openai"

[!INCLUDE [azure-openai-prereqs](includes/prerequisites-azure-openai.md)]

:::zone-end

[!INCLUDE [semantic-kernel](includes/semantic-kernel.md)]

[!INCLUDE [clone-sample-repo](includes/clone-sample-repo.md)]

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
    dotnet package add Azure.Identity
    dotnet package add Azure.AI.OpenAI
    dotnet package add Microsoft.Extensions.AI.OpenAI
    dotnet package add Microsoft.Extensions.Configuration
    dotnet package add Microsoft.Extensions.Configuration.UserSecrets
    ```

    :::zone-end

    :::zone target="docs" pivot="openai"

    ```bash
    dotnet package add OpenAI
    dotnet package add Microsoft.Extensions.AI.OpenAI
    dotnet package add Microsoft.Extensions.Configuration
    dotnet package add Microsoft.Extensions.Configuration.UserSecrets
    ```

    :::zone-end

1. Open the app in Visual Studio code or your editor of choice

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
    dotnet user-secrets set OpenAIKey <your-openai-key>
    dotnet user-secrets set ModelName <your-openai-model-name>
    ```

:::zone-end

## Add the app code

The app uses the [`Microsoft.Extensions.AI`](https://www.nuget.org/packages/Microsoft.Extensions.AI/) package to send and receive requests to the AI model.

1. In the **Program.cs** file, add the following code to connect and authenticate to the AI model.

    :::zone target="docs" pivot="azure-openai"

    :::code language="csharp" source="snippets/prompt-completion/azure-openai/program.cs" range="1-12":::

    > [!NOTE]
    > <xref:Azure.Identity.DefaultAzureCredential> searches for authentication credentials from your local tooling. If you aren't using the `azd` template to provision the Azure OpenAI resource, you'll need to assign the `Azure AI Developer` role to the account you used to sign-in to Visual Studio or the Azure CLI. For more information, see [Authenticate to Azure AI services with .NET](/dotnet/ai/azure-ai-services-authentication).

    :::zone-end

    :::zone target="docs" pivot="openai"

    :::code language="csharp" source="snippets/prompt-completion/openai/program.cs" range="1-11":::

    :::zone-end

1. Read the *benefits.md* file content and use it to create a prompt for the model. The prompt instructs the model to summarize the file text content.

    :::code language="csharp" source="snippets/prompt-completion/openai/program.cs" range="13-19":::

1. Call the `InvokePromptAsync` function to send the prompt to the model to generate a response.

    :::code language="csharp" source="snippets/prompt-completion/openai/program.cs" range="21-23":::

1. Use the `dotnet run` command to run the app:

    ```dotnetcli
    dotnet run
    ```

    The app prints out the completion response from the AI model. Customize the text content of the `benefits.md` file or the length of the summary to see the differences in the responses.

:::zone target="docs" pivot="azure-openai"

## Clean up resources

When you no longer need the sample application or resources, remove the corresponding deployment and all resources.

```azdeveloper
azd down
```

:::zone-end

## Next steps

- [Quickstart - Build an AI chat app with .NET](/dotnet/ai/quickstarts/build-chat-app)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
