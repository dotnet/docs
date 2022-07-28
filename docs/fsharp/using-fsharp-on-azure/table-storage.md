---
title: Get started with Azure Table Storage using F#
description: Store structured data in the cloud using Azure Table Storage or Azure Cosmos DB.
author: sylvanc
ms.date: 07/28/2022
ms.custom: "devx-track-fsharp"
---
# Get started with Azure Table Storage and the Azure Cosmos DB Table api using F\#

Azure Table Storage is a service that stores structured NoSQL data in the cloud. Table storage is a key/attribute store with a schemaless design. Because Table storage is schemaless, it's easy to adapt your data as the needs of your application evolve. Access to data is fast and cost-effective for all kinds of applications. Table storage is typically significantly lower in cost than traditional SQL for similar volumes of data.

You can use Table storage to store flexible datasets, such as user data for web applications, address books, device information, and any other type of metadata that your service requires. You can store any number of entities in a table, and a storage account may contain any number of tables, up to the capacity limit of the storage account.

Azure Cosmos DB provides the Table API for applications that are written for Azure Table Storage and that require premium capabilities such as:

- Turnkey global distribution.
- Dedicated throughput worldwide.
- Single-digit millisecond latencies at the 99th percentile.
- Guaranteed high availability.
- Automatic secondary indexing.

