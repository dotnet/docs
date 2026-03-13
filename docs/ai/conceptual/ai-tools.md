---
title: "AI tool calling"
description: "Understand how tool calling lets you integrate external tools with AI models across providers using Microsoft.Extensions.AI."
ms.topic: concept-article
ms.date: 03/03/2026
ai-usage: ai-assisted
---

# AI tool calling

*Tool calling* is an AI model capability that lets you describe available tools to an AI model so the model can request that your application invoke them. Tools can be .NET methods, calls to external APIs, interactions with [Model Context Protocol (MCP)](../get-started-mcp.md) servers, or any other executable operation. Instead of directly executing those tools, the model returns a structured output describing which tools to call and with what arguments. Your application invokes those tools and sends the results back to the model, enabling it to build a more accurate and grounded response.

<xref:Microsoft.Extensions.AI> (MEAI) provides provider-agnostic abstractions for tool calling that work across AI services, including Azure OpenAI, OpenAI, Ollama, and others. You write your tool-calling logic once, and it works regardless of which underlying model or provider you use.

## Why use tool calling

Tool calling simplifies how you connect external tools to AI models. You describe each tool to the model as part of the conversation. The model then decides which tools to invoke based on the user's question. After your application invokes the requested tools and returns the results, the model uses those results to construct a more complete and accurate response.

Common use cases for tool calling include:

- Answering questions by calling external APIs. For example, checking the weather forecast, or sending email.
- Retrieving information from internal data stores. For example, aggregating sales data to answer, "What are my best-selling products?"
- Producing structured data from unstructured text. For example, constructing a user profile from chat history.

## Call AI functions in MEAI

The general flow for calling AI functions with <xref:Microsoft.Extensions.AI.IChatClient> is:

1. Define .NET methods as functions and configure them on a <xref:Microsoft.Extensions.AI.ChatOptions> instance.
1. Send the user's message to the model. The model decides which functions, if any, to call. It returns a structured response that lists the function calls and their arguments.

   > [!NOTE]
   > Models might hallucinate arguments that weren't described in your function definitions.

1. Parse the model's response and invoke the requested functions with the specified arguments.
1. Send another request that includes the function results as new messages in the conversation history.
1. The model responds with more function call requests or a final answer to the user's question. Continue invoking requested functions until the model provides a final response.

MEAI's <xref:Microsoft.Extensions.AI.FunctionInvokingChatClient> handles steps 3 through 5 automatically, so you don't need to manage the invocation loop yourself.

## Key types

MEAI provides the following types to support function calling:

- <xref:Microsoft.Extensions.AI.AIFunction>: Represents a function that can be described to an AI model, and invoked. This is the core abstraction for a function in MEAI.
- <xref:Microsoft.Extensions.AI.AIFunctionFactory>: Provides factory methods for creating `AIFunction` instances from .NET methods. Use `AIFunctionFactory` to wrap existing methods as functions without writing boilerplate description or argument-parsing code.
- <xref:Microsoft.Extensions.AI.FunctionInvokingChatClient>: Wraps any `IChatClient` and adds automatic function-invocation capabilities. When the model requests a function call, `FunctionInvokingChatClient` invokes the corresponding `AIFunction`, collects the result, and continues the conversation—all transparently.

## Parallel function calling

Some models support *parallel function calling*, where the model requests multiple function invocations in a single response. Your application invokes each function and returns all results together in one follow-up message. Parallel function calling reduces the number of round trips to the model, which lowers latency and API usage. `FunctionInvokingChatClient` supports parallel function calling automatically.

## Cross-provider support

One of the key benefits of using MEAI for function calling is provider independence. The `AIFunction`, `AIFunctionFactory`, and `FunctionInvokingChatClient` types work with any `IChatClient` implementation, including:

- Azure OpenAI
- OpenAI
- Ollama
- Any other provider that implements `IChatClient`

Because function calling support varies across models and providers, check your provider's documentation to confirm whether a specific model supports function calling or parallel function calling.

## Token considerations

Tool descriptions are included in the request sent to the model and count against the model's token limit. This means tool definitions contribute to both token consumption and request cost.

If your request approaches the model's token limit, consider these adjustments:

- Reduce the number of tools registered for the conversation.
- Shorten the method names and descriptions used to generate tool definitions.
- Limit tool registration to only the tools relevant for a given conversation context.

## Related content

- [Invoke .NET functions using an AI model](../quickstarts/use-function-calling.md)
- [Use the IChatClient interface](../ichatclient.md)
- [Understanding tokens](understanding-tokens.md)
- [Prompt engineering](prompt-engineering-dotnet.md)
