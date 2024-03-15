---
title: Overview of the .NET + AI Ecosystem
description: This article provides an overview of the ecosystem of SDKs and tools available to .NET developers integrating AI into their applications.
ms.date: 03/21/2023
ms.topic: overview
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
---

# Overview of the .NET + AI ecosystem

.NET can be used with many different libraries and tools that support the development of generative AI applications. This page includes a summary of the services and tools you may need to use in your appliations and links to learn more about each of them. 

For .NET developers, we recommend using the [Semantic Kernel SDK]() to orchestrate your calls to large language models (LLMs) and manage interactions with the various services mentioned here. Semantic Kernel makes it easier to work with and change out the different services without having to rewrite your source each time.

# LLM APIs



# Orchestration frameworks



# Vector databases

> [!IMPORTANT]
> Vector store SDKs are built by a variety of sources. Not all providers are maintained by Microsoft. When considering a provider, be sure to evaluate quality, licensing, support, etc. to ensure they meet your requirements. Also make sure you review each provider's documentation for detailed version compatibility information.

| NuGet Package                                                                          | Supported Vector Store            | Maintainer / Vendor                                                                                         | Useful links |
|----------------------------------------------------------------------------------------|-----------------------------------|-------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------|
| [Azure.Search.Documents](https://www.nuget.org/packages/Azure.Search.Documents/)       | Azure AI Search                   | [Azure SDK for .NET](https://github.com/Azure/azure-sdk-for-net) (Microsoft)                                | [docs](https://learn.microsoft.com/en-us/dotnet/api/overview/azure/search.documents-readme?view=azure-dotnet)     |
| [Milvus.Client](https://www.nuget.org/packages/Milvus.Client)                          | Milvus Vector Database            | [Milvus](https://milvus.io/)                                                                                | [docs](https://milvus.io/docs/v2.2.x/install-csharp.md)                                                           |
| [Qdrant.Client](https://www.nuget.org/packages/Qdrant.Client)                          | Qdrant Vector Database            | [Qdrant](https://qdrant.tech)                                                                               | [docs](https://github.com/qdrant/qdrant-dotnet)                                                                   |
