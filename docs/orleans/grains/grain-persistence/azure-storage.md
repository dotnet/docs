---
title: Azure Storage grain persistence
description: Learn about Azure Storage grain persistence in .NET Orleans.
ms.date: 07/03/2024
ms.topic: how-to
---

# Azure Storage grain persistence

The Azure Storage grain persistence provider supports both [Azure Blob Storage](/azure/storage/blobs/storage-blobs-introduction) and [Azure Table Storage](/azure/storage/common/storage-introduction?toc=/azure/storage/blobs/toc.json#table-storage).

## Install Azure Table Storage

Install the [Microsoft.Orleans.Persistence.AzureStorage](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.AzureStorage) package from NuGet. The Azure Table Storage provider stores state in a table row, splitting the state over multiple columns if the limits of a single column are exceeded. Each row can hold a maximum length of 1 megabyte, as [imposed by Azure Table Storage](/azure/storage/common/storage-scalability-targets#azure-table-storage-scale-targets).

Configure the Azure Table Storage grain persistence provider using the <xref:Orleans.Hosting.AzureTableSiloBuilderExtensions.AddAzureTableGrainStorage%2A?displayProperty=nameWithType> extension methods.

```csharp
siloBuilder.AddAzureTableGrainStorage(
    name: "profileStore",
    configureOptions: options =>
    {
        options.ConfigureTableServiceClient(
            "DefaultEndpointsProtocol=https;AccountName=data1;AccountKey=SOMETHING1");
    });
```

## Install Azure Blob Storage

The Azure Blob Storage provider stores state in a blob.

Configure the Azure Blob Storage grain persistence provider using the <xref:Orleans.Hosting.AzureBlobSiloBuilderExtensions.AddAzureBlobGrainStorage%2A?displayProperty=nameWithType> extension methods.

```csharp
siloBuilder.AddAzureBlobGrainStorage(
    name: "profileStore",
    configureOptions: options =>
    {
        options.ConfigureBlobServiceClient(
             "DefaultEndpointsProtocol=https;AccountName=data1;AccountKey=SOMETHING1");
    });
```
