---
title: Get started with Azure File Storage using F#
description: Store file data in the cloud with Azure File Storage, and mount your cloud file share from an Azure virtual machine (VM) or from an on-premises application running Windows.
author: sylvanc
ms.date: 09/20/2016
ms.custom: "devx-track-fsharp"
---
# Get started with Azure File Storage using F\#

Azure File Storage is a service that offers file shares in the cloud using the standard [Server Message Block (SMB) Protocol](/windows/win32/fileio/microsoft-smb-protocol-and-cifs-protocol-overview). Both SMB 2.1 and SMB 3.0 are supported. With Azure File Storage, you can migrate legacy applications that rely on file shares to Azure quickly and without costly rewrites. Applications running in Azure virtual machines or cloud services or from on-premises clients can mount a file share in the cloud, just as a desktop application mounts a typical SMB share. Any number of application components can then mount and access the File storage share simultaneously.

For a conceptual overview of file storage, see [the .NET guide for file storage](/azure/storage/storage-dotnet-how-to-use-files).

## Prerequisites

To use this guide, you must first [create an Azure storage account](/azure/storage/storage-create-storage-account).
You'll also need your storage access key for this account.

## Create an F# Script and Start F# Interactive

The samples in this article can be used in either an F# application or an F# script. To create an F# script, create a file with the `.fsx` extension, for example `files.fsx`, in your F# development environment.

