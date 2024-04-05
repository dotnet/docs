---
title: Overview of the .NET + AI Ecosystem
description: This article provides an overview of the ecosystem of SDKs and tools available to .NET developers integrating AI into their applications.
ms.date: 04/04/2024
ms.topic: overview
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
---

# Overview of the .NET + AI ecosystem

.NET can be used with many different libraries and tools that support the development of generative AI applications. This page includes a summary of the services and tools you might need to use in your applications, with links to learn more about each of them.

> [!NOTE]
> We recommend using the [Semantic Kernel SDK](/semantic-kernel/overview/) to orchestrate your calls to large language models (LLMs) and manage interactions with the various services mentioned here. Semantic Kernel makes it easy to work with different services without having to learn a different API for each one.

> [!IMPORTANT]
> These SDKs and tools are built by a variety of sources. Not all SDKs are maintained by Microsoft. When considering an SDK, be sure to evaluate its quality, licensing, and support to ensure they meet your requirements. Also make sure you review each SDK's documentation for detailed version compatibility information.

## Working with models

Today, you can use .NET to access models built by OpenAI, using either the Azure OpenAI SDK or the Semantic Kernel. These models can be hosted by OpenAI or in Azure using the Azure AI services. Preview support is coming soon in Semantic Kernel to work with other models, and you can experiment today using open-source SDKs created by the .NET developer community.

| NuGet package                                                                          | Supported models                                                                                                                                | Maintainer or vendor                                                                                         | Link to docs |
|----------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------|
| [Microsoft.SemanticKernel](https://www.nuget.org/packages/Microsoft.SemanticKernel/)   | [OpenAI models](https://platform.openai.com/docs/models/overview)<br/>[Azure OpenAI supported models](/azure/ai-services/openai/concepts/models)                   | [Semantic Kernel](https://github.com/microsoft/semantic-kernel) (Microsoft)                                 | [Semantic Kernel documentation](/semantic-kernel/)     |
| [Azure OpenAI SDK](https://www.nuget.org/packages/Azure.AI.OpenAI/)                    | [Azure OpenAI supported models](/azure/ai-services/openai/concepts/models)                                     | [Azure SDK for .NET](https://github.com/Azure/azure-sdk-for-net) (Microsoft)                                | [Azure OpenAI services documentation](/azure/ai-services/openai/)                                               |

## Connect your data using vector stores

To increase relevancy and tailor AI applications for your own data, you'll likely need to work with a vector store. Many services provide a native SDK for .NET, which you can use directly. You can also use Semantic Kernel, which provides an extensible component model that allows you to try different vector stores without needing to learn each SDK.

| NuGet package                                                                          | Supported vector store            | Maintainer or vendor                                                                                         | Link to docs |
|----------------------------------------------------------------------------------------|-----------------------------------|-------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------|
| [Microsoft.SemanticKernel](https://www.nuget.org/packages/Microsoft.SemanticKernel/)   | [Supported vector stores](/semantic-kernel/memories/vector-db#available-connectors-to-vector-databases)        | [Semantic Kernel](https://github.com/microsoft/semantic-kernel) (Microsoft)                                 | [Semantic Kernel: What is a vector database](/semantic-kernel/memories/vector-db)     |
| [Azure.Search.Documents](https://www.nuget.org/packages/Azure.Search.Documents/)       | Azure AI Search                   | [Azure SDK for .NET](https://github.com/Azure/azure-sdk-for-net) (Microsoft)                                | [Azure AI Search client library for .NET](/dotnet/api/overview/azure/search.documents-readme)     |
| [Milvus.Client](https://www.nuget.org/packages/Milvus.Client)                          | Milvus Vector Database            | [Milvus](https://milvus.io/)                                                                                | [Install Milvus C# SDK](https://milvus.io/docs/v2.2.x/install-csharp.md)                                                           |
| [Qdrant.Client](https://www.nuget.org/packages/Qdrant.Client)                          | Qdrant Vector Database            | [Qdrant](https://qdrant.tech)                                                                               | [Qdrant .NET SDK](https://github.com/qdrant/qdrant-dotnet)                                                                   |

## Other options

This article summarized the tools and SDKs in the .NET ecosystem, with a focus on services that provide official support for .NET. Depending on your needs and stage of app development, you might also want to take a look at the open-source options for the ecosystem in [the unofficial list of .NET + AI resources](https://github.com/jmatthiesen/dotnet-ai-resources?tab=readme-ov-file#models). Microsoft is not the maintainer of many of these projects, so be sure to review their quality, licensing, and support.

## Next Steps

- [What is Semantic Kernel?](/semantic-kernel/overview/)
- [Quickstart - Summarize text using Azure AI chat app with .NET](./quickstarts/quickstart-openai-summarize-text.md)