Applications written for Azure Table Storage can migrate to Azure Cosmos DB by using the Table API with no code changes and take advantage of premium capabilities. The Table API has client SDKs available for [.NET](https://www.nuget.org/packages/Azure.Data.Tables/), [Java](https://mvnrepository.com/artifact/com.azure/azure-data-tables), [Python](https://pypi.org/project/azure-data-tables/), and [Node.js](https://www.npmjs.com/package/@azure/data-tables).

For more information, see [Introduction to Azure Cosmos DB Table API](/azure/cosmos-db/table-introduction).

## About this tutorial

This tutorial shows how to write F# code to do some common tasks using Azure Table Storage or the Azure Cosmos DB Table API, including creating and deleting a table and inserting, updating, deleting, and querying table data.

## Prerequisites

To use this guide, you must first [create an Azure storage account](/azure/storage/storage-create-storage-account) or [Azure Cosmos DB account](https://azure.microsoft.com/free/cosmos-db/).

## Create an F\# script and start F\# interactive

The samples in this article can be used in either an F# application or an F# script. To create an F# script, create a file with the `.fsx` extension, for example, `tables.fsx`, in your F# development environment.

### How to execute scripts

F# Interactive, `dotnet fsi`, can be launched interactively, or it can be launched from the command line to run a script. The command-line syntax is

```.NET CLI
> dotnet fsi [options] [ script-file [arguments] ]
```

### Add packages in a script

Next, use `#r` `nuget:package name` to install the `Azure.Data.Tables` package and `open` namespaces. Such as

```fsharp
> #r "nuget: Azure.Data.Tables"
open Azure.Data.Tables
```

### Add namespace declarations

Add the following `open` statements to the top of the `tables.fsx` file:

:::code language="fsharp" source="../../../samples/snippets/fsharp/azure/table-storage.fsx" id="open":::

### Get your Azure Storage connection string

If you're connecting to Azure Storage Table service, you'll need your connection string for this tutorial. You can copy your connection string from the Azure portal. For more information about connection strings, see [Configure Storage Connection Strings](/azure/storage/storage-configure-connection-string).

### Get your Azure Cosmos DB connection string

If you're connecting to Azure Cosmos DB, you'll need your connection string for this tutorial. You can copy your connection string from the Azure portal. In the Azure portal, in your Cosmos DB account, go to **Settings** > **Connection String**, and select the **Copy** button to copy your Primary Connection String.

For the tutorial, enter your connection string in your script, like the following example:

:::code language="fsharp" source="../../../samples/snippets/fsharp/azure/table-storage.fsx" id="connectionString":::

### Create the table service client

The `TableServiceClient` class enables you to retrieve tables and entities in Table storage. Here's one way to create the service client:

:::code language="fsharp" source="../../../samples/snippets/fsharp/azure/table-storage.fsx" id="createTableClient":::

Now you are ready to write code that reads data from and writes data to Table storage.

### Create a table

This example shows how to create a table if it does not already exist:

:::code language="fsharp" source="../../../samples/snippets/fsharp/azure/table-storage.fsx" id="createTable":::

### Add an entity to a table

An entity has to have a type that implements `ITableEntity`. You can extend `ITableEntity` in any way you like, but your type *must* have a parameter-less constructor. Only properties that have both `get` and `set` are stored in your Azure Table.

An entity's partition and row key uniquely identify the entity in the table. Entities with the same partition key can be queried faster than those with different partition keys, but using diverse partition keys allows for greater scalability of parallel operations.

Here's an example of a `Customer` that uses the `lastName` as the partition key and the `firstName` as the row key.

:::code language="fsharp" source="../../../samples/snippets/fsharp/azure/table-storage.fsx" id="addEntity":::

Now add `Customer` to the table. To do so, we can use the AddEntity() method.

:::code language="fsharp" source="../../../samples/snippets/fsharp/azure/table-storage.fsx" id="addEntityToTable":::

### Insert a batch of entities

You can insert a batch of entities into a table using a single write operation. Batch operations allow you to combine operations into a single execution, but they have some restrictions:

- You can perform updates, deletes, and inserts in the same batch operation.
- A batch operation can include up to 100 entities.
- All entities in a batch operation must have the same partition key.
- While it is possible to perform a query in a batch operation, it must be the only operation in the batch.

Here's some code that combines two inserts into a batch operation:

:::code language="fsharp" source="../../../samples/snippets/fsharp/azure/table-storage.fsx" id="addBatchOfEntities":::

### Retrieve all entities in a partition

To query a table for all entities in a partition, use a `Query<T>` object. Here, you filter for entities where "Smith" is the partition key.

:::code language="fsharp" source="../../../samples/snippets/fsharp/azure/table-storage.fsx" id="retrieveEntities":::

### Retrieve a range of entities in a partition

If you don't want to query all the entities in a partition, you can specify a range by combining the partition key filter with a row key filter. Here, you use two filters to get all entities in the "Smith" partition where the row key (first name) starts with a letter earlier than "M" in the alphabet.

:::code language="fsharp" source="../../../samples/snippets/fsharp/azure/table-storage.fsx" id="retrieveEntitiesRange":::

### Retrieve a single entity

To retrieve a single, specific entity, use `GetEntityAsync` to specify the customer "Ben Smith". Instead of a collection, you get back a `Customer`. Specifying both the partition key and the row key in a query is the fastest way to retrieve a single entity from the Table service.

:::code language="fsharp" source="../../../samples/snippets/fsharp/azure/table-storage.fsx" id="retrieveEntity":::

You now print the results:

:::code language="fsharp" source="../../../samples/snippets/fsharp/azure/table-storage.fsx" id="printEntity":::

### Update an entity

To update an entity, retrieve it from the Table service, modify the entity object, and then save the changes back to the Table service using a `TableUpdateMode.Replace` operation. This causes the entity to be fully replaced on the server, unless the entity on the server has changed since it was retrieved, in which case the operation fails. This failure is to prevent your application from inadvertently overwriting changes from other sources.

:::code language="fsharp" source="../../../samples/snippets/fsharp/azure/table-storage.fsx" id="updateEntity":::

### Upsert an entity

Sometimes, you don't know whether an entity exists in the table. And if it does, the current values stored in it are no longer needed. You can use `UpsertEntity` method to create the entity or replace it if it exists, regardless of its state.

:::code language="fsharp" source="../../../samples/snippets/fsharp/azure/table-storage.fsx" id="upsertEntity":::

### Query a subset of entity properties

A table query can retrieve just a few properties from an entity instead of all of them. This technique, called projection, can improve query performance, especially for large entities. Here, you return only email addresses using `Query<T>` and `Select`. Projection is not supported on the local storage emulator, so this code runs only when you're using an account on the Table service.

:::code language="fsharp" source="../../../samples/snippets/fsharp/azure/table-storage.fsx" id="querySubset":::

### Retrieve entities in pages asynchronously

If you are reading a large number of entities, and you want to process them as they are retrieved rather than waiting for them all to return, you can use a segmented query. Here, you return results in pages by using an async workflow so that execution is not blocked while you're waiting for a large set of results to return.

:::code language="fsharp" source="../../../samples/snippets/fsharp/azure/table-storage.fsx" id="retrieveEntitiesAsync":::

### Delete an entity

You can delete an entity after you have retrieved it. As with updating an entity, this fails if the entity has changed since you retrieved it.

:::code language="fsharp" source="../../../samples/snippets/fsharp/azure/table-storage.fsx" id="deleteEntity":::

### Delete a table

You can delete a table from a storage account. A table that has been deleted will be unavailable to be re-created for some time following the deletion.

:::code language="fsharp" source="../../../samples/snippets/fsharp/azure/table-storage.fsx" id="deleteTable":::

## See also

- [Introduction to Azure Cosmos DB Table API](/azure/cosmos-db/table-introduction)
- [Storage Client Library for .NET reference](/dotnet/api/overview/azure/storage)
- [Configuring Connection Strings](/azure/storage/common/storage-configure-connection-string)
