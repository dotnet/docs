---
title: Using the Redis Vector Store connector (Preview)
description: Contains information on how to use a Vector Store connector to access and manipulate data in Redis.
ms.topic: concept-article
ms.date: 07/08/2024
---
# Using the Redis connector (Preview)

> [!WARNING]
> The Redis Vector Store functionality is in preview, and improvements that require breaking changes might still occur in limited circumstances before release.

## Overview

The Redis Vector Store connector can be used to access and manage data in Redis. The connector supports both Hashes and JSON modes and which mode you pick will determine what other features are supported.

The connector has the following characteristics.

| Feature Area | Support |
|--|--|
| Collection maps to | Redis index with prefix set to `<collectionname>:` |
| Supported key property types | string |
| Supported data property types | **When using Hashes:**<ul><li>string</li><li>int</li><li>uint</li><li>long</li><li>ulong</li><li>double</li><li>float</li><li>bool</li></ul> |
| Supported vector property types | <ul><li>ReadOnlyMemory\<float\></li><li>Embedding\<float\></li><li>float[]</li><li>ReadOnlyMemory\<double\></li><li>Embedding\<double\></li><li>double[]</li></ul> |
| Supported index types | <ul><li>Hnsw</li><li>Flat</li></ul> |
| Supported distance functions | <ul><li>CosineSimilarity</li><li>DotProductSimilarity</li><li>EuclideanSquaredDistance</li></ul> |
| Supported filter clauses | <ul><li>AnyTagEqualTo</li><li>EqualTo</li></ul> |
| Supports multiple vectors in a record | Yes |
| IsIndexed supported? | Yes |
| IsFullTextIndexed supported? | Yes |
| StorageName supported? | **When using Hashes:** Yes<br>**When using JSON:** No, use `JsonSerializerOptions` and `JsonPropertyNameAttribute` instead. [See here for more info.](#data-mapping) |
| HybridSearch supported? | No |

## Get started

Add the Redis Vector Store connector NuGet package to your project.

```dotnetcli
dotnet add package Microsoft.SemanticKernel.Connectors.Redis --prerelease
```

You can add the vector store to the `IServiceCollection` dependency injection container using extension methods provided by the Semantic Kernel connector packages.

:::code language="csharp" source="./snippets/redis-connector.cs" id="GetStarted1":::

:::code language="csharp" source="./snippets/redis-connector.cs" id="GetStarted2":::

Extension methods that take no parameters are also provided. These require an instance of the Redis `IDatabase` to be separately registered with the dependency injection container.

:::code language="csharp" source="./snippets/redis-connector.cs" id="GetStarted3":::

:::code language="csharp" source="./snippets/redis-connector.cs" id="GetStarted4":::

You can construct a Redis Vector Store instance directly.

:::code language="csharp" source="./snippets/redis-connector.cs" id="GetStarted5":::

It's possible to construct a direct reference to a named collection.
When doing so, you have to choose between the JSON or Hashes instance depending on how you wish to store data in Redis.

:::code language="csharp" source="./snippets/redis-connector.cs" id="GetStarted6":::

:::code language="csharp" source="./snippets/redis-connector.cs" id="GetStarted7":::

When constructing a `RedisVectorStore` or registering it with the dependency injection container, it's possible to pass a `RedisVectorStoreOptions` instance
that configures the preferred storage type / mode used: Hashes or JSON. If not specified, the default is JSON.

:::code language="csharp" source="./snippets/redis-connector.cs" id="GetStarted8":::

## Index prefixes

Redis uses a system of key prefixing to associate a record with an index.
When creating an index you can specify one or more prefixes to use with that index.
If you want to associate a record with that index, you have to add the prefix to the key of that record.

For example, If you create a index called `skhotelsjson` with a prefix of `skhotelsjson:`, when setting a record
with key `h1`, the record key will need to be prefixed like this `skhotelsjson:h1` to be added to the index.

When creating a new collection using the Redis connector, the connector will create an index in Redis with a
prefix consisting of the collection name and a colon, like this `<collectionname>:`.
By default, the connector will also prefix all keys with the this prefix when doing record operations like Get, Upsert, and Delete.

If you didn't want to use a prefix consisting of the collection name and a colon, it is possible to switch
off the prefixing behavior and pass in the fully prefixed key to the record operations.

:::code language="csharp" source="./snippets/redis-connector.cs" id="IndexPrefixes":::

## Data mapping

Redis supports two modes for storing data: JSON and Hashes. The Redis connector supports both storage types, and mapping differs depending on the chosen storage type.

### Data mapping when using the JSON storage type

When using the JSON storage type, the Redis connector will use `System.Text.Json.JsonSerializer` to do mapping.
Since Redis stores records with a separate key and value, the mapper will serialize all properties except for the key to a JSON object
and use that as the value.

Usage of the `JsonPropertyNameAttribute` is supported if a different storage name to the
data model property name is required. It's also possible to use a custom `JsonSerializerOptions` instance with a customized property naming policy. To enable this, the `JsonSerializerOptions`
must be passed to the `RedisJsonCollection` on construction.

:::code language="csharp" source="./snippets/redis-connector.cs" id="DataMappingWhenUsingTheJSONStorageType1":::

Since a naming policy of snake case upper was chosen, here is an example of how this data type will be set in Redis.
Also note the use of `JsonPropertyNameAttribute` on the `Description` property to further customize the storage naming.

:::code language="csharp" source="./snippets/redis-connector.cs" id="DataMappingWhenUsingTheJSONStorageType2":::

```redis
JSON.SET skhotelsjson:h1 $ '{ "HOTEL_NAME": "Hotel Happy", "HOTEL_DESCRIPTION": "A place where everyone can be happy.", "DESCRIPTION_EMBEDDING": [0.9, 0.1, 0.1, 0.1] }'
```

### Data mapping when using the Hashes storage type

When using the Hashes storage type, the Redis connector provides its own mapper to do mapping.
This mapper will map each property to a field-value pair as supported by the Redis `HSET` command.

For data properties and vector properties, you can provide override field names to use in storage that is different to the
property names on the data model. This is not supported for keys, since keys cannot be named in Redis.

Property name overriding is done by setting the <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> option via the data model attributes or record definition.

Here is an example of a data model with <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> set on its attributes and how these are set in Redis.

:::code language="csharp" source="./snippets/redis-connector.cs" id="DataMappingWhenUsingTheHashesStorageType":::

```redis
HSET skhotelshashes:h1 hotel_name "Hotel Happy" hotel_description 'A place where everyone can be happy.' hotel_description_embedding <vector_bytes>
```