---
title: Get started with Azure Queue storage using F# 
description: Azure Queues provide reliable, asynchronous messaging between application components. Cloud messaging enables your application components to scale independently.
keywords: visual f#, f#, functional programming, .NET, .NET Core, Azure
author: syclebsc
manager: jbronsk
ms.date: 09/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 70dc554c-8f4d-42a7-8e2a-6438657d012a
---

# Get started with Azure Queue storage using F#

Azure Queue storage provides cloud messaging between application components. In designing applications for scale, application components are often decoupled, so that they can scale independently. Queue storage delivers asynchronous messaging for communication between application components, whether they are running in the cloud, on the desktop, on an on-premises server, or on a mobile device. Queue storage also supports managing asynchronous tasks and building process work flows.

### About this tutorial

This tutorial shows how to write F# code for some common tasks using Azure Queue storage. Tasks covered include creating and deleting queues and adding, reading, and deleting queue messages.

### Conceptual overview

For a conceptual overview of queue storage, please see [the .NET guide for queue storage](https://azure.microsoft.com/en-us/documentation/articles/storage-dotnet-how-to-use-queues/).

### Create an Azure storage account

To use this guide, you must first [create an Azure storage account](https://azure.microsoft.com/en-us/documentation/articles/storage-create-storage-account/).
You'll also need your storage access key for this account.

## Create an F# Script and Start F# Interactive

The samples in this article can be used in either an F# application or an F# script. To create an F# script, create a file with the `.fsx` extension, for example `queues.fsx`, in your F# development environment.

Next, use a [package manager](package-management.md) such as Paket or NuGet to install the `WindowsAzure.Storage` package and reference `WindowsAzure.Storage.dll` in your script using a `#r` directive.

### Add namespace declarations

Add the following `open` statements to the top of the `queues.fsx` file:

    open Microsoft.Azure // Namespace for CloudConfigurationManager 
    open Microsoft.WindowsAzure.Storage // Namespace for CloudStorageAccount
    open Microsoft.WindowsAzure.Storage.Queue // Namespace for Queue storage types

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

### Create the Queue service client

The `CloudQueueClient` class enables you to retrieve queues stored in Queue storage. Here's one way to create the service client:

    let queueClient = storageAccount.CreateCloudQueueClient()

Now you are ready to write code that reads data from and writes data to Queue storage.

## Create a queue

This example shows how to create a queue if it doesn't already exist:

    // Retrieve a reference to a container.
    let queue = queueClient.GetQueueReference("myqueue")

    // Create the queue if it doesn't already exist
    queue.CreateIfNotExists()

## Insert a message into a queue

To insert a message into an existing queue, first create a new
`CloudQueueMessage`. Next, call the `AddMessage` method. A
`CloudQueueMessage` can be created from either a string (in UTF-8
format) or a `byte` array, like this:

    // Create a message and add it to the queue.
    let message = new CloudQueueMessage("Hello, World")
    queue.AddMessage(message);

## Peek at the next message

You can peek at the message in the front of a queue, without removing it
from the queue, by calling the `PeekMessage` method.

    // Peek at the next message.
    let peekedMessage = queue.PeekMessage()
    let msgAsString = peekedMessage.AsString

## Change the contents of a queued message

You can change the contents of a message in-place in the queue. If the
message represents a work task, you could use this feature to update the
status of the work task. The following code updates the queue message
with new contents, and sets the visibility timeout to extend another 60
seconds. This saves the state of work associated with the message, and
gives the client another minute to continue working on the message. You
could use this technique to track multi-step workflows on queue
messages, without having to start over from the beginning if a
processing step fails due to hardware or software failure. Typically,
you would keep a retry count as well, and if the message is retried more
than some number of times, you would delete it. This protects against a message
that triggers an application error each time it is processed.

  	// Update the message contents and set a new timeout.
    message.SetMessageContent("Updated contents.")
    queue.UpdateMessage(message,
        TimeSpan.FromSeconds(60.0),
        MessageUpdateFields.Content ||| MessageUpdateFields.Visibility)

## De-queue the next message

Your code de-queues a message from a queue in two steps. When you call
`GetMessage`, you get the next message in a queue. A message returned
from `GetMessage` becomes invisible to any other code reading messages
from this queue. By default, this message stays invisible for 30
seconds. To finish removing the message from the queue, you must also
call `DeleteMessage`. This two-step process of removing a message
assures that if your code fails to process a message due to hardware or
software failure, another instance of your code can get the same message
and try again. Your code calls `DeleteMessage` right after the message
has been processed.

    // Process the message in less than 30 seconds, and then delete the message.
    queue.DeleteMessage(message)

## Use Async-Await pattern with common Queue storage APIs

This example shows how to use an async workflow with common Queue storage APIs.

    async {
        let! exists = queue.CreateIfNotExistsAsync() |> Async.AwaitTask
        let msg = new CloudQueueMessage("My message")
        queue.AddMessageAsync(msg) |> Async.AwaitTask
        let! retrieved = queue.GetMessageAsync() |> Async.AwaitTask
        queue.DeleteMessageAsync(retrieved) |> Async.AwaitTask
    }

## Additional options for de-queuing messages

There are two ways you can customize message retrieval from a queue.
First, you can get a batch of messages (up to 32). Second, you can set a
longer or shorter invisibility timeout, allowing your code more or less
time to fully process each message. The following code example uses
`GetMessages` to get 20 messages in one call and then processes
each message. It also sets the invisibility timeout to five minutes for
each message. Note that the 5 minutes starts for all messages at the same
time, so after 5 minutes have passed since the call to `GetMessages`, any 
messages which have not been deleted will become visible again.

    for msg in queue.GetMessages(20, Nullable(TimeSpan.FromMinutes(5.))) do
        // Process the message here.
        queue.DeleteMessage(msg)

## Get the queue length

You can get an estimate of the number of messages in a queue. The `FetchAttributes` method asks the Queue service to retrieve the queue attributes, including the message count. The `ApproximateMessageCount` property returns the last value retrieved by the `FetchAttributes` method, without calling the Queue service.

    queue.FetchAttributes()
    let count = queue.ApproximateMessageCount.GetValueOrDefault()

## Delete a queue

To delete a queue and all the messages contained in it, call the
`Delete` method on the queue object.

    // Delete the queue.
    queue.Delete()

## Next steps

Now that you've learned the basics of Queue storage, follow these links
to learn about more complex storage tasks.

- [Storage Client Library for .NET reference](http://go.microsoft.com/fwlink/?LinkID=390731&clcid=0x409)
- [Azure Storage Team Blog](http://blogs.msdn.com/b/windowsazurestorage/)
- [Configuring Connection Strings](http://msdn.microsoft.com/library/azure/ee758697.aspx)
- [.NET client library reference](http://go.microsoft.com/fwlink/?LinkID=390731&clcid=0x409)
- [REST API reference](http://msdn.microsoft.com/library/azure/dd179355)
