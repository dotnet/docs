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

The sample application for this tutorial may be cloned or downloaded from the repository [https://github.com/azure-samples/dotnetcore-sqldb-tutorial](https://github.com/azure-samples/dotnetcore-sqldb-tutorial).

```bash
git clone https://github.com/azure-samples/dotnetcore-sqldb-tutorial
```

## Step 1 - Create Azure Storage resources

You first need to create a resource group and storage account in Azure for the sample application to use.

Storage accounts are created using the `az storage account create` command.  Storage account names must be between 3 and 24 characters in length and may contain numbers and lowercase letters only.  Storage account names must also be unique across Azure.

```azurecli
$LOCATION = 'eastus'             # az account list-locations --output table
$RESOURCE_GROUP_NAME = 'rg-msdocs-blob-storage-demo'
$STORAGE_ACCOUNT_NAME = ''   

# Create a resource group
az group create \
    --location $LOCATION \
    --name $RESOURCE_GROUP_NAME

# Create the storage account
az storage account create `
    --name $STORAGE_ACCOUNT_NAME `
    --resource-group $RESOURCE_GROUP_NAME `
    --location $LOCATION
```

## Step 2 - Get Storage Connection String

To access the storage account, your app will need the connection string for the storage account.  Use the Azure CLI to retrieve the connection string.

```azurecli
az storage account show-connection-string \
    -g $RESOURCE_GROUP_NAME \
    -n $STORAGE_ACCOUNT_NAME \
    --output tsv
```

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

## Step 3 - Install the Azure SDK package

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

## Step 5 - Configure the Azure Storage Client in Startup.cs

The Azure SDK communicates with Azure using client objects to execute different operations against Azure.  The `BlobServiceClient` object is the top level object used to communicate with a storage account.  An application will typically create a single `BlobServiceClient` object per storage account to be used throughout the application.  It is recommended to use dependency injection and register the `BlobServiceClient` object as a singleton to accomplish this.

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

## Step 6 - Implement Azure Storage Operations in Code

All storage operations are implemented in the `StorageDemoService` class located in the Services folder in the sample application.  At the top of this class, add a member variable for the `BlobServiceClient` object and also add a constructor to allow the `BlobServiceClient` object to be injected into this class.

```csharp

    private BlobServiceClient _blobServiceClient;

    public StorageDemoService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }

```

### Create a container

```csharp
    public MessageModel CreateContainer(string containerName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        if (containerClient.Exists())
        {
            // Container already exists
            return new MessageModel() { Level = MessageLevel.Warning, Message = $"Could not create container {containerName} as it a container with that name already exists in this storage account" };
        }
        else
        {
            containerClient.Create();
            return new MessageModel() { Level = MessageLevel.Success, Message = $"Container {containerName} created" };
        }
    }
```

### Delete a container

```csharp
    public MessageModel DeleteContainer(string containerName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        if (containerClient.Exists())
        {
            _blobServiceClient.DeleteBlobContainer(containerName);
            return new MessageModel() { Level = MessageLevel.Success, Message = $"Container {containerName} deleted" };
        }
        else
        {
            // Can't delete a container that does not exist
            return new MessageModel() { Level = MessageLevel.Warning, Message = $"Could not delete container {containerName} as no container with that name exists in this storage account" };
        }
    }
```

### List blobs in a container

```csharp
    public IEnumerable<BlobModel> GetBlobs(string containerName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobs = containerClient.GetBlobs();
        var models = blobs.Select(b => new BlobModel()
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
     public MessageModel UploadBlob(string containerName, string blobName, String contentType, Stream content)
     {
         var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
         if (!containerClient.Exists())
         {
             return new MessageModel() { Level = MessageLevel.Danger, Message = $"Could not upload blob as no container with the name {containerName} exists in this storage account" };
         }
         else
         {                
             var blobClient = containerClient.GetBlobClient(blobName);
             var options = new BlobUploadOptions() { HttpHeaders = new BlobHttpHeaders() { ContentType = contentType }  } ;
             var response = blobClient.Upload(content, options); 
             return new MessageModel() { Level = MessageLevel.Success, Message = $"Blob {blobName} uploaded to container {containerName}" };
         }
     }
```

### Download a blob

```csharp
    public BlobContentModel GetBlobContents(String containerName, string blobName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);            
        var blobClient = containerClient.GetBlobClient(blobName);
        return new BlobContentModel() {
            Name = blobName,
            ContentType = containerClient.GetBlobs().FirstOrDefault()?.Properties.ContentType,
            Content = blobClient.OpenRead()
        };
    }
```

### Delete a blob

```csharp
    public void DeleteBlob(string containerName, string blobName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        containerClient.DeleteBlob(blobName);
    }
```

## Step 7 - Run the code

## Clean up resources

## Next Steps
