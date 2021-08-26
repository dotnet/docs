---
title: Get started with Azure Blob Storage using F#
description: Store unstructured data in the cloud with Azure Blob Storage.
author: sylvanc
ms.date: 08/26/2021
ms.custom: "devx-track-fsharp"
---
# Get started with Azure Blob Storage using F\#

Azure Blob Storage is a service that stores unstructured data in the cloud as objects/blobs. Blob storage can store any type of text or binary data, such as a document, media file, or application installer. Blob storage is also referred to as object storage.

This article shows you how to perform common tasks using Blob storage. The samples are written using F# using the Azure Storage Client Library for .NET. The tasks covered include how to upload, list, download, and delete blobs.

For a conceptual overview of blob storage, see [the .NET guide for blob storage](/azure/storage/blobs/storage-quickstart-blobs-dotnet).

## Prerequisites

To use this guide, you must first [create an Azure storage account](/azure/storage/common/storage-account-create). You also need your storage access key for this account.

## Create an F\# script and start F\# interactive

The samples in this article can be used in either an F# application or an F# script. To create an F# script, create a file with the `.fsx` extension, for example `blobs.fsx`, in your F# development environment.

### How to execute scripts

F# Interactive, `dotnet fsi`, can be launched interactively, or it can be launched from the command line to run a script. The command-line syntax is

```.NET CLI
> dotnet fsi [options] [ script-file [arguments] ]
```

### Add packages in a script

Next, use `#r` `nuget:package name` to install the `Azure.Storage.Blobs` package and `open` namespaces.Such as

```fsharp
> #r "nuget: Azure.Storage.Blobs"
open Azure.Storage.Blobs
open Azure.Storage.Blobs.Models
open Azure.Storage.Blobs.Specialized
```

### Add namespace declarations

Add the following `open` statements to the top of the `blobs.fsx` file:

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L1-L6)]

### Get your connection string

You need an Azure Storage connection string for this tutorial. For more information about connection strings, see [Configure Storage Connection Strings](/azure/storage/storage-configure-connection-string).

For the tutorial, you enter your connection string in your script, like this:

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L18-L18)]

### Create some local dummy data

Before you begin, create some dummy local data in the directory of our script. Later you upload this data.

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L24-L26)]

### Create the blob service client

The `BlobContainerClient` type enables you to create containers and retrieve blobs stored in Blob storage. Here's one way to create the container client:

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L33-L33)]

Now you are ready to write code that reads data from and writes data to Blob storage.

## Create a container

This example shows how to create a container if it does not already exist:

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L36-L36)]

By default, the new container is private, meaning that you must specify your storage access key to download blobs from this container. If you want to make the files within the container available to everyone, you can set the container to be public using the following code:

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L38-L39)]

Anyone on the Internet can see blobs in a public container, but you can modify or delete them only if you have the appropriate account access key or a shared access signature.

## Upload a blob into a container

Azure Blob Storage supports block blobs and page blobs. In most cases, a block blob is the recommended type to use.

To upload a file to a block blob, get a container client and use it to get a block blob reference. Once you have a blob reference, you can upload any stream of data to it by calling the `Upload` method. This operation overwrites the contents of the blob, creating a new block blob if none exists.

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L45-L50)]

## List the blobs in a container

To list the blobs in a container, first get a container reference. You can then use the container's `GetBlobs` method to retrieve the blobs and/or directories within it. To access the rich set of properties and methods for a returned `BlobItem`.

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L57-L58)]

For example, consider the following set of block blobs in a container named `photos`:

*photo1.jpg*\
*2015/architecture/description.txt*\
*2015/architecture/photo3.jpg*\
*2015/architecture/photo4.jpg*\
*2016/architecture/photo5.jpg*\
*2016/architecture/photo6.jpg*\
*2016/architecture/description.txt*\
*2016/photo7.jpg*\

When you call `GetBlobsByHierarchy` on a container (as in the above sample), a hierarchical listing is returned.

```console
Directory: https://<accountname>.blob.core.windows.net/photos/2015/
Directory: https://<accountname>.blob.core.windows.net/photos/2016/
Block blob of length 505623: https://<accountname>.blob.core.windows.net/photos/photo1.jpg
```

## Download blobs

To download blobs, first retrieve a blob reference and then call the `DownloadTo` method. The following example uses the `DownloadTo` method to transfer the blob contents to a stream object that you can then persist to a local file.

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L64-L70)]

You can also use the `DownloadContent` method to download the contents of a blob as a text string.

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L72-L72)]

## Delete blobs

To delete a blob, first get a blob reference and then call the
`Delete` method on it.

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L78-L82)]

## List blobs in pages asynchronously

