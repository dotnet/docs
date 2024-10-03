---
title: Semantic Kernel overview for .NET
description: Learn how to add the Semantic Kernel SDK to your .NET projects and explore fundamental concepts
ms.date: 06/07/2024
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
---

# Semantic Kernel overview for .NET

In this article, you explore [Semantic Kernel](/semantic-kernel/overview) core concepts and capabilities. Semantic Kernel is a powerful and recommended choice for working with AI in .NET applications. In the sections ahead, you learn:

- How to add semantic kernel to your project
- Semantic Kernel core concepts

This article serves as an introductory overview of Semantic Kernel specifically in the context of .NET. For more comprehensive information and training about Semantic Kernel, see the following resources:

- [Semantic Kernel documentation](/semantic-kernel/overview)
- [Semantic Kernel training](/training/paths/develop-ai-agents-azure-open-ai-semantic-kernel-sdk/)

## Add Semantic Kernel to a .NET project

The Semantic Kernel SDK is available as a NuGet package for .NET and integrates with standard app configurations.

Install the [`Microsoft.SemanticKernel`](https://www.nuget.org/packages/Microsoft.SemanticKernel) package using the following command:

```dotnetcli
dotnet add package Microsoft.SemanticKernel
```

> [!NOTE]
> Although `Microsoft.SemanticKernel` provides core features of Semantic Kernel, additional capabilities require you to install additional packages. For example, the [`Microsoft.SemanticKernel.Plugins.Memory`](https://www.nuget.org/packages/Microsoft.SemanticKernel.Plugins.Memory) package provides to access memory related features. For more information, see the [Semantic Kernel documentation](/semantic-kernel/overview).

Create and configure a `Kernel` instance using the `KernelBuilder` class to access and work with Semantic Kernel. The `Kernel` holds services, data, and connections to orchestrate integrations between your code and AI models.

Configure the `Kernel` in a .NET console app:

```csharp
var builder = Kernel.CreateBuilder();

// Add builder configuration and services

var kernel = builder.Build();
```

Configure the Kernel in an ASP.NET Core app:

```csharp
var builder = WebApplication.CreateBuilder();
builder.Services.AddKernel();

// Add builder configuration and services

var app = builder.Build();
```

## Understand Semantic Kernel

[Semantic Kernel](/semantic-kernel/overview/) is an open-source SDK that integrates and orchestrates AI models and services like OpenAI, Azure OpenAI, and Hugging Face with conventional programming languages like C#, Python, and Java.

The Semantic Kernel SDK benefits enterprise developers in the following ways:

- Streamlines integration of AI capabilities into existing applications to enable a cohesive solution for enterprise products.
- Minimizes the learning curve of working with different AI models or services by providing abstractions that reduce complexity.
- Improves reliability by reducing the unpredictable behavior of prompts and responses from AI models. You can fine-tune prompts and plan tasks to create a controlled and predictable user experience.

Semantic Kernel is built around several core concepts:

- **Connections**: Interface with external AI services and data sources.
- **Plugins**: Encapsulate functions that applications can use.
- **Planner**: Orchestrates execution plans and strategies based on user behavior.
- **Memory**: Abstracts and simplifies context management for AI apps.

These building blocks are explored in more detail in the following sections.

### Connections

The Semantic Kernel SDK includes a set of connectors that enable developers to integrate LLMs and other services into their existing applications. These connectors serve as the bridge between the application code and the AI models or services. Semantic Kernel handles many common connection concerns and challenges for you so you can focus on building your own workflows and features.

The following code snippet creates a `Kernel` and adds a connection to an Azure OpenAI model:

```csharp
using Microsoft.SemanticKernel;

// Create kernel
var builder = Kernel.CreateBuilder();

// Add a chat completion service:
builder.Services.AddAzureOpenAIChatCompletion(
    "your-resource-name",
    "your-endpoint",
    "your-resource-key",
    "deployment-model");
var kernel = builder.Build();
```

### Plugins

Semantic Kernel [plugins](/semantic-kernel/agents/plugins) encapsulate standard language functions for applications and AI models to consume. You can create your own plugins or rely on plugins provided by the SDK. These plugins streamline tasks where AI models are advantageous and efficiently combine them with more traditional C# methods. Plugin functions are generally categorized into two types: *semantic functions* and *native functions*.

#### Semantic functions

Semantic functions are essentially AI prompts defined in your code that Semantic Kernel can customize and call as needed. You can templatize these prompts to use variables, custom prompt and completion formatting, and more.

The following code snippet defines and registers a semantic function:

```csharp
var userInput = Console.ReadLine();

// Define semantic function inline.
string skPrompt = @"Summarize the provided unstructured text in a sentence that is easy to understand.
                    Text to summarize: {{$userInput}}";

// Register the function
kernel.CreateSemanticFunction(
    promptTemplate: skPrompt,
    functionName: "SummarizeText",
    pluginName: "SemanticFunctions"
);
```

#### Native functions

Native functions are C# methods that Semantic Kernel can call directly to manipulate or retrieve data. They perform operations that are better suited for traditional code instructions instead of LLM prompts.

The following code snippet defines and registers a native function:

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

var nativeFunctions = new NativeFunctions();
kernel.ImportFunctions(nativeFunctions, plugInName);
```

### Planner

The [planner](/semantic-kernel/agents/planners) is a core component of Semantic Kernel that provides AI orchestration to manage seamless integration between AI models and plugins. This layer devises execution strategies from user requests and dynamically orchestrates Plugins to perform complex tasks with AI-assisted planning.

Consider the following pseudo-code snippet:

```csharp
// Native function definition and kernel configuration code omitted for brevity

// Configure and create the plan
string planDefinition = "Read content from a local file and summarize the content.";
SequentialPlanner sequentialPlanner = new SequentialPlanner(kernel);

string assetsFolder = @"../../assets";
string fileName = Path.Combine(assetsFolder,"docs","06_SemanticKernel", "aci_documentation.txt");

ContextVariables contextVariables = new ContextVariables();
contextVariables.Add("fileName", fileName);

var customPlan = await sequentialPlanner.CreatePlanAsync(planDefinition);

// Execute the plan
KernelResult kernelResult = await kernel.RunAsync(contextVariables, customPlan);
Console.WriteLine($"Summarization: {kernelResult.GetValue<string>()}");
```

The preceding code creates an executable, sequential plan to read content from a local file and summarize the content. The plan sets up instructions to read the file using a native function and then analyze it using an AI model.

### Memory

Semantic Kernel's [Vector stores](/semantic-kernel/concepts/vector-store-connectors/) provide abstractions over embedding models, vector databases, and other data to simplify context management for AI applications. Vector stores are agnostic to the underlying LLM or Vector database, offering a uniform developer experience. You can configure memory features to store data in a variety of sources or service, including Azure AI Search and Azure Cache for Redis.

Consider the following code snippet:

```csharp
var facts = new Dictionary<string,string>();
facts.Add(
    "Azure Machine Learning; https://learn.microsoft.com/en-us/azure/machine-learning/",
    @"Azure Machine Learning is a cloud service for accelerating and
    managing the machine learning project lifecycle. Machine learning professionals,
    data scientists, and engineers can use it in their day-to-day workflows"
);

facts.Add(
    "Azure SQL Service; https://learn.microsoft.com/en-us/azure/azure-sql/",
    @"Azure SQL is a family of managed, secure, and intelligent products
    that use the SQL Server database engine in the Azure cloud."
);

string memoryCollectionName = "SummarizedAzureDocs";

foreach (var fact in facts) {
    await memoryBuilder.SaveReferenceAsync(
        collection: memoryCollectionName,
        description: fact.Key.Split(";")[1].Trim(),
        text: fact.Value,
        externalId: fact.Key.Split(";")[2].Trim(),
        externalSourceName: "Azure Documentation"
    );
}
```

The preceding code loads a set of facts into memory so that the data is available to use when interacting with AI models and orchestrating tasks.

>[!div class="step-by-step"]
>[Quickstart - Summarize text with OpenAI](quickstarts/quickstart-openai-summarize-text.md)
>[Quickstart - Chat with your data](quickstarts/quickstart-ai-chat-with-data.md)
