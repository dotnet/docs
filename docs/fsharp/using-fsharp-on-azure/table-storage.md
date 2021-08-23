---
title: Get started with Azure Table Storage using F#
description: Store structured data in the cloud using Azure Table Storage or Azure Cosmos DB.
author: sylvanc
ms.date: 03/26/2018
ms.custom: "devx-track-fsharp"
---
# Get started with Azure Table Storage and the Azure Cosmos DB Table API using F\#

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

To use this guide, you must first [create an Azure storage account](/azure/storage/storage-create-storage-account) or [Azure Cosmos DB account](https://azure.microsoft.com/try/cosmosdb/).

## Create an F# Script and Start F# Interactive

The samples in this article can be used in either an F# application or an F# script. To create an F# script, create a file with the `.fsx` extension, for example `tables.fsx`, in your F# development environment.

Next, use a [package manager](package-management.md) such as [Paket](https://fsprojects.github.io/Paket/) or [NuGet](https://www.nuget.org/) to install the `WindowsAzure.Storage` package and reference `WindowsAzure.Storage.dll` in your script using a `#r` directive. Do it again for `Microsoft.WindowsAzure.ConfigurationManager` in order to get the Microsoft.Azure namespace.

### Add namespace declarations

Add the following `open` statements to the top of the `tables.fsx` file:

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L1-L5)]

### Get your Azure Storage connection string

If you're connecting to Azure Storage Table service, you'll need your connection string for this tutorial. You can copy your connection string from the Azure portal. For more information about connection strings, see [Configure Storage Connection Strings](/azure/storage/storage-configure-connection-string).

### Get your Azure Cosmos DB connection string

If you're connecting to Azure Cosmos DB, you'll need your connection string for this tutorial. You can copy your connection string from the Azure portal. In the Azure portal, in your Cosmos DB account, go to **Settings** > **Connection String**, and select the **Copy** button to copy your Primary Connection String.

For the tutorial, enter your connection string in your script, like the following example:

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L11-L11)]

However, this is **not recommended** for real projects. Your storage account key is similar to the root password for your storage account. Always be careful to protect your storage account key. Avoid distributing it to other users, hard-coding it, or saving it in a plain-text file that is accessible to others. You can regenerate your key using the Azure portal if you believe it may have been compromised.

For real applications, the best way to maintain your storage connection string is in a configuration file. To fetch the connection string from a configuration file, you can do this:

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L13-L15)]

Using Azure Configuration Manager is optional. You can also use an API such as the .NET Framework's `ConfigurationManager` type.

### Create the Table service client

The `TableServiceClient` class enables you to retrieve tables and entities in Table storage. Here's one way to create the service client:

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L23)]

Now you are ready to write code that reads data from and writes data to Table storage.

### Create a table

This example shows how to create a table if it does not already exist:

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L29-L33)]

### Add an entity to a table

An entity has to have a type that implements `ITableEntity`. You can extend `ITableEntity` in any way you like, but your type *must* have a parameter-less constructor. Only properties that have both `get` and `set` are stored in your Azure Table.

An entity's partition and row key uniquely identify the entity in the table. Entities with the same partition key can be queried faster than those with different partition keys, but using diverse partition keys allows for greater scalability of parallel operations.

Here's an example of a `Customer` that uses the `lastName` as the partition key and the `firstName` as the row key.

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L39-L65)]

Now add `Customer` to the table. To do so, we can use the AddEntity() method.

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L67-L68)]

### Insert a batch of entities

You can insert a batch of entities into a table using a single write operation. Batch operations allow you to combine operations into a single execution, but they have some restrictions:

- You can perform updates, deletes, and inserts in the same batch operation.
- A batch operation can include up to 100 entities.
- All entities in a batch operation must have the same partition key.
- While it is possible to perform a query in a batch operation, it must be the only operation in the batch.

Here's some code that combines two inserts into a batch operation:

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L74-L89)]

### Retrieve all entities in a partition

To query a table for all entities in a partition, use a `Query<T>` object. Here, you filter for entities where "Smith" is the partition key.

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L95)]

You now print the results:

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L97-L98)]

### Retrieve a range of entities in a partition

If you don't want to query all the entities in a partition, you can specify a range by combining the partition key filter with a row key filter. Here, you use two filters to get all entities in the "Smith" partition where the row key (first name) starts with a letter earlier than "M" in the alphabet.

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L104)]

You now print the results:

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L106-L107)]

### Retrieve a single entity

To retrieve a single, specific entity, use `GetEntityAsync` to specify the customer "Ben Smith". Instead of a collection, you get back a `Customer`. Specifying both the partition key and the row key in a query is the fastest way to retrieve a single entity from the Table service.

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L113)]

You now print the results:

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L116)]

### Update an entity

To update an entity, retrieve it from the Table service, modify the entity object, and then save the changes back to the Table service using a `TableUpdateMode.Replace` operation. This causes the entity to be fully replaced on the server, unless the entity on the server has changed since it was retrieved, in which case the operation fails. This failure is to prevent your application from inadvertently overwriting changes from other sources.

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L122-L127)]

### Upsert an entity

Sometimes, you don't know whether an entity exists in the table. And if it does, the current values stored in it are no longer needed. You can use `UpsertEntity` method to create the entity, or replace it if it exists, regardless of its state.

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L133-L138)]

### Query a subset of entity properties

A table query can retrieve just a few properties from an entity instead of all of them. This technique, called projection, can improve query performance, especially for large entities. Here, you return only email addresses using `Query<T>` and `Select`. Projection is not supported on the local storage emulator, so this code runs only when you're using an account on the Table service.

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L144-L147)]

### Retrieve entities in pages asynchronously

If you are reading a large number of entities, and you want to process them as they are retrieved rather than waiting for them all to return, you can use a segmented query. Here, you return results in pages by using an async workflow so that execution is not blocked while you're waiting for a large set of results to return.

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L153-L158)]

### Delete an entity

You can delete an entity after you have retrieved it. As with updating an entity, this fails if the entity has changed since you retrieved it.

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L164)]

### Delete a table

You can delete a table from a storage account. A table that has been deleted will be unavailable to be re-created for a period of time following the deletion.

[!code-fsharp[TableStorage](../../../samples/snippets/fsharp/azure/table-storage.fsx#L170)]

## Next steps

Now that you've learned the basics of Table storage, follow these links
to learn about more complex storage tasks and the Azure Cosmos DB Table API.

- [Introduction to Azure Cosmos DB Table API](/azure/cosmos-db/table-introduction)
- [Storage Client Library for .NET reference](/dotnet/api/overview/azure/storage)
- [Azure Storage Type Provider](https://fsprojects.github.io/AzureStorageTypeProvider/)
- [Azure Storage Team Blog](/archive/blogs/windowsazurestorage/)
- [Configuring Connection Strings](/azure/storage/common/storage-configure-connection-string)
