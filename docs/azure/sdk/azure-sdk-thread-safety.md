---
title: Azure SDK thread safety
description: This article discusses how Azure SDK client objects are designed to be thread safe and how this design impacts client lifetime management (client objects can be singletons) and why it is unnecessary to dispose of SDK client objects after using them.
ms.date: 05/24/2021
ms.author: pakrym
author: pakrym
---

# Thread safety and client lifetime management for Azure SDK objects

This article is designed to help you understand thread safety issues when using the Azure SDK. It also discusses how the design of the SDK impacts client lifetime management and why it's unnecessary to dispose of Azure SDK client objects.

## Thread safety

All Azure SDK client objects are thread-safe and independent of each other. This ensures that reusing client instances is always safe, even across threads. For example, the following code launches multiple tasks but is thread safe:

```csharp
var client = new SecretClient(new Uri("<secrets_endpoint>"), new DefaultAzureCredential());

foreach (var secretName in secretNames)
{
    // Using clients from parallel threads
    Task.Run(() => Console.WriteLine(client.GetSecret(secretName).Value));
}
```

Model objects used by SDK clients, whether input or output models are *not* thread-safe by default.  Most use cases involving model objects only involve a single thread, making the cost of implementing synchronization as a default behavior too high for these objects. The following sample illustrates a bug where accessing a model from multiple threads could cause an undefined behavior.

```csharp
KeyVaultSecret newSecret = client.SetSecret("secret", "value");

foreach (var tag in tags)
{
    // Don't use model type from parallel threads
    Task.Run(() => newSecret.Properties.Tags[tag] = CalculateTagValue(tag));
}

client.UpdateSecretProperties(newSecret.Properties);

```

If you need to access the model from different threads, you must implement your own synchronization code.

```csharp
KeyVaultSecret newSecret = client.SetSecret("secret", "value");

foreach (var tag in tags)
{
    Task.Run(() =>
    {
        lock (newSecret)
        {
            newSecret.Properties.Tags[tag] = CalculateTagValue(tag);
        }
    );
}

client.UpdateSecretProperties(newSecret.Properties);
```

## Client Lifetime

Because Azure SDK clients are thread-safe, there is no reason to construct multiple SDK client objects for a given set of constructor parameters. Therefore, you should treat Azure SDK client objects as singletons once constructed.  This is most commonly implemented by registering Azure SDK client objects as singletons in the application's IoC container and using dependency injection to pass out references to the SDK client object.  The following example shows how this is done in an ASP.NET Core application with the built-in IoC container.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();

    var blobServiceClient = new BlobServiceClient(new Uri("<secrets_endpoint>"), new DefaultAzureCredential());                   
    services.AddSingleton(blobServiceClient);
          
    // Additional code ...
}

```

For more information about implementing dependency injection with the Azure SDK, refer to the article [Dependency injection with the Azure .NET SDK](./dependency-injection.md).

Alternatively, you may also create the instance of an SDK client and pass it around as a parameter to methods in need of a client. The point is, avoid unnecessary instantiations of the same SDK client object with the same parameters as it's unnecessary and wasteful.

## Clients are not disposable

Two final questions that often come up are:

* Do I need to dispose of Azure SDK client objects when I'm finished using them?
* Why aren't HTTP-based Azure SDK client objects disposable?

Internally, all Azure SDK clients use a single shared `HttpClient` instance. The clients don't create any other resources that need to be actively freed. The shared `HttpClient` instance persists throughout the entire application lifetime.

```csharp
// Both clients reuse the shared HttpClient and don't need to be disposed
var blobClient = new BlobClient(new Uri(sasUri));
var blobClient2 = new BlobClient(new Uri(sasUri2));
```

It is possible to provide a custom instance of `HttpClient` to an Azure SDK client object.  In this case, then you become responsible for managing the `HttpClient` lifetime and properly disposing of it at the right time.  

```csharp
var httpClient = new HttpClient();

var clientOptions = new BlobClientOptions()
{
    Transport = new HttpClientTransport(httpClient)
}

// Both client would use the HttpClient instance provided in clientOptions
var blobClient = new BlobClient(new Uri(sasUri), clientOptions);
var blobClient2 = new BlobClient(new Uri(sasUri2), clientOptions);

// ...

// you are responsible for properly disposing httpClient some time later
httpClient.Dispose();
```

Further guidance for properly managing and disposing of `HttpClient` instances can be found in the <xref:System.Net.Http.HttpClient> documentation.

## See also

- [Lifetime management for Azure SDK .NET clients (Azure SDK blog)](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
- [Best practices for using Azure SDK with ASP.NET Core (Azure SDK blog)](https://devblogs.microsoft.com/azure-sdk/best-practices-for-using-azure-sdk-with-asp-net-core/)
- [Dependency injection with the Azure .NET SDK](./dependency-injection.md)
- [Dependency injection in .NET](/dotnet/core/extensions/dependency-injection)
