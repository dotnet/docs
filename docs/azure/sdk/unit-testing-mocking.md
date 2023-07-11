---
title: Unit testing and mocking with the Azure SDK for .NET
description: Learn techniques and tools for unit testing and mocking the Azure SDK for .NET
ms.custom: devx-track-dotnet, engagement-fy23
ms.date: 07/05/2023
---

# Unit testing and mocking with the Azure SDK for .NET

Unit testing is an important part of a sustainable development process that can improve code quality and prevent regressions or bugs in your apps. However, unit testing presents challenges when the code you're testing performs network calls to Azure resources. Tests that run against live services can experience issues, such as latency that slows down test execution, dependencies on code outside of the isolated test, and issues with managing service state and costs every time the test is run. Instead of testing against live Azure services, replace the service clients with mocked or in-memory implementations. This avoids the above issues and lets developers focus on testing their application logic, independent from the network and service.

In this article, you'll learn how to write unit tests for the Azure SDK for .NET that isolate your dependencies to make your tests more reliable. You'll also learn how to replace key components with in-memory test implementations to create fast and reliable unit tests, and see how to design your own classes to better support unit testing. This article includes examples that use [Moq](https://www.nuget.org/packages/moq/), which is a popular mocking and testing library for .NET.

## Understand service clients

A service client class is the main entry point for developers in an Azure SDK library and implements most of the logic to communicate with the Azure service. When unit testing service client classes, it's important to be able to create an instance of the client that behaves as expected without making any network calls.

Each of the Azure SDK clients follows mocking guidelines that allow their behavior to be overridden:

* Each client offers at least one protected constructor to allow inheritance for testing.
* All public client members are virtual to allow overriding.

> [!NOTE]
> The code examples in this article use types from the [`Azure.Security.KeyVault.Secrets`](https://www.nuget.org/packages/Azure.Security.KeyVault.Secrets/) library for the Azure Key Vault service. The concepts demonstrated in this article also apply to service clients from many other Azure services, such as Azure Storage or Azure Service Bus.

To create a test service client, you can either use a mocking library such as [Moq](https://www.nuget.org/packages/moq/) or standard C# features such as inheritance. Mocking frameworks allow you to simplify the code that you must write to override member behavior (as well as other useful features that are beyond the scope of this article).

# [Moq](#tab/moq)

```csharp
KeyVaultSecret keyVaultSecret = SecretModelFactory.KeyVaultSecret(
    new SecretProperties("secret"), "secretValue");
Mock<SecretClient> clientMock = new Mock<SecretClient>();
clientMock.Setup(c => c.GetSecret(
        It.IsAny<string>(),
        It.IsAny<string>(),
        It.IsAny<CancellationToken>())
    )
    .Returns(Response.FromValue(keyVaultSecret, Mock.Of<Response>()));

clientMock.Setup(c => c.GetSecretAsync(
        It.IsAny<string>(), 
        It.IsAny<string>(), 
        It.IsAny<CancellationToken>())
    )
    .ReturnsAsync(Response.FromValue(keyVaultSecret, Mock.Of<Response>()));

SecretClient secretClient = clientMock.Object;
```

# [C#](#tab/csharp)

To create a test client instance using C# without a library, inherit from the client type and override methods you are calling in your code with an implementation that returns a set of test objects. Most clients contain both synchronous and asynchronous methods for operations; override only the one your application code is calling.

> [!NOTE]
> It can be cumbersome to manually define test classes, especially if you need to customize behavior differently for each test. Consider using a library like Moq to streamline your testing.

```csharp
public class MockSecretClient : SecretClient 
{
    public override Response<KeyVaultSecret> GetSecret(
        string name,
        string version = null, 
        CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
        
    public override Task<Response<KeyVaultSecret>> GetSecretAsync(
        string name, 
        string version = null, 
        CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}

SecretClient secretClient = new MockSecretClient();
```

---

### Service client input and output models

Model types hold the data being sent and received from Azure services. There are two main kinds of models:

* **Input models** are intended to be created and passed as parameters to service methods by developers. They have one or more public constructors and writeable properties.
* **Output models** are only returned by the service and have neither public constructors nor writeable properties.

To create a test instance of an input model use one of the available public constructors and set the additional properties you need.

```csharp
SecretProperties secretProperties = new("secret")
{
    NotBefore = DateTimeOffset.Now
};
```

To create instances of output models, a model factory is used. Most Azure SDK client libraries provide a static model factory class that ends in `ModelFactory` and contains a set of static methods to initialize the library's output model types.

```C#
KeyVaultSecret keyVaultSecret = SecretModelFactory.KeyVaultSecret(
    new SecretProperties("secret"), "secretValue");
```

> [!NOTE]
> Some input models have read-only properties that are only populated when the model is returned by the service. In this case, a model factory method will be available that allows setting these properties. See <xref:Azure.Security.KeyVault.Secrets.SecretModelFactory>.

```csharp
// CreatedOn is a read-only property and can only be 
// set via a model factory SecretProperties.
secretPropertiesWithCreatedOn = SecretModelFactory.SecretProperties(
    name: "secret", createdOn: DateTimeOffset.Now);
```

## Explore response types

The <xref:Azure.Response> class is an abstract class that represents an HTTP response and is a part of almost all types returned by service client methods. You can create test `Response` instances using either the Moq library or standard C# inheritence.

## [Moq](#tab/moq)

The Moq library provides concise functionality for setting up mock responses:

```csharp
Mock responseMock = new Mock();
responseMock.SetupGet(r => r.Status).Returns(200);

Response response = responseMock.Object;
```

To create an instance of Response without defining any behaviors:

```csharp
Response response = Mock.Of<Response>();
```

## [C#](#tab/csharp)

The Response class is abstract, which means there are a lot of members to override. Consider using the Moq library to streamline your approach.

```csharp
public class TestResponse : Response
{
    protected override bool TryGetHeader(string name, out string value)
        => throw new NotImplementedException();
    protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
        => throw new NotImplementedException();
         
    protected override bool ContainsHeader(string name) => throw new NotImplementedException();
    protected override IEnumerable<HttpHeader> EnumerateHeaders() 
        => throw new NotImplementedException();

    public override int Status => throw new NotImplementedException();
    public override string ReasonPhrase => throw new NotImplementedException();
    public override Stream ContentStream => throw new NotImplementedException();
    public override string ClientRequestId => throw new NotImplementedException();

    public override void Dispose() => throw new NotImplementedException();
}
```

---

Some services also support using the <xref:Azure.Response%601> type, which is a class that contains a model and the HTTP response that returned it. To create a test instance of `Response<T>` use the static `Response.FromValue` method:

## [Moq](#tab/moq)

```csharp
KeyVaultSecret keyVaultSecret = SecretModelFactory.KeyVaultSecret(
    new SecretProperties("secret"), "secretValue");
Response response = Response.FromValue(keyVaultSecret, new TestResponse());
```

## [C#](#tab/csharp)

```csharp
KeyVaultSecret keyVaultSecret = SecretModelFactory.KeyVaultSecret(
    new SecretProperties("secret"), "secretValue");
Response<KeyVaultSecret> response = Response.FromValue(
    keyVaultSecret, Mock.Of<Response>());
```

---

### Explore paging

The <xref:Azure.Page%601> class is used as a building block in service methods that invoke operations returning results in multiple pages. The `Page<T>` is rarely returned from APIs directly but is useful to create the `AsyncPageable<T>` and `Pageable<T>` instances in the next section. To create a `Page<T>` instance, use the `Page<T>.FromValues` method, passing a list of items, a continuation token, and the Response.

The `continuationToken` parameter is used to retrieve the next page from the service. For unit testing purposes, it should be set to null for the last page and should be non-empty for other pages.

## [Moq](#tab/moq)

```csharp
Page<SecretProperties> responsePage = Page<SecretProperties>.FromValues(
    new[] {
        new SecretProperties("secret1"),
        new SecretProperties("secret2")
    },
    continuationToken: null,
    Mock.Of<Response>());
```

## [C#](#tab/csharp)

```csharp
Page responsePage = Page.FromValues(
    new[]
    {
        new SecretProperties("secret1"),
        new SecretProperties("secret2")
    }, 
    continuationToken: null,
    new TestResponse());
```

---

<xref:Azure.AsyncPageable%601> and <xref:Azure.Pageable%601> are classes that represent collections of models returned by the service in pages. The only difference between them is that one is used with synchronous methods while the other is used with asynchronous methods.

To create a test instance of `Pageable` or `AsyncPageable`, use the `FromPages` static method:

```csharp
Page page1 = Page.FromValues(
    new[]
    {
        new SecretProperties("secret1"),
        new SecretProperties("secret2")
    },
    "continuationToken",
    Mock.Of<Response>());

Page page2 = Page.FromValues(
    new[]
    {
        new SecretProperties("secret3"),
        new SecretProperties("secret4")
    },
    "continuationToken2",
    Mock.Of<Response>());

Page lastPage = Page.FromValues(
    new[]
    {
        new SecretProperties("secret5"),
        new SecretProperties("secret6")
    },
    continuationToken: null,
    Mock.Of<Response>());

Pageable pageable = Pageable.FromPages(new[] { page1, page2, lastPage });
AsyncPageable asyncPageable = AsyncPageable.FromPages(new[] { page1, page2, lastPage });
```

## Write a mocked unit test

Suppose your app contains a class that finds the names of keys that will expire within a given amount of time.

```csharp
using Azure.Security.KeyVault.Secrets;

public class AboutToExpireSecretFinder
{
    private readonly TimeSpan _threshold;
    private readonly SecretClient _client;

    public AboutToExpireSecretFinder(TimeSpan threshold, SecretClient client)
    {
        _threshold = threshold;
        _client = client;
    }

    public async Task<string[]> GetAboutToExpireSecrets()
    {
        List<string> secretsAboutToExpire = new();

        await foreach (var secret in _client.GetPropertiesOfSecretsAsync())
        {
            if (secret.ExpiresOn.HasValue &&
                secret.ExpiresOn.Value - DateTimeOffset.Now <= _threshold)
            {
                secretsAboutToExpire.Add(secret.Name);
            }
        }

        return secretsAboutToExpire.ToArray();
    }
}
```

You want to test the following behaviors of the `AboutToExpireSecretFinder` to ensure they continue working as expected:

* Secrets that don't have an expiry date set are not returned.
* Secrets with an expiry date closer to the current date than the threshold are returned.

When unit testing you only want the unit tests to verify the application logic and not whether the Azure service or SDK works correctly. The following example tests the key behaviors using the popular xUnit framework for C#:

```csharp
using Azure;
using Azure.Security.KeyVault.Secrets;
using Moq;
using Xunit;

public class AboutToExpireSecretFinderTests
{
    [Fact]
    public async Task DoesNotReturnNonExpiringSecrets()
    {
        // Arrange
        // Create a page of enumeration results
        Page<SecretProperties> page = Page<SecretProperties>.FromValues(new[]
        {
            new SecretProperties("secret1") { ExpiresOn = null },
            new SecretProperties("secret2") { ExpiresOn = null }
        }, null, Mock.Of<Response>());

        // Create a pageable that consists of a single page
        AsyncPageable<SecretProperties> pageable = AsyncPageable<SecretProperties>.FromPages(new[] { page });

        // Setup a client mock object to return the pageable when GetPropertiesOfSecretsAsync is called
        var clientMock = new Mock<SecretClient>();
        clientMock.Setup(c => c.GetPropertiesOfSecretsAsync(It.IsAny<CancellationToken>()))
            .Returns(pageable);

        // Create an instance of a class to test passing in the mock client
        var finder = new AboutToExpireSecretFinder(TimeSpan.FromDays(2), clientMock.Object);

        // Act
        var soonToExpire = await finder.GetAboutToExpireSecrets();

        // Assert
        Assert.Empty(soonToExpire);
    }

    [Fact]
    public async Task ReturnsSecretsThatExpireSoon()
    {
        // Arrange

        // Create a page of enumeration results
        DateTimeOffset now = DateTimeOffset.Now;
        Page<SecretProperties> page = Page<SecretProperties>.FromValues(new[]
        {
            new SecretProperties("secret1") { ExpiresOn = now.AddDays(1) },
            new SecretProperties("secret2") { ExpiresOn = now.AddDays(2) },
            new SecretProperties("secret3") { ExpiresOn = now.AddDays(3) }
        }, null, Mock.Of<Response>());

        // Create a pageable that consists of a single page
        AsyncPageable<SecretProperties> pageable = AsyncPageable<SecretProperties>.FromPages(new[] { page });

        // Setup a client mock object to return the pageable when GetPropertiesOfSecretsAsync is called
        var clientMock = new Mock<SecretClient>();
        clientMock.Setup(c => c.GetPropertiesOfSecretsAsync(It.IsAny<CancellationToken>()))
            .Returns(pageable);

        // Create an instance of a class to test passing in the mock client
        var finder = new AboutToExpireSecretFinder(TimeSpan.FromDays(2), clientMock.Object);

        // Act
        var soonToExpire = await finder.GetAboutToExpireSecrets();

        // Assert
        Assert.Equal(new[] { "secret1", "secret2" }, soonToExpire);
    }
}
```

## Refactor your types for testability

Classes that need to be tested should be designed for [dependency injection](/dotnet/azure/sdk/dependency-injection), which allows the class to receive its dependencies instead of creating them internally. It was a seamless process to replace the `SecretClient` implementation in the example from the previous section because it was one of the constructor parameters. However, there may be classes in your code that create their own dependencies and are not easily testable, such as the following:

```csharp
public class AboutToExpireSecretFinder
{
    public AboutToExpireSecretFinder(TimeSpan threshold)
    {
        _threshold = threshold;
        _client = new SecretClient(
            new Uri(Environment.GetEnvironmentVariable("KeyVaultUri")),
            new DefaultAzureCredential());
    }
}
```

The simplest refactoring you can do to enable testing with dependency injection would be to expose the client as a parameter and run default creation code when no value is provided. This approach allows you to make the class testable while still retaining the flexibility of using the type without much ceremony.

```csharp
public class AboutToExpireSecretFinder
{
    public AboutToExpireSecretFinder(TimeSpan threshold, SecretClient client = null) 
    { 
        _threshold = threshold; 
        _client = client ?? new SecretClient(
            new Uri(Environment.GetEnvironmentVariable("KeyVaultUri")),
            new DefaultAzureCredential());
    }
}
```

Another option is to move the dependency creation entirely into the calling code:

```csharp
public class AboutToExpireSecretFinder
{
    public AboutToExpireSecretFinder(TimeSpan threshold, SecretClient client)
    {
        _threshold = threshold;
        _client = client;
    }
}

var secretClient = new SecretClient(
    new Uri(Environment.GetEnvironmentVariable("KeyVaultUri")), 
    new DefaultAzureCredential());
var finder = new AboutToExpireSecretFinder(TimeSpan.FromDays(2), secretClient);
```

This approach is useful when you would like to consolidate the dependency creation and share the client between multiple consuming classes.

## See also

* [Dependency injection in .NET](/dotnet/core/extensions/dependency-injection)
* [Unit testing best practices](/dotnet/core/testing/unit-testing-best-practices)
* [Unit testing C# in .NET Core using dotnet test and xUnit](/dotnet/core/testing/unit-testing-with-dotnet-test)
