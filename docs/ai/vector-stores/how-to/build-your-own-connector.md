---
title: How to build your own Vector Store connector (Preview)
description: Describes how to build your own Vector Store connector connector
ms.topic: tutorial
ms.date: 07/08/2024
---
# How to build your own Vector Store connector (Preview)

This article provides guidance for building a Vector Store connector. This article can be used by database providers that want to build and maintain their own implementation, or for anyone that wants to build and maintain an unofficial connector for a database that lacks support.

To contribute your connector to the Semantic Kernel code base:

1. Create an issue in the [Semantic Kernel Github repository](https://github.com/microsoft/semantic-kernel/issues).
1. Review the [Semantic Kernel contribution guidelines](https://github.com/microsoft/semantic-kernel/blob/main/CONTRIBUTING.md).

## Overview

Vector Store connectors are implementations of the [Vector Store abstraction](https://www.nuget.org/packages/Microsoft.Extensions.VectorData.Abstractions). Some of the decisions that were made when designing the Vector Store abstraction mean that a Vector Store connector requires certain features to provide users with a good experience.

A key design decision is that the Vector Store abstraction takes a strongly typed approach to working with database records.
This means that <xref:Microsoft.Extensions.VectorData.VectorStoreCollection%602.UpsertAsync*> takes a strongly typed record as input, while <xref:Microsoft.Extensions.VectorData.VectorStoreCollection%602.GetAsync*> returns a strongly typed record.
The design uses C# generics to achieve the strong typing. This means that a connector has to be able to map from this data model to the storage model used by the underlying database. It also means that a connector might need to find out certain information about the record properties in order to know how to map each of these properties. For example, some vector databases (such as Chroma, Qdrant and Weaviate) require vectors to be stored in a specific structure and non-vectors in a different structure, or require record keys to be stored in a specific field.

At the same time, the Vector Store abstraction also provides a generic data model that allows a developer to work with a database without needing to create a custom data model.

It's important for connectors to support different types of model and provide developers with flexibility around how they use the connector. The following section deep dives into each of these requirements.

## Requirements

To be considered a full implementation of the Vector Store abstractions, the following set of requirements must be met.

### 1. Implement the core abstract base clases and interfaces

1.1 The three core abstract base classes and interfaces that need to be implemented are:

- <xref:Microsoft.Extensions.VectorData.VectorStore>
- <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2>
- <xref:Microsoft.Extensions.VectorData.IVectorSearchable`1>

<xref:Microsoft.Extensions.VectorData.VectorStoreCollection%602> implements `IVectorSearchable<TRecord>`, so only two inheriting classes are required. Use the following naming convention:

- {database type}VectorStore : VectorStore
- {database type}Collection<TKey, TRecord\> : VectorStoreCollection\<TKey, TRecord\>

For example:

- MyDbVectorStore : VectorStore
- MyDbCollection<TKey, TRecord\> : VectorStoreCollection\<TKey, TRecord\>

The <xref:Microsoft.Extensions.VectorData.VectorStoreCollection%602> implementation should accept the name of the collection as a constructor parameter and each instance of it is therefore tied to a specific collection instance in the database.

Here follows specific requirements for individual methods on these abstract base classes and interfaces.

1.2 *`VectorStore.GetCollection`* implementations should not do any checks to verify whether a collection exists or not.
The method should simply construct a collection object and return it. The user can optionally use the `CollectionExistsAsync` method to check if the collection exists in cases where this is not known. Doing checks on each invocation of `GetCollection` might add unwanted overhead for users when they are working with a collection that they know exists.

1.3 *`VectorStoreCollection<TKey, TRecord>.DeleteAsync`* that takes a single key as input should succeed if the record does not exist and for any other failures an exception should be thrown.
For requirements on the exception types to throw, see the [standard exceptions](#10-standard-exceptions) section.

1.4 *`VectorStoreCollection<TKey, TRecord>.DeleteAsync`* that takes multiple keys as input should succeed if any of the requested records do not exist and for any other failures an exception should be thrown.
For requirements on the exception types to throw, see the [standard exceptions](#10-standard-exceptions) section.

1.5 *`VectorStoreCollection<TKey, TRecord>.GetAsync`* that takes a single key as input should return null and not throw if a record is not found. For any other failures an exception should be thrown.
For requirements on the exception types to throw, see the [standard exceptions](#10-standard-exceptions) section.

1.6 *`VectorStoreCollection<TKey, TRecord>.GetAsync`* that takes multiple keys as input should return the subset of records that were found and not throw if any of the requested records were not found. For any other failures an exception should be thrown.
For requirements on the exception types to throw, see the [standard exceptions](#10-standard-exceptions) section.

1.7 *`VectorStoreCollection<TKey, TRecord>.GetAsync`* implementations should respect the `IncludeVectors` option provided via `RecordRetrievalOptions` where possible.
Vectors are often most useful in the database itself, since that is where vector comparison happens during vector searches and downloading them can be costly due to their size.
There might be cases where the database doesn't support excluding vectors in which case returning them is acceptable.

1.8 *`IVectorSearchable<TRecord>.SearchAsync<TVector>`* implementations should also respect the `IncludeVectors` option provided via `VectorSearchOptions<TRecord>` where possible.

1.9 *`IVectorSearchable<TRecord>.SearchAsync<TVector>`* implementations should simulate the `Top` and `Skip` functionality requested via `VectorSearchOptions<TRecord>` if the database
does not support this natively. To simulate this behavior, the implementation should fetch a number of results equal to Top + Skip, and then skip the first Skip number of results
before returning the remaining results.

1.10 *`IVectorSearchable<TRecord>.SearchAsync<TVector>`* implementations should not require `VectorPropertyName` or `VectorProperty` to be specified if only one vector exists on the data model.
In this case that single vector should automatically become the search target. If no vector or multiple vectors exists on the data model, and no `VectorPropertyName` or `VectorProperty` is provided the search method should throw.

When using `VectorPropertyName`, if a user does provide this value, the expected name should be the
property name from the data model and not any customized name that the property might be stored under
in the database. For example, imagine that the user has a data model property called `TextEmbedding` and they
decorated the property with a `JsonPropertyNameAttribute` that indicates that it should be serialized
as `text_embedding`. Assuming that the database is json based, it means that the property should be
stored in the database with the name `text_embedding`.
 When specifying the `VectorPropertyName` option, the user should always provide
`TextEmbedding` as the value. This is to ensure that where different connectors are used with the
same data model, the user can always use the same property names, even though the storage name
of the property might be different.

### 2. Support data model attributes

The Vector Store abstraction allows a user to use attributes to decorate their data model to indicate the type of each property and to configure the type of indexing required
for each vector property.

This information is typically required for

- Mapping between a data model and the underlying database's storage model.
- Creating a collection or index.
- Vector search.

If the user does not provide a <xref:Microsoft.Extensions.VectorData.VectorStoreCollectionDefinition>, read this information from the data model attributes using reflection. If the user did provide a
<xref:Microsoft.Extensions.VectorData.VectorStoreCollectionDefinition>, don't use the data model as the source of truth.

> [!TIP]
> For a detailed list of all attributes and settings that need to be supported, see [Defining your data model](../defining-your-data-model.md).

### 3. Support record definitions

As mentioned in [Support data model attributes](#2-support-data-model-attributes), you need information about each property to build out a connector. This information can also
be supplied via a <xref:Microsoft.Extensions.VectorData.VectorStoreCollectionDefinition> and if supplied, the connector should avoid trying to read this information from the data model or try and validate that the
data model matches the definition in any way.

The user should be able to provide a <xref:Microsoft.Extensions.VectorData.VectorStoreCollectionDefinition> to the <xref:Microsoft.Extensions.VectorData.VectorStoreCollection%602> implementation via options.

> [!TIP]
> Refer to [Defining your storage schema using a record definition](../schema-with-record-definition.md) for a detailed list of > all record definition settings that need to be supported.

### 4. Collection and index creation

4.1 A user can optionally choose an index kind and distance function for each vector property.
These are specified via string based settings, but where available a connector should expect
the strings that are provided as string consts on `Microsoft.Extensions.VectorData.IndexKind`
and `Microsoft.Extensions.VectorData.DistanceFunction`. Where the connector requires
index kinds and distance functions that are not available on the above mentioned static classes
additional custom strings might be accepted.

For example, the goal is for a user to be able to specify a standard distance function, like `DotProductSimilarity`
for any connector that supports this distance function, without needing to use different naming for each connector.

```csharp
[VectorStoreVector(1536, DistanceFunction = DistanceFunction.DotProductSimilarity]
public ReadOnlyMemory<float>? Embedding { get; set; }
```

4.2 A user can optionally choose whether each data property should be indexed or full text indexed.
In some databases, all properties might already be filterable or full text searchable by default, however
in many databases, special indexing is required to achieve this. If special indexing is required
this also means that adding this indexing will most likely incur extra cost.
The <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.IsIndexed> and <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.IsFullTextIndexed> settings allow a user to control whether to enable
this additional indexing per property.

### 5. Data model validation

Every database doesn't support every data type. To improve the user experience it's important to validate
the data types of any record properties and to do so early, for example, when an <xref:Microsoft.Extensions.VectorData.VectorStoreCollection%602>
instance is constructed. This way the user will be notified of any potential failures before starting to use the database.

### 6. Storage property naming

The naming conventions used for properties in code doesn't always match the preferred naming
for matching fields in a database.
It's therefore valuable to support customized storage names for properties.
Some databases might support storage formats that already have their own mechanism for
specifying storage names, for example, when using JSON as the storage format you can use
a `JsonPropertyNameAttribute` to provide a custom name.

6.1 Where the database has a storage format that supports its own mechanism for specifying storage
names, the connector should preferably use that mechanism.

6.2 Where the database does not use a storage format that supports its own mechanism for specifying
storage names, the connector must support the <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> settings from the data model
attributes or the <xref:Microsoft.Extensions.VectorData.VectorStoreCollectionDefinition>.

### 7. Mapper support

Connectors should provide the ability to map between the user supplied data model and the
storage model that the database requires, but should also provide some flexibility in how
that mapping is done. Most connectors would typically need to support the following two
mappers.

7.1 All connectors should come with a built in mapper that can map between the user supplied
data model and the storage model required by the underlying database.

7.2. All connectors should have a built in mapper that works with the <xref:Microsoft.Extensions.VectorData.VectorStoreGenericDataModel%602>.
See [Support GenericDataModel](#8-support-genericdatamodel) for more information.

### 8. Support GenericDataModel

While it is very useful for users to be able to define their own data model, in some cases
it might not be desirable, for example, when the database schema is not known at coding time and driven
by configuration.

To support this scenario, connectors should have out of the box support for the generic data
model supplied by the abstraction package: `Microsoft.Extensions.VectorData.VectorStoreGenericDataModel<TKey>`.

In practice this means that the connector must implement a special mapper
to support the generic data model. The connector should automatically use this mapper
if the user specified the generic data model as their data model.

### 9. Divergent data model and database schema

The only divergence required to be supported by connector implementations are
customizing storage property names for any properties.

Any more complex divergence is not supported, since this causes additional
complexity for filtering. For example, if the user has a filter expression that references
the data model, but the underlying schema is different to the data model, the
filter expression cannot be used against the underlying schema.

### 10. Standard Exceptions

The database operation methods provided by the connector should throw a set of standard
exceptions so that users of the abstraction know what exceptions they need to handle,
instead of having to catch a different set for each provider. For example, if the underlying
database client throws a `MyDBClientException` when a call to the database fails, this
should be caught and wrapped in a <xref:Microsoft.Extensions.VectorData.VectorStoreOperationException>, preferably preserving
the original exception as an inner exception.

11.1 For failures relating to service call or database failures the connector should throw:
`Microsoft.Extensions.VectorData.VectorStoreOperationException`

11.2 For mapping failures, the connector should throw:
`Microsoft.Extensions.VectorData.VectorStoreRecordMappingException`

11.3 For cases where a certain setting or feature is not supported, for example, an unsupported index type, use:
`System.NotSupportedException`.

11.4 In addition, use `System.ArgumentException`, `System.ArgumentNullException` for argument validation.

### 11. Batching

The <xref:Microsoft.Extensions.VectorData.VectorStoreCollection%602> abstract base class includes batching overloads for Get, Upsert and Delete.
Not all underlying database clients might have the same level of support for batching.

The base batch method implementations on <xref:Microsoft.Extensions.VectorData.VectorStoreCollection%602> calls the abstract non-batch implementations in serial.
If the database supports batching natively, these base batch implementations should be overridden and implemented
using the native database support.

## Recommended common patterns and practices

- Keep <xref:Microsoft.Extensions.VectorData.VectorStore> and <xref:Microsoft.Extensions.VectorData.VectorStoreCollection%602> implementations sealed. It's recommended to use a decorator pattern to override a default vector store behavior.
- Always use options classes for optional settings with smart defaults.
- Keep required parameters on the main signature and move optional parameters to options.

Here is an example of an <xref:Microsoft.Extensions.VectorData.VectorStoreCollection%602> constructor following this pattern.

```csharp
public sealed class MyDBCollection<TRecord> : VectorStoreCollection<string, TRecord>
{
    public MyDBCollection(MyDBClient myDBClient, string collectionName, MyDBCollectionOptions<TRecord>? options = default)
    {
    }

    ...
}

public class MyDBCollectionOptions<TRecord> : VectorStoreCollectionOptions
{
}
```

## SDK changes

See the following articles for a history of changes to the SDK and therefore implementation requirements:

- [Vector Store Changes March 2025](../../../support/migration/vectorstore-march-2025.md)
- [Vector Store Changes April 2025](../../../support/migration/vectorstore-april-2025.md)
- [Vector Store Changes May 2025](../../../support/migration/vectorstore-may-2025.md)

## Documentation

To share the features and limitations of your implementation, you can contribute an article to this
Microsoft Learn website. For the documentation on existing connectors, see [Out-of-the-box Vector Store connectors](../out-of-the-box-connectors/index.md).

To create your article, create a pull request in the [.NET docs GitHub repository](https://github.com/dotnet/docs).

Areas to cover:

1. An `Overview` with a standard table describing the main features of the connector.
1. An optional `Limitations` section with any limitations for your connector.
1. A `Getting started` section that describes how to import your NuGet and construct your <xref:Microsoft.Extensions.VectorData.VectorStore> and <xref:Microsoft.Extensions.VectorData.VectorStoreCollection%602>.
1. A `Data mapping` section showing the connector's default data mapping mechanism to the database storage model, including any property renaming it might support.
1. Information about additional features your connector supports.