---
title: Get started with Azure Blob storage using F#
description: Store unstructured data in the cloud with Azure Blob storage.
keywords: visual f#, f#, functional programming, .NET, .NET Core, Azure
author: sylvanc
ms.author: phcart
ms.date: 09/20/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: c5b74a4f-dcd1-4849-930c-904b6c8a04e1
---

# Get started with Azure Blob storage using F# #

Azure Blob storage is a service that stores unstructured data in the cloud as objects/blobs. Blob storage can store any type of text or binary data, such as a document, media file, or application installer. Blob storage is also referred to as object storage.

This article shows you how to perform common tasks using Blob storage. The samples are written using F# using the Azure Storage Client Library for .NET. The tasks covered include how to upload, list, download, and delete blobs.

For a conceptual overview of blob storage, see [the .NET guide for blob storage](/azure/storage/storage-dotnet-how-to-use-blobs).

## Prerequisites

To use this guide, you must first [create an Azure storage account](/azure/storage/storage-create-storage-account). You also need your storage access key for this account.

## Create an F# Script and Start F# Interactive

The samples in this article can be used in either an F# application or an F# script. To create an F# script, create a file with the `.fsx` extension, for example `blobs.fsx`, in your F# development environment.

Next, use a [package manager](package-management.md) such as [Paket](https://fsprojects.github.io/Paket/) or [NuGet](https://www.nuget.org/) to install the `WindowsAzure.Storage` and `Microsoft.WindowsAzure.ConfigurationManager` packages and reference `WindowsAzure.Storage.dll` and `Microsoft.WindowsAzure.Configuration.dll` in your script using a `#r` directive.

### Add namespace declarations

Add the following `open` statements to the top of the `blobs.fsx` file:

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L1-L5)]

### Get your connection string

You need an Azure Storage connection string for this tutorial. For more information about connection strings, see [Configure Storage Connection Strings](/azure/storage/storage-configure-connection-string).

For the tutorial, you enter your connection string in your script, like this:

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L11-L11)]

However, this is **not recommended** for real projects. Your storage account key is similar to the root password for your storage account. Always be careful to protect your storage account key. Avoid distributing it to other users, hard-coding it, or saving it in a plain-text file that is accessible to others. You can regenerate your key using the Azure Portal if you believe it may have been compromised.

For real applications, the best way to maintain your storage connection string is in a configuration file. To fetch the connection string from a configuration file, you can do this:

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L13-L15)]

Using Azure Configuration Manager is optional. You can also use an API such as the .NET Framework's `ConfigurationManager` type.

### Parse the connection string

To parse the connection string, use:

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L21-L22)]

This returns a `CloudStorageAccount`.

### Create some local dummy data

Before you begin, create some dummy local data in the directory of our script. Later you upload this data.

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L28-L30)]

### Create the Blob service client

The `CloudBlobClient` type enables you to retrieve containers and blobs stored in Blob storage. Here's one way to create the service client:

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L36-L36)]

Now you are ready to write code that reads data from and writes data to Blob storage.

## Create a container

This example shows how to create a container if it does not already exist:

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L42-L46)]

By default, the new container is private, meaning that you must specify your storage access key to download blobs from this container. If you want to make the files within the container available to everyone, you can set the container to be public using the following code:

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L48-L49)]

Anyone on the Internet can see blobs in a public container, but you can modify or delete them only if you have the appropriate account access key or a shared access signature.

## Upload a blob into a container

Azure Blob Storage supports block blobs and page blobs. In most cases, a block blob is the recommended type to use.

To upload a file to a block blob, get a container reference and use it to get a block blob reference. Once you have a blob reference, you can upload any stream of data to it by calling the `UploadFromFile` method. This operation creates the blob if it didn't previously exist, or overwrite it if it does exist.

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L55-L59)]

## List the blobs in a container

To list the blobs in a container, first get a container reference. You can then use the container's `ListBlobs` method to retrieve the blobs and/or directories within it. To access the rich set of properties and methods for a returned `IListBlobItem`, you must cast it to a `CloudBlockBlob`, `CloudPageBlob`, or `CloudBlobDirectory` object. If the type is unknown, you can use a type check to determine which to cast it to. The following code demonstrates how to retrieve and output the URI of each item in the `mydata` container:

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L67-L80)]

