---
title: Authenticate with the Azure libraries for .NET
description: Authenticate into the Azure libraries for .NET
ms.date: 08/22/2018
---

# Authenticate with the Azure Libraries for .NET

## Connect to services with connection strings

Most Azure service libraries require a connection string or keys for authentication. For example, SQL Database uses a standard SQL connection string:

```csharp
var builder = new SqlConnectionStringBuilder();
builder.DataSource = "example.database.windows.net";
builder.InitialCatalog = "MyDatabase";
builder.UserID = "sampleuser@example"; // Format user ID as "user@server"
builder.Password = password;
builder.Encrypt = true;
builder.TrustServerCertificate = true;
                
using (var conn = new SqlConnection(builder.ConnectionString))
{
    conn.Open();
    // Do things with the connection...
    // ...
}
```

Azure Storage uses a storage key:

```csharp
string storageConnectionString = "DefaultEndpointsProtocol=https;"
        + "AccountName=" + storageName
        + ";AccountKey=" + storageKey
        + ";EndpointSuffix=core.windows.net";

var account = CloudStorageAccount.Parse(storageConnectionString);
// Do things with the account here...
```

Service connection strings are used in other Azure services like [CosmosDB](/azure/documentdb/documentdb-dotnet-application#a-nametoc395637769astep-5-wiring-up-azure-cosmos-db), [Azure Cache for Redis](/azure/azure-cache-for-redis/cache-dotnet-how-to-use-azure-redis-cache), and [Service Bus](/azure/service-bus-messaging/service-bus-dotnet-get-started-with-queues) and you can get those strings using the Azure portal, CLI, or PowerShell.  You can also use the Azure management libraries for .NET to query resources to build connection strings in your code. 

This snippet uses the management libraries to create a storage account connection string:

```csharp
// Get a storage account
var storage = azure.StorageAccounts.GetByResourceGroup("myResourceGroup", "myStorageAccount");

// Extract the keys
var storageKeys = storage.GetKeys();

// Build the connection string
string storageConnectionString = "DefaultEndpointsProtocol=https;"
        + "AccountName=" + storage.Name
        + ";AccountKey=" + storageKeys[0].Value
        + ";EndpointSuffix=core.windows.net";

// Connect
var account = CloudStorageAccount.Parse(storageConnectionString);

// Do things with the account here...
```

Other libraries require your application to run with a [service principal](https://docs.microsoft.com/azure/active-directory/develop/active-directory-application-objects) authorizing the application to run with granted credentials. This configuration is similar to the object-based authentication steps for the management library listed below.

## <a name="mgmt-auth"></a>Azure management libraries for .NET authentication

[!include[Create service principal](includes/create-sp.md)]

Now that the service principal is created, two options are available to authenticate to the service principal to create and manage resources.

For both options you will need to add the following NuGet packages to your project.

```powershell
Install-Package Microsoft.Azure.Management.Fluent
Install-Package Microsoft.Azure.Management.ResourceManager.Fluent
```

### Authenticate with token credentials

The first method is to build the token credential object in code.  You should store the credentials securely in a configuration file, the registry, or Azure KeyVault.

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

### <a name="mgmt-file"></a>File-based authentication

File-based authentication allows you to put the service principal credentials in a plain text file and secure it within the file system.

[!include[File-based authentication](includes/file-based-auth.md)]

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