Next, use a [package manager](package-management.md) such as [Paket](https://fsprojects.github.io/Paket/) or [NuGet](https://www.nuget.org/) to install the `WindowsAzure.Storage` package and reference `WindowsAzure.Storage.dll` in your script using a `#r` directive.

### Add namespace declarations

Add the following `open` statements to the top of the `files.fsx` file:

[!code-fsharp[FileStorage](../../../samples/snippets/fsharp/azure/file-storage.fsx#L1-L8)]

### Get your connection string

You'll need an Azure Storage connection string for this tutorial. For more information about connection strings, see [Configure Storage Connection Strings](/azure/storage/storage-configure-connection-string).

For the tutorial, you'll enter your connection string in your script, like this:

[!code-fsharp[FileStorage](../../../samples/snippets/fsharp/azure/file-storage.fsx#L14-L14)]

However, this is **not recommended** for real projects. Your storage account key is similar to the root password for your storage account. Always be careful to protect your storage account key. Avoid distributing it to other users, hard-coding it, or saving it in a plain-text file that is accessible to others. You can regenerate your key using the Azure portal if you believe it may have been compromised.

For real applications, the best way to maintain your storage connection string is in a configuration file. To fetch the connection string from a configuration file, you can do this:

[!code-fsharp[FileStorage](../../../samples/snippets/fsharp/azure/file-storage.fsx#L16-L18)]

Using Azure Configuration Manager is optional. You can also use an API such as the .NET Framework's `ConfigurationManager` type.

### Create the File service client

The `ShareClient` type enables you to programmatically use files stored in File storage. Here's one way to create the service client:

[!code-fsharp[FileStorage](../../../samples/snippets/fsharp/azure/file-storage.fsx#L25-L25)]

Now you are ready to write code that reads data from and writes data to File storage.

## Create a file share

This example shows how to create a file share if it does not already exist:

[!code-fsharp[FileStorage](../../../samples/snippets/fsharp/azure/file-storage.fsx#L31-L31)]

## Create a directory

Here, you get the directory. You create if it doesn't already exist.

[!code-fsharp[FileStorage](../../../samples/snippets/fsharp/azure/file-storage.fsx#L37-L41)]

## Upload a file to the sample directory

This example shows how to upload a file to the sample directory.

[!code-fsharp[FileStorage](../../../samples/snippets/fsharp/azure/file-storage.fsx#L47-L52)]

### Download a file to a local file

Here you download the file just created, appending the contents to a local file.

[!code-fsharp[FileStorage](../../../samples/snippets/fsharp/azure/file-storage.fsx#L58-L60)]

### Set the maximum size for a file share

The example below shows how to check the current usage for a share and how to set the quota for the share.

[!code-fsharp[FileStorage](../../../samples/snippets/fsharp/azure/file-storage.fsx#L66-L75)]

### Generate a shared access signature for a file or file share

You can generate a shared access signature (SAS) for a file share or for an individual file. You can also create a shared access policy on a file share to manage shared access signatures. Creating a shared access permissions is recommended, as it provides a means of revoking the SAS if it should be compromised.

Here, you create a shared access permissions on a share, and then set that permissions to provide the constraints for a SAS on a file in the share.

[!code-fsharp[FileStorage](../../../samples/snippets/fsharp/azure/file-storage.fsx#L81-L101)]

For more information about creating and using shared access signatures, see [Using Shared Access Signatures (SAS)](/azure/storage/storage-dotnet-shared-access-signature-part-1) and [Create and use a SAS with Blob storage](/azure/storage/storage-dotnet-shared-access-signature-part-2).

### Copy files

You can copy a file to another file or to a blob, or a blob to a file. If you are copying a blob to a file, or a file to a blob, you *must* use a shared access signature (SAS) to authenticate the source object, even if you are copying within the same storage account.

### Copy a file to another file

Here, you copy a file to another file in the same share. Because this copy operation copies between files in the same storage account, you can use Shared Key authentication to perform the copy.

[!code-fsharp[FileStorage](../../../samples/snippets/fsharp/azure/file-storage.fsx#L106-L108)]

### Copy a file to a blob

Here, you create a file and copy it to a blob within the same storage account. You create a SAS for the source file, which the service uses to authenticate access to the source file during the copy operation.

[!code-fsharp[FileStorage](../../../samples/snippets/fsharp/azure/file-storage.fsx#L114-L131)]

You can copy a blob to a file in the same way. If the source object is a blob, then create a SAS to authenticate access to that blob during the copy operation.

## Troubleshooting File storage using metrics

Azure Storage Analytics supports metrics for File storage. With metrics data, you can trace requests and diagnose issues.

You can enable metrics for File storage from the [Azure portal](https://portal.azure.com), or you can do it from F# like this:

[!code-fsharp[FileStorage](../../../samples/snippets/fsharp/azure/file-storage.fsx#L137-L155)]

## Next steps

For more information about Azure File Storage, see these links.

### Conceptual articles and videos

- [Azure Files Storage: a frictionless cloud SMB file system for Windows and Linux](https://azure.microsoft.com/resources/videos/azurecon-2015-azure-files-storage-a-frictionless-cloud-smb-file-system-for-windows-and-linux/)
- [How to use Azure File Storage with Linux](/azure/storage/storage-how-to-use-files-linux)

### Tooling support for File storage

- [Using Azure PowerShell with Azure Storage](/azure/storage/storage-powershell-guide-full)
- [How to use AzCopy with Microsoft Azure Storage](/azure/storage/storage-use-azcopy)
- [Create, download, and list blobs with Azure CLI](/azure/storage/blobs/storage-quickstart-blobs-cli#create-and-manage-file-shares)

### Reference

- [Storage Client Library for .NET reference](/dotnet/api/overview/azure/storage)
- [File Service REST API reference](/rest/api/storageservices/fileservices/File-Service-REST-API)

### Blog posts

- [Azure File Storage is now generally available](https://azure.microsoft.com/blog/azure-file-storage-now-generally-available/)
- [Inside Azure File Storage](https://azure.microsoft.com/blog/inside-azure-file-storage/)
- [Introducing Microsoft Azure File Service](/archive/blogs/windowsazurestorage/introducing-microsoft-azure-file-service)
- [Persisting connections to Microsoft Azure Files](/archive/blogs/windowsazurestorage/persisting-connections-to-microsoft-azure-files)
