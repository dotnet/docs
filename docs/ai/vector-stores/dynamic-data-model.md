---
title: Using Vector Store abstractions without defining your own data model
description: Describes how to use Vector Store abstractions without defining your own data model.
ms.topic: reference
ms.date: 10/16/2024
---
# Use Vector Store abstractions without defining your own data model

The Vector Store connectors use a model-first approach to interact with databases. This makes using the connectors easy and simple, since
your data model reflects the schema of your database records and to add any additional schema information required, you can simply add attributes to your data model properties.

However, there are cases where it isn't desirable or possible to define your own data model. For example, imagine that you don't know at compile time what your
database schema looks like, and the schema is only provided via configuration. Creating a data model that reflects the schema would be impossible in this case.

In this case, you can use a `Dictionary<string, object?>` for the record type. Properties are added to the `Dictionary` with key as the property name and the value as the property value.

## Supply schema information when using `Dictionary`

When using a `Dictionary`, connectors still need to know what the database schema looks like. Without the schema information
the connector would not be able to create a collection, or know how to map to and from the storage representation that each database uses.

A record definition can be used to provide the schema information. Unlike a data model, a record definition can be created from configuration at runtime, providing a solution for when schema information is not known at compile time.

> [!TIP]
> To see how to create a record definition, see [defining your schema with a record definition](./schema-with-record-definition.md).

## Example

To use the `Dictionary` with a connector, simply specify it as your data model when creating a collection, and simultaneously provide a record definition.

:::code language="csharp" source="./snippets/dynamic-data-model.cs" id="Example1":::

When constructing a collection instance directly, the record definition
is passed as an option. For example, here is an example of constructing
an Azure AI Search collection instance with `Dictionary`.

Each vector store collection implementation has a separate `*DynamicCollection`
class that can be used with `Dictionary<string, object?>`.
This is because these implementations might support NativeAOT/trimming.

:::code language="csharp" source="./snippets/dynamic-data-model.cs" id="Example2":::