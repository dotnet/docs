---
title: Access data in AI functions
description: Learn how to pass data to AIFunction objects and how to access the data within the function delegate.
ms.date: 11/17/2025
---

# Access data in AI functions

When you create AI functions, you might need to access contextual data beyond the parameters provided by the AI model. The `Microsoft.Extensions.AI` library provides several mechanisms to pass data to function delegates.

## Pass data

You can associate data with the function at the time it's created, either via closure or via <xref:Microsoft.Extensions.AI.ChatOptions.AdditionalProperties>. If you're creating your own function, you can populate `AdditionalProperties` however you want. If you use <xref:Microsoft.Extensions.AI.AIFunctionFactory> to create the function, you can populate data using <xref:Microsoft.Extensions.AI.AIFunctionFactoryOptions.AdditionalProperties?displayProperty=nameWithType>.

## Access data in function delegates

You might call your `AIFunction` directly, or you might call it indirectly by using <xref:Microsoft.Extensions.AI.FunctionInvokingChatClient>. The following sections describe how to access argument data using either approach.

### Manual function invocation

If you manually invoke an <xref:Microsoft.Extensions.AI.AIFunction> by calling <xref:Microsoft.Extensions.AI.AIFunction.InvokeAsync(Microsoft.Extensions.AI.AIFunctionArguments,System.Threading.CancellationToken)?displayProperty=nameWithType>, you pass in <xref:Microsoft.Extensions.AI.AIFunctionArguments>. The <xref:Microsoft.Extensions.AI.AIFunctionArguments> type includes:

- A dictionary of named arguments.
- <xref:Microsoft.Extensions.AI.AIFunctionArguments.Context>: An arbitrary `IDictionary<object, object>` for passing additional ambient data into the function.
- <xref:Microsoft.Extensions.AI.AIFunctionArguments.Services>: An <xref:System.IServiceProvider> that lets the `AIFunction` resolve arbitrary state from a [dependency injection (DI)](../../core/extensions/dependency-injection.md) container.

If you want to access either the `AIFunctionArguments` or the `IServiceProvider` from within your <xref:Microsoft.Extensions.AI.AIFunctionFactory.Create*?displayProperty=nameWithType> delegate, create a parameter typed as `IServiceProvider` or `AIFunctionArguments`. That parameter will be bound to the relevant data from the `AIFunctionArguments` passed to `AIFunction.InvokeAsync()`.

The following code shows an example:

:::code language="csharp" source="snippets/access-data/ArgumentsExample.cs" id="UseAIFunctionArguments":::

### Invocation through `FunctionInvokingChatClient`

<xref:Microsoft.Extensions.AI.FunctionInvokingChatClient> publishes state about the current invocation to <xref:Microsoft.Extensions.AI.FunctionInvokingChatClient.CurrentContext?displayProperty=nameWithType>, including not only the arguments, but all of the input `ChatMessage` objects, the <xref:Microsoft.Extensions.AI.ChatOptions>, and details on which function is being invoked (out of how many). You can add any data you want into <xref:Microsoft.Extensions.AI.ChatOptions.AdditionalProperties?displayProperty=nameWithType> and extract that inside of your `AIFunction` from `FunctionInvokingChatClient.CurrentContext.Options.AdditionalProperties`.

The following code shows an example:

:::code language="csharp" source="snippets/access-data/ArgumentsExample.cs" id="UseAdditionalProperties":::

#### Dependency injection

If you use <xref:Microsoft.Extensions.AI.FunctionInvokingChatClient> to invoke functions automatically, that client configures an <xref:Microsoft.Extensions.AI.AIFunctionArguments> object that it passes into the `AIFunction`. Because `AIFunctionArguments` includes the `IServiceProvider` that the `FunctionInvokingChatClient` was itself provided with, if you construct your client using standard DI means, that `IServiceProvider` is passed all the way into your `AIFunction`. At that point, you can query it for anything you want from DI.

## Advanced techniques

If you want more fine-grained control over how parameters are bound, you can use <xref:Microsoft.Extensions.AI.AIFunctionFactoryOptions.ConfigureParameterBinding?displayProperty=nameWithType>, which puts you in control over how each parameter is populated. For example, the [MCP C# SDK uses this technique](https://github.com/modelcontextprotocol/csharp-sdk/blob/d344c651203841ec1c9e828736d234a6e4aebd07/src/ModelContextProtocol.Core/Server/AIFunctionMcpServerTool.cs#L83-L107) to automatically bind parameters from DI.

If you use the <xref:Microsoft.Extensions.AI.AIFunctionFactory.Create(System.Reflection.MethodInfo,System.Func{Microsoft.Extensions.AI.AIFunctionArguments,System.Object},Microsoft.Extensions.AI.AIFunctionFactoryOptions)?displayProperty=nameWithType> overload, you can also run your own arbitrary logic when you create the target object that the instance method will be called on, each time. And you can do whatever you want to configure that instance.
