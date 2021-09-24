---
title: Access Azure Blob Storage from .NET applications
description: Learn how to connect your applications to Azure Blob Storage
ms.date: 09/21/2021
ms.topic: article
ms.custom: devx-track-dotnet
ms.author: daberry
ROBOTS: NOINDEX
---

# Access Azure Blob Storage from .NET applications

> [!NOTE]
> This article is experimental and temporary. If you attempt to revisit this page at a later time, it may no longer exist.

Azure Blob Storage can be used by .NET applications to store files in the cloud.  Through the use of the [Azure.Storage.Blobs](https://www.nuget.org/packages/Azure.Storage.Blobs/) NuGet package, .NET applications can upload and download files to blob storage as well as create containers (folders) in blob storage to organize their data.  

The [Azure.Storage.Blobs](https://www.nuget.org/packages/Azure.Storage.Blobs/) package is a [.NET Standard 2.0](/dotnet/standard/net-standard) library that works with both .NET Framework (4.7.2 and later) and .NET Core (2.0 and later) applications.

## Sample application

The sample application for this tutorial may be cloned or downloaded from the repository [https://github.com/Azure-Samples/msdocs-azure-blob-storage-dotnet](https://github.com/Azure-Samples/msdocs-azure-blob-storage-dotnet).  

Both a starter and completed app are included in the sample repository.  After downloading the sample code, open the solution for the starter app in either Visual Studio or VS Code.

```bash
git clone https://github.com/Azure-Samples/msdocs-azure-blob-storage-dotnet
```

When complete, the sample application will allow you to create blob containers, upload blobs to a storage account as well as visualize the relationship between containers and blobs in the storage account.

:::image type="content" source="./media/blobs-and-containers-640.png" alt-text="A screenshot of the sample application for this article showing three blob containers in a storage account.  One of the containers is expanded showing it contains three different blob objects inside" lightbox="./media/blobs-and-containers.png":::

## 1 - Create Azure Storage resources

You first need to create a resource group and storage account in Azure for the sample application to use. This can be done using the Azure portal, Azure CLI, or Azure PowerShell.

### [Azure portal](#tab/azure-portal)

Sign in to the [Azure portal](https://portal.azure.com/) and follow these steps to create a Storage account.

| Instructions    | Screenshot |
|:----------------|-----------:|
| [!INCLUDE [Create storage account step 1](<./includes/create-storage-acct-1.md>)] | :::image type="content" source="./media/azportal-create-storage-account-1-240px.png" alt-text="A screenshot showing how to use the search box in the top tool bar to find storage accounts in Azure." lightbox="./media/azportal-create-storage-account-1.png"::: |
| [!INCLUDE [Create storage account step 2](<./includes/create-storage-acct-2.md>)] | :::image type="content" source="./media/azportal-create-storage-account-2-240px.png" alt-text="A screenshot showing the create button on the storage accounts page used to create a new storage account." lightbox="./media/azportal-create-storage-account-2.png"::: |
| [!INCLUDE [Create storage account step 3](<./includes/create-storage-acct-3.md>)] | :::image type="content" source="./media/azportal-create-storage-account-3-240px.png" alt-text="A screenshot showing the form to fill out to create a new storage account in Azure." lightbox="./media/azportal-create-storage-account-3.png"::: |
| [!INCLUDE [Create storage account step 4](<./includes/create-storage-acct-4.md>)] | :::image type="content" source="./media/azportal-create-storage-account-4-240px.png" alt-text="A screenshot of the completion page after a storage account has been created.  This page contains a button that will take you to the storage account you just created." lightbox="./media/azportal-create-storage-account-4.png"::: |

### [Azure CLI](#tab/azure-cli)

Storage accounts are created using the [az storage account create](/cli/azure/storage/account#az_storage_account_create) command.  Storage account names must be between 3 and 24 characters in length and may contain numbers and lowercase letters only.  Storage account names must also be unique across Azure.

Azure CLI commands can be run in the [Azure Cloud Shell](https://shell.azure.com) or on a workstation with the [Azure CLI installed](/cli/azure/install-azure-cli).

```azurecli
LOCATION='eastus'                             # Use 'az account list-locations --output table' to list locations
RESOURCE_GROUP_NAME='rg-msdocs-blob-storage-demo'
STORAGE_ACCOUNT_NAME='stblobstoragedemo123'   # Replace 123 with three random numbers to get unique name

# Create a resource group
az group create \
    --location $LOCATION \
    --name $RESOURCE_GROUP_NAME

# Create the storage account
az storage account create \
    --name $STORAGE_ACCOUNT_NAME \
    --resource-group $RESOURCE_GROUP_NAME \
    --location $LOCATION
```

### [Azure PowerShell](#tab/azure-powershell)

Storage accounts are created using the [New-AzStorageAccount](/powershell/module/az.storage/new-azstorageaccount) cmdlet.  Storage account names must be between 3 and 24 characters in length and may contain numbers and lowercase letters only.  Storage account names must also be unique across Azure.

Azure PowerShell commands can be run in the [Azure Cloud Shell](https://shell.azure.com) or on a workstation with [Azure PowerShell installed](/powershell/azure/install-az-ps).

```azurepowershell
$location = 'eastus'   # Use 'Get-AzLocation | Select-Object -Property DisplayName,Location' to list all locations
$resourceGroupName = 'rg-msdocs-blob-storage-demo'
$storageAccountName = 'stblobstoragedemo123'   # Replace 123 with three random numbers to get unique name

# Create a resource group
New-AzResourceGroup `
    -Location $location `
    -Name $resourceGroupName

# Create the storage account
New-AzStorageAccount `
    -Name $storageAccountName `
    -ResourceGroupName $resourceGroupName `
    -Location $location `
    -SkuName Standard_LRS
```

---

## 2 - Get Storage connection string

To access the storage account, your app will need the connection string for the storage account.  The connection string can be retrieved using the Azure portal, Azure CLI, or Azure PowerShell.

### [Azure portal](#tab/azure-portal)

In the [Azure portal](https://portal.azure.com/), navigate to the storage account and retrieve the connection string using the following instruction.

| Instructions    | Screenshot |
|:----------------|-----------:|
| [!INCLUDE [Create storage account step 1](<./includes/get-storage-conn-string-1.md>)] | :::image type="content" source="./media/azportal-get-storage-connection-string-1-240px.png" alt-text="A screenshot highlighting the location of the Access keys link on the page for a storage account." lightbox="./media/azportal-get-storage-connection-string-1.png"::: |
| [!INCLUDE [Create storage account step 1](<./includes/get-storage-conn-string-2.md>)] | :::image type="content" source="./media/azportal-get-storage-connection-string-2-240px.png" alt-text="A screenshot showing the access keys page for a storage account, highlighting the button to select to storage accounts and the value to copy for use by your application." lightbox="./media/azportal-get-storage-connection-string-2.png"::: |

### [Azure CLI](#tab/azure-cli)

```azurecli
az storage account show-connection-string \
    -g $RESOURCE_GROUP_NAME \
    -n $STORAGE_ACCOUNT_NAME \
    --output tsv
```

### [Azure PowerShell](#tab/azure-powershell)

```azurepowershell
# Get Connection String for Storage Account
$storageKey=(Get-AzStorageAccountKey -ResourceGroupName $resourceGroupName -Name $storageAccountName).Value[0]
$storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=$storageAccountName;AccountKey=$storageKey;EndpointSuffix=core.windows.net"

Write-Host 'This is the connection string your application will use to connect to the storage account'
Write-Host 'Safeguard this value like you would any other secret'
Write-Host $storageConnectionString
```

---

The connection string for your storage account is considered an app secret and must be protected like any other app secret or password.  This example uses the [Secret Manager](/aspnet/core/security/app-secrets#secret-manager) tool to store the connection string during development and make it available to the application.  The Secret Manager tool can be accessed from either Visual Studio or the .NET CLI.

### [Visual Studio](#tab/visual-studio)

With your solution open in Visual Studio, right click on the *project* **AzureBlobStorageDemo** and select **Manage User Secrets** from the context menu. Be sure to right click on the *project* and not the *solution* in the Visual Studio solution explorer.  This will open the *secrets.json* file for the project.  Edit the file to look like the JSON  below, substituting in your storage connection string.

```json
{
  "ConnectionStrings": {
    "AzureStorage": "<storage connection string>"
  }  
}
```

### [.NET CLI](#tab/netcore-cli)

If you are using Visual Studio Code, the Secret Manager is accessed via the .NET CLI.  In a terminal window, change directories into the **AzureBlobStorageDemo** project directory.

Then, to use the Secret Manager, you must first initialize it for your project using the `dotnet user-secrets init` command.

```dotnetcli
dotnet user-secrets init
```

Finally, use the `dotnet user-secrets set` command to add the storage connection string as a secret.

```dotnetcli
dotnet user-secrets set "ConnectionStrings:AzureStorage" "<storage connection string>"
```

---

## 3 - Install Azure.Storage.Blobs NuGet package

To access Azure Blob Storage from a .NET application, you need to install the [Azure.Storage.Blobs](https://www.nuget.org/packages/Azure.Storage.Blobs) package from NuGet.

### [Visual Studio](#tab/visual-studio)

```PowerShell
Install-Package Azure.Storage.Blobs
```

### [.NET CLI](#tab/netcore-cli)

```dotnetcli
dotnet add package Azure.Storage.Blobs
```

---

## 4 - Configure the Azure Storage client in Startup.cs

The Azure SDK communicates with Azure using client objects to execute different operations against Azure.  The [BlobServiceClient](/dotnet/api/azure.storage.blobs.blobserviceclient) object is the top-level object used to communicate with a storage account.

An application will typically create a single [BlobServiceClient](/dotnet/api/azure.storage.blobs.blobserviceclient) object per storage account to be used throughout the application.  It is recommended to use dependency injection (DI) and register the [BlobServiceClient](/dotnet/api/azure.storage.blobs.blobserviceclient) object as a singleton to accomplish this.  For more information about using DI with the Azure SDK, see [Dependency injection with the Azure SDK for .NET](../sdk/dependency-injection.md).

In the `Startup.cs` file of the application, first add the following using statement at the top of the file.

```csharp
using Azure.Storage.Blobs;
```

Then, in the `ConfigureServices()` method, add the following three lines after the `services.AddRazorPages()` method call.

```csharp
var connectionString = Configuration.GetConnectionString("AzureStorage");
var blobServiceClient = new BlobServiceClient(connectionString);
services.AddSingleton(blobServiceClient);
```

When finished, the `ConfigureServices()` method should look like the following.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddRazorPages();

    // Configure BlobServicesClient object for Azure Storage
    var connectionString = Configuration.GetConnectionString("AzureStorage");
    var blobServiceClient = new BlobServiceClient(connectionString);
    services.AddSingleton(blobServiceClient);
      
    services.AddSingleton<StorageDemoService>();
}
```

## 5 - Implement Azure Storage operations in code

All storage operations for the sample app are implemented in the `BlobStorageService.cs` file located in the *Services* directory.  You will need to import the `Azure`, `Azure.Storage.Blobs`, and `Azure.Storage.Blobs.Models` namespaces at the top of this file to work with objects in the `Azure.Storage.Blobs` SDK package.

```csharp
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
```

At the start of the StorageDemoService class, add a member variable for the [BlobServiceClient](/dotnet/api/azure.storage.blobs.blobserviceclient) object and a constructor to allow the [BlobServiceClient](/dotnet/api/azure.storage.blobs.blobserviceclient) object to be injected into the class.

```csharp
private readonly BlobServiceClient _blobServiceClient;

public StorageDemoService(BlobServiceClient blobServiceClient)
{
    _blobServiceClient = blobServiceClient;
}
```

### Create a container

A blob container acts like a folder in a storage account to help organize your blob objects.  Only one level of blob containers is supported in a storage account.  That is, containers can't contain other containers.

To create a blob container, call the [`GetBlobContainerClient()`](/dotnet/api/azure.storage.blobs.blobserviceclient.getblobcontainerclient#Azure_Storage_Blobs_BlobServiceClient_GetBlobContainerClient_System_String_) on the [`BlobServiceClient`](/dotnet/api/azure.storage.blobs.blobserviceclient) object with the name of the container you want to create.  This will return a [BlobContainerClient](/dotnet/api/azure.storage.blobs.blobcontainerclient) object which has methods to interact with the named container, including creating that container if it does not exist.  

This method checks to make sure that the container does not exist by first calling the [Exists()](/dotnet/api/azure.storage.blobs.blobcontainerclient.exists#Azure_Storage_Blobs_BlobContainerClient_Exists_System_Threading_CancellationToken_) method on the [BlobContainerClient](/dotnet/api/azure.storage.blobs.blobcontainerclient) and then creates the container using the [Create()](/dotnet/api/azure.storage.blobs.blobcontainerclient.create#Azure_Storage_Blobs_BlobContainerClient_Create_Azure_Storage_Blobs_Models_PublicAccessType_System_Collections_Generic_IDictionary_System_String_System_String__Azure_Storage_Blobs_Models_BlobContainerEncryptionScopeOptions_System_Threading_CancellationToken_) method if it does not exist.  Attempting to create a container that already exists would result in a [RequestFailedException](/dotnet/api/azure.requestfailedexception) being thrown.  

As an alternative, the [CreateIfNotExists()](/dotnet/api/azure.storage.blobs.blobcontainerclient.createifnotexists#Azure_Storage_Blobs_BlobContainerClient_CreateIfNotExists_Azure_Storage_Blobs_Models_PublicAccessType_System_Collections_Generic_IDictionary_System_String_System_String__Azure_Storage_Blobs_Models_BlobContainerEncryptionScopeOptions_System_Threading_CancellationToken_) method could also be called on the [BlobContainerClient](/dotnet/api/azure.storage.blobs.blobcontainerclient) object to create the container.

```csharp
public void CreateContainer(string containerName)
{
    BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

    if (containerClient.Exists())
        throw new ApplicationException($"Unable to create container '{containerName}' as it already exists");

    containerClient.Create();
}
```

### List blob containers

To get a list of blob containers in the storage account, call the [GetBlobContainers()](/dotnet/api/azure.storage.blobs.blobserviceclient.getblobcontainers#Azure_Storage_Blobs_BlobServiceClient_GetBlobContainers_Azure_Storage_Blobs_Models_BlobContainerTraits_Azure_Storage_Blobs_Models_BlobContainerStates_System_String_System_Threading_CancellationToken_) method on the [BlobServiceClient](/dotnet/api/azure.storage.blobs.blobserviceclient) object for the storage account.

This will return a [Pageable\<BlobContainer\>](/dotnet/api/azure.pageable-1) object listing the blob containers.  In this method in the sample application, a LINQ query is used to map each BlobContainerItem to a model object and return it to the application.

```csharp
public IEnumerable<StorageContainerModel> GetContainers()
{
    Pageable<BlobContainerItem> containers = _blobServiceClient.GetBlobContainers();

    return containers.Select(c => new StorageContainerModel { Name = c.Name });
}
```

### Delete a container

To delete a blob container, first a [BlobContainerClient](/dotnet/api/azure.storage.blobs.blobcontainerclient) for the container is obtained from the [BlobServiceClient](/dotnet/api/azure.storage.blobs.blobserviceclient) by calling the GetBlobContainerClient() method with the name of the container being deleted.  The code makes sure the container exists and then calls the `Delete()` method on the [BlobContainerClient](/dotnet/api/azure.storage.blobs.blobcontainerclient).

Deleting a blob container will also delete all of the blobs in the container.

```csharp
public void DeleteContainer(string containerName)
{
    BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

    if (!containerClient.Exists())
        throw new ApplicationException($"Unable to delete container '{containerName}' as it does not exists");

    containerClient.Delete();
}
```

### List blobs in a container

To list the blobs in a container, call the [GetBlobs()](/dotnet/api/azure.storage.blobs.blobcontainerclient.getblobs?#Azure_Storage_Blobs_BlobContainerClient_GetBlobs_Azure_Storage_Blobs_Models_BlobTraits_Azure_Storage_Blobs_Models_BlobStates_System_String_System_Threading_CancellationToken_) method on a [BlobContainerClient](/dotnet/api/azure.storage.blobs.blobcontainerclient) object for the container. It is important to check for the existence of the blob container as calling [GetBlobs()](/dotnet/api/azure.storage.blobs.blobcontainerclient.getblobs?#Azure_Storage_Blobs_BlobContainerClient_GetBlobs_Azure_Storage_Blobs_Models_BlobTraits_Azure_Storage_Blobs_Models_BlobStates_System_String_System_Threading_CancellationToken_) on a container that does not exist will result in an exception.  A [Pageable\<BlobItem\>](/dotnet/api/azure.pageable-1) collection will be returned.

In the example application, this collection is mapped into Model objects defined by the application before being returned.  Among the properties available on for each blob are the name of the blob, any tags on the blob, its content type, its creation date, and its size in bytes.

```csharp
public IEnumerable<BlobInfoModel> ListBlobsInContainer(string containerName)
{
    BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

    if (!containerClient.Exists())
        throw new ApplicationException($"Cannot list blobs in container '{containerName}' as it does not exists");

    Pageable<BlobItem> blobs = containerClient.GetBlobs();
    var models = blobs.Select(b => new BlobInfoModel
    {
        Name = b.Name,
        Tags = b.Tags,
        ContentEncoding = b.Properties.ContentEncoding,
        ContentType = b.Properties.ContentType,
        Size = b.Properties.ContentLength,
        CreatedOn = b.Properties.CreatedOn,
        AccessTier = b.Properties.AccessTier?.ToString(),
        BlobType = b.Properties.BlobType?.ToString()
    });

    return models;
}
```

### Upload a blob

To upload a blob, first get a [BlobContainerClient](/dotnet/api/azure.storage.blobs.blobcontainerclient) object for the container you want to upload the blob to.  Then call the [GetBlobClient()](/dotnet/api/azure.storage.blobs.blobcontainerclient.getblobclient#Azure_Storage_Blobs_BlobContainerClient_GetBlobClient_System_String_) with the name of the blob to be uploaded to get a [BlobClient](/dotnet/api/azure.storage.blobs.blobclient) class.  

The [BlobClient](/dotnet/api/azure.storage.blobs.blobclient) class contains multiple [Upload()](/dotnet/api/azure.storage.blobs.blobclient.upload#Azure_Storage_Blobs_BlobClient_Upload_System_IO_Stream_Azure_Storage_Blobs_Models_BlobUploadOptions_System_Threading_CancellationToken_) methods to upload the contents of a blob to Azure Blob storage.  This example uses a [BlobUploadOptions](/en-us/dotnet/api/azure.storage.blobs.models.blobuploadoptions) object to set the ContentType of the blob and uploads it as a Stream.  There are also overloads available to [upload a blob from a file path](/dotnet/api/azure.storage.blobs.blobclient.upload#Azure_Storage_Blobs_BlobClient_Upload_System_String_) and to [upload a blob from an array of bytes](/dotnet/api/azure.storage.blobs.blobclient.upload#Azure_Storage_Blobs_BlobClient_Upload_System_BinaryData_)

```csharp
    public void UploadBlob(string containerName, string blobName, string contentType, Stream content)
    {
        BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        if (!containerClient.Exists())
            throw new ApplicationException(
                $"Unable to upload blobs to container '{containerName}' as the container does not exists");

        BlobClient blobClient = containerClient.GetBlobClient(blobName);
        var options = new BlobUploadOptions { HttpHeaders = new BlobHttpHeaders { ContentType = contentType } };
        var response = blobClient.Upload(content, options);
    }
```

### Download a blob

To download the contents of a blob from Blob Storage you need both the container name and the name of the blob.

The container name is used to get a [BlobContainerClient](/dotnet/api/azure.storage.blobs.blobcontainerclient) object for the container the blob is in.  Then call the [GetBlobClient()](/dotnet/api/azure.storage.blobs.blobcontainerclient.getblobclient#Azure_Storage_Blobs_BlobContainerClient_GetBlobClient_System_String_) with the name of the blob on the [BlobContainerClient](/dotnet/api/azure.storage.blobs.blobcontainerclient) object to get a `BlobClient` object that allows access to the blob.  The [OpenRead()](/dotnet/api/azure.storage.blobs.specialized.blobbaseclient.openread#Azure_Storage_Blobs_Specialized_BlobBaseClient_OpenRead_Azure_Storage_Blobs_Models_BlobOpenReadOptions_System_Threading_CancellationToken_) method on the [BlobClient](/dotnet/api/azure.storage.blobs.blobclient) object will return a Stream that can be used to read the blob.

In this example, the Blob data is mapped to a Model object that is used by the application to return a stream of the blob data to the browser for download.

```csharp
    public BlobModel GetBlobContents(string containerName, string blobName)
    {
        BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        if (!containerClient.Exists())
            throw new ApplicationException(
                $"Unable to get blob {blobName} in container '{containerName}' as the container does not exists");

        BlobClient blobClient = containerClient.GetBlobClient(blobName);
        if (!blobClient.Exists())
            throw new ApplicationException(
                $"Unable to delete blob {blobName} in container '{containerName}'" +
                " as no blob with this name exists in this container");
                   
        return new BlobModel
        {
            Name = blobName,
            ContentType = blobClient.GetProperties().Value.ContentType,
            Content = blobClient.OpenRead()
        };
    }
```

### Delete a blob

To delete a blob from a container, first get the [BlobContainerClient](/dotnet/api/azure.storage.blobs.blobcontainerclient) object for the container the blob is in. Then on the [BlobContainerClient](/dotnet/api/azure.storage.blobs.blobcontainerclient) object call the [GetBlobClient()](/dotnet/api/azure.storage.blobs.blobcontainerclient.getblobclient#Azure_Storage_Blobs_BlobContainerClient_GetBlobClient_System_String_) method  with the name of the blob to get a [BlobClient](/dotnet/api/azure.storage.blobs.blobclient) object that provides operations to manipulate the blob in Azure storage.  Finally, call the [Delete()](/dotnet/api/azure.storage.blobs.specialized.blobbaseclient.delete#Azure_Storage_Blobs_Specialized_BlobBaseClient_Delete_Azure_Storage_Blobs_Models_DeleteSnapshotsOption_Azure_Storage_Blobs_Models_BlobRequestConditions_System_Threading_CancellationToken_) method on the [BlobClient](/dotnet/api/azure.storage.blobs.blobclient) object to delete the blob.

As shown in this example, it is suggested to validate the existence of the container and the blob before deleting the blob to avoid an error.

```csharp
public void DeleteBlob(string containerName, string blobName)
{
    BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

    if (!containerClient.Exists())
        throw new ApplicationException($"Unable to delete blob {blobName} in container '{containerName}' as the container does not exists");

    BlobClient blobClient = containerClient.GetBlobClient(blobName);
    if (!blobClient.Exists() )
        throw new ApplicationException($"Unable to delete blob {blobName} in container '{containerName}' as no blob with this name exists in this container");

    blobClient.Delete();
}
```

## 6 - Run the code

Build and run the application to interact with Azure blob storage using the sample application.  The first time the application starts you should see a screen similar to the following.

:::image type="content" source="./media/sample-app-initial-page.png" alt-text="A screenshot showing how the application looks when run the first time.":::

Select the **New container** button to create a container in your blob storage account.

:::image type="content" source="./media/sample-app-showing-containers.png" alt-text="A screenshot showing the application after two containers have been created in the storage account.":::

You can expand each container by selecting the container name.  Within a container, select the **Upload file** button to upload files to the blob storage container.

:::image type="content" source="./media/sample-app-blobs-uploaded.png" alt-text="A screenshot showing that files have been uploaded into the container in the storage account.":::

## Clean up resources

When you are finished with the sample application, you should remove all Azure resources related to this article from your Azure account.  You can do this by deleting the resource group.

### [Azure portal](#tab/azure-portal)

A resource group can be deleted using the [Azure portal](https://portal.azure.com/) by doing the following.

| Instructions    | Screenshot |
|:----------------|-----------:|
| [!INCLUDE [Delete resource group step 1](<./includes/delete-resource-group-1.md>)] | :::image type="content" source="./media/azportal-delete-resource-group-1-240px.png" alt-text="Azure screenshot 1." lightbox="./media/azportal-delete-resource-group-1.png"::: |
| [!INCLUDE [Delete resource group step 2](<./includes/delete-resource-group-2.md>)] | :::image type="content" source="./media/azportal-delete-resource-group-2-240px.png" alt-text="Azure screenshot 2" lightbox="./media/azportal-delete-resource-group-2.png"::: |
| [!INCLUDE [Delete resource group step 3](<./includes/delete-resource-group-3.md>)] | :::image type="content" source="./media/azportal-delete-resource-group-3-240px.png" alt-text="Azure screenshot 3" lightbox="./media/azportal-delete-resource-group-3.png"::: |

### [Azure CLI](#tab/azure-cli)

To delete a resource group using the Azure CLI, use the [az group delete](/cli/azure/group#az_group_delete) command with the name of the resource group to be deleted.  Deleting a resource group will also remove all Azure resources contained in the resource group.

```azurecli
az group delete --name $RESOURCE_GROUP_NAME
```

### [Azure PowerShell](#tab/azure-powershell)

To delete a resource group using Azure PowerShell, use the [Remove-AzResourceGroup](/powershell/module/az.resources/remove-azresourcegroup) command with the name of the resource group to be deleted.  Deleting a resource group will also remove all Azure resources contained in the resource group.

```azurepowershell
Remove-AzResourceGroup -Name $resourceGroupName
```

---
