---
title: Get started with Azure Queue Storage using F#
description: Azure Queues provide reliable, asynchronous messaging between application components. Cloud messaging enables your application components to scale independently.
author: sylvanc
ms.date: 08/26/2021
ms.custom: "devx-track-fsharp"
---
# Get started with Azure Queue Storage using F\#

Azure Queue Storage provides cloud messaging between application components. In designing applications for scale, application components are often decoupled, so that they can scale independently. Queue storage delivers asynchronous messaging for communication between application components, whether they are running in the cloud, on the desktop, on an on-premises server, or on a mobile device. Queue storage also supports managing asynchronous tasks and building process work flows.

### About this tutorial

This tutorial shows how to write F# code for some common tasks using Azure Queue Storage. Tasks covered include creating and deleting queues and adding, reading, and deleting queue messages.

For a conceptual overview of queue storage, see [the .NET guide for queue storage](/azure/storage/storage-dotnet-how-to-use-queues).

## Prerequisites

To use this guide, you must first [create an Azure storage account](/azure/storage/storage-create-storage-account).
You'll also need your storage access key for this account.

## Create an F\# script and start F\# interactive

The samples in this article can be used in either an F# application or an F# script. To create an F# script, create a file with the `.fsx` extension, for example `queues.fsx`, in your F# development environment.

### How to execute scripts

F# Interactive, `dotnet fsi`, can be launched interactively, or it can be launched from the command line to run a script. The command-line syntax is

```.NET CLI
> dotnet fsi [options] [ script-file [arguments] ]
```

### Add packages in a script

Next, use `#r` `nuget:package name` to install the `Azure.Storage.Queues` package and `open` namespaces.Such as

```fsharp
> #r "nuget: Azure.Storage.Queues"
open Azure.Storage.Queues
```

### Add namespace declarations

Add the following `open` statements to the top of the `queues.fsx` file:

[!code-fsharp[QueueStorage](../../../samples/snippets/fsharp/azure/queue-storage.fsx#L1-L3)]

### Get your connection string

You'll need an Azure Storage connection string for this tutorial. For more information about connection strings, see [Configure Storage Connection Strings](/azure/storage/storage-configure-connection-string).

For the tutorial, you'll enter your connection string in your script, like this:

[!code-fsharp[QueueStorage](../../../samples/snippets/fsharp/azure/queue-storage.fsx#L9-L9)]

### Create the queue service client

The `QueueClient` class enables you to retrieve queues stored in Queue storage. Here's one way to create the client:

[!code-fsharp[QueueStorage](../../../samples/snippets/fsharp/azure/queue-storage.fsx#L15-L15)]

Now you are ready to write code that reads data from and writes data to Queue storage.

## Create a queue

This example shows how to create a queue if it doesn't already exist:

[!code-fsharp[QueueStorage](../../../samples/snippets/fsharp/azure/queue-storage.fsx#L21-L21)]

## Insert a message into a queue

To insert a message into an existing queue, first create a new
Message. Next, call the `SendMessage` method. A
Message can be created from either a string (in UTF-8
format) or a `byte` array, like this:

[!code-fsharp[QueueStorage](../../../samples/snippets/fsharp/azure/queue-storage.fsx#L27-L28)]

## Peek at the next message

You can peek at the message in the front of a queue, without removing it
from the queue, by calling the `PeekMessage` method.

[!code-fsharp[QueueStorage](../../../samples/snippets/fsharp/azure/queue-storage.fsx#L34-L35)]

## Get the next message for processing

You can retrieve the message at the front of a queue for processing by calling the `ReceiveMessage` method.

[!code-fsharp[QueueStorage](../../../samples/snippets/fsharp/azure/queue-storage.fsx#L41-L41)]

You later indicate successful processing of the message by using `DeleteMessage`.

## Change the contents of a queued message

You can change the contents of a retrieved message in-place in the queue. If the
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

[!code-fsharp[QueueStorage](../../../samples/snippets/fsharp/azure/queue-storage.fsx#L47-L51)]

## De-queue the next message

Your code de-queues a message from a queue in two steps. When you call
`ReceiveMessage`, you get the next message in a queue. A message returned
from `ReceiveMessage` becomes invisible to any other code reading messages
from this queue. By default, this message stays invisible for 30
seconds. To finish removing the message from the queue, you must also
call `DeleteMessage`. This two-step process of removing a message
assures that if your code fails to process a message due to hardware or
software failure, another instance of your code can get the same message
and try again. Your code calls `DeleteMessage` right after the message
has been processed.
All of the Queue methods we've shown so far have `Async` alternatives.

[!code-fsharp[QueueStorage](../../../samples/snippets/fsharp/azure/queue-storage.fsx#L57-L58)]

## Use Async workflows with common Queue storage APIs

This example shows how to use an async workflow with common Queue storage APIs.

[!code-fsharp[QueueStorage](../../../samples/snippets/fsharp/azure/queue-storage.fsx#L64-L73)]

## Additional options for de-queuing messages

There are two ways you can customize message retrieval from a queue.
First, you can get a batch of messages (up to 32). Second, you can set a
longer or shorter invisibility timeout, allowing your code more or less
time to fully process each message. The following code example uses
`ReceiveMessages` to get 20 messages in one call and then processes
each message. It also sets the invisibility timeout to five minutes for
each message. The 5 minutes starts for all messages at the same
time, so after 5 minutes have passed since the call to `ReceiveMessages`, any
messages that have not been deleted will become visible again.

[!code-fsharp[QueueStorage](../../../samples/snippets/fsharp/azure/queue-storage.fsx#L79-L81)]

## Get the queue length

You can get an estimate of the number of messages in a queue. The `GetProperties` method asks the Queue service to retrieve the queue attributes, including the message count. The `ApproximateMessagesCount` property returns the last value retrieved by the `GetProperties` method.

[!code-fsharp[QueueStorage](../../../samples/snippets/fsharp/azure/queue-storage.fsx#L87-L88)]

## Delete a queue

To delete a queue and all the messages contained in it, call the
`Delete` method on the queue object.

[!code-fsharp[QueueStorage](../../../samples/snippets/fsharp/azure/queue-storage.fsx#L94-L94)]

## Note

If you're migrating from the old libraries, they Base64-encoded messages by default, but the new libraries don't because it's more performant. For information on how to set up encoding, see <xref:Azure.Storage.Queues.QueueClientOptions.MessageEncoding>.

## Next steps

Now that you've learned the basics of Queue storage, follow these links to learn about more complex storage tasks.

- [Azure Storage APIs for .NET](/dotnet/api/overview/azure/storage)
- [Azure Storage Type Provider](https://github.com/fsprojects/AzureStorageTypeProvider)
- [Azure Storage Team Blog](/archive/blogs/windowsazurestorage/)
- [Configure Azure Storage connection strings](/azure/storage/common/storage-configure-connection-string)
- [Azure Storage Services REST API Reference](/rest/api/storageservices/Azure-Storage-Services-REST-API-Reference)
