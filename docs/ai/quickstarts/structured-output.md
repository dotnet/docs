---
title: Quickstart - Request a response with structured output
description: Learn how to create a chat app that responds with structured output, that is, output that conforms to a type that you specify.
ms.date: 04/30/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
---

# Request a response with structured output

In this quickstart, you create a chat app that requests a response with *structured output*. A structured output response is a chat response that's of a type you specify instead of just plain text. The chat app you create in this quickstart analyzes sentiment of various product reviews, categorizing each review according to the values of a custom enumeration.

## Prerequisites

- [.NET 8 or a later version](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/) (optional)

## Configure the AI service

To provision an Azure OpenAI service and model using the Azure portal, complete the steps in the [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource?pivots=web-portal) article. In the "Deploy a model" step, select the `gpt-4o` model.

## Create the chat app

Complete the following steps to create a console app that connects to the `gpt-4o` AI model.

1. In a terminal window, navigate to the directory where you want to create your app, and create a new console app with the `dotnet new` command:

    ```dotnetcli
    dotnet new console -o SOChat
    ```

1. Navigate to the `SOChat` directory, and add the necessary packages to your app:

    ```dotnetcli
    dotnet add package Azure.AI.OpenAI
    dotnet add package Azure.Identity
    dotnet add package Microsoft.Extensions.AI --prerelease
    dotnet add package Microsoft.Extensions.AI.OpenAI --prerelease
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    ```

1. Run the following commands to add [app secrets](/aspnet/core/security/app-secrets) for your Azure OpenAI endpoint, model name, and tenant ID:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set AZURE_OPENAI_ENDPOINT <your-azure-openai-endpoint>
    dotnet user-secrets set AZURE_OPENAI_GPT_NAME gpt-4o
    dotnet user-secrets set AZURE_TENANT_ID <your-tenant-id>
    ```

   (Depending on your environment, the tenant ID might not be needed. In that case, remove it from the code that instantiates the <xref:Azure.Identity.DefaultAzureCredential>.)

1. Open the new app in your editor of choice.

## Add the code

1. Define the enumeration that describes the different sentiments.

   :::code language="csharp" source="./snippets/structured-output/Program.cs" id="SentimentEnum":::

1. Create the <xref:Microsoft.Extensions.AI.IChatClient> that will communicate with the model.

   :::code language="csharp" source="./snippets/structured-output/Program.cs" id="GetChatClient":::

1. Send a request to the model with a single product review, and then print the analyzed sentiment to the console. You declare the requested structured output type by passing it as the type argument to the <xref:Microsoft.Extensions.AI.ChatClientStructuredOutputExtensions.GetResponseAsync``1(Microsoft.Extensions.AI.IChatClient,System.String,Microsoft.Extensions.AI.ChatOptions,System.Nullable{System.Boolean},System.Threading.CancellationToken)?displayProperty=nameWithType> extension method.

   :::code language="csharp" source="./snippets/structured-output/Program.cs" id="SimpleRequest":::

   This code produces output similar to:

   ```output
   Sentiment: Positive
   ```

1. Instead of just analyzing a single review, you can analyze a collection of reviews.

   :::code language="csharp" source="./snippets/structured-output/Program.cs" id="MultipleReviews":::

   This code produces output similar to:

   ```output
   Review: Best purchase ever! | Sentiment: Positive
   Review: Returned it immediately. | Sentiment: Negative
   Review: Hello | Sentiment: Neutral
   Review: It works as advertised. | Sentiment: Neutral
   Review: The packaging was damaged but otherwise okay. | Sentiment: Neutral
   ```

1. And instead of requesting just the analyzed enumeration value, you can request the text response along with the analyzed value.

   Define a record type to contain the text response and analyzed sentiment:

   :::code language="csharp" source="./snippets/structured-output/Program.cs" id="InputOutputRecord":::

   Send the request using the record type as the type argument to `GetResponseAsync<T>`:

   :::code language="csharp" source="./snippets/structured-output/Program.cs" id="RecordRequest":::

   This code produces output similar to:

   ```output
   Response text: Analyzing the sentiment of the review. | Sentiment: Neutral
   ```

## See also

- [Structured outputs (Azure OpenAI Service)](/azure/ai-services/openai/how-to/structured-outputs)
- [Using JSON schema for structured output in .NET for OpenAI models](https://devblogs.microsoft.com/semantic-kernel/using-json-schema-for-structured-output-in-net-for-openai-models)
- [Introducing Structured Outputs in the API (OpenAI)](https://openai.com/index/introducing-structured-outputs-in-the-api/)
