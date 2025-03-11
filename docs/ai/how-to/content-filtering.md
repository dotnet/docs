---
title: "Manage OpenAI Content Filtering in a .NET app"
description: "Learn how to manage OpenAI content filtering programmatically in a .NET app using the OpenAI client library."
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
ms.topic: how-to
ms.date: 12/19/2024

#customer intent: As a .NET developer, I want to manage OpenAI Content Filtering in a .NET app

---

# Work with Azure OpenAI content filtering in a .NET app

This article demonstrates how to handle content filtering concerns in a .NET app. Azure OpenAI Service includes a content filtering system that works alongside core models. This system works by running both the prompt and completion through an ensemble of classification models aimed at detecting and preventing the output of harmful content. The content filtering system detects and takes action on specific categories of potentially harmful content in both input prompts and output completions. Variations in API configurations and application design might affect completions and thus filtering behavior.

The [Content Filtering](/azure/ai-services/openai/concepts/content-filter) documentation provides a deeper exploration of content filtering concepts and concerns. This article provides examples of how to work with content filtering features programmatically in a .NET app.

## Prerequisites

* An Azure account that has an active subscription. [Create an account for free](https://azure.microsoft.com/free/?WT.mc_id=A261C142F).
* [.NET SDK](https://dotnet.microsoft.com/download/visual-studio-sdks)
* [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource)

## Configure and test the content filter

To use the sample code in this article, you need to create and assign a content filter to your OpenAI model.

1. [Create and assign a content filter](/azure/ai-services/openai/how-to/content-filters) to your provisioned model.

1. Add the [`Azure.AI.OpenAI`](https://www.nuget.org/packages/Azure.AI.OpenAI) NuGet package to your project.

    ```dotnetcli
    dotnet add package Azure.AI.OpenAI
    ```

1. Create a simple chat completion flow in your .NET app using the `AzureOpenAiClient`. Replace the `YOUR_MODEL_ENDPOINT` and `YOUR_MODEL_DEPLOYMENT_NAME` values with your own.

    :::code language="csharp" source="./snippets/content-filtering/program.cs" :::

1. Replace the `YOUR_PROMPT` placeholder with your own message and run the app to experiment with content filtering results. If you enter a prompt the AI considers unsafe, Azure OpenAI returns a `400 Bad Request` code. The app prints a message in the console similar to the following:

```output
The response was filtered due to the prompt triggering Azure OpenAI's content management policy...
```

## Related content

* [Create and assign a content filter](/azure/ai-services/openai/how-to/content-filters)
* [Content Filtering concepts](/azure/ai-services/openai/concepts/content-filter)
* [Create a chat app](/dotnet/ai/quickstarts/prompt-model)