You can also name blobs with path information in their names. This creates a virtual directory structure that you can organize and traverse as you would a traditional file system. Note that the directory structure is virtual only - the only resources available in Blob storage are containers and blobs. However, the storage client library offers a `CloudBlobDirectory` object to refer to a virtual directory and simplify the process of working with blobs that are organized in this way.

For example, consider the following set of block blobs in a container named `photos`:

*photo1.jpg*
*2015/architecture/description.txt*
*2015/architecture/photo3.jpg*
*2015/architecture/photo4.jpg*
*2016/architecture/photo5.jpg*
*2016/architecture/photo6.jpg*
*2016/architecture/description.txt*
*2016/photo7.jpg*

When you call `ListBlobs` on a container (as in the above sample), a hierarchical listing is returned. If it contains both `CloudBlobDirectory` and `CloudBlockBlob` objects, representing the directories and blobs in the container, respectively, then the resulting output looks similar to this:

```console
Directory: https://<accountname>.blob.core.windows.net/photos/2015/
Directory: https://<accountname>.blob.core.windows.net/photos/2016/
Block blob of length 505623: https://<accountname>.blob.core.windows.net/photos/photo1.jpg
```

Optionally, you can set the `UseFlatBlobListing` parameter of the `ListBlobs` method to `true`. In this case, every blob in the container is returned as a `CloudBlockBlob` object. The call to `ListBlobs` to return a flat listing looks like this:

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L82-L89)]

and, depending on the current contents of your container, the results look like this:

```console
Block blob of length 4: https://<accountname>.blob.core.windows.net/photos/2015/architecture/description.txt
Block blob of length 314618: https://<accountname>.blob.core.windows.net/photos/2015/architecture/photo3.jpg
Block blob of length 522713: https://<accountname>.blob.core.windows.net/photos/2015/architecture/photo4.jpg
Block blob of length 4: https://<accountname>.blob.core.windows.net/photos/2016/architecture/description.txt
Block blob of length 419048: https://<accountname>.blob.core.windows.net/photos/2016/architecture/photo5.jpg
Block blob of length 506388: https://<accountname>.blob.core.windows.net/photos/2016/architecture/photo6.jpg
Block blob of length 399751: https://<accountname>.blob.core.windows.net/photos/2016/photo7.jpg
Block blob of length 505623: https://<accountname>.blob.core.windows.net/photos/photo1.jpg
```

## Download blobs

To download blobs, first retrieve a blob reference and then call the `DownloadToStream` method. The following example uses the `DownloadToStream` method to transfer the blob contents to a stream object that you can then persist to a local file.

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L95-L101)]

You can also use the `DownloadToStream` method to download the contents of a blob as a text string.

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L103-L106)]

## Delete blobs

To delete a blob, first get a blob reference and then call the
`Delete` method on it.

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L112-L116)]

## List blobs in pages asynchronously

If you are listing a large number of blobs, or you want to control the number of results you return in one listing operation, you can list blobs in pages of results. This example shows how to return results in pages asynchronously, so that execution is not blocked while waiting to return a large set of results.

This example shows a flat blob listing, but you can also perform a hierarchical listing, by setting the `useFlatBlobListing` parameter of the `ListBlobsSegmentedAsync` method to `false`.

The sample defines an asynchronous method, using an `async` block. The ``let!`` keyword suspends execution of the sample method until the listing task completes.

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L122-L160)]

We can now use this asynchronous routine as follows. First you upload some dummy data (using the local
file created earlier in this tutorial).

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L162-L166)]

Now, call the routine. You use ``Async.RunSynchronously`` to force the execution of the asynchronous operation.

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L168-L168)]

## Writing to an append blob

An append blob is optimized for append operations, such as logging. Like a block blob, an append blob is comprised of blocks, but when you add a new block to an append blob, it is always appended to the end of the blob. You cannot update or delete an existing block in an append blob. The block IDs for an append blob are not exposed as they are for a block blob.

