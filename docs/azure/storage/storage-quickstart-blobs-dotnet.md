---
title: Accessing Azure Blob Storage from .NET applications
description: Learn how to connect your applications to Azure Blob Storage
ms.date: 06/02/2021
ms.topic: article
ms.custom: devx-track-dotnet
ms.author: daberry
---

# Accessing Azure Blob Storage from .NET applications

## Sample application

The sample application for this tutorial may be cloned or downloaded from the repository [https://github.com/azure-samples/dotnetcore-sqldb-tutorial](https://github.com/azure-samples/dotnetcore-sqldb-tutorial).  Both a starter and completed app are included in the sample repository.

```bash
git clone https://github.com/azure-samples/dotnetcore-sqldb-tutorial
```

When complete, the sample application will allow you to create blob containers, upload blobs to a storage account as well as visualize the relationship between containers and blobs in the storage account.

:::image type="content" source="./media/blobs-and-containers-640.png" alt-text="A screenshot of the sample application for this article showing three blob containers in a storage account.  One of the containers is expanded showing it contains three different blob objects inside" lightbox="./media/blobs-and-containers.png":::

## 1 - Create Azure Storage resources

You first need to create a resource group and storage account in Azure for the sample application to use. This can be done using the Azure CLI or Azure PowerShell.

### [Azure CLI](#tab/azure-cli)

Storage accounts are created using the `az storage account create` command.  Storage account names must be between 3 and 24 characters in length and may contain numbers and lowercase letters only.  Storage account names must also be unique across Azure.

Azure CLI commands can be run in the [Azure Cloud Shell](https://shell.azure.com) or on a workstation with the [Azure CLI installed](/cli/azure/install-azure-cli).

```azurecli
$LOCATION = 'eastus'             # Use 'az account list-locations --output table' to list locations
$RESOURCE_GROUP_NAME = 'rg-msdocs-blob-storage-demo'
$STORAGE_ACCOUNT_NAME = ''   

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

Storage accounts are created using the `New-AzStorageAccount` cmdlt.  Storage account names must be between 3 and 24 characters in length and may contain numbers and lowercase letters only.  Storage account names must also be unique across Azure.

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

### [Azure Portal](#tab/azure-portal)

A Storage account can be created using the [Azure portal](https://portal.azure.com/) by following these steps.

:::row:::
   :::column span="3":::
      **Step**
   :::column-end:::
   :::column span="":::
      **Screenshot**
   :::column-end:::
:::row-end:::
:::row:::
   :::column span="3":::
      In the Azure portal:
      1. In the search bar at the top of the Azure portal, enter "storage account"
      1. On the menu that appears below the search bar, under *Services*, select the item labeled *Storage accounts*
   :::column-end:::
   :::column span="":::
      :::image type="content" source="./media/azportal-create-storage-account-1-240px.png" alt-text="A screenshot showing how to use the search box in the top tool bar to find storage accounts in Azure." lightbox="./media/azportal-create-storage-account-1.png":::
   :::column-end:::
:::row-end:::
:::row:::
   :::column span="3":::
      On the **Storage Accounts** page select "+Create"
   :::column-end:::
   :::column span="":::
      :::image type="content" source="./media/azportal-create-storage-account-2-240px.png" alt-text="A screenshot showing the create button on the storage accounts page used to create a new storage account." lightbox="./media/azportal-create-storage-account-2.png":::
   :::column-end:::
:::row-end:::
:::row:::
   :::column span="3":::
      On the **Create a storage account** page, fill out the form as follows.
      1. Create a new resource group for the storage account named `rg-msdocs-blob-storage-demo` by selecting the **Create new** link under **Resource group**.
      1. Give your storage account a name of `stblobstoragedemoXYZ` where XYZ are any three random digits.  
      1. Select the region for your storage account.
      1. Select **Standard** performance.
      1. Select **Locally-redundant storage** for this example under redundancy.
      1. Select the **Review + create" button at the bottom of the screen and then select "Create" on the summary screen to create your storage account.
   :::column-end:::
   :::column span="":::
        :::image type="content" source="./media/azportal-create-storage-account-3-240px.png" alt-text="A screenshot showing the form to fill out to create a new storage account in Azure." lightbox="./media/azportal-create-storage-account-3.png":::
   :::column-end:::
:::row-end:::
:::row:::
   :::column span="3":::
      Upon creation of your Azure storage account, you will see a page indicating "Your deployment is complete". Select the **Go to resource** button on the page to view your Storage account.

      Do not close your browser as you will need to copy information about your Azure Storage account in the next step.
   :::column-end:::
   :::column span="":::
            :::image type="content" source="./media/azportal-create-storage-account-4-240px.png" alt-text="A screenshot of the completion page after a storage account has been created.  This page contains a button which will take you to the just created storage account." lightbox="./media/azportal-create-storage-account-4.png":::
   :::column-end:::
:::row-end:::

---

## 2 - Get Storage connection string

To access the storage account, your app will need the connection string for the storage account.  The connection string can be retrieved using the Azure Portal, Azure CLI or Azure PowerShell.

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

### [Azure Portal](#tab/azure-portal)

Coming soon...

---

The connection string for your storage account is considered an app secret and must be protected like any other app secret or password.  This example uses the Secret Manager tool to store the connection string during development and make it available to the application.  The Secret Manager tool can be accessed from either Visual Studio or the .NET CLI.

### [Visual Studio](#tab/visual-studio)

To open the Secret Manager tool from Visual Studio, right click on the project and select **Manage User Secrets** from the context menu.  This will open the *secrets.json" file for the project.  Replace the contents of the file with the JSON below, substituting in your storage connection string.

```json
{
  "ConnectionStrings": {
    "AzureStorage": "<storage connection string>"
  }  
}
```

### [.NET Core CLI](#tab/netcore-cli)

To use the Secret Manager, you must first initialize it for your project using the `dotnet user-secrets init` command.

```dotnetcli
dotnet user-secrets init
```

Then, use the `dotnet user-secrets set` command to add the storage connection string as a secret.

```dotnetcli
dotnet user-secrets set "ConnectionStrings:AzureStorage" "<storage connection string>"
```

---

## 3 - Install Azure SDK package

To access Azure Blob Storage from a .NET application, you need to install the [Azure.Storage.Blobs package from NuGet](https://www.nuget.org/packages/Azure.Storage.Blobs).

### [Visual Studio](#tab/visual-studio)

```PowerShell
Install-Package Azure.Storage.Blobs
```

### [.NET Core CLI](#tab/netcore-cli)

```dotnetcli
dotnet add package Azure.Storage.Blobs
```

---

## 4 - Configure the Azure Storage client in Startup.cs

The Azure SDK communicates with Azure using client objects to execute different operations against Azure.  The `BlobServiceClient` object is the top level object used to communicate with a storage account.

An application will typically create a single `BlobServiceClient` object per storage account to be used throughout the application.  It is recommended to use dependency injection and register the `BlobServiceClient` object as a singleton to accomplish this.

In the Startup.cs file of the application, edit the ConfigureServices() method to include the highlighted code.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();

    // Configure BlobServicesClient object for Azure Storage
    var connectionString = Configuration.GetConnectionString("AzureStorage");
    BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);                       
    services.AddSingleton(blobServiceClient);
      
    services.AddSingleton<StorageDemoService>();
}
```

## 5 - Implement Azure Storage operations in code

All storage operations for the sample app are implemented in the `StorageDemoService` class located in the Services folder.  You will need to import the `Azure`, `Azure.Storage.Blobs`, and `Azure.Storage.Blobs.Models` namespaces at the top of this file to work with objects in the Azure.Storage.Blobs SDK package.

```csharp
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
```

At the start of the StorageDemoService class, add a member variable for the `BlobServiceClient` object and a constructor to allow the `BlobServiceClient` object to be injected into the class.

```csharp
private BlobServiceClient _blobServiceClient;

public StorageDemoService(BlobServiceClient blobServiceClient)
{
    _blobServiceClient = blobServiceClient;
}
```

### Create a container

A blob container acts like a folder in a storage account to help organize your blob objects.  Only one level of blob containers is supported in a storage account.  That is, containers can't contain other containers.

To create a blob container, call the `GetBlobContainerClient()` on the `BlobServiceClient` object with the name of the container you want to create.  This will return a `BlobContainerClient` object which has methods to interact with the named container, including creating that container if it does not exist.  

This method checks to make sure that the container does not exist by first calling the `Exists()` method on the `BlobContainerClient` and then creates the container using the `Create()` method if it does not exist.  Attempting to create a container that already exists would result in a `RequestFailedException` being thrown.  

As an alternative, the `CreateIfNotExists()` method could also be called on the `ContainerClient` object to create the container.

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

To get a list of blob containers in the storage account, call the `GetBlobContainers()` method on the `BlobServiceClient` object for the storage account.

This will return a `Pageable<BlobContainer>` object listing the blob containers.  In this method in the sample application, a LINQ query is used to map each BlobContainerItem to a model object and return it to the application.

```csharp
public IEnumerable<StorageContainerModel> GetContainers()
{
    Pageable<BlobContainerItem> containers = _blobServiceClient.GetBlobContainers();

    return containers.Select(c => new StorageContainerModel() { Name = c.Name });
}
```

### Delete a container

To delete a blob container, first a `BlobContainerClient` for the container is obtained from the `BlobServiceClient` by calling the `GetBlobContainerClient()` method with the name of the container being deleted.  The code makes sure the container exists and then called the `Delete()` method on the `BlobContainerClient`.

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

To list the blobs in a container, call the `GetBlobs()` method on a `BlobContainerClient` object for the container. It is important to check for the exsistence of the blob container as calling `GetBlobs()` on a container that does not exist will result in an exception.  A `Pageable<BlobItem>` collection will be returned.

In the example application, this collection is mapped into Model objects defined by the application before being returned.  Among the properties available on for each blob are the name of the blob, any tags on the blob, its content type, its creation date and its size in bytes.

```csharp
public IEnumerable<BlobInfoModel> ListBlobsInContainer(string containerName)
{
    BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

    if (!containerClient.Exists())
        throw new ApplicationException($"Cannot list blobs in container '{containerName}' as it does not exists");

    Pageable<BlobItem> blobs = containerClient.GetBlobs();
    var models = blobs.Select(b => new BlobInfoModel()
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

```csharp
    public void UploadBlob(string containerName, string blobName, string contentType, Stream content)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        if (!containerClient.Exists())
            throw new ApplicationException($"Unable to upload blobs to container '{containerName}' as the container does not exists");

        var blobClient = containerClient.GetBlobClient(blobName);
        var options = new BlobUploadOptions() { HttpHeaders = new BlobHttpHeaders() { ContentType = contentType } };
        var response = blobClient.Upload(content, options);                        
    }
```

### Download a blob

To download the contents of a blob from Blob Storage you need both the container name and the name of the blob.  The container name is used to get a `ContainerClient` object for the container the blob is in.  The call the `GetBlobClient()` with the name of the blob on the `ContainerClient` object to get a `BlobClient` object that allows access to the blob.  The `OpenRead()` method on the `BlobClient` object will return a Stream that can be used to read the blob.

In this example, the Blob data is mapped to a Model object which is used by the application to return a stream of the blob data to the browser for download.

```csharp
    public BlobModel GetBlobContents(string containerName, string blobName)
    {
        ContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        if (!containerClient.Exists())
            throw new ApplicationException($"Unable to get blob {blobName} in container '{containerName}' as the container does not exists");

        BlobClient blobClient = containerClient.GetBlobClient(blobName);
        if (!blobClient.Exists())
            throw new ApplicationException($"Unable to delete blob {blobName} in container '{containerName}' as no blob with this name exists in this container");
                   
        return new BlobModel()
        {
            Name = blobName,
            ContentType = blobClient.GetProperties().Value.ContentType,
            Content = blobClient.OpenRead()
        };
    }
```

### Delete a blob

To delete a blob from a container, first get the `ContainerClient` object for the container the blob is in. Then on the `ContainerClient` object call the `GetBlobClient()` method  with the name of the blob to get a `BlobClient` object which provides operations to manipulate the blob in Azure storage.  Finally, call the `Delete()` method on the `BlobClient` object to delete the blob.

As shown in this example, it is suggested the validate the existence of the container and the blob before deleting the blob to avoid an error.

```csharp
    public void DeleteBlob(string containerName, string blobName)
    {
        ContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

        if (!containerClient.Exists())
            throw new ApplicationException($"Unable to delete blob {blobName} in container '{containerName}' as the container does not exists");

        BlobClient blobClient = containerClient.GetBlobClient(blobName);
        if (!blobClient.Exists() )
            throw new ApplicationException($"Unable to delete blob {blobName} in container '{containerName}' as no blob with this name exists in this container");

        blobClient.Delete();
    }
```

## 6 - Run the code

## Clean up resources

When you are finished with the sample application, you should remove all Azure resources related to this article from your Azure account.  You can do this by deleting the resource group.


## Next Steps
