---
title: Azure Storage grain persistence
description: Learn about Azure Storage grain persistence in .NET Orleans.
ms.date: 01/21/2026
ms.topic: how-to
zone_pivot_groups: orleans-version
---

# Azure Storage grain persistence

The Azure Storage grain persistence provider supports both [Azure Blob Storage](/azure/storage/blobs/storage-blobs-introduction) and [Azure Table Storage](/azure/storage/common/storage-introduction?toc=/azure/storage/blobs/toc.json#table-storage).

:::zone target="docs" pivot="orleans-7-0,orleans-8-0,orleans-9-0,orleans-10-0"

## Configure Azure Table Storage

Install the [Microsoft.Orleans.Persistence.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.AzureStorage) package from NuGet. The Azure Table Storage provider stores state in a table row, splitting the state across multiple columns if it exceeds the limits of a single column. Each row can hold a maximum of 1 megabyte, as [imposed by Azure Table Storage](/azure/storage/common/storage-scalability-targets#azure-table-storage-scale-targets).

Configure the Azure Table Storage grain persistence provider using the <xref:Orleans.Hosting.AzureTableSiloBuilderExtensions.AddAzureTableGrainStorage%2A?displayProperty=nameWithType> extension method.

### [Managed identity (recommended)](#tab/managed-identity)

Using <xref:Azure.Identity.DefaultAzureCredential> with a URI endpoint is the recommended approach for production environments. This pattern avoids storing secrets in configuration and leverages Azure managed identities for secure authentication.

```csharp
using Azure.Identity;

var endpoint = new Uri(configuration["AZURE_TABLE_STORAGE_ENDPOINT"]!);
var credential = new DefaultAzureCredential();

siloBuilder.AddAzureTableGrainStorage(
    name: "profileStore",
    configureOptions: options =>
    {
        options.ConfigureTableServiceClient(endpoint, credential);
    });
```

### [Connection string](#tab/connection-string)

> [!WARNING]
> Connection strings contain secrets and should be avoided in production. Use managed identity whenever possible.

```csharp
siloBuilder.AddAzureTableGrainStorage(
    name: "profileStore",
    configureOptions: options =>
    {
        options.ConfigureTableServiceClient(
            "DefaultEndpointsProtocol=https;AccountName=data1;AccountKey=SOMETHING1");
    });
```

---

## Configure Azure Blob Storage

The Azure Blob Storage provider stores state in a blob.

Configure the Azure Blob Storage grain persistence provider using the <xref:Orleans.Hosting.AzureBlobSiloBuilderExtensions.AddAzureBlobGrainStorage%2A?displayProperty=nameWithType> extension method.

### [Managed identity (recommended)](#tab/managed-identity)

```csharp
using Azure.Identity;

var endpoint = new Uri(configuration["AZURE_BLOB_STORAGE_ENDPOINT"]!);
var credential = new DefaultAzureCredential();

siloBuilder.AddAzureBlobGrainStorage(
    name: "profileStore",
    configureOptions: options =>
    {
        options.ConfigureBlobServiceClient(endpoint, credential);
    });
```

### [Connection string](#tab/connection-string)

```csharp
siloBuilder.AddAzureBlobGrainStorage(
    name: "profileStore",
    configureOptions: options =>
    {
        options.ConfigureBlobServiceClient(
             "DefaultEndpointsProtocol=https;AccountName=data1;AccountKey=SOMETHING1");
    });
```

---

:::zone-end

:::zone target="docs" pivot="orleans-3-x"

## Configure Azure Table Storage

Install the [Microsoft.Orleans.Persistence.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.AzureStorage) package from NuGet. The Azure Table Storage provider stores state in a table row, splitting the state across multiple columns if it exceeds the limits of a single column. Each row can hold a maximum of 1 megabyte, as [imposed by Azure Table Storage](/azure/storage/common/storage-scalability-targets#azure-table-storage-scale-targets).

Configure the Azure Table Storage grain persistence provider using the <xref:Orleans.Hosting.AzureTableSiloBuilderExtensions.AddAzureTableGrainStorage%2A?displayProperty=nameWithType> extension method.

```csharp
siloBuilder.AddAzureTableGrainStorage(
    name: "profileStore",
    configureOptions: options =>
    {
        options.ConnectionString = 
            "DefaultEndpointsProtocol=https;AccountName=data1;AccountKey=SOMETHING1";
    });
```

## Configure Azure Blob Storage

The Azure Blob Storage provider stores state in a blob.

Configure the Azure Blob Storage grain persistence provider using the <xref:Orleans.Hosting.AzureBlobSiloBuilderExtensions.AddAzureBlobGrainStorage%2A?displayProperty=nameWithType> extension method.

```csharp
siloBuilder.AddAzureBlobGrainStorage(
    name: "profileStore",
    configureOptions: options =>
    {
        options.ConnectionString = 
             "DefaultEndpointsProtocol=https;AccountName=data1;AccountKey=SOMETHING1";
    });
```

:::zone-end
