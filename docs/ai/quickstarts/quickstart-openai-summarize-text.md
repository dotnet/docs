---
title: Quickstart - Summarize text using an AI chat app with .NET
description: Create a simple chat app using Microsoft.Extensions.AI and the Semantic Kernel SDK to summarize a text.
ms.date: 07/17/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
ms.author: frbouche
zone_pivot_groups: openai-library
# CustomerIntent: As a .NET developer new to OpenAI, I want deploy and use sample code to interact to learn from the sample code to summarize text.
---

# Connect to and prompt an AI model using .NET

In this quickstart, learn how to create a .NET console chat app to connect to and prompt an OpenAI or Azure OpenAI model. The app uses the [`Microsoft.Extensions.AI`](https://www.nuget.org/packages/Microsoft.Extensions.AI) library so you can write code using AI abstractions rather than a specific SDK. AI abstractions enable you to change the underlying AI model with minimal code changes.

## Prerequisites

:::zone target="docs" pivot="openai"

[!INCLUDE [azure-openai-prereqs](includes/prerequisites-azure-openai.md)]

:::zone-end

:::zone target="docs" pivot="azure-openai"

[!INCLUDE [openai-prereqs](includes/prerequisites-openai.md)]

:::zone-end

## Clone the sample repository

[!INCLUDE [clone-sample-repo](includes/clone-sample-repo.md)]

## Create the app

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
    dotnet add package Azure.Identity
    dotnet add package Azure.AI.OpenAI
    dotnet add package Microsoft.Extensions.AI.OpenAI
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    ```

:::zone-end

:::zone target="docs" pivot="openai"

    ```bash
    dotnet add package OpenAI
    dotnet add package Microsoft.Extensions.AI.OpenAI
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    ```

:::zone-end

1. Open the app in Visual Studio code or your editor of choice

    ```bash
    code .
    ```

[!INCLUDE [create-ai-service](includes/create-ai-service.md)]

## Add the app code

The app uses the [`Microsoft.SemanticKernel`](https://www.nuget.org/packages/Microsoft.SemanticKernel) package to send and receive requests to the OpenAI service.

1. In the **Program.cs** file, add the following code to connect and authenticate to the AI model.

    <!-- markdownlint-disable MD023 -->
    # [Azure OpenAI](#tab/azure-openai)

    :::code language="csharp" source="snippets/prompt-completion/azure-openai/program.cs" range="6-14":::

    > [!NOTE]
    > `DefaultAzureCredential` searches for credentials from  your local tooling. If you are not using the `azd` template to provision the Azure OpenAI resource, you'll need to assign the `Azure AI Developer` role to the account you used to sign-in to Visual Studio or the Azure CLI.

    # [OpenAI](#tab/openai)

    :::code language="csharp" source="snippets/prompt-completion/openai/program.cs" range="5-13":::

    ---

1. Read the `benefits.md` file content and use it to create a `prompt` for model. The prompt instructs the model to summarize the file text content.

    :::code language="csharp" source="snippets/prompt-completion/openai/program.cs" range="15-20":::

1. Call the `InvokePromptAsync` function to send the `prompt` to the model to generate a response.

    :::code language="csharp" source="snippets/prompt-completion/openai/program.cs" range="22-24":::

    Customize the text content of the `benefits.md` file or the length of the summary to see the differences in the responses.

## Clean up resources

When you no longer need the sample application or resources, remove the corresponding deployment and all resources.

```azdeveloper
azd down
```

## Next steps

- [Quickstart - Build an AI chat app with .NET](get-started-openai.md)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
