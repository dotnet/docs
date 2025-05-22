---
title: Quickstart - Extend OpenAI using Tools and execute a local Function with .NET
description: Create a simple chat app using OpenAI and extend the model to execute a local function.
ms.date: 03/13/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: fboucher
zone_pivot_groups: openai-library
# CustomerIntent: As a .NET developer new to OpenAI, I want deploy and use sample code to interact to learn from the sample code how to extend the model using Tools.
---

# Invoke .NET functions using an AI model

In this quickstart, you create a .NET console AI chat app to connect to an AI model with local function calling enabled. The app uses the <xref:Microsoft.Extensions.AI> library so you can write code using AI abstractions rather than a specific SDK. AI abstractions enable you to change the underlying AI model with minimal code changes.

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
    dotnet new console -o FunctionCallingAI
    ```

1. Change directory into the app folder:

    ```dotnetcli
    cd FunctionCallingAI
    ```

1. Install the required packages:

    :::zone target="docs" pivot="azure-openai"

    ```bash
    dotnet add package Azure.Identity
    dotnet add package Azure.AI.OpenAI
    dotnet add package Microsoft.Extensions.AI
    dotnet add package Microsoft.Extensions.AI.OpenAI --prerelease
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    ```

    :::zone-end

    :::zone target="docs" pivot="openai"

    ```bash
    dotnet add package Microsoft.Extensions.AI
    dotnet add package Microsoft.Extensions.AI.OpenAI --prerelease
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    ```

    :::zone-end

1. Open the app in Visual Studio Code or your editor of choice

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

The app uses the [`Microsoft.Extensions.AI`](https://www.nuget.org/packages/Microsoft.Extensions.AI/) package to send and receive requests to the AI model.

1. In the **Program.cs** file, add the following code to connect and authenticate to the AI model. The `ChatClient` is also configured to use function invocation, which allows the AI model to call .NET functions in your code.

    :::zone target="docs" pivot="azure-openai"

    :::code language="csharp" source="snippets/function-calling/azure-openai/program.cs" id="GetChatClient":::

    > [!NOTE]
    > <xref:Azure.Identity.DefaultAzureCredential> searches for authentication credentials from your local tooling. If you aren't using the `azd` template to provision the Azure OpenAI resource, you'll need to assign the `Azure AI Developer` role to the account you used to sign in to Visual Studio or the Azure CLI. For more information, see [Authenticate to Azure AI services with .NET](../azure-ai-services-authentication.md).

    :::zone-end

    :::zone target="docs" pivot="openai"

    :::code language="csharp" source="snippets/function-calling/openai/program.cs" id="GetChatClient":::

    :::zone-end

1. Create a new `ChatOptions` object that contains an inline function the AI model can call to get the current weather. The function declaration includes a delegate to run logic, and name and description parameters to describe the purpose of the function to the AI model.

    :::code language="csharp" source="snippets/function-calling/openai/program.cs" id="AddOptions":::

1. Add a system prompt to the `chatHistory` to provide context and instructions to the model. Send a user prompt with a question that requires the AI model to call the registered function to properly answer the question.

    :::code language="csharp" source="snippets/function-calling/openai/program.cs" id="PromptModel":::

1. Use the `dotnet run` command to run the app:

    ```dotnetcli
    dotnet run
    ```

    The app prints the completion response from the AI model, which includes data provided by the .NET function. The AI model understood that the registered function was available and called it automatically to generate a proper response.

:::zone target="docs" pivot="azure-openai"

## Clean up resources

If you no longer need them, delete the Azure OpenAI resource and GPT-4 model deployment.

1. In the [Azure Portal](https://aka.ms/azureportal), navigate to the Azure OpenAI resource.
1. Select the Azure OpenAI resource, and then select **Delete**.

:::zone-end

## Next steps

- [Quickstart - Build an AI chat app with .NET](build-chat-app.md)
- [Generate text and conversations with .NET and Azure OpenAI Completions](/training/modules/open-ai-dotnet-text-completions/)
