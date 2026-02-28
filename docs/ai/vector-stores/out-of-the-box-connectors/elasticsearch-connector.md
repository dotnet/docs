---
title: Using the Elasticsearch Vector Store connector (Preview)
description: Contains information on how to use a Vector Store connector to access and manipulate data in Elasticsearch.
author: flobernd
ms.topic: concept-article
ms.date: 11/04/2024
---
# Using the Elasticsearch connector (Preview)

> [!WARNING]
> The Vector Store functionality is in preview, and improvements that require breaking changes might still occur in limited circumstances before release.

## Overview

The Elasticsearch Vector Store connector can be used to access and manage data in Elasticsearch. The connector has the following characteristics.

| Feature area       | Support             |
|--------------------|---------------------|
| Collection maps to | Elasticsearch index |
| Supported key property types | <ul><li>`string`</li><li>`long`</li><li>`Guid`</li></ul> |
| Supported data property types | All types that are supported by `System.Text.Json` (etiher built-in or by using a custom converter) |
| Supported vector property types | <ul><li>`ReadOnlyMemory<float>`</li><li>`IEnumerable<float>`</li><li>`IReadOnlyCollection<float>`</li><li>`ICollection<float>`</li><li>`IReadOnlyList<float>`</li><li>`IList<float>`</li><li>`float[]`</li></ul> |
| Supported index types | <ul><li>HNSW (32, 8, or 4 bit or BBQ)</li><li>FLAT (32, 8, or 4 bit or BBQ)</li></ul> |
| Supported distance functions | <ul><li>CosineSimilarity</li><li>DotProductSimilarity</li><li>EuclideanDistance</li><li>MaxInnerProduct</li></ul> |
| Supported filter clauses | <ul><li>`AnyTagEqualTo`</li><li>`EqualTo`</li></ul> |
| Supports multiple vectors in a record | Yes |
| IsIndexed supported? | Yes |
| IsFullTextIndexed supported? | Yes |
| StoragePropertyName supported? | No, use `JsonSerializerOptions` and `JsonPropertyNameAttribute` instead. [See here for more info.](#data-mapping) |
| HybridSearch supported? | Yes |

## Get started

To [run Elasticsearch locally](https://www.elastic.co/guide/en/elasticsearch/reference/current/run-elasticsearch-locally.html) for local development or testing run the `start-local` script with one command:

```bash
curl -fsSL https://elastic.co/start-local | sh
```

Add the Elasticsearch Vector Store connector NuGet package to your project.

```dotnetcli
dotnet add package Elastic.SemanticKernel.Connectors.Elasticsearch --prerelease
```

You can add the vector store to the `IServiceCollection` dependency injection container using extension methods provided by the Semantic Kernel connector packages.

:::code language="csharp" source="./snippets/elasticsearch-connector.cs" id="GetStarted1":::

:::code language="csharp" source="./snippets/elasticsearch-connector.cs" id="GetStarted2":::

Extension methods that take no parameters are also provided. These require an instance of the `Elastic.Clients.Elasticsearch.ElasticsearchClient` class to be separately registered with the dependency injection container.

:::code language="csharp" source="./snippets/elasticsearch-connector.cs" id="GetStarted3":::

:::code language="csharp" source="./snippets/elasticsearch-connector.cs" id="GetStarted4":::

You can construct an Elasticsearch Vector Store instance directly.

:::code language="csharp" source="./snippets/elasticsearch-connector.cs" id="GetStarted5":::

It's possible to construct a direct reference to a named collection.

:::code language="csharp" source="./snippets/elasticsearch-connector.cs" id="GetStarted6":::

## Data mapping

The Elasticsearch connector will use `System.Text.Json.JsonSerializer` to do mapping.
Since Elasticsearch stores documents with a separate key/id and value, the mapper will serialize all properties except for the key to a JSON object
and use that as the value.

Usage of the `JsonPropertyNameAttribute` is supported if a different storage name to the
data model property name is required. It's also possible to use a custom `JsonSerializerOptions` instance with a customized property naming policy. To enable this,
a custom source serializer must be configured.

:::code language="csharp" source="./snippets/elasticsearch-connector.cs" id="DataMapping1":::

As an alternative, the `DefaultFieldNameInferrer` lambda function can be configured to achieve the same result or to even further customize property naming based on dynamic conditions.

:::code language="csharp" source="./snippets/elasticsearch-connector.cs" id="DataMapping2":::

Since a naming policy of snake case upper was chosen, here is an example of how this data type will be set in Elasticsearch.
Also note the use of `JsonPropertyNameAttribute` on the `Description` property to further customize the storage naming.

:::code language="csharp" source="./snippets/elasticsearch-connector.cs" id="DataMapping3":::

```json
{
  "_index" : "skhotelsjson",
  "_id" : "h1",
  "_source" : {
    "HOTEL_NAME" : "Hotel Happy",
    "HOTEL_DESCRIPTION" : "A place where everyone can be happy.",
    "DESCRIPTION_EMBEDDING" : [
      0.9,
      0.1,
      0.1,
      0.1
    ]
  }
}
```