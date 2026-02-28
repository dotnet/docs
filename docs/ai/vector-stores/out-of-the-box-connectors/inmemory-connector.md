---
title: Using the In-Memory Vector Store connector (Preview)
description: Contains information on how to use a Vector Store connector to access and manipulate data in an in-memory vector store.
ms.topic: concept-article
ms.date: 11/10/2024
---
# Using the In-Memory connector (Preview)

> [!WARNING]
> The In-Memory Vector Store functionality is in preview, and improvements that require breaking changes might still occur in limited circumstances before release.

## Overview

The In-Memory Vector Store connector is a Vector Store implementation that uses no external database and stores data in memory.
This Vector Store is useful for prototyping scenarios or where high-speed in-memory operations are required.

The connector has the following characteristics.

| Feature Area                  | Support                       |
|-------------------------------|-------------------------------|
| Collection maps to            | In-memory dictionary          |
| Supported key property types  | Any type that can be compared |
| Supported data property types | Any type                      |
| Supported vector property types | <ul><li>ReadOnlyMemory\<float\></li><li>Embedding\<float\></li><li>float[]</li></ul> |
| Supported index types | Flat |
| Supported distance functions | <ul><li>CosineSimilarity</li><li>CosineDistance</li><li>DotProductSimilarity</li><li>EuclideanDistance</li></ul> |
| Supported filter clauses | <ul><li>AnyTagEqualTo</li><li>EqualTo</li></ul> |
| Supports multiple vectors in a record | Yes |
| IsIndexed supported? | Yes |
| IsFullTextIndexed supported? | Yes |
| StorageName supported? | No, since storage is in-memory and data reuse is therefore not possible, custom naming is not applicable. |
| HybridSearch supported? | No |

## Get started

Add the Semantic Kernel Core NuGet package to your project.

```dotnetcli
dotnet add package Microsoft.SemanticKernel.Connectors.InMemory --prerelease
```

You can add the vector store to the `IServiceCollection` dependency injection container using extension methods provided by the Semantic Kernel connector packages.

:::code language="csharp" source="./snippets/inmemory-connector.cs" id="GetStarted1":::

:::code language="csharp" source="./snippets/inmemory-connector.cs" id="GetStarted2":::

You can construct an InMemory Vector Store instance directly.

:::code language="csharp" source="./snippets/inmemory-connector.cs" id="GetStarted3":::

It's possible to construct a direct reference to a named collection.

:::code language="csharp" source="./snippets/inmemory-connector.cs" id="GetStarted4":::