---
title: Using the Azure AI Search Vector Store connector (Preview)
description: Contains information on how to use a Vector Store connector to access and manipulate data in Azure AI Search.
ms.topic: concept-article
ms.date: 07/08/2024
---
# Using the Azure AI Search Vector Store connector (Preview)

> [!WARNING]
> The Azure AI Search Vector Store functionality is in preview, and improvements that require breaking changes might still occur in limited circumstances before release.

## Overview

The Azure AI Search Vector Store connector can be used to access and manage data in Azure AI Search. The connector has the following characteristics.

| Feature Area                  | Support               |
|-------------------------------|-----------------------|
| Collection maps to            | Azure AI Search Index |
| Supported key property types  | string                |
| Supported data property types | <ul><li>string</li><li>int</li><li>long</li><li>double</li><li>float</li><li>bool</li><li>DateTimeOffset</li><li>*and enumerables of each of these types*</li></ul> |
| Supported vector property types | <ul><li>ReadOnlyMemory\<float\></li><li>Embedding\<float\></li><li>float[]</li></ul> |
| Supported index types         | <ul><li>Hnsw</li><li>Flat</li></ul> |
| Supported distance functions  | <ul><li>CosineSimilarity</li><li>DotProductSimilarity</li><li>EuclideanDistance</li></ul> |
| Supported filter clauses     | <ul><li>AnyTagEqualTo</li><li>EqualTo</li></ul> |
| Supports multiple vectors in a record | Yes                                                                                                                                                                 |
| IsIndexed supported?          | Yes |
| IsFullTextIndexed supported?  | Yes |
| StorageName supported?        | No, use `JsonSerializerOptions` and `JsonPropertyNameAttribute` instead. [See here for more info.](#data-mapping) |
| HybridSearch supported?       | |

## Limitations

Notable Azure AI Search connector functionality limitations.

| Feature Area | Workaround |
|--------------|------------|
| Configuring full text search analyzers during collection creation is not supported. | Use the Azure AI Search Client SDK directly for collection creation |

## Get started

Add the Azure AI Search Vector Store connector NuGet package to your project.

```dotnetcli
dotnet add package Microsoft.SemanticKernel.Connectors.AzureAISearch --prerelease
```

You can add the vector store to the `IServiceCollection` dependency injection container using extension methods provided by the Semantic Kernel connector packages.

:::code language="csharp" source="./snippets/azure-ai-search-connector.cs" id="GetStarted1":::

:::code language="csharp" source="./snippets/azure-ai-search-connector.cs" id="GetStarted2":::

Extension methods that take no parameters are also provided. These require an instance of the Azure AI Search `SearchIndexClient` to be separately registered with the dependency injection container.

:::code language="csharp" source="./snippets/azure-ai-search-connector.cs" id="GetStarted3":::

:::code language="csharp" source="./snippets/azure-ai-search-connector.cs" id="GetStarted4":::

You can construct an Azure AI Search Vector Store instance directly.

:::code language="csharp" source="./snippets/azure-ai-search-connector.cs" id="GetStarted5":::

It's possible to construct a direct reference to a named collection.

:::code language="csharp" source="./snippets/azure-ai-search-connector.cs" id="GetStarted6":::

## Data mapping

The default mapper used by the Azure AI Search connector when mapping data from the data model to storage is the one provided by the Azure AI Search SDK.

This mapper does a direct conversion of the list of properties on the data model to the fields in Azure AI Search and uses `System.Text.Json.JsonSerializer`
to convert to the storage schema. This means that usage of the `JsonPropertyNameAttribute` is supported if a different storage name to the
data model property name is required.

It's also possible to use a custom `JsonSerializerOptions` instance with a customized property naming policy. To enable this, the `JsonSerializerOptions`
must be passed to both the `SearchIndexClient` and the `AzureAISearchCollection` on construction.

:::code language="csharp" source="./snippets/azure-ai-search-connector.cs" id="DataMapping":::