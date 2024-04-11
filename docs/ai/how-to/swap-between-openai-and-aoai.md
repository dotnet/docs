---
title: "Swap between OpenAI and AOAI"
description: "Demonstrates how to swap between OpenAI and Azure OpenAI (AOAI) using the Semantic Kernel SDK for .NET."
author: haywoodsloan
ms.topic: how-to
ms.date: 04/09/2024

#customer intent: As a .NET developer, I want to swap between OpenAI and Azure OpenAI (AOAI) so that I can choose the AI service that's best for me.

---

# Swap between OpenAI and AOAI

This article demonstrates how to swap between the OpenAI and [Azure OpenAI](/azure/ai-services/openai/overview) (AOAI) services using the [Semantic Kernel SDK](/semantic-kernel/overview). Additionally, it shows how to switch your .NET projects to the Semantic Kernel SDK from the [AOAI client library](/dotnet/api/overview/azure/ai.openai-readme).

## Prerequisites

* An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/free/?WT.mc_id=A261C142F).
* [.NET SDK](https://dotnet.microsoft.com/download/visual-studio-sdks)
* [`Microsoft.SemanticKernel` NuGet package](https://www.nuget.org/packages/Microsoft.SemanticKernel)
* [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource)

## Switch from the AOAI client library to Semantic Kernel SDK

The following section shows how to add the Semantic Kernel SDK to your .NET project and use it to replace the AOAI client library.

To begin, add the [Semantic Kernel NuGet package](https://www.nuget.org/packages/Microsoft.SemanticKernel) to your project. The following command adds this package to the .NET project in your current working directory:

```dotnetcli
dotnet add package Microsoft.SemanticKernel
```

The Semantic Kernel SDK supports both prompt and chat completions.

### Implement prompt completions with Semantic Kernel

A basic implementation of prompt completions with the AOAI client library might look like the following:

:::code language="csharp" source="./snippets/azure-openai-sdk/CompletionExamples.cs" id="promptCompletion":::

The Semantic Kernel equivalent would be:

:::code language="csharp" source="./snippets/semantic-kernel/CompletionExamples.cs" id="promptCompletion":::

### Implement chat completions with Semantic Kernel

A basic implementation of chat completions with the AOAI client library might look like the following:

:::code language="csharp" source="./snippets/azure-openai-sdk/CompletionExamples.cs" id="chatCompletion":::

The Semantic Kernel equivalent would be:

:::code language="csharp" source="./snippets/semantic-kernel/CompletionExamples.cs" id="chatCompletion":::

## Swap between OpenAI and AOAI with Semantic Kernel

The following section shows how to swap your .NET project between OpenAI and AOAI services when using the Semantic Kernel SDK.

Before swapping to AOAI, ensure you have followed the prerequisite steps to [create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource). Once you've created an AOAI resource, you'll need retrieve the endpoint URL; you can do that through the [Azure portal](https://portal.azure.com) or with the following Azure CLI command:

```azurecli
az cognitiveservices account show \
--name <myResourceName> \
--resource-group  <myResourceGroupName>
```

Swapping between OpenAI and AOAI simply requires changing the initial service configuration. For example, consider the following configuration for using OpenAI:

:::code language="csharp" source="./snippets/semantic-kernel/AuthExamples.cs" id="openaiAuth":::

Semantic Kernel can be similarly configured to use AOAI with either an API key or token-based authentication:

### Use AOAI with API key authentication

To begin, you'll need to retrieve the key from your deployed AOAI resource. You can retrieve the key through the [Azure portal](https://portal.azure.com) or with the following Azure CLI command:

```azurecli
az cognitiveservices account keys list \
--name <myResourceName> \
--resource-group  <myResourceGroupName>
```

The following configuration uses AOAI with API key authentication:

:::code language="csharp" source="./snippets/semantic-kernel/AuthExamples.cs" id="aoaiApiKeyAuth":::

### Use AOAI with token-based authentication

To begin, you'll need to add the [Azure Identity NuGet package](https://www.nuget.org/packages/Azure.Identity) to your project. The following command adds this package to the .NET project in your current working directory:

```dotnetcli
dotnet add package Azure.Identity
```

The following configuration uses AOAI with token-based authentication:

:::code language="csharp" source="./snippets/semantic-kernel/AuthExamples.cs" id="aoaiTokenAuth":::

## Related content

* [What is Semantic Kernel](/semantic-kernel/overview/)
* [Summarize text using Azure AI chat app with .NET](../quickstarts/quickstart-openai-summarize-text.md?pivots=semantic-kernel)
* [How to work with local models](work-with-local-models.md)
