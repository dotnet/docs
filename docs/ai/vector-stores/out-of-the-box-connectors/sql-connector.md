---
title: Using the SQL Server Vector Store connector (Preview)
description: Contains information on how to use a Vector Store connector to access and manipulate data in SQL Server.
author: eavanvalkenburg
ms.topic: concept-article
ms.author: edvan
ms.date: 03/21/2024
---
# Using the SQL Server Vector Store connector (Preview)

> [!WARNING]
> The Sql Server Vector Store functionality is in preview, and improvements that require breaking changes might still occur in limited circumstances before release.

## Overview

The SQL Server Vector Store connector can be used to access and manage data in SQL Server. The connector has the following characteristics.

| Feature Area | Support |
|--|--|
| Collection maps to | SQL Server table |
| Supported key property types | <ul><li>int</li><li>long</li><li>string</li><li>Guid</li><li>DateTime</li><li>byte[]</li></ul> |
| Supported data property types | <ul><li>int</li><li>short</li><li>byte</li><li>long</li><li>Guid</li><li>string</li><li>bool</li><li>float</li><li>double</li><li>decimal</li><li>byte[]</li><li>DateTime</li><li>TimeOnly</li></ul> |
| Supported vector property types | <ul><li>ReadOnlyMemory\<float\></li><li>Embedding\<float\></li><li>float[]</li></ul> |
| Supported index types | <ul><li>Flat</li></ul> |
| Supported distance functions | <ul><li>CosineDistance</li><li>NegativeDotProductSimilarity</li><li>EuclideanDistance</li></ul> |
| Supports multiple vectors in a record | Yes |
| IsIndexed supported? | Yes |
| IsFullTextIndexed supported? | No |
| StorageName supported? | Yes |
| HybridSearch supported? | No |

## Get started

Add the SQL Sever Vector Store connector NuGet package to your project.

```dotnetcli
dotnet add package Microsoft.SemanticKernel.Connectors.SqlServer --prerelease
```

You can add the vector store to the `IServiceCollection` dependency injection container using extension methods from the Semantic Kernel connector packages.

:::code language="csharp" source="./snippets/sql-connector.cs" id="GetStarted1":::

:::code language="csharp" source="./snippets/sql-connector.cs" id="GetStarted2":::

You can construct a Sql Server Vector Store instance directly.

:::code language="csharp" source="./snippets/sql-connector.cs" id="GetStarted3":::

It's possible to construct a direct reference to a named collection.

:::code language="csharp" source="./snippets/sql-connector.cs" id="GetStarted4":::

## Data mapping

The SQL Server Vector Store connector provides a default mapper when mapping from the data model to storage.
This mapper does a direct conversion of the list of properties on the data model to the columns in SQL Server.

### Property name override

You can provide override property names to use in storage that is different to the property names on the data model.
The property name override is done by setting the <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> option via the data model property attributes or record definition.

Here is an example of a data model with <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> set on its attributes and how that will be represented in a SQL Server command.

:::code language="csharp" source="./snippets/sql-connector.cs" id="PropertyNameOverride":::

```sql
CREATE TABLE Hotel (
[HotelId] BIGINT NOT NULL,
[hotel_name] NVARCHAR(MAX),
[hotel_description] NVARCHAR(MAX),
[DescriptionEmbedding] VECTOR(4),
PRIMARY KEY ([HotelId])
);
```