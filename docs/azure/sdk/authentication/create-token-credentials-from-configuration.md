---
title: Create token credentials from configuration
description: This article describes how to create token credentials from configuration files
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23
ms.date: 1/16/2024
---

# Create TokenCredential types using configuration files

The `Microsoft.Extensions.Azure` library supports creating different <xref:Azure.Core.TokenCredential?displayProperty=fullName> types from values defined in _appsettings.json_ and other configuration files. This article describes which `TokenCredential` types can be created and how to configure the required values.

## Support for credentials through configuration

The `Microsoft.Extensions.Azure` library can automatically create and provide Azure service clients with a _TokenCredential_ class by searching _appsettings.json_ or other configuration files for credentials. The configuration files are searched using the default `IConfiguration` service for .NET. The following credential types are supported:

* <xref:Azure.Identity.ManagedIdentityCredential?displayProperty=fullName>
* <xref:Azure.Identity.WorkloadIdentityCredential?displayProperty=fullName>
* <xref:Azure.Identity.ClientSecretCredential?displayProperty=fullName>
* <xref:Azure.Identity.ClientCertificateCredential?displayProperty=fullName>
* <xref:Azure.Identity.DefaultAzureCredential?displayProperty=fullName>

The configuration file values are only used if the service client does not explicitly set an authentication mechanism. For example, the following code *will* initiate a search for values in _appsettings.json_ because the <xref:azure.storage.blob.BlobServiceClient?displayProperty=fullName> is created without specifying any credentials:

```csharp
// No TokenCredential or access key provided, configuration files will be searched
var blobServiceClient = new BlobServiceClient("<storage-account-name>");
```

However, the following code will *not* initiate a search for configuration values in _appsettings.json_, because `DefaultAzureCredential` is already provided:

```csharp
// Configuration files will not be searched because DefaultAzureCredential is already provided
var blobServiceClient = new BlobServiceClient("<storage-account-name>", new DefaultAzureCredential());
```

> [!NOTE]
> The examples in this article use `BlobServiceClient`, but the concepts apply to other Azure service clients as well, such as `CosmosClient` or `SecretClient`.

### Create a `ManagedIdentityCredential` type

Add the following configuration values to your _appsettings.json_ file to create a <xref:Azure.Identity.ManagedIdentityCredential?displayProperty=fullName>:

```json
{
  "credential": "managedidentity",
  "resourceId":  "<managedIdentityResourceId>"
}
```

### Create a `WorkloadIdentityCredential` type

Add the following configuration values to your _appsettings.json_ file to create a <xref:Azure.Identity.WorkloadCredentialId?displayProperty=fullName>:

```json
{
    "credential": "workloadidentity",
    "tenantId":  "<tenantId>",
    "clientId":  "<clientId>",
    "tokenFilePath": "<tokenFilePath>"
}
```

### Create a `ClientSecretCredential` type

Add the following configuration values to your _appsettings.json_ file to create a <xref:Azure.Identity.ClientSecretCredential?displayProperty=fullName>:

```json
{
    "tenantId":  "<tenantId>",
    "clientId":  "<clientId>",
    "tokenFilePath": "<clientSecret>"
}
```

### Create a `ClientCertificateCredential` type

Add the following configuration values to your _appsettings.json_ file to create a <xref:Azure.Identity.ClientCertificateCredential?displayProperty=fullName>:

```json
{
    "tenantId":  "<tenantId>",
    "clientId":  "<clientId>",
    "clientCertificate": "<managedIdentityResourceId>"
}
```

### Create a `DefaultAzureCredential` type

Add the following configuration values to your _appsettings.json_ file to create a <xref:Azure.Identity.DefaultAzureCredential?displayProperty=fullName>:

```json
{
    "tenantId":  "<tenantId>",
    "clientId":  "<clientId>",
    "clientCertificate": "<clientCertificate>"
}
```
