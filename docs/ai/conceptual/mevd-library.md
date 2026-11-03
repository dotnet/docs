---
title: "The Microsoft.Extensions.VectorData library"
description: "Learn how to use Microsoft.Extensions.VectorData to build semantic search features."
ms.topic: concept-article
ms.date: 04/15/2026
ai-usage: ai-assisted
---

# The Microsoft.Extensions.VectorData library

The [📦 Microsoft.Extensions.VectorData.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.VectorData.Abstractions) package provides a unified layer of abstractions for interacting with vector stores in .NET. These abstractions let you write simple, high-level code against a single API, and swap out the underlying vector store with minimal changes to your application.

The library provides the following key capabilities:

- **Seamless .NET type mapping**: Map your .NET type directly to the database, similar to an object/relational mapper.
- **Unified data model**: Define your data model once using .NET attributes and use it across any supported vector store.
- **CRUD operations**: Create, read, update, and delete records in a vector store.
- **Vector and hybrid search**: Query records by semantic similarity using vector search, or combine vector and text search for hybrid search.
- **Embedding generation management**: Configure your embedding generator once and let the library transparently handle generation.
- **Collection management**: Create, list, and delete collections (tables or indices) in a vector store.

Microsoft.Extensions.VectorData is also the building block for additional, higher-level layers that need to interact with vector databases, for example, the [Microsoft.Extensions.DataIngestion](../conceptual/data-ingestion.md) library.

## Microsoft.Extensions.VectorData and Entity Framework Core

If you're already using [Entity Framework Core](/ef/core) to access your database, it's likely that your database provider already supports vector search, and LINQ queries can be used to express such searches. In such applications, Microsoft.Extensions.VectorData isn't necessarily needed. However, most dedicated vector databases aren't supported by EF Core, and Microsoft.Extensions.VectorData can provide a good experience for working with those. In addition, you might also find yourself using both EF and Microsoft.Extensions.VectorData in the same application, for example, when using an additional layer such as [Microsoft.Extensions.DataIngestion](../conceptual/medi-library.md).

## See also

- [Vector databases for .NET AI apps](../vector-stores/overview.md)