If you are listing a large number of blobs, or you want to control the number of results you return in one listing operation, you can list blobs in pages of results. This example shows how to return results in pages.

This example shows a hierarchical listing, by using the `GetBlobsByHierarchy` method of the `BlobClient` .

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L88-L100)]

We can now use this hierarchical listing routine as follows. First, upload some dummy data (using the local
file created earlier in this tutorial).

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L104-L107)]

Now, call the routine.

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L109-L109)]

## Writing to an append blob

An append blob is optimized for append operations, such as logging. Like a block blob, an append blob is composed of blocks, but when you add a new block to an append blob, it is always appended to the end of the blob. You cannot update or delete an existing block in an append blob. The block IDs for an append blob are not exposed as they are for a block blob.

Each block in an append blob can be a different size, up to a maximum of 4 MB, and an append blob can include a maximum of 50,000 blocks. The maximum size of an append blob is therefore slightly more than 195 GB (4 MB X 50,000 blocks).

The following example creates a new append blob and appends some data to it, simulating a simple logging operation.

[!code-fsharp[BlobStorage](../../../samples/snippets/fsharp/azure/blob-storage.fsx#L115-L146)]

See [Understanding Block Blobs, Page Blobs, and Append Blobs](/rest/api/storageservices/Understanding-Block-Blobs--Append-Blobs--and-Page-Blobs) for more information about the differences between the three types of blobs.

## Concurrent access

To support concurrent access to a blob from multiple clients or multiple process instances, you can use **ETags** or **leases**.

- **Etag** - provides a way to detect that the blob or container has been modified by another process

- **Lease** - provides a way to obtain exclusive, renewable, write, or delete access to a blob for a period of time

For more information, see [Managing Concurrency in Microsoft Azure Storage](https://azure.microsoft.com/blog/managing-concurrency-in-microsoft-azure-storage-2/).

## Naming containers

Every blob in Azure storage must reside in a container. The container forms part of the blob name. For example, `mydata` is the name of the container in these sample blob URIs:

- `https://storagesample.blob.core.windows.net/mydata/blob1.txt`
- `https://storagesample.blob.core.windows.net/mydata/photos/myphoto.jpg`

A container name must be a valid DNS name, conforming to the following naming rules:

1. Container names must start with a letter or number, and can contain only letters, numbers, and the dash (-) character.
1. Every dash (-) character must be immediately preceded and followed by a letter or number; consecutive dashes are not permitted in container names.
1. All letters in a container name must be lowercase.
1. Container names must be from 3 through 63 characters long.

The name of a container must always be lowercase. If you include an upper-case letter in a container name, or otherwise violate the container naming rules, you may receive a 400 error (Bad Request).

## Managing security for blobs

By default, Azure Storage keeps your data secure by limiting access to the account owner, who is in possession of the account access keys. When you need to share blob data in your storage account, it is important to do so without compromising the security of your account access keys. Additionally, you can encrypt blob data to ensure that it is secure going over the wire and in Azure Storage.

### Controlling access to blob data

By default, the blob data in your storage account is accessible only to storage account owner. Authenticating requests against Blob storage requires the account access key by default. However, you might want to make certain blob data available to other users.

### Encrypting blob data

Azure Storage supports encrypting blob data both at the client and on the server.

## Next steps

Now that you've learned the basics of Blob storage, follow these links to learn more.

### Tools

- [F# AzureStorageTypeProvider](https://fsprojects.github.io/AzureStorageTypeProvider/)\
An F# Type Provider that can be used to explore Blob, Table, and Queue Azure Storage assets and easily apply CRUD operations on them.

- [FSharp.Azure.Storage](https://github.com/fsprojects/FSharp.Azure.Storage)\
An F# API for using Microsoft Azure Table Storage service

- [Microsoft Azure Storage Explorer (MASE)](/azure/vs-azure-tools-storage-manage-with-storage-explorer)\
A free, standalone app from Microsoft that enables you to work visually with Azure Storage data on Windows, OS X, and Linux.

### Blob storage reference

- [Azure Storage APIs for .NET](/dotnet/api/overview/azure/storage)
- [Azure Storage Services REST API Reference](/rest/api/storageservices/)

### Related guides

- [Azure Blob Storage Samples for .NET](/samples/azure-samples/storage-blob-dotnet-getting-started/storage-blob-dotnet-getting-started/)
- [Get started with AzCopy](/azure/storage/common/storage-use-azcopy-v10)
- [Configure Azure Storage connection strings](/azure/storage/common/storage-configure-connection-string)
- [Azure Storage Team Blog](/archive/blogs/windowsazurestorage/)
- [Quickstart: Use .NET to create a blob in object storage](/azure/storage/blobs/storage-quickstart-blobs-dotnet)
