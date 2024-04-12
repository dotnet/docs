---
title: "Work with local models"
description: "Demonstrates how to use custom or local models with the Semantic Kernel SDK for .NET."
author: haywoodsloan
ms.topic: how-to 
ms.date: 04/11/2024

#customer intent: As a .NET developer, I want use custom or local AI models with the Semantic Kernel SDK so that I can choose the model that's best for me.

---

# Work with local models

This article demonstrates how to integrate a local or custom model into the [Semantic Kernel SDK](/semantic-kernel/overview).

Integrating a custom model enables the Semantic Kernel SDK to utilize any model you have available, regardless of where or how you access the model.

## Prerequisites

* An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/free/?WT.mc_id=A261C142F).
* [.NET SDK](https://dotnet.microsoft.com/download/visual-studio-sdks)
* [`Microsoft.SemanticKernel` NuGet package](https://www.nuget.org/packages/Microsoft.SemanticKernel)
* Deploy your model, it should be accessible to your .NET application

## Implement text generation using a local model

The following section shows how to integrate your model with the Semantic Kernel SDK and use it for text generation.

1. Create a service class that implements the `ITextGenerationService` interface. For example:

    :::code language="csharp" source="./snippets/semantic-kernel/services/MyTextGenerationService.cs" id="service":::

2. Include the new service class when building the `Kernel`. For example:

    :::code language="csharp" source="./snippets/semantic-kernel/LocalModelExamples.cs" id="addTextService":::

3. Send a text generation prompt to your model directly through the `Kernel` or using the service class. For example:

    :::code language="csharp" source="./snippets/semantic-kernel/LocalModelExamples.cs" id="useTextService":::

## Implement chat completion using a local model

The following section shows how to integrate your model with the Semantic Kernel SDK and use it for chat completion.

1. Create a service class that implements the `IChatCompletionService` interface. For example:

    :::code language="csharp" source="./snippets/semantic-kernel/services/MyChatCompletionService.cs" id="service":::

2. Include the new service class when building the `Kernel`. For example:

    :::code language="csharp" source="./snippets/semantic-kernel/LocalModelExamples.cs" id="addChatService":::

3. Send a chat completion prompt to your model directly through the `Kernel` or using the service class. For example:

    :::code language="csharp" source="./snippets/semantic-kernel/LocalModelExamples.cs" id="useChatService":::

## Related content

* [What is Semantic Kernel](/semantic-kernel/overview/)
