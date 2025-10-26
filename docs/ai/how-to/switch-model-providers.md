---
title: Switch model providers with Microsoft.Extensions.AI
description: Learn how to dynamically switch between different AI model providers using Microsoft.Extensions.AI in various scenarios such as development vs production, smart routing, and batch evaluations.
author: IEvangelist
ms.author: dapine
ms.topic: how-to
ms.date: 01/16/2025
ai-usage: ai-generated
#customer intent: As a .NET developer, I want to switch between different AI model providers based on environment, complexity, or other criteria using Microsoft.Extensions.AI.
---

# Switch model providers with Microsoft.Extensions.AI

This article demonstrates how to dynamically switch between different AI model providers using Microsoft.Extensions.AI. The Microsoft.Extensions.AI libraries provide abstractions that enable seamless portability across different AI services and models.

## Why switch model providers

There are several scenarios where you might want to switch between different AI model providers:

- **Environment-based switching**: Use local models during development and cloud models in production
- **Smart routing**: Choose different providers based on query complexity, cost, or performance requirements
- **Batch evaluations**: Test prompts across multiple providers to compare results and find the best performing model
- **Fallback scenarios**: Automatically switch to an alternative provider if the primary one is unavailable
- **Cost optimization**: Route simpler queries to less expensive models and complex ones to premium models

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- Basic understanding of [Microsoft.Extensions.AI](../microsoft-extensions-ai.md)
- Access to at least one AI service (Azure OpenAI, OpenAI, Ollama, etc.)

## Environment-based provider switching

One of the most common scenarios is switching between local models during development and cloud-hosted models in production. This approach allows you to develop and test locally without incurring cloud costs or requiring internet connectivity.

### Switching chat clients

The following example shows how to conditionally create different `IChatClient` implementations based on the current environment:

:::code language="csharp" source="snippets/switch-model-providers/EnvironmentSwitch/Program.cs" range="1-25":::

### Switching embedding generators

Similarly, you can switch embedding generators based on environment:

:::code language="csharp" source="snippets/switch-model-providers/EnvironmentSwitch/Program.cs" range="27-37":::

## Smart routing based on query complexity

You can implement smart routing to choose different providers based on the complexity or type of query. This approach helps optimize cost and performance.

:::code language="csharp" source="snippets/switch-model-providers/SmartRouting/Program.cs":::

## Batch evaluation across providers

For evaluation purposes, you might want to test the same prompt across multiple providers to compare results:

:::code language="csharp" source="snippets/switch-model-providers/BatchEvaluation/Program.cs":::

## Configuration-based provider switching

For more complex scenarios, you can use configuration to define which providers to use:

:::code language="csharp" source="snippets/switch-model-providers/ConfigurationBased/Program.cs":::

With the corresponding configuration in `appsettings.json`:

:::code language="json" source="snippets/switch-model-providers/ConfigurationBased/appsettings.json":::

## Dependency injection with multiple providers

When using dependency injection, you can register multiple providers and resolve them by name or type:

:::code language="csharp" source="snippets/switch-model-providers/DependencyInjection/Program.cs":::

## Best practices

When switching between model providers, consider the following best practices:

### Use abstractions consistently

Always program against the `IChatClient` and `IEmbeddingGenerator<TInput, TEmbedding>` interfaces rather than concrete implementations. This ensures your code remains portable across different providers.

### Handle provider-specific differences

Different providers might have varying capabilities, rate limits, or response formats. Implement error handling and fallback mechanisms:

```csharp
try
{
    var response = await chatClient.GetResponseAsync(prompt, options);
    return response;
}
catch (Exception ex) when (IsRateLimitException(ex))
{
    // Switch to fallback provider or implement retry logic
    var fallbackClient = GetFallbackClient();
    return await fallbackClient.GetResponseAsync(prompt, options);
}
```

### Configure options appropriately

Different providers might require different configuration options. Use the `ChatOptions` parameter to specify provider-specific settings:

```csharp
var options = new ChatOptions
{
    ModelId = provider == "openai" ? "gpt-4" : "llama3.1",
    Temperature = 0.7f,
    MaxOutputTokens = provider == "local" ? 1000 : 2000
};
```

### Monitor and log provider usage

Track which providers are being used and their performance characteristics:

```csharp
using var activity = ActivitySource.StartActivity("chat-request");
activity?.SetTag("provider", providerName);
activity?.SetTag("model", modelId);

var response = await chatClient.GetResponseAsync(prompt, options);

activity?.SetTag("tokens.input", response.Usage?.InputTokenCount);
activity?.SetTag("tokens.output", response.Usage?.OutputTokenCount);
```

## See also

- [Microsoft.Extensions.AI libraries](../microsoft-extensions-ai.md)
- [Sample implementations of IChatClient and IEmbeddingGenerator](../advanced/sample-implementations.md)
- [Authentication for Azure-hosted apps and services](../azure-ai-services-authentication.md)
- [Configuration in .NET](../../core/extensions/configuration.md)
- [Dependency injection in .NET](../../core/extensions/dependency-injection.md)
