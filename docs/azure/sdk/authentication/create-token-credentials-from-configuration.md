---
title: Create token credentials from configuration
description: This article describes how to create Microsoft Entra token credentials from configuration files.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23
ms.date: 02/19/2025
---

# Create Microsoft Entra credential types using configuration files

The `Microsoft.Extensions.Azure` library supports creating different <xref:Azure.Core.TokenCredential?displayProperty=fullName> types from key-value pairs defined in _appsettings.json_ and other configuration files. The credential types correspond to a subset of the [credential classes](/dotnet/api/overview/azure/identity-readme) in the Azure Identity client library. This article describes the support for different `TokenCredential` types and how to configure the required key-value pairs for each type.

## Support for Azure credentials through configuration

The [`Microsoft.Extensions.Azure`](https://www.nuget.org/packages/Microsoft.Extensions.Azure) library can automatically provide Azure service clients with a `TokenCredential` class by searching _appsettings.json_ or other configuration files for credential values using the `IConfiguration` abstraction for .NET. This approach allows developers to explicitly set credential values across different environments through configuration rather than through app code directly.

The following credential types are supported via configuration:

* [ClientCertificateCredential](#create-a-clientcertificatecredential-type)
* [ClientSecretCredential](#create-a-clientsecretcredential-type)
* [DefaultAzureCredential](#create-a-defaultazurecredential-type)
* [ManagedIdentityCredential](#create-a-managedidentitycredential-type)
* [WorkloadIdentityCredential](#create-a-workloadidentitycredential-type)

## Configure Azure credentials

Azure service clients registered with the <xref:Microsoft.Extensions.Azure.AzureClientServiceCollectionExtensions.AddAzureClients%2A> method are automatically configured with an instance of `DefaultAzureCredential` if no explicit credential is supplied via the <xref:Microsoft.Extensions.Azure.AzureClientBuilderExtensions.WithCredential%2A> extension method. You can also override the global `DefaultAzureCredential` using credential values from configuration files when registering a client to create a specific credential type:

```csharp
builder.Services.AddAzureClients(clientBuilder =>
{
    // Register BlobServiceClient using credentials from appsettings.json
    clientBuilder.AddBlobServiceClient(builder.Configuration.GetSection("Storage"));

    // Register ServiceBusClient using the fallback DefaultAzureCredential credentials
    clientBuilder.AddServiceBusClientWithNamespace(
        "<your_namespace>.servicebus.windows.net");
});
```

The associated _appsettings.json_ file:

```json
"Storage": {
    "serviceUri": "<service_uri>",
    "credential": "managedidentity",
    "clientId":  "<clientId>"
}
```

The following credential types also support the `AdditionallyAllowedTenants` property, which specifies additional Microsoft Entra tenants beyond the default tenant for which the credential may acquire tokens:

* [ClientCertificateCredential](#create-a-clientcertificatecredential-type)
* [ClientSecretCredential](#create-a-clientsecretcredential-type)
* [DefaultAzureCredential](#create-a-defaultazurecredential-type)

Add the wildcard value "*" to allow the credential to acquire tokens for any Microsoft Entra tenant the logged in account can access. If no tenant IDs are specified, this option will have no effect on that authentication method, and the credential will acquire tokens for any requested tenant when using that method.

```json
{
    "additionallyAllowedTenants":  "<tenant-ids-separated-by-semicolon>"
}
```

### Create a `ManagedIdentityCredential` type

You can create both user-assigned and system-assigned managed identities using configuration values. Add the following key-value pairs to your _appsettings.json_ file to create an instance of <xref:Azure.Identity.ManagedIdentityCredential?displayProperty=fullName>.

#### User-assigned managed identities

A user-assigned managed identity can be used by providing a client ID, resource ID, or object ID.

## [Client ID](#tab/client-id)

```json
{
    "credential": "managedidentity",
    "clientId":  "<clientId>"
}
```

## [Resource ID](#tab/resource-id)

```json
{
    "credential": "managedidentity",
    "managedIdentityResourceId":  "<managedIdentityResourceId>"
}
```

The resource ID takes the form `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}`.

## [Object ID](#tab/object-id)

```json
{
    "credential": "managedidentity",
    "managedIdentityObjectId":  "<managedIdentityObjectId>"
}    
```

> [!IMPORTANT]
> The `managedIdentityObjectId` JSON property is supported in `Microsoft.Extensions.Azure` versions 1.8.0 and later.

---

#### System-assigned managed identities

```json
{
    "credential": "managedidentity"
}
```

### Create a `WorkloadIdentityCredential` type

Add the following key-value pairs to your _appsettings.json_ file to create an <xref:Azure.Identity.WorkloadIdentityCredential?displayProperty=fullName>:

```json
{
    "credential": "workloadidentity",
    "tenantId":  "<tenantId>",
    "clientId":  "<clientId>",
    "tokenFilePath": "<tokenFilePath>"
}
```

### Create a `ClientSecretCredential` type

Add the following key-value pairs to your _appsettings.json_ file to create an <xref:Azure.Identity.ClientSecretCredential?displayProperty=fullName>:

```json
{
    "tenantId":  "<tenantId>",
    "clientId":  "<clientId>",
    "clientSecret": "<clientSecret>"
}
```

### Create a `ClientCertificateCredential` type

Add the following key-value pairs to your _appsettings.json_ file to create an <xref:Azure.Identity.ClientCertificateCredential?displayProperty=fullName>:

```json
{
    "tenantId":  "<tenantId>",
    "clientId":  "<clientId>",
    "clientCertificate": "<clientCertificate>",
    "clientCertificateStoreLocation": "<clientCertificateStoreLocation>",
    "additionallyAllowedTenants": "<tenant-ids-separated-by-semicolon>"
}
```

> [!NOTE]
> The `clientCertificateStoreLocation` and `additionallyAllowedTenants` key-value pairs are optional. If the keys are present and have empty values, they are ignored. If no `clientCertificateStoreLocation` is specified, the default `CurrentUser` is used from the <xref:System.Fabric.X509Credentials.StoreLocation?displayProperty=nameWithType> enum.

### Create a `DefaultAzureCredential` type

Add the following key-value pairs to your _appsettings.json_ file to create an <xref:Azure.Identity.DefaultAzureCredential?displayProperty=fullName>:

```json
{
    "tenantId":  "<tenantId>",
    "clientId":  "<clientId>",
    "managedIdentityResourceId": "<managedIdentityResourceId>"
}
```
