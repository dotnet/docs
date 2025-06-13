---
title: Create Azure Identity library credentials via configuration files
description: Learn how to create token credentials from configuration files.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23
ms.date: 06/13/2025
---

# Create Azure Identity library credentials via configuration files

The [Azure client library integration for ASP.NET Core](/dotnet/api/overview/azure/microsoft.extensions.azure-readme?view=azure-dotnet&preserve-view=true) (`Microsoft.Extensions.Azure`) supports creating different <xref:Azure.Core.TokenCredential?displayProperty=fullName> types from key-value pairs defined in _appsettings.json_ and other configuration files. The credentials correspond to a subset of the [credential classes](/dotnet/api/overview/azure/identity-readme?view=azure-dotnet&preserve-view=true#credential-classes) in the Azure Identity client library. This article describes the support for different `TokenCredential` types and how to configure the required key-value pairs for each type.

## Support for Azure credentials through configuration

`Microsoft.Extensions.Azure` can automatically provide Azure service clients with a `TokenCredential` class by searching _appsettings.json_ or other configuration files for credential values using the `IConfiguration` abstraction for .NET. This approach allows developers to explicitly set credential values across different environments through configuration rather than through app code directly.

The following credentials can be created via configuration:

* [AzurePipelinesCredential](#create-an-instance-of-azurepipelinescredential)
* [ClientCertificateCredential](#create-an-instance-of-clientcertificatecredential)
* [ClientSecretCredential](#create-an-instance-of-clientsecretcredential)
* [DefaultAzureCredential](#create-an-instance-of-defaultazurecredential)
* [ManagedIdentityCredential](#create-an-instance-of-managedidentitycredential)
* [WorkloadIdentityCredential](#create-an-instance-of-workloadidentitycredential)

## Configure Azure credentials

Azure service clients registered with the <xref:Microsoft.Extensions.Azure.AzureClientServiceCollectionExtensions.AddAzureClients%2A> method are automatically configured with an instance of `DefaultAzureCredential` if no explicit credential is supplied via the <xref:Microsoft.Extensions.Azure.AzureClientBuilderExtensions.WithCredential%2A> extension method. You can also override the global `DefaultAzureCredential` using credential values from configuration files when registering a client to create a specific credential:

```csharp
builder.Services.AddAzureClients(clientBuilder =>
{
    // Register BlobServiceClient using credential from appsettings.json
    clientBuilder.AddBlobServiceClient(builder.Configuration.GetSection("Storage"));

    // Register ServiceBusClient using the fallback DefaultAzureCredential
    clientBuilder.AddServiceBusClientWithNamespace(
        "<your_namespace>.servicebus.windows.net");
});
```

The associated _appsettings.json_ file:

```json
"Storage": {
    "serviceUri": "<service_uri>",
    "credential": "managedidentity",
    "clientId": "<client_id>"
}
```

The following credentials also support the `AdditionallyAllowedTenants` property, which specifies Microsoft Entra tenants beyond the default tenant for which the credential can acquire tokens:

* [AzurePipelinesCredential](#create-an-instance-of-azurepipelinescredential)
* [ClientCertificateCredential](#create-an-instance-of-clientcertificatecredential)
* [ClientSecretCredential](#create-an-instance-of-clientsecretcredential)
* [DefaultAzureCredential](#create-an-instance-of-defaultazurecredential)
* [WorkloadIdentityCredential](#create-an-instance-of-workloadidentitycredential)

Add the wildcard value `*` to allow the credential to acquire tokens for any Microsoft Entra tenant the logged in account can access. If no tenant IDs are specified, this option has no effect on that authentication method, and the credential will acquire tokens for any requested tenant when using that method.

```json
{
    "additionallyAllowedTenants": "<tenant_ids_separated_by_semicolon>"
}
```

### Create an instance of `ManagedIdentityCredential`

You can configure a credential to utilize a managed identity in the following ways using configuration values:

- System-assigned managed identity
- User-assigned managed identity
- Managed identity as a federated identity credential

To create an instance of <xref:Azure.Identity.ManagedIdentityCredential?displayProperty=fullName>, add the following key-value pairs to your _appsettings.json_ file.

#### System-assigned managed identity

```json
{
    "credential": "managedidentity"
}
```

#### User-assigned managed identity

A user-assigned managed identity can be used by providing a client ID, resource ID, or object ID.

## [Client ID](#tab/client-id)

```json
{
    "credential": "managedidentity",
    "managedIdentityClientId": "<managed_identity_client_id>"
}
```

## [Resource ID](#tab/resource-id)

```json
{
    "credential": "managedidentity",
    "managedIdentityResourceId": "<managed_identity_resource_id>"
}
```

The resource ID takes the form
`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}`

## [Object ID](#tab/object-id)

```json
{
    "credential": "managedidentity",
    "managedIdentityObjectId": "<managed_identity_object_id>"
}    
```

> [!IMPORTANT]
> The `managedIdentityObjectId` JSON property is supported in `Microsoft.Extensions.Azure` versions 1.8.0 and later.

---

#### Managed identity as a federated identity credential

The [managed identity as a federated identity credential](/entra/workload-id/workload-identity-federation-config-app-trust-managed-identity?tabs=microsoft-entra-admin-center%2Cdotnet) feature is supported in `Microsoft.Extensions.Azure` versions 1.12.0 and later. The feature doesn't work with system-assigned managed identity. A user-assigned managed identity can be used by providing a client ID, resource ID, or object ID.

## [Client ID](#tab/client-id)

```json
{
    "credential": "managedidentityasfederatedidentity",
    "azureCloud": "<azure_cloud>",
    "tenantId": "<tenant_id>",
    "clientId": "<client_id>",
    "managedIdentityClientId": "<managed_identity_client_id>"
}
```

## [Resource ID](#tab/resource-id)

```json
{
    "credential": "managedidentityasfederatedidentity",
    "azureCloud": "<azure_cloud>",
    "tenantId": "<tenant_id>",
    "clientId": "<client_id>",
    "managedIdentityResourceId": "<managed_identity_resource_id>"
}
```

The resource ID takes the form
`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}`

## [Object ID](#tab/object-id)

```json
{
    "credential": "managedidentityasfederatedidentity",
    "azureCloud": "<azure_cloud>",
    "tenantId": "<tenant_id>",
    "clientId": "<client_id>",
    "managedIdentityObjectId": "<managed_identity_object_id>"
}
```

---

The `azureCloud` key value is used to set the Microsoft Entra access token scope. It can be one of the following values:

- `public` for Azure Public Cloud
- `usgov` for Azure US Government Cloud
- `china` for Azure operated by 21Vianet

### Create an instance of `AzurePipelinesCredential`

To create an instance of <xref:Azure.Identity.AzurePipelinesCredential?displayProperty=fullName>, add the following key-value pairs to your _appsettings.json_ file:

```json
{
    "credential": "azurepipelines",
    "clientId": "<client_id>",
    "tenantId": "<tenant_id>",
    "serviceConnectionId": "<service_connection_id>",
    "systemAccessToken": "<system_access_token>"
}
```

> [!IMPORTANT]
> `AzurePipelinesCredential` is supported in `Microsoft.Extensions.Azure` versions 1.11.0 and later.

### Create an instance of `WorkloadIdentityCredential`

To create an instance of <xref:Azure.Identity.WorkloadIdentityCredential?displayProperty=fullName>, add the following key-value pairs to your _appsettings.json_ file:

```json
{
    "credential": "workloadidentity",
    "tenantId": "<tenant_id>",
    "clientId": "<client_id>",
    "tokenFilePath": "<token_file_path>"
}
```

### Create an instance of `ClientSecretCredential`

To create an instance of <xref:Azure.Identity.ClientSecretCredential?displayProperty=fullName>, add the following key-value pairs to your _appsettings.json_ file:

```json
{
    "tenantId": "<tenant_id>",
    "clientId": "<client_id>",
    "clientSecret": "<client_secret>"
}
```

### Create an instance of `ClientCertificateCredential`

To create an instance of <xref:Azure.Identity.ClientCertificateCredential?displayProperty=fullName>, add the following key-value pairs to your _appsettings.json_ file:

```json
{
    "tenantId": "<tenant_id>",
    "clientId": "<client_id>",
    "clientCertificate": "<client_certificate>",
    "clientCertificateStoreLocation": "<client_certificate_store_location>"
}
```

> [!NOTE]
> The `clientCertificateStoreLocation` key is optional. If the key:
>
> * Is present and has an empty value, it's ignored.
> * Isn't present, the default `CurrentUser` is used from the <xref:System.Fabric.X509Credentials.StoreLocation?displayProperty=nameWithType> enum.

### Create an instance of `DefaultAzureCredential`

To create an instance of <xref:Azure.Identity.DefaultAzureCredential?displayProperty=fullName>, add the following key-value pairs to your _appsettings.json_ file:

```json
{
    "tenantId": "<tenant_id>",
    "clientId": "<client_id>",
    "managedIdentityResourceId": "<managed_identity_resource_id>"
}
```
