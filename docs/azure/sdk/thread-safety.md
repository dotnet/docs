---
title: Thread safety with the Azure SDK for .NET
description: Learn about thread safety in Azure SDK client objects and how this design impacts client lifetime management.
ms.date: 05/24/2021
ms.author: pakrym
author: pakrym
---

# Thread safety and client lifetime management for Azure SDK objects

This article helps you understand thread safety issues when using the Azure SDK. It also discusses how the design of the SDK impacts client lifetime management. You'll learn why it's unnecessary to dispose of Azure SDK client objects.

## Thread safety

All Azure SDK client objects are thread-safe and independent of each other. This design ensures that reusing client instances is always safe, even across threads. For example, the following code launches multiple tasks but is thread safe:

```csharp
var client = new SecretClient(
    new Uri("<secrets_endpoint>"), new DefaultAzureCredential());

foreach (var secretName in secretNames)
{
    // Using clients from parallel threads
    Task.Run(() => Console.WriteLine(client.GetSecret(secretName).Value));
}
```

Model objects used by SDK clients, whether input or output models, aren't thread-safe by default. Most use cases involving model objects only use a single thread. Therefore, the cost of implementing synchronization as a default behavior is too high for these objects. The following code illustrates a bug in which accessing a model from multiple threads could cause an undefined behavior:

```csharp
KeyVaultSecret newSecret = client.SetSecret("secret", "value");

foreach (var tag in tags)
{
    // Don't use model type from parallel threads
    Task.Run(() => newSecret.Properties.Tags[tag] = CalculateTagValue(tag));
}

client.UpdateSecretProperties(newSecret.Properties);
```

To access the model from different threads, you must implement your own synchronization code. For example:

```csharp
KeyVaultSecret newSecret = client.SetSecret("secret", "value");

// Code omitted for brevity

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

## Client lifetime

Because Azure SDK clients are thread-safe, there's no reason to construct multiple SDK client objects for a given set of constructor parameters. Treat Azure SDK client objects as singletons once constructed. This recommendation is commonly implemented by registering Azure SDK client objects as singletons in the app's Inversion of Control (IoC) container. Dependency injection (DI) is used to obtain references to the SDK client object. The following example shows a singleton client object registration in an ASP.NET Core app's `Startup.ConfigureServices` method:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();

    var blobServiceClient = new BlobServiceClient(
        new Uri("<secrets_endpoint>"), new DefaultAzureCredential());
    services.AddSingleton(blobServiceClient);

    // Code omitted for brevity
}
```

For more information about implementing DI with the Azure SDK, see [Dependency injection with the Azure SDK for .NET](./dependency-injection.md).

Alternatively, you may create an SDK client instance and provide it to methods that require a client. The point is to avoid unnecessary instantiations of the same SDK client object with the same parameters. It's both unnecessary and wasteful.

## Clients aren't disposable

Two final questions that often come up are:

* Do I need to dispose of Azure SDK client objects when I'm finished using them?
* Why aren't HTTP-based Azure SDK client objects disposable?

Internally, all Azure SDK clients use a single shared `HttpClient` instance. The clients don't create any other resources that need to be actively freed. The shared `HttpClient` instance persists throughout the entire application lifetime.

```csharp
// Both clients reuse the shared HttpClient and don't need to be disposed
var blobClient = new BlobClient(new Uri(sasUri));
var blobClient2 = new BlobClient(new Uri(sasUri2));
```

It's possible to provide a custom instance of `HttpClient` to an Azure SDK client object. In this case, you become responsible for managing the `HttpClient` lifetime and properly disposing of it at the right time.

```csharp
var httpClient = new HttpClient();

var clientOptions = new BlobClientOptions()
{
    Transport = new HttpClientTransport(httpClient)
};

// Both clients would use the HttpClient instance provided in clientOptions
var blobClient = new BlobClient(new Uri(sasUri), clientOptions);
var blobClient2 = new BlobClient(new Uri(sasUri2), clientOptions);

// Code omitted for brevity

// You're responsible for properly disposing httpClient some time later
httpClient.Dispose();
```

Further guidance for properly managing and disposing of `HttpClient` instances can be found in the <xref:System.Net.Http.HttpClient> documentation.

## See also

- [Dependency injection with the Azure SDK for .NET](./dependency-injection.md)
- [Dependency injection in .NET](../../core/extensions/dependency-injection.md)
