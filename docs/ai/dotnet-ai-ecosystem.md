---
title: Overview of the .NET + AI Ecosystem
description: This article provides an overview of the ecosystem of SDKs and tools available to .NET developers integrating AI into their applications.
ms.date: 03/21/2023
ms.topic: overview
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
---

# Overview of the .NET + AI ecosystem

.NET can be used with many different libraries and tools that support the development of generative AI applications. This page includes a summary of the services and tools you may need to use in your appliations, with links to learn more about each of them.

**Note:** For .NET developers, we recommend using the [Semantic Kernel SDK](https://learn.microsoft.com/semantic-kernel/overview/) to orchestrate your calls to large language models (LLMs) and manage interactions with the various services mentioned here. Semantic Kernel makes it easy to work with different services without having to learn a different API for each one.

> [!IMPORTANT]
> These SDKs and tools are built by a variety of sources. Not all SDKs are maintained by Microsoft. When considering an SDK, be sure to evaluate quality, licensing, support, etc. to ensure they meet your requirements. Also make sure you review each SDK's documentation for detailed version compatibility information.

## Working with models

Today, you can use .NET to access models built by OpenAI, using either the Azure OpenAI SDK or the Semantic Kernel. These models may be hosted by OpenAI or in Azure using the Azure AI services. Preview support is coming soon in Semantic Kernel to work with other models and you can experiment today using open source SDKs created by the .NET developer community.

| NuGet Package                                                                          | Supported Models                                                                                                                                | Maintainer / Vendor                                                                                         | Useful links |
|----------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------|
| [Microsoft.SemanticKernel](https://www.nuget.org/packages/Microsoft.SemanticKernel/)   | [OpenAI models](https://platform.openai.com/docs/models/overview)<br/>[Azure OpenAI supported models](https://learn.microsoft.com/azure/ai-services/openai/concepts/models)                   | [Semantic Kernel](https://github.com/microsoft/semantic-kernel) (Microsoft)                                 | [docs](https://learn.microsoft.com/semantic-kernel/)     |
| [Azure OpenAI SDK](https://www.nuget.org/packages/Azure.AI.OpenAI/)                    | [Azure OpenAI supported models](https://learn.microsoft.com/azure/ai-services/openai/concepts/models)                                     | [Azure SDK for .NET](https://github.com/Azure/azure-sdk-for-net) (Microsoft)                                | [docs](https://learn.microsoft.com/azure/ai-services/openai/)                                               |

## Connect your data using vector stores

To increase relevancy and tailor AI applications for your own data, you'll likely need to work with a vector store. Many services provide a native SDK for .NET, which you can use directly. You can also use Semantic Kernel, which provides an extensible component model that allows you to try different vector stores without needing to learn each SDK.

| NuGet Package                                                                          | Supported Vector Store            | Maintainer / Vendor                                                                                         | Useful links |
|----------------------------------------------------------------------------------------|-----------------------------------|-------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------|
| [Microsoft.SemanticKernel](https://www.nuget.org/packages/Microsoft.SemanticKernel/)   | [Supported vector stores](https://learn.microsoft.com/semantic-kernel/memories/vector-db#available-connectors-to-vector-databases)        | [Semantic Kernel](https://github.com/microsoft/semantic-kernel) (Microsoft)                                 | [docs](https://learn.microsoft.com/semantic-kernel/memories/vector-db)     |
| [Azure.Search.Documents](https://www.nuget.org/packages/Azure.Search.Documents/)       | Azure AI Search                   | [Azure SDK for .NET](https://github.com/Azure/azure-sdk-for-net) (Microsoft)                                | [docs](https://learn.microsoft.com/dotnet/api/overview/azure/search.documents-readme?view=azure-dotnet)     |
| [Milvus.Client](https://www.nuget.org/packages/Milvus.Client)                          | Milvus Vector Database            | [Milvus](https://milvus.io/)                                                                                | [docs](https://milvus.io/docs/v2.2.x/install-csharp.md)                                                           |
| [Qdrant.Client](https://www.nuget.org/packages/Qdrant.Client)                          | Qdrant Vector Database            | [Qdrant](https://qdrant.tech)                                                                               | [docs](https://github.com/qdrant/qdrant-dotnet)                                                                   |

## Looking for other options? Check the .NET + AI open source community

In this article we've summarized tools and SDKs in the .NET ecosystem, focused on services that provide official support for .NET. Depending on your needs, and stage of application development, you may also want to take a look at the [open source options](https://github.com/jmatthiesen/dotnet-ai-resources?tab=readme-ov-file#models) for the ecosystem, in the unofficial list of .NET + AI resources. Note that Microsoft does not maintain many of these projects, so be sure to review their quality, licensing, support, etc.
