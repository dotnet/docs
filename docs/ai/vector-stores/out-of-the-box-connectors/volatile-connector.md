---
title: Using the Volatile (In-Memory) Vector Store connector (Preview)
description: Contains information on how to use a Vector Store connector to access and manipulate data using the Volatile (in-memory) vector store.
ms.topic: concept-article
ms.date: 07/08/2024
---
# Using the Volatile (In-Memory) connector (Preview)

> [!WARNING]
> The C# VolatileVectorStore is obsolete and has been replaced with a new package.  See [InMemory Connector](./inmemory-connector.md)

## Overview

The Volatile Vector Store connector is a Vector Store implementation that uses no external database and stores data in memory.
This Vector Store is useful for prototyping scenarios or where high-speed in-memory operations are required.

The connector has the following characteristics.

| Feature Area                          | Support                       |
|---------------------------------------|-------------------------------|
| Collection maps to                    | In-memory dictionary          |
| Supported key property types          | Any type that can be compared |
| Supported data property types         | Any type                      |
| Supported vector property types       | ReadOnlyMemory\<float\>       |
| Supported index types                 | N/A                           |
| Supported distance functions          | N/A                           |
| Supports multiple vectors in a record | Yes                           |
| IsIndexed supported?               | Yes                           |
| IsFullTextIndexed supported?       | Yes                           |
| StoragePropertyName supported? | No, since storage is volatile and data reuse is therefore not possible, custom naming is not useful and not supported. |

## Get started

Add the Semantic Kernel Core NuGet package to your project.

```dotnetcli
dotnet add package Microsoft.SemanticKernel.Core
```

You can add the vector store to the `IServiceCollection` dependency injection container using extension methods provided by the Semantic Kernel connector packages.

```csharp
using Microsoft.SemanticKernel;

// Using a ServiceCollection.
var kernelBuilder = Kernel
    .CreateBuilder()
    .AddVolatileVectorStore();
```

```csharp
using Microsoft.SemanticKernel;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddVolatileVectorStore();
```

You can construct a Volatile Vector Store instance directly.

```csharp
using Microsoft.SemanticKernel.Data;

var vectorStore = new VolatileVectorStore();
```

It's possible to construct a direct reference to a named collection.

```csharp
using Microsoft.SemanticKernel.Data;

var collection = new VolatileVectorStoreRecordCollection<string, Hotel>("skhotels");
```