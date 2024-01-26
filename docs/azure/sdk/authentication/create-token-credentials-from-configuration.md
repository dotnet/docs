---
title: Create token credentials from configuration
description: This article describes how to create Microsoft Entra token credentials from configuration files.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23
ms.date: 1/16/2024
---

# Create Microsoft Entra credential types using configuration files

The `Microsoft.Extensions.Azure` library supports creating different <xref:Azure.Core.TokenCredential?displayProperty=fullName> types from values defined in _appsettings.json_ and other configuration files. This article describes the support for different `TokenCredential` types and how to configure the required values for each type.

## Support for Azure credentials through configuration

The [`Microsoft.Extensions.Azure`](https://www.nuget.org/packages/Microsoft.Extensions.Azure) library can automatically provide Azure service clients with a `TokenCredential` class by searching _appsettings.json_ or other configuration files for credential values using the `IConfiguration` abstraction for .NET. This approach allows developers to explicitly set credential values across different environments through configuration rather than through app code directly.

The following credential types are supported via configuration:

* [ClientCertificateCredential](#create-a-clientcertificatecredential-type)
* [ClientSecretCredential](#create-a-clientsecretcredential-type)
* [DefaultAzureCredential](#create-a-defaultazurecredential-type)
* [ManagedIdentityCredential](#create-a-managedidentitycredential-type)
* [WorkloadIdentityCredential](#create-a-workloadidentitycredential-type)

## Configure Azure credentials

Azure service clients registered with the `AddAzureClients` method are automatically configured with an instance of `DefaultAzureCredential` if no explicit credential is supplied via the `WithCredential` extension method. You can also override the global `DefaultAzureCredential` using credential values from configuration files when registering a client:

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
    "clientid":  "<clientId>"
}
```

### Create a `ManagedIdentityCredential` type

You can create both user-assigned and system-assigned managed identities using configuration values. Add the following configuration values to your _appsettings.json_ file to create an <xref:Azure.Identity.ManagedIdentityCredential?displayProperty=fullName>.

#### User-assigned identities

1. Specify a user-assigned managed identity via a client ID:

    ```json
    {
        "credential": "managedidentity",
        "clientId":  "<clientId>"
    }
    ```

1. Specify a user-assigned managed identity via a resource ID:

    ```json
    {
        "credential": "managedidentity",
        "managedIdentityResourceId":  "<managedIdentityResourceId>"
    }
    ```

    The resource ID takes the form `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}`.

#### System-assigned identities

1. Configure managed identity with a system-assigned identity:

    ```json
    {
        "credential": "managedidentity"
    }
    ```

### Create a `WorkloadIdentityCredential` type

Add the following configuration values to your _appsettings.json_ file to create an <xref:Azure.Identity.WorkloadIdentityCredential?displayProperty=fullName>:

```json
{
    "credential": "workloadidentity",
    "tenantId":  "<tenantId>",
    "clientId":  "<clientId>",
    "tokenFilePath": "<tokenFilePath>"
}
```

### Create a `ClientSecretCredential` type

Add the following configuration values to your _appsettings.json_ file to create an <xref:Azure.Identity.ClientSecretCredential?displayProperty=fullName>:

```json
{
    "tenantId":  "<tenantId>",
    "clientId":  "<clientId>",
    "clientSecret": "<clientSecret>"
}
```

### Create a `ClientCertificateCredential` type

Add the following configuration values to your _appsettings.json_ file to create an <xref:Azure.Identity.ClientCertificateCredential?displayProperty=fullName>:

```json
{
    "tenantId":  "<tenantId>",
    "clientId":  "<clientId>",
    "clientCertificate": "<clientCertificate>",
    "clientCertificateStoreLocation": "<clientCertificateStoreLocation>",
    "additionallyAllowedTenants": "<additionallyAllowedTenants>"
}
```

> [!NOTE]
> The `clientCertificateStoreLocation` and `additionallyAllowedTenants` values are optional.

### Create a `DefaultAzureCredential` type

Add the following configuration values to your _appsettings.json_ file to create an <xref:Azure.Identity.DefaultAzureCredential?displayProperty=fullName>:

```json
{
    "tenantId":  "<tenantId>",
    "clientId":  "<clientId>",
    "managedIdentityResourceId": "<managedIdentityResourceId>"
}
```