Each block in an append blob can be a different size, up to a maximum of 4 MB, and an append blob can include a maximum of 50,000 blocks. The maximum size of an append blob is therefore slightly more than 195 GB (4 MB X 50,000 blocks).

The following example creates a new append blob and appends some data to it, simulating a simple logging operation.

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L174-L203)]

See [Understanding Block Blobs, Page Blobs, and Append Blobs](https://msdn.microsoft.com/library/azure/ee691964.aspx) for more information about the differences between the three types of blobs.

## Concurrent access

To support concurrent access to a blob from multiple clients or multiple process instances, you can use **ETags** or **leases**.

* **Etag** - provides a way to detect that the blob or container has been modified by another process

* **Lease** - provides a way to obtain exclusive, renewable, write or delete access to a blob for a period of time

For more information, see [Managing Concurrency in Microsoft Azure Storage](https://azure.microsoft.com/blog/managing-concurrency-in-microsoft-azure-storage-2/).

## Naming containers

Every blob in Azure storage must reside in a container. The container forms part of the blob name. For example, `mydata` is the name of the container in these sample blob URIs:

	https://storagesample.blob.core.windows.net/mydata/blob1.txt
	https://storagesample.blob.core.windows.net/mydata/photos/myphoto.jpg

A container name must be a valid DNS name, conforming to the following naming rules:

1. Container names must start with a letter or number, and can contain only letters, numbers, and the dash (-) character.
1. Every dash (-) character must be immediately preceded and followed by a letter or number; consecutive dashes are not permitted in container names.
1. All letters in a container name must be lowercase.
1. Container names must be from 3 through 63 characters long.

Note that the name of a container must always be lowercase. If you include an upper-case letter in a container name, or otherwise violate the container naming rules, you may receive a 400 error (Bad Request).

## Managing security for blobs

By default, Azure Storage keeps your data secure by limiting access to the account owner, who is in possession of the account access keys. When you need to share blob data in your storage account, it is important to do so without compromising the security of your account access keys. Additionally, you can encrypt blob data to ensure that it is secure going over the wire and in Azure Storage.

### Controlling access to blob data

By default, the blob data in your storage account is accessible only to storage account owner. Authenticating requests against Blob storage requires the account access key by default. However, you might want to make certain blob data available to other users.

For details on how to control access to blob storage, see [the .NET guide for blob storage section on access control](/azure/storage/storage-dotnet-how-to-use-blobs#controlling-access-to-blob-data).


### Encrypting blob data

Azure Storage supports encrypting blob data both at the client and on the server.

For details on encrypting blob data, see [the .NET guide for blob storage section on encryption](/azure/storage/storage-dotnet-how-to-use-blobs#encrypting-blob-data).

## Next steps

Now that you've learned the basics of Blob storage, follow these links to learn more.

### Tools
- [F# AzureStorageTypeProvider](https://fsprojects.github.io/AzureStorageTypeProvider/) An F# Type Provider which can be used to explore Blob, Table and Queue Azure Storage assets and easily apply CRUD operations on them.
- [FSharp.Azure.Storage](https://github.com/fsprojects/FSharp.Azure.Storage) An F# API for using Microsoft Azure Table Storage service
- [Microsoft Azure Storage Explorer (MASE)](/azure/vs-azure-tools-storage-manage-with-storage-explorer) is a free, standalone app from Microsoft that enables you to work visually with Azure Storage data on Windows, OS X, and Linux.

### Blob storage reference

- [Azure Storage APIs for .NET](/dotnet/api/overview/azure/storage)
- [Azure Storage Services REST API Reference](/rest/api/storageservices/Azure-Storage-Services-REST-API-Reference)

### Related guides

- [Getting Started with Azure Blob Storage in C#](https://azure.microsoft.com/resources/samples/storage-blob-dotnet-getting-started/)
- [Transfer data with the AzCopy command-line utility on Windows](/azure/storage/common/storage-use-azcopy)
- [Transfer data with the AzCopy command-line utility on Linux](/azure/storage/common/storage-use-azcopy-linux)
- [Configure Azure Storage connection strings](/azure/storage/common/storage-configure-connection-string)
- [Azure Storage Team Blog](https://blogs.msdn.microsoft.com/windowsazurestorage/)
