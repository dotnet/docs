---
title: "Understanding OpenAI Function Calling"
description: "Understand how function calling enables you to integrate external tools with your OpenAI application."
ms.topic: concept-article
ms.date: 12/19/2024

#customer intent: As a .NET developer, I want to understand OpenAI function calling so that I can integrate external tools with AI completions in my .NET project.

---

# Understand OpenAI function calling

*Function calling* is an OpenAI model feature that lets you describe functions and their arguments in prompts using JSON. Instead of invoking the function itself, the model returns a JSON output describing what functions should be called and the arguments to use.

Function calling simplifies how you connect external tools to your AI model. First, you specify each tool's functions to the model. Then the model decides which functions should be called, based on the prompt question. The model uses the function call results to build a more accurate and consistent response.

Potential use cases for function calling include:

* Answering questions by calling external APIs, for example, sending emails or getting the weather forecast.
* Answering questions with info from an internal datastore, for example, aggregating sales data to answer, "What are my best-selling products?".
* Creating structured data from text info, for example, building a user info object with details from the chat history.

## Call functions with OpenAI

The general steps for calling functions with an OpenAI model are:

1. Send the user's question as a request with functions defined in the [`tools` parameters](https://platform.openai.com/docs/api-reference/chat/create#chat-create-tools).
1. The model decides which functions, if any, to call. The output contains a JSON object that lists the function calls and their arguments.
    > [!NOTE]
    > The model might hallucinate additional arguments.
1. Parse the output and call the requested functions with their specified arguments.
1. Send another request with the function results included as a new message.
1. The model responds with more function call requests or an answer to the user's question.
   * Continue invoking the requested function calls until the model responds with an answer.

You can force the model to request a specific function by setting the `tool_choice` parameter to the function's name. You can also force the model to respond with a message for the user by setting the `tool_choice` parameter to `"none"`.

## Call functions in parallel

Some models support parallel function calling, which enables the model to request multiple function calls in one output. The results of each function call are included together in one response back to the model. Parallel function calling reduces the number of API requests and time needed to generate an answer. Each function result is included as a new message in the conversation with a `tool_call_id` matching the `id` of the function call request.

## Supported models

Not all OpenAI models are trained to support function calling. For a list of models that support function calling or parallel function calling, see [OpenAI - Supported Models](https://platform.openai.com/docs/guides/function-calling/supported-models).

## Function calling with the Semantic Kernel SDK

The [Semantic Kernel SDK](/semantic-kernel/overview/) supports describing which functions are available to your AI [using the `KernelFunction` decorator](/semantic-kernel/agents/plugins/using-the-kernelfunction-decorator?tabs=Csharp#use-the-kernelfunction-decorator-to-define-a-native-function).

The Kernel builds the `tools` parameter of a request based on your decorators, orchestrates the requested function calls to your code, and returns results back to the model.

## Token counts

Function descriptions are include in the system message of your request to a model. These function descriptions count against your model's [token limit](/azure/ai-services/openai/quotas-limits) and are [included in the cost of the request](https://azure.microsoft.com/pricing/details/cognitive-services/openai-service/).

If your request exceeds the model's token limit, try the following modifications:

* Reduce the number of functions.
* Shorten the function and argument descriptions in your JSON.

## Related content

* [Understanding tokens](understanding-tokens.md)
* [Creating native functions for AI to call](/semantic-kernel/agents/plugins/using-the-kernelfunction-decorator?tabs=Csharp)
* [Prompt engineering](prompt-engineering-dotnet.md)
