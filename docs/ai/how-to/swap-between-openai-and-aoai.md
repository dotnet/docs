---
title: "Swap between OpenAI and AOAI"
description: "Demonstrates how to swap between OpenAI and Azure OpenAI (AOAI) using the Semantic Kernel SDK for .NET."
author: haywoodsloan
ms.topic: how-to
ms.date: 04/09/2024

#customer intent: As a .NET developer, I want to swap between OpenAI and Azure OpenAI (AOAI) so that I can choose the AI service that's best for me.

---

# Swap between OpenAI and AOAI

This article demonstrates how to swap between the OpenAI and [Azure OpenAI](https://learn.microsoft.com/azure/ai-services/openai/overview) (AOAI) services using the [Semantic Kernel SDK](https://learn.microsoft.com/semantic-kernel/overview). Additionally, it shows how to switch your .NET projects to the Semantic Kernel SDK from the [AOAI client library](https://learn.microsoft.com/dotnet/api/overview/azure/ai.openai-readme).

## Prerequisites

* An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/free/?WT.mc_id=A261C142F).
* [.NET SDK](https://dotnet.microsoft.com/download/visual-studio-sdks)
* [`Microsoft.SemanticKernel` Nuget package](https://www.nuget.org/packages/Microsoft.SemanticKernel)
* [Create and deploy an Azure OpenAI Service resource](https://learn.microsoft.com/azure/ai-services/openai/how-to/create-resource)

## Switch from the AOAI client library to Semantic Kernal SDK

The following section shows how to add the Semantic Kernal SDK to your .NET project and use it to replace the AOAI client library.

To begin add the [Semantic Kernal Nuget package](https://www.nuget.org/packages/Microsoft.SemanticKernel) to your project. The following command will add this package to the .NET project in your current working directory:

```dotnetcli
dotnet add package Microsoft.SemanticKernel
```

The Semantic Kernel SDK supports both prompt and chat completions:

### Implement prompt completions with Semantic Kernel

A basic implementation of prompt completions with the AOAI client library might look like the following:

```csharp
// === Retrieve the secrets saved during the Azure deployment ===
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
var openAIEndpoint = config["AZURE_OPENAI_ENDPOINT"];
var openAIDeploymentName = config["AZURE_OPENAI_GPT_NAME"];
var openAiKey = config["AZURE_OPENAI_KEY"];


// === Creating the OpenAIClient ===
var endpoint = new Uri(openAIEndpoint);
var credentials = new AzureKeyCredential(openAiKey);
var openAIClient = new OpenAIClient(endpoint, credentials);

var completionOptions = new ChatCompletionsOptions
{
    DeploymentName = openAIDeploymentName
    // Additional options, e.g., MaxTokens, Temperature, etc.
};

// === Specify the prompt as a user message ===
var userRequest = "Please list three services offered by Azure";
completionOptions.Messages.Add(new ChatRequestUserMessage(userRequest));
Console.WriteLine($"Prompt: {userRequest}");

// === Get the response and display it ===

ChatCompletions response = await openAIClient.GetChatCompletionsAsync(completionOptions);
var assistantResponse = response.Choices[0].Message;
Console.WriteLine($"Output: {assistantResponse.Content}");
```

The Semantic Kernel equivalent would be:

```csharp
// === Retrieve the secrets saved during the Azure deployment ===
// The config values should remain the same between AOAI and Semantic Kernel
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
var endpoint = config["AZURE_OPENAI_ENDPOINT"];
var deployment = config["AZURE_OPENAI_GPT_NAME"];
var key = config["AZURE_OPENAI_KEY"];

var executionSettings = new OpenAIPromptExecutionSettings
{
    MaxTokens = 400
    // Additional options, e.g., Temperature, ResultsPerPrompt, etc.
};

// === Create a Kernel containing the AOAI Chat Completion Service ===
var kernel = Kernel.CreateBuilder()
    .AddAzureOpenAIChatCompletion(deployment, endpoint, key)
    .Build();

// === Define the prompt ===
var prompt = "Please list three services offered by Azure";
Console.WriteLine($"Prompt: {prompt}");

// === Get the response and display it ===
var response = await kernel.InvokePromptAsync<string>(prompt, new(executionSettings));
Console.WriteLine($"Output: {response}");
```

### Implement chat completions with Semantic Kernel

A basic implementation of chat completions with the AOAI client library might look like the following:

```csharp
// === Retrieve the secrets saved during the Azure deployment ===
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
var openAIEndpoint = config["AZURE_OPENAI_ENDPOINT"];
var openAIDeploymentName = config["AZURE_OPENAI_GPT_NAME"];
var openAiKey = config["AZURE_OPENAI_KEY"];


// == Creating the OpenAIClient ==========
var endpoint = new Uri(openAIEndpoint);
var credentials = new AzureKeyCredential(openAiKey);
var openAIClient = new OpenAIClient(endpoint, credentials);

var completionOptions = new ChatCompletionsOptions
{
    DeploymentName = openAIDeploymentName
    // Additional options, e.g., MaxTokens, Temperature, etc.
};

// === Providing context for the AI model as a system message ===
var systemPrompt =
"""
You are a hiking enthusiast who helps people discover fun hikes in their area. You are upbeat and friendly. 
You introduce yourself when first saying hello. When helping people out, you always ask them 
for this information to inform the hiking recommendation you provide:

1. Where they are located
2. What hiking intensity they are looking for

You will then provide three suggestions for nearby hikes that vary in length after you get that information. 
You will also share an interesting fact about the local nature on the hikes when making a recommendation.
""";

Console.WriteLine($"System Prompt: {systemPrompt}");
completionOptions.Messages.Add(new ChatRequestSystemMessage(systemPrompt));

// === Starting the conversation with a user message ===
var userGreeting =
"""
Hi! 
Apparently you can help me find a hike that I will like?
""";

Console.WriteLine($"User: {userGreeting}");
completionOptions.Messages.Add(new ChatRequestUserMessage(userGreeting));

// === Get the first response, display it, and add it to the message list
ChatCompletions response = await openAIClient.GetChatCompletionsAsync(completionOptions);
var assistantResponse = response.Choices[0].Message;

Console.WriteLine($"Assistant: {assistantResponse.Content}");
completionOptions.Messages.Add(new ChatRequestAssistantMessage(assistantResponse.Content));


// === Providing the user's request ===
var hikeRequest =
"""
I live in the greater Montreal area and would like an easy hike. I don't mind driving a bit to get there.
I don't want the hike to be over 10 miles round trip. I'd consider a point-to-point hike.
I want the hike to be as isolated as possible. I don't want to see many people.
I would like it to be as bug free as possible.
""";

Console.WriteLine($"User: {hikeRequest}");
completionOptions.Messages.Add(new ChatRequestUserMessage(hikeRequest));

// === Get the next response and display it ===
response = await openAIClient.GetChatCompletionsAsync(completionOptions);
assistantResponse = response.Choices[0].Message;

Console.WriteLine($"Assistant: {assistantResponse.Content}");
```

The Semantic Kernel equivalent would be:

```csharp
// === Retrieve the secrets saved during the Azure deployment ===
// The config values should remain the same between AOAI and Semantic Kernel
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
var endpoint = config["AZURE_OPENAI_ENDPOINT"];
var deployment = config["AZURE_OPENAI_GPT_NAME"];
var key = config["AZURE_OPENAI_KEY"];

var executionSettings = new OpenAIPromptExecutionSettings
{
    MaxTokens = 400,
    // Additional options, e.g., Temperature, ResultsPerPrompt, etc.
};

// === Create the AOAI Chat Completion Service ===
var service = new AzureOpenAIChatCompletionService(deployment, endpoint, key);

// === Providing context for AI models via the chat history, initialized with a system message ===
var systemMessage =
"""
You are a hiking enthusiast who helps people discover fun hikes in their area. You are upbeat and friendly. 
You introduce yourself when first saying hello. When helping people out, you always ask them 
for this information to inform the hiking recommendation you provide:

1. Where they are located
2. What hiking intensity they are looking for

You will then provide three suggestions for nearby hikes that vary in length after you get that information. 
You will also share an interesting fact about the local nature on the hikes when making a recommendation.
""";

Console.WriteLine($"System Prompt: {systemMessage}");
var chatHistory = new ChatHistory(systemMessage);

// === Starting the conversation with a user message ===
var userGreeting =
"""
Hi! 
Apparently you can help me find a hike that I will like?
""";

Console.WriteLine($"User: {userGreeting}");
chatHistory.AddUserMessage(userGreeting);

// === Get the first response, display it, and add it to the chat history ===
var assistantResponse = await service.GetChatMessageContentAsync(chatHistory, executionSettings);
Console.WriteLine($"Assistant: {assistantResponse.Content}");
chatHistory.Add(assistantResponse);

// === Providing the user's request ===
var hikeRequest =
"""
I live in the greater Montreal area and would like an easy hike. I don't mind driving a bit to get there.
I don't want the hike to be over 10 miles round trip. I'd consider a point-to-point hike.
I want the hike to be as isolated as possible. I don't want to see many people.
I would like it to be as bug free as possible.
""";

Console.WriteLine($"User: {hikeRequest}");
chatHistory.AddUserMessage(hikeRequest);

// === Get the next response and display it ===
assistantResponse = await service.GetChatMessageContentAsync(chatHistory, executionSettings);
Console.WriteLine($"Assistant: ${assistantResponse.Content}");
```

## Swap between OpenAI and AOAI with Semantic Kernal

The following section shows how to swap your .NET project between OpenAI and AOAI services when using the Semantic Kernel SDK.

Before swapping to AOAI ensure you have followed the prerequisite steps to [create and deploy an Azure OpenAI Service resource](https://learn.microsoft.com/azure/ai-services/openai/how-to/create-resource). Once you have created an AOAI resource you'll need retrieve the endpoint URL; this can be done through the [Azure portal](https://portal.azure.com) or with the following Azure CLI command:

```azurecli
az cognitiveservices account show \
--name <myResourceName> \
--resource-group  <myResourceGroupName>
```

Swapping between OpenAI and AOAI simply requires changing the initial service configuration. For example, consider the following configuration for using OpenAI:

```csharp
// === Retrieve the secrets saved when signing up for OpenAI ===
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
var model = config["OPENAI_GPT_NAME"];
var key = config["OPENAI_API_KEY"];

// === Create a Kernel containing the OpenAI Chat Completion Service ===
var kernel = Kernel.CreateBuilder()
    .AddOpenAIChatCompletion(model, key)
    .Build();

// === Alternatively, directly create the OpenAI Chat Completion Service ===
var service = new OpenAIChatCompletionService(model, key);
```

Semantic Kernel can be similarly configured to use AOAI with either API key or token based authentication:

### Using AOAI with API key authentication

To begin you'll need to retrieve the key from your deployed AOAI resource. This can be done through the [Azure portal](https://portal.azure.com) or with the following Azure CLI command:

```azurecli
az cognitiveservices account keys list \
--name <myResourceName> \
--resource-group  <myResourceGroupName>
```

The following configuration uses AOAI with API key authentication:

```csharp
// === Retrieve the secrets obtained from the Azure deployment ===
// Must use the deployment name not the underlying model name
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
var endpoint = config["AZURE_OPENAI_ENDPOINT"];
var deployment = config["AZURE_OPENAI_GPT_NAME"];
var key = config["AZURE_OPENAI_KEY"];

// === Create a Kernel containing the AOAI Chat Completion Service ===
var kernel = Kernel.CreateBuilder()
    .AddAzureOpenAIChatCompletion(deployment, endpoint, key)
    .Build();

// === Alternatively, directly create the AOAI Chat Completion Service ===
var service = new AzureOpenAIChatCompletionService(deployment, endpoint, key);
```

### Using AOAI with token based authentication

To begin you'll need to add the [Azure Identity Nuget package](https://www.nuget.org/packages/Azure.Identity) to your project. The following command will add this package to the .NET project in your current working directory:

```dotnetcli
dotnet add package Azure.Identity
```

The following configuration uses AOAI with token based authentication:

```csharp
// === Retrieve the secrets obtained from the Azure deployment ===
// Must use the deployment name not the underlying model name
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
var endpoint = config["AZURE_OPENAI_ENDPOINT"];
var deployment = config["AZURE_OPENAI_GPT_NAME"];

// === Create a TokenCredential instance, e.g. DefaultAzureCredential, ManagedIdentityCredential, EnvironmentCredential, etc.
TokenCredential credentials = new DefaultAzureCredential(new DefaultAzureCredentialOptions
{
    // Credential options, e.g., TenantID, ManagedIdentityClientId, etc.
});

// === Create a Kernel containing the AOAI Chat Completion Service ===
var kernel = Kernel.CreateBuilder()
    .AddAzureOpenAIChatCompletion(deployment, endpoint, credentials)
    .Build();

// === Alternatively, directly create the AOAI Chat Completion Service ===
var service = new AzureOpenAIChatCompletionService(deployment, endpoint, credentials);
```

## Related content

* [What is Semantic Kernel](https://learn.microsoft.com/semantic-kernel/overview/)
* [Summarize text using Azure AI chat app with .NET](https://learn.microsoft.com/dotnet/ai/quickstarts/quickstart-openai-summarize-text?pivots=semantic-kernel)
* [How to work with local models](work-with-local-models.md)
