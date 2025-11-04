---
title: .NET + AI ecosystem tools and SDKs
description: This article provides an overview of the ecosystem of SDKs and tools available to .NET developers integrating AI into their applications.
ms.date: 11/04/2025
ms.topic: overview
---

# .NET + AI ecosystem tools and SDKs

The .NET ecosystem provides many powerful tools, libraries, and services to develop AI applications. .NET supports both cloud and local AI model connections, many different SDKs for various AI and vector database services, and other tools to help you build intelligent apps of varying scope and complexity.

> [!IMPORTANT]
> Not all of the SDKs and services presented in this article are maintained by Microsoft. When considering an SDK, make sure to evaluate its quality, licensing, support, and compatibility to ensure they meet your requirements.

## Microsoft.Extensions.AI libraries

[`Microsoft.Extensions.AI`](microsoft-extensions-ai.md) is a set of core .NET libraries that provide a unified layer of C# abstractions for interacting with AI services, such as small and large language models (SLMs and LLMs), embeddings, and middleware. These APIs were created in collaboration with developers across the .NET ecosystem, including Semantic Kernel. The low-level APIs, such as <xref:Microsoft.Extensions.AI.IChatClient> and <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2>, were extracted from Semantic Kernel and moved into the <xref:Microsoft.Extensions.AI> namespace.

`Microsoft.Extensions.AI` provides abstractions that can be implemented by various services, all adhering to the same core concepts. This library is not intended to provide APIs tailored to any specific provider's services. The goal of `Microsoft.Extensions.AI` is to act as a unifying layer within the .NET ecosystem, enabling developers to choose their preferred frameworks and libraries while ensuring seamless integration and collaboration across the ecosystem.

## Microsoft Agent Framework

If you just want to use the low-level services, such as <xref:Microsoft.Extensions.AI.IChatClient> and <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2>, you can reference the `Microsoft.Extensions.AI.Abstractions` package directly from your app. However, if you want to build agentic AI applications with higher-level orchestration capabilities, you should use [Microsoft Agent Framework](/agent-framework/overview/agent-framework-overview).

Microsoft Agent Framework is a production-ready, open-source framework that brings together the best capabilities of Semantic Kernel and Microsoft Research's AutoGen. Agent Framework provides:

- **Multi-agent orchestration**: Support for sequential, concurrent, group chat, handoff, and magnetic orchestration patterns (where agents are dynamically attracted to tasks or conversations based on context or expertise).
- **Cloud and provider flexibility**: Cloud-agnostic (containers, on-premises, or multi-cloud) and provider-agnostic (for example, OpenAI or Azure AI Foundry) using plugin and connector models.
- **Enterprise-grade features**: Built-in observability (OpenTelemetry), Microsoft Entra security integration, and responsible AI features including prompt injection protection and task adherence monitoring.
- **Standards-based interoperability**: Integration with open standards like Agent-to-Agent (A2A) protocol and Model Context Protocol (MCP) for agent discovery and tool interaction.

Agent Framework builds on the `Microsoft.Extensions.AI.Abstractions` package and provides concrete implementations of <xref:Microsoft.Extensions.AI.IChatClient> for different services, including OpenAI, Azure OpenAI, Azure AI Foundry, and more.

Microsoft Agent Framework is the recommended approach for .NET apps that need to build agentic AI systems with advanced orchestration, multi-agent collaboration, and enterprise-grade security and observability.

For more information, see the [Microsoft Agent Framework documentation](/agent-framework/overview/agent-framework-overview).

## Semantic Kernel for .NET

[Semantic Kernel](/semantic-kernel/overview/) is an open-source library that enables AI integration and orchestration capabilities in your .NET apps. Semantic Kernel has a dependency on the `Microsoft.Extensions.AI.Abstractions` package and provides connectors with concrete implementations of <xref:Microsoft.Extensions.AI.IChatClient> and <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2> for different services, including OpenAI, Amazon Bedrock, and Google Gemini.

Semantic Kernel continues to be actively maintained and is suitable for AI integration scenarios, especially for applications that:

- Need AI integration without complex multi-agent orchestration.
- Are already built on Semantic Kernel and don't require advanced agentic features.
- Benefit from Semantic Kernel's extensive connector ecosystem and community support.

For new applications that require advanced agentic capabilities, multi-agent orchestration, or enterprise-grade observability and security, consider using [Microsoft Agent Framework](/agent-framework/overview/agent-framework-overview).

For more information, see the [Semantic Kernel documentation](/semantic-kernel/overview/).

## .NET SDKs for building AI apps

Many different SDKs are available to build .NET apps with AI capabilities depending on the target platform or AI model. OpenAI models offer powerful generative AI capabilities, while other Azure AI Services provide intelligent solutions for a variety of specific scenarios.

### .NET SDKs for OpenAI models

| NuGet package | Supported models | Maintainer or vendor | Documentation |
|---------------|------------------|----------------------|--------------|
| [Microsoft.Agents.AI.OpenAI](https://www.nuget.org/packages/Microsoft.Agents.AI.OpenAI/) | [OpenAI models](https://platform.openai.com/docs/models/overview)<br/>[Azure OpenAI supported models](/azure/ai-services/openai/concepts/models) | [Microsoft Agent Framework](https://github.com/microsoft/agent-framework) (Microsoft) | [Agent Framework documentation](/agent-framework/overview/agent-framework-overview) |
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

.NET apps can also connect to local AI models for many different development scenarios. [Microsoft Agent Framework](https://github.com/microsoft/agent-framework) is the recommended tool to connect to local models using .NET. This framework can connect to many different models hosted across a variety of platforms and abstracts away lower-level implementation details.

For example, you can use [Ollama](https://ollama.com/) to [connect to local AI models with .NET](quickstarts/chat-local-model.md), including several small language models (SLMs) developed by Microsoft:

| Model               | Description                                               |
|---------------------|-----------------------------------------------------------|
| [phi3 models][phi3] | A family of powerful SLMs with groundbreaking performance at low cost and low latency. |
| [orca models][orca] | Research models in tasks such as reasoning over user-provided data, reading comprehension, math problem solving, and text summarization. |

> [!NOTE]
> The preceding SLMs can also be hosted on other services, such as Azure.

## Connect to vector databases and services

[!INCLUDE [vector-databases](includes/vector-databases.md)]

## Next steps

- [What is Microsoft Agent Framework?](/agent-framework/overview/agent-framework-overview)
- [What is Semantic Kernel?](/semantic-kernel/overview/)
- [Quickstart - Summarize text using Azure AI chat app with .NET](quickstarts/prompt-model.md)

[phi3]: https://azure.microsoft.com/products/phi-3
[orca]: https://www.microsoft.com/research/project/orca/
