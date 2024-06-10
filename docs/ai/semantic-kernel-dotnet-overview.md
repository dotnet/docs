---
title: Semantic Kernel overview for .NET
description: Understand the Semantic Kernel SDK for .NET
ms.date: 06/07/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
---

# Semantic Kernel overview for .NET

In this article, you'll explore core concepts and capabilities of Semantic Kernel and why you might want to use it in your .NET apps. You'll also learn how to add Semantic Kernel to different types of projects and perform some initial configurations. You'll learn about the following topics:

- How to add semantic kernel to your project
- Semantic Kernel core concepts

## Add Semantic Kernel to your project

The Semantic Kernel SDK is available as a NuGet package for .NET and integrates with standard app configurations. Install the package using the following command:

```dotnetcli
dotnet add package Microsoft.SemanticKernel
```

Semantic Kernel is implemented and accessed through a `Kernel` class created using a `KernelBuilder`. The `Kernel` holds services, data, and connections to orchestrate integrations between your code and AI models.

The following code creates a `Kernel` object and registers an Azure OpenAI service with the provided settings in a .NET console app:

```csharp
var builder = Kernel.CreateBuilder();
builder.Services.AddAzureOpenAIChatCompletion(
    "your-resource-name",
    "your-endpoint",
    "your-resource-key",
    "deployment-model");
var kernel = builder.Build();
```

// aspnetcore config

## Understand Semantic Kernel

[Semantic Kernel](/semantic-kernel/overview/) is an open-source SDK that facilitates the integration of AI models with programming frameworks like .NET. Use it to interface with AI models running on Azure, OpenAI, Hugging Face, Ollama, and more. Semantic Kernel allows developers to easily apply AI models in their own applications without having to learn the intricacies of each model's API. The tool is built around several core concepts, which are explored :

- **Plugins**: Encapsulate functions that applications can use.
- **Memory**: Abstracts and simplifies context management for AI apps.
- **Planner**: Orchestrates execution plans and strategies based on user behavior.

The Kernel is used to implement several Semantic Kernel core concepts, which are explained in the following sections.

### Plugins

Semantic Kernel plugins encapsulate functions that applications can use. These plugins streamline tasks where LLMs are advantageous and efficiently combine them with more traditional C# methods. Plugin functions are generally categorized into two types:

- **Semantic function** are essentially stored AI prompts that Semantic Kernel can customize and call as needed. These prompts can be templatized to use variables, custom prompt and completion  formatting, and more.
- **Native functions** are C# methods that can be called by Semantic Kernel directly to manipulate or retrieve data, and perform any other operation that you can do in code that is better suited for traditional code instructions instead of LLM prompts.

Semantic function example:

```csharp
//Define semantic function inline
string skPrompt = @"Summarize the provided unstructured text in 3 easy to understand sentences. 
                    The sentences need to be short and provide the most important content of the provided text.
                    Text to summarize: {{$input}}";

// Register the function
kernel.CreateSemanticFunction(
    promptTemplate: skPrompt, 
    functionName: "SummarizeText",
    pluginName: "SemanticFunctions"
);
```

Native function example:

```csharp
// Define native function
public class NativeFunctions {

    [SKFunction, Description("Retrieve content from local file")]
    public async Task<string> RetrieveLocalFile(string fileName, int maxSize = 5000) 
    {
        string content = await File.ReadAllTextAsync(fileName); 
        if (content.Length <= maxSize) return content;
        return content.Substring(0, maxSize);

    }
}

//Import native function
string plugInName = "NativeFunction";
string functionName = "RetrieveLocalFile";

NativeFunctions nativeFunctions = new NativeFunctions();
kernel.ImportFunctions(nativeFunctions, plugInName);
```


### Planner
The core of the Semantic Kernel stack is an AI orchestration layer that allows the seamless integration of AI models and plugins. This layer devises execution strategies from user requests and dynamically orchestrates Plugins to perform complex tasks with AI-assisted planning.

### Memory

**Connectors**
The Semantic Kernel SDK offers a set of connectors that enable developers to integrate LLMs into their existing applications. These connectors serve as the bridge between the application code and the AI models.

## Implement Semantic Kernel in a .NET project

The Semantic Kernel SDK is available as a NuGet package for .NET and integrates with standard app configurations. Install the package using the following command:

```dotnetcli
dotnet add package Microsoft.SemanticKernel
```

