---
title: Get started with Azure Table storage using F#
description: Store structured data in the cloud using Azure Table storage, a NoSQL data store.
keywords: visual f#, f#, functional programming, .NET, .NET Core, Azure
author: syclebsc
manager: jbronsk
ms.date: 09/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 9e5d6cea-a98c-461e-a5cc-75f1d154eafd
---

# Get started with Azure Table storage using F# 

Azure Table storage is a service that stores structured NoSQL data in the cloud. Table storage is a key/attribute store with a schemaless design. Because Table storage is schemaless, it's easy to adapt your data as the needs of your application evolve. Access to data is fast and cost-effective for all kinds of applications. Table storage is typically significantly lower in cost than traditional SQL for similar volumes of data.

You can use Table storage to store flexible datasets, such as user data for web applications, address books, device information, and any other type of metadata that your service requires. You can store any number of entities in a table, and a storage account may contain any number of tables, up to the capacity limit of the storage account.

### About this tutorial

This tutorial shows how to write F# code to do some common tasks using Azure Table storage, including creating and deleting a table and inserting, updating, deleting, and querying table data.

### Conceptual overview

For a conceptual overview of table storage, please see [the .NET guide for table storage](https://azure.microsoft.com/en-us/documentation/articles/storage-dotnet-how-to-use-tables/)

### Create an Azure storage account

To use this guide, you must first [create an Azure storage account](https://azure.microsoft.com/en-us/documentation/articles/storage-create-storage-account/).
You'll also need your storage access key for this account.

## Create an F# Script and Start F# Interactive

The samples in this article can be used in either an F# application or an F# script. To create an F# script, create a file with the `.fsx` extension, for example `tables.fsx`, in your F# development environment.

Next, use a [package manager](package-management.md) such as Paket or NuGet to install the `WindowsAzure.Storage` package and reference `WindowsAzure.Storage.dll` in your script using a `#r` directive.

### Add namespace declarations

Add the following `open` statements to the top of the `blobs.fsx` file:

    open System
    open System.IO
    open Microsoft.Azure // Namespace for CloudConfigurationManager
    open Microsoft.WindowsAzure.Storage // Namespace for CloudStorageAccount
    open Microsoft.WindowsAzure.Storage.Table // Namespace for Table storage types

### Get your connection string

You'll need an Azure Storage connection string for this tutorial. For more information about connection strings, see [Configure Storage Connection Strings](https://azure.microsoft.com/en-us/documentation/articles/storage-configure-connection-string/).

For the tutorial, you'll enter your connection string in your script, like this:

    let storageConnString = "..." // fill this in from your storage account

However, this is a **bad idea** for real projects. Your storage account key is similar to the root password for your storage account. Always be careful to protect your storage account key. Avoid distributing it to other users, hard-coding it, or saving it in a plain-text file that is accessible to others. You can regenerate your key using the Azure Portal if you believe it may have been compromised.

For real applications, the best way to maintain your storage connection string is in a configuration file. To fetch the connection string from a configuration file, you can do this:

    // Parse the connection string and return a reference to the storage account.
    let storageConnString = 
        CloudConfigurationManager.GetSetting("StorageConnectionString")

Using Azure Configuration Manager is optional. You can also use an API such as the .NET Framework's `ConfigurationManager` type.

### Parse the connection string

To parse the connection string, use:

    // Parse the connection string and return a reference to the storage account.
    let storageAccount = CloudStorageAccount.Parse(storageConnString)

This will return a `CloudStorageAccount`.

### Create the Table service client

The `CloudTableClient` class enables you to retrieve tables and entities stored in Table storage. Here's one way to create the service client:

    // Create the table client.
    let tableClient = storageAccount.CreateCloudTableClient()

Now you are ready to write code that reads data from and writes data to Table storage.

## Create a table

This example shows how to create a table if it does not already exist:

    // Retrieve a reference to the table.
    let table = tableClient.GetTableReference("people")

    // Create the table if it doesn't exist.
    table.CreateIfNotExists()

## Add an entity to a table

An entity has to have a type that inherits from `TableEntity`. You can extend `TableEntity` in any way you like, but your type *must* have a parameter-less constructor. Only properties that have both `get` and `set` will be stored in your Azure Table.

An entity's partition and row key uniquely identify the entity in the table. Entities with the same partition key can be queried faster than those with different partition keys, but using diverse partition keys allows for greater scalability of parallel operations.

Here's an example of a `Customer` that uses the `lastName` as the partition key and the `firstName` as the row key.

    type Customer
        (firstName, lastName, email: string, phone: string) =
        inherit TableEntity(lastName, firstName)
        new() = Customer(null, null, null, null)
        member val Email = email with get, set
        member val PhoneNumber = phone with get, set

    let customer = 
        Customer("Larry", "Buster", "larry@example.com", "425-555-0101")

Now we'll add our `Customer` to the table. To do so, we create a `TableOperation` that we will execute on the table. In this case, we create an `Insert` operation.

    let insertOp = TableOperation.Insert(customer)
    table.Execute(insertOp)

## Insert a batch of entities

You can insert a batch of entities into a table using a single write operation. Batch operations allow you to combine operations into a single execution, but they have some restrictions:

- You can perform updates, deletes, and inserts in the same batch operation.
- A batch operation can include up to 100 entities.
- All entities in a batch operation must have the same partition key.
- While it is possible to perform a query in a batch operation, it must be the only operation in the batch.

Here's some code that combines two inserts into a batch operation:

    let customer2 =
        Customer("Bob", "Boomer", "bob@example.com", "425-555-0102")

    let batchOp = TableBatchOperation()
    batchOp.Insert(customer)
    batchOp.Insert(customer2)
    table.ExecuteBatch(batchOp)

## Retrieve all entities in a partition

To query a table for all entities in a partition, use a `TableQuery` object. Here, we filter for entities where "Buster" is the partition key.

    let query =
        TableQuery<Customer>().Where(
            TableQuery.GenerateFilterCondition(
                "PartitionKey", QueryComparisons.Equal, "Buster"))

    let result = table.ExecuteQuery(query)

## Retrieve a range of entities in a partition

If you don't want to query all the entities in a partition, you can specify a range by combining the partition key filter with a row key filter. Here, we use two filters to get all entities in the "Buster" partition where the row key (first name) starts with a letter earlier than "M" in the alphabet.

    let range =
        TableQuery<Customer>().Where(
            TableQuery.CombineFilters(
                TableQuery.GenerateFilterCondition(
                    "PartitionKey", QueryComparisons.Equal, "Buster"),
                TableOperators.And,
                TableQuery.GenerateFilterCondition(
                    "RowKey", QueryComparisons.LessThan, "M")))

    let rangeResult = table.ExecuteQuery(query)

## Retrieve a single entity

You can write a query to retrieve a single, specific entity. Here, we use a `TableOperation` to specify the customer "Larry Buster". Instead of a collection, we get back a `Customer`. Specifying both the partition key and the row key in a query is the fastest way to retrieve a single entity from the Table service.

    let retrieveOp = TableOperation.Retrieve<Customer>("Buster", "Larry")
    let retrieveResult = table.Execute(retrieveOp)

## Replace an entity

To update an entity, retrieve it from the Table service, modify the entity object, and then save the changes back to the Table service using a `Replace` operation. This causes the entity to be fully replaced on the server, unless the entity on the server has changed since it was retrieved, in which case the operation will fail. This failure is to prevent your application from inadvertently overwriting changes from other sources.

    try
        let customer = retrieveResult.Result :?> Customer
        customer.PhoneNumber <- "425-555-0103"
        let replaceOp = TableOperation.Replace(customer)
        table.Execute(replaceOp) |> ignore
    with e ->
        Console.WriteLine("Update failed")

## Insert-or-replace an entity

Sometimes, you don't know if the entity exists in the table or not. And if it does, the current values stored in it are no longer needed. We can use `InsertOrReplace` to create the entity, or replace it if it exists, regardless of its state.

    try
        customer.PhoneNumber <- "425-555-0104"
        let replaceOp = TableOperation.InsertOrReplace(customer)
        table.Execute(replaceOp) |> ignore
    with e ->
        Console.WriteLine("Update failed")

## Query a subset of entity properties

A table query can retrieve just a few properties from an entity instead of all of them. This technique, called projection, can improve query performance, especially for large entities. Here, we return only email addresses using `DynamicTableEntity` and `EntityResolver`. Note that projection is not supported on the local storage emulator, so this code runs only when you're using an account on the Table service.

    // Define the query, and select only the Email property.
    let projectionQ = TableQuery<DynamicTableEntity>().Select([|"Email"|])

    // Define an entity resolver to work with the entity after retrieval.
    let resolver = EntityResolver<string>(fun pk rk ts props etag ->
        if props.ContainsKey("Email") then
            props.["Email"].StringValue
        else
            null
        )

    table.ExecuteQuery(projectionQ, resolver, null, null)

## Delete an entity

You can delete an entity after you have retrieved it. As with updating an entity, this will fail if the entity has changed since you retrieved it.

    let deleteOp = TableOperation.Delete(customer)
    table.Execute(deleteOp)

## Delete a table

You can delete a table from a storage account. A table that has been deleted will be unavailable to be re-created for a period of time following the deletion.

    table.DeleteIfExists()

## Retrieve entities in pages asynchronously

If you are reading a large number of entities, and you want to process them as they are retrieved rather than waiting for them all to return, you can use a segmented query. Here, we return results in pages by using an async workflow so that execution is not blocked while you're waiting for a large set of results to return.

    let tableQ = TableQuery<Customer>()

    async {
        let rec q (cont: TableContinuationToken) = async {
            let! result = 
                table.ExecuteQuerySegmentedAsync(tableQ, cont) 
                |> Async.AwaitTask

            // Process the result here.
            match result.ContinuationToken with
            | null -> return ()
            | cont -> q cont |> Async.RunSynchronously
        }
        q null |> Async.RunSynchronously
    } |> Async.RunSynchronously

## Next steps

Now that you've learned the basics of Table storage, follow these links
to learn about more complex storage tasks:

- [Storage Client Library for .NET reference](http://go.microsoft.com/fwlink/?LinkID=390731&clcid=0x409)
- [Azure Storage Team Blog](http://blogs.msdn.com/b/windowsazurestorage/)
- [Configuring Connection Strings](http://msdn.microsoft.com/library/azure/ee758697.aspx)
- [REST API reference](http://msdn.microsoft.com/library/azure/dd179355)
- [Getting Started with Azure Table Storage in .NET](https://azure.microsoft.com/documentation/samples/storage-table-dotnet-getting-started/)
