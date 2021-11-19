---
title: Understanding Authentication in the Azure libraries for .NET
description: Explains the different ways of authenticating with the Azure SDK for .NET.
ms.date: 06/19/2020
ms.custom: devx-track-dotnet
---

# Authenticate with the Azure SDK for .NET

## Recommended: Azure.Identity

The latest packages in the Azure SDK for .NET use a common authentication package to authenticate, `Azure.Identity`. Using `Azure.Identity` is recommended over other authentication mechanisms described later in this document. Packages supporting the credentials provided by `Azure.Identity` are built on top of `Azure.Core` and have package identifiers starting with *Azure*. [See the package list](packages.md) for an inventory of packages that use `Azure.Core`.

For complete instructions on using `Azure.Identity` in your project, see the documentation for [Azure Identity client for .NET](/dotnet/api/overview/azure/identity-readme).

> [!TIP]
> See the [Azure Identity, Resource Management, and Storage sample](/samples/dotnet/samples/azure-identity-resource-management-storage/) for examples of using Azure Identity to manage and access Azure resources.

To authenticate with libraries that don't support Azure.Identity, see the rest of this topic.

## Access Azure resources

To interact with Azure resources, such as retrieving a secret from Key Vault or storing a blob in Storage, many Azure service libraries require a connection string or keys for authentication. For example, SQL Database uses a [standard SQL connection string](/azure/azure-sql/database/connect-query-dotnet-core). Service connection strings are used in other Azure services like [CosmosDB](/azure/cosmos-db/), [Azure Cache for Redis](/azure/azure-cache-for-redis/cache-dotnet-how-to-use-azure-redis-cache), and [Service Bus](/azure/service-bus-messaging/service-bus-dotnet-get-started-with-queues). You can get those strings using the Azure portal, CLI, or PowerShell. You can also use the Azure management libraries for .NET to query resources to build connection strings in your code.

The methods for using a connection string vary by product. [Refer to the documentation for your Azure product](/azure/?product=featured).

## Manage Azure resources

[!include[Create service principal](../includes/create-sp.md)]

Now that the service principal is created, two options are available to authenticate to the service principal to create and manage resources.

For both options you will need to add the following NuGet packages to your project.

```powershell
Install-Package Microsoft.Azure.Management.Fluent
Install-Package Microsoft.Azure.Management.ResourceManager.Fluent
```

### Authenticate with token credentials

The first method is to build the token credential object in code. You should store the credentials securely in a configuration file, the registry, or Azure KeyVault.

```csharp
var credentials = SdkContext.AzureCredentialsFactory
    .FromServicePrincipal(clientId,
        clientSecret,
        tenantId,
        AzureEnvironment.AzureGlobalCloud);
```

Use the *clientId*, *clientSecret*, and *tenantId* values from the JSON output when you created the service principal.

Then create the entry point `Azure` object to start working with the API:

```csharp
var azure = Microsoft.Azure.Management.Fluent.Azure
    .Configure()
    .Authenticate(credentials)
    .WithDefaultSubscription();
```

It is recommended that you explicitly provide the *subscriptionId* from the JSON output to the `Azure` object:

```csharp
var azure = Microsoft.Azure.Management.Fluent.Azure
    .Configure()
    .Authenticate(credentials)
    .WithSubscription(subscriptionId);
```

### <a name="mgmt-file"></a>File-based authentication

File-based authentication allows you to put the service principal credentials in a plain text file and secure it within the file system.

[!include[File-based authentication](../includes/file-based-auth.md)]

Read the contents of the file and create the entry point `Azure` object to start working with the API:

```csharp
// pull in the location of the authentication properties file from the environment
var credentials = SdkContext.AzureCredentialsFactory
    .FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

var azure = Microsoft.Azure.Management.Fluent.Azure
    .Configure()
    .Authenticate(credentials)
    .WithDefaultSubscription();
```
