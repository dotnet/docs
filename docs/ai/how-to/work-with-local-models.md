---
title: "Use Custom and Local AI Models with the Semantic Kernel SDK for .NET"
titleSuffix: ""
description: "Learn how to use custom or local models for text generation and chat completions in Semantic Kernel SDK for .NET."
author: haywoodsloan
ms.topic: how-to 
ms.date: 04/11/2024
ms.service: dotnet
ms.subservice: intelligent-apps

#customer intent: As a .NET developer, I want to use custom or local AI models with the Semantic Kernel SDK so that I can perform text generation and chat completions using any model available to me.

---

# Use custom and local AI models with the Semantic Kernel SDK

This article demonstrates how to integrate custom and local models into the [Semantic Kernel SDK](/semantic-kernel/overview) and use them for text generation and chat completions.

You can adapt the steps to use them with any model that you can access, regardless of where or how you access it. For example, you can integrate the [codellama](https://ollama.com/library/codellama) model with the Semantic Kernel SDK to enable code generation and discussion.

Custom and local models often provide access via REST APIs, for example see [Ollama OpenAI compatibility](https://ollama.com/blog/openai-compatibility). Before you integrate your model it will need to be hosted and accessible to your .NET application via HTTPS.

## Prerequisites

* An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/free/?WT.mc_id=A261C142F).
* [.NET SDK](https://dotnet.microsoft.com/download/visual-studio-sdks)
* [`Microsoft.SemanticKernel` NuGet package](https://www.nuget.org/packages/Microsoft.SemanticKernel)
* A custom or local model, deployed and accessible to your .NET application

## Implement text generation using a local model

The following section shows how you can integrate your model with the Semantic Kernel SDK and then use it to generate text completions.

1. Create a service class that implements the `ITextGenerationService` interface. For example:

    :::code language="csharp" source="./snippets/semantic-kernel/services/MyTextGenerationService.cs" id="service":::

2. Include the new service class when building the `Kernel`. For example:

    :::code language="csharp" source="./snippets/semantic-kernel/LocalModelExamples.cs" id="addTextService":::

3. Send a text generation prompt to your model directly through the `Kernel` or using the service class. For example:

    :::code language="csharp" source="./snippets/semantic-kernel/LocalModelExamples.cs" id="useTextService":::

## Implement chat completion using a local model

The following section shows how you can integrate your model with the Semantic Kernel SDK and then use it for chat completions.

1. Create a service class that implements the `IChatCompletionService` interface. For example:

    :::code language="csharp" source="./snippets/semantic-kernel/services/MyChatCompletionService.cs" id="service":::

2. Include the new service class when building the `Kernel`. For example:

    :::code language="csharp" source="./snippets/semantic-kernel/LocalModelExamples.cs" id="addChatService":::

3. Send a chat completion prompt to your model directly through the `Kernel` or using the service class. For example:

    :::code language="csharp" source="./snippets/semantic-kernel/LocalModelExamples.cs" id="useChatService":::

## Related content

* [What is Semantic Kernel](/semantic-kernel/overview/)
* [Understanding AI plugins in Semantic Kernel](/semantic-kernel/agents/plugins/?tabs=Csharp)
