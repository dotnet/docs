---
title: Overview of the .NET + AI ecosystem
description: This article provides an overview of the ecosystem of SDKs and tools available to .NET developers integrating AI into their applications.
ms.date: 11/24/2024
ms.topic: overview
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
---

# Overview of the .NET + AI ecosystem

The .NET ecosystem provides many powerful tools, libraries, and services to develop AI applications. .NET supports both cloud and local AI model connections, many different SDKs for various AI and vector database services, and other tools to help you build intelligent apps of varying scope and complexity.

> [!IMPORTANT]
> Not all of the SDKs and services presented in this doc are maintained by Microsoft. When considering an SDK, make sure to evaluate its quality, licensing, support, and compatibility to ensure they meet your requirements.

## Microsoft.Extensions.AI libraries

[`Microsoft.Extensions.AI`](ai-extensions.md) is a set of core .NET libraries that provide a unified layer of C# abstractions for interacting with AI services, such as small and large language models (SLMs and LLMs), embeddings, and middleware. These APIs were created in collaboration with developers across the .NET ecosystem, including Semantic Kernel. The low-level APIs, such as <xref:Microsoft.Extensions.AI.IChatClient> and <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2>, were extracted from Semantic Kernel and moved into the <xref:Microsoft.Extensions.AI> namespace.

`Microsoft.Extensions.AI` provides abstractions that can be implemented by various services, all adhering to the same core concepts. This library is not intended to provide APIs tailored to any specific provider's services. The goal of `Microsoft.Extensions.AI` is to act as a unifying layer within the .NET ecosystem, enabling developers to choose their preferred frameworks and libraries while ensuring seamless integration and collaboration across the ecosystem.

## Semantic Kernel for .NET

If you just want to use the low-level services, such as <xref:Microsoft.Extensions.AI.IChatClient> and <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2>, you can reference the `Microsoft.Extensions.AI.Abstractions` package directly from your app. However, if you want to use higher-level, more opinionated approaches to AI, then you should use [Semantic Kernel](semantic-kernel-dotnet-overview.md).

Semantic Kernel, which has a dependency on the `Microsoft.Extensions.AI.Abstractions` package, is an open-source library that enables AI integration and orchestration capabilities in your .NET apps. Its connectors provides concrete implementations of <xref:Microsoft.Extensions.AI.IChatClient> and <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2> for different services, including OpenAI, Amazon Bedrock, and Google Gemini.

The Semantic Kernel SDK is generally the recommended AI orchestration tool for .NET apps that use one or more AI services in combination with other APIs or web services, data stores, and custom code. Semantic Kernel benefits enterprise developers in the following ways:

- Streamlines integration of AI capabilities into existing applications to enable a cohesive solution for enterprise products.
- Minimizes the learning curve of working with different AI models or services by providing abstractions that reduce complexity.
- Improves reliability by reducing the unpredictable behavior of prompts and responses from AI models. You can fine-tune prompts and plan tasks to create a controlled and predictable user experience.

For more information, see the [Semantic Kernel documentation](/semantic-kernel/overview/).

## .NET SDKs for building AI apps

Many different SDKs are available to build .NET apps with AI capabilities depending on the target platform or AI model. OpenAI models offer powerful generative AI capabilities, while other Azure AI Services provide intelligent solutions for a variety of specific scenarios.

### .NET SDKs for OpenAI models

| NuGet package | Supported models | Maintainer or vendor | Documentation |
|---------------|------------------|----------------------|--------------|
| [Microsoft.SemanticKernel](https://www.nuget.org/packages/Microsoft.SemanticKernel/) | [OpenAI models](https://platform.openai.com/docs/models/overview)<br/>[Azure OpenAI supported models](/azure/ai-services/openai/concepts/models) | [Semantic Kernel](https://github.com/microsoft/semantic-kernel) (Microsoft) | [Semantic Kernel documentation](/semantic-kernel/) |
| [Azure OpenAI SDK](https://www.nuget.org/packages/Azure.AI.OpenAI/) | [Azure OpenAI supported models](/azure/ai-services/openai/concepts/models) | [Azure SDK for .NET](https://github.com/Azure/azure-sdk-for-net) (Microsoft) | [Azure OpenAI services documentation](/azure/ai-services/openai/) |
| [OpenAI SDK](https://www.nuget.org/packages/OpenAI/) | [OpenAI supported models](https://platform.openai.com/docs/models) | [OpenAI SDK for .NET](https://github.com/openai/openai-dotnet) (OpenAI) | [OpenAI services documentation](https://platform.openai.com/docs/overview) |

### .NET SDKs for Azure AI Services

Azure offers many other AI services to build specific application capabilities and workflows. Most of these services provide a .NET SDK to integrate their functionality into custom apps. Some of the most commonly used services are shown in the following table. For a complete list of available services and learning resources, see the [Azure AI Services](/azure/ai-services/what-are-ai-services) documentation.

| Service                           | Description                                  |
|-----------------------------------|----------------------------------------------|
| [Azure AI Search](/azure/search/) | Bring AI-powered cloud search to your mobile and web apps. |
| [Azure AI Content Safety](/azure/ai-services/content-safety/) | Detect unwanted or offensive content.                      |
| [Azure AI Document Intelligence](/azure/ai-services/document-intelligence/) | Turn documents into intelligent data-driven solutions. |
| [Azure AI Language](/azure/ai-services/language-service/)     | Build apps with industry-leading natural language understanding capabilities. |
| [Azure AI Speech](/azure/ai-services/speech-service/)         | Speech to text, text to speech, translation, and speaker recognition. |
| [Azure AI Translator](/azure/ai-services/translator/)         | AI-powered translation technology with support for more than 100 languages and dialects. |
| [Azure AI Vision](/azure/ai-services/computer-vision/)        | Analyze content in images and videos.                      |

## Develop with local AI models

.NET apps can also connect to local AI models for many different development scenarios. [Semantic Kernel](https://github.com/microsoft/semantic-kernel) is the recommended tool to connect to local models using .NET. Semantic Kernel can connect to many different models hosted across a variety of platforms and abstracts away lower-level implementation details.

For example, you can use [Ollama](https://ollama.com/) to [connect to local AI models with .NET](quickstarts/quickstart-local-ai.md), including several small language models (SLMs) developed by Microsoft:

| Model               | Description                                               |
|---------------------|-----------------------------------------------------------|
| [phi3 models][phi3] | A family of powerful SLMs with groundbreaking performance at low cost and low latency. |
| [orca models][orca] | Research models in tasks such as reasoning over user-provided data, reading comprehension, math problem solving, and text summarization. |

> [!NOTE]
> The preceding SLMs can also be hosted on other services, such as Azure.

## Connect to vector databases and services

[!INCLUDE [vector-databases](includes/vector-databases.md)]

## Other options

This article summarized the tools and SDKs in the .NET ecosystem, with a focus on services that provide official support for .NET. Depending on your needs and stage of app development, you might also want to take a look at the open-source options for the ecosystem in [the unofficial list of .NET + AI resources](https://github.com/jmatthiesen/dotnet-ai-resources?tab=readme-ov-file#models). Microsoft is not the maintainer of many of these projects, so be sure to review their quality, licensing, and support.

## Next steps

- [What is Semantic Kernel?](/semantic-kernel/overview/)
- [Quickstart - Summarize text using Azure AI chat app with .NET](./quickstarts/quickstart-openai-summarize-text.md)

[phi3]: https://azure.microsoft.com/products/phi-3
[orca]: https://www.microsoft.com/research/project/orca/
