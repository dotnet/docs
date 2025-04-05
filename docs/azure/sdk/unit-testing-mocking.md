---
title: Unit testing and mocking with the Azure SDK for .NET
description: Learn techniques and tools for unit testing and mocking the Azure SDK for .NET
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-arm-template
ms.date: 07/05/2023
---

# Unit testing and mocking with the Azure SDK for .NET

Unit testing is an important part of a sustainable development process that can improve code quality and prevent regressions or bugs in your apps. However, unit testing presents challenges when the code you're testing performs network calls, such as those made to Azure resources. Tests that run against live services can experience issues, such as latency that slows down test execution, dependencies on code outside of the isolated test, and issues with managing service state and costs every time the test is run. Instead of testing against live Azure services, replace the service clients with mocked or in-memory implementations. This avoids the above issues and lets developers focus on testing their application logic, independent from the network and service.

In this article, you learn how to write unit tests for the Azure SDK for .NET that isolate your dependencies to make your tests more reliable. You also learn how to replace key components with in-memory test implementations to create fast and reliable unit tests, and see how to design your own classes to better support unit testing. This article includes examples that use [Moq](https://www.nuget.org/packages/moq/) and [NSubstitute](https://www.nuget.org/packages/nsubstitute/), which are popular mocking libraries for .NET.

## Understand service clients

A service client class is the main entry point for developers in an Azure SDK library and implements most of the logic to communicate with the Azure service. When unit testing service client classes, it's important to be able to create an instance of the client that behaves as expected without making any network calls.

Each of the Azure SDK clients follows [mocking guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking) that allow their behavior to be overridden:

* Each client offers at least one protected constructor to allow inheritance for testing.
* All public client members are virtual to allow overriding.

> [!NOTE]
> The code examples in this article use types from the [Azure.Security.KeyVault.Secrets](https://www.nuget.org/packages/Azure.Security.KeyVault.Secrets/) library for the Azure Key Vault service. The concepts demonstrated in this article also apply to service clients from many other Azure services, such as Azure Storage or Azure Service Bus.

To create a test service client, you can either use a mocking library or standard C# features such as inheritance. Mocking frameworks allow you to simplify the code that you must write to override member behavior. (These frameworks also have other useful features that are beyond the scope of this article.)

# [Non-library](#tab/csharp)

To create a test client instance using C# without a mocking library, inherit from the client type and override methods you're calling in your code with an implementation that returns a set of test objects. Most clients contain both synchronous and asynchronous methods for operations; override only the one your application code is calling.

> [!NOTE]
> It can be cumbersome to manually define test classes, especially if you need to customize behavior differently for each test. Consider using a library like Moq or NSubstitute to streamline your testing.

:::code language="csharp" source="snippets/unit-testing/NonLibrary/MockSecretClient.cs" :::

# [Moq](#tab/moq)

:::code language="csharp" source="snippets/unit-testing/Moq/TestSnippets_Moq.cs" id="MockSecretClient" :::

# [NSubstitute](#tab/nsubstitute)

:::code language="csharp" source="snippets/unit-testing/NSubstitute/TestSnippets_NSubstitute.cs" id="MockSecretClient" :::

---

### Service client input and output models

Model types hold the data being sent and received from Azure services. There are three types of models:

* **Input models** are intended to be created and passed as parameters to service methods by developers. They have one or more public constructors and writeable properties.
* **Output models** are only returned by the service and have no public constructors or writeable properties.
* **Round-trip models** are less common, but are returned by the service, modified, and used as an input.

To create a test instance of an input model, use one of the available public constructors and set the additional properties you need.

```csharp
var secretProperties = new SecretProperties("secret")
{
    NotBefore = DateTimeOffset.Now
};
```

To create instances of output models, a model factory is used. Azure SDK client libraries provide a static model factory class with a `ModelFactory` suffix in its name. The class contains a set of static methods to initialize the library's output model types. For example, the model factory for `SecretClient` is `SecretModelFactory`:

```csharp
KeyVaultSecret keyVaultSecret = SecretModelFactory.KeyVaultSecret(
    new SecretProperties("secret"), "secretValue");
```

> [!NOTE]
> Some input models have read-only properties that are only populated when the model is returned by the service. In this case, a model factory method will be available that allows setting these properties. For example, <xref:Azure.Security.KeyVault.Secrets.SecretModelFactory.SecretProperties%2A>.

```csharp
// CreatedOn is a read-only property and can only be
// set via the model factory's SecretProperties method.
secretPropertiesWithCreatedOn = SecretModelFactory.SecretProperties(
    name: "secret", createdOn: DateTimeOffset.Now);
```

## Explore response types

The <xref:Azure.Response> class is an abstract class that represents an HTTP response and is returned by most service client methods. You can create test `Response` instances using either a mocking library or standard C# inheritance.

## [Non-library](#tab/csharp)

The `Response` class is abstract, which means there are many members to override. Consider using a library to streamline your approach.

:::code language="csharp" source="snippets/unit-testing/NonLibrary/MockResponse.cs" :::

## [Moq](#tab/moq)

:::code language="csharp" source="snippets/unit-testing/Moq/TestSnippets_Moq.cs" id="MockResponse" :::

# [NSubstitute](#tab/nsubstitute)

:::code language="csharp" source="snippets/unit-testing/NSubstitute/TestSnippets_NSubstitute.cs" id="MockResponse" :::

---

Some services also support using the <xref:Azure.Response%601> type, which is a class that contains a model and the HTTP response that returned it. To create a test instance of `Response<T>`, use the static `Response.FromValue` method:

## [Non-library](#tab/csharp)

:::code language="csharp" source="snippets/unit-testing/NonLibrary/TestSnippets.cs" id="MockResponseT" :::

## [Moq](#tab/moq)

:::code language="csharp" source="snippets/unit-testing/Moq/TestSnippets_Moq.cs" id="MockResponseT" :::

# [NSubstitute](#tab/nsubstitute)

:::code language="csharp" source="snippets/unit-testing/NSubstitute/TestSnippets_NSubstitute.cs" id="MockResponseT" :::

---

### Explore paging

The <xref:Azure.Page%601> class is used as a building block in service methods that invoke operations returning results in multiple pages. The `Page<T>` is rarely returned from APIs directly but is useful to create the `AsyncPageable<T>` and `Pageable<T>` instances in the next section. To create a `Page<T>` instance, use the <xref:Azure.Page%601.FromValues%2A?displayProperty=nameWithType> method, passing a list of items, a continuation token, and the `Response`.

The `continuationToken` parameter is used to retrieve the next page from the service. For unit testing purposes, it should be set to `null` for the last page and should be nonempty for other pages.

## [Non-library](#tab/csharp)

:::code language="csharp" source="snippets/unit-testing/NonLibrary/TestSnippets.cs" id="SingleResponsePage" :::

## [Moq](#tab/moq)

:::code language="csharp" source="snippets/unit-testing/Moq/TestSnippets_Moq.cs" id="SingleResponsePage" :::

# [NSubstitute](#tab/nsubstitute)

:::code language="csharp" source="snippets/unit-testing/NSubstitute/TestSnippets_NSubstitute.cs" id="SingleResponsePage" :::

---

<xref:Azure.AsyncPageable%601> and <xref:Azure.Pageable%601> are classes that represent collections of models returned by the service in pages. The only difference between them is that one is used with synchronous methods while the other is used with asynchronous methods.

To create a test instance of `Pageable` or `AsyncPageable`, use the <xref:Azure.Pageable%601.FromPages%2A> static method:

## [Non-library](#tab/csharp)

:::code language="csharp" source="snippets/unit-testing/NonLibrary/TestSnippets.cs" id="MultipleResponsePage" :::

## [Moq](#tab/moq)

:::code language="csharp" source="snippets/unit-testing/Moq/TestSnippets_Moq.cs" id="MultipleResponsePage" :::

# [NSubstitute](#tab/nsubstitute)

:::code language="csharp" source="snippets/unit-testing/NSubstitute/TestSnippets_NSubstitute.cs" id="MultipleResponsePage" :::

---

## Write a mocked unit test

Suppose your app contains a class that finds the names of keys that will expire within a given amount of time.

:::code language="csharp" source="snippets/unit-testing/AboutToExpireSecretsFinder.cs" :::

You want to test the following behaviors of the `AboutToExpireSecretFinder` to ensure they continue working as expected:

* Secrets without an expiry date set aren't returned.
* Secrets with an expiry date closer to the current date than the threshold are returned.

When unit testing you only want the unit tests to verify the application logic and not whether the Azure service or library works correctly. The following example tests the key behaviors using the popular [xUnit](https://www.nuget.org/packages/xunit) library:

## [Non-library](#tab/csharp)

:::code language="csharp" source="snippets/unit-testing/NonLibrary/AboutToExpireSecretsFinderTests.cs" :::

## [Moq](#tab/moq)

:::code language="csharp" source="snippets/unit-testing/Moq/AboutToExpireSecretsFinderTests_Moq.cs" :::

# [NSubstitute](#tab/nsubstitute)

:::code language="csharp" source="snippets/unit-testing/NSubstitute/AboutToExpireSecretsFinderTests_NSubstitute.cs" :::

---

## Refactor your types for testability

Classes that need to be tested should be designed for [dependency injection](dependency-injection.md), which allows the class to receive its dependencies instead of creating them internally. It was a seamless process to replace the `SecretClient` implementation in the example from the previous section because it was one of the constructor parameters. However, there might be classes in your code that create their own dependencies and aren't easily testable, such as the following class:

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

## Understand Azure Resource Manager (ARM) clients

In ARM libraries, the clients were designed to emphasize their relationship to one another, mirroring the service hierarchy. To achieve that goal, extension methods are widely used to add additional features to clients.

For example, an Azure virtual machine exists in an Azure resource group. The `Azure.ResourceManager.Compute` namespace models the Azure virtual machine as `VirtualMachineResource`. The `Azure.ResourceManager` namespace models the Azure resource group as `ResourceGroupResource`. To query the virtual machines for a resource group, you would write:

:::code language="csharp" source="snippets/unit-testing/ResourceManager/ResourceManagerCodeStructure.cs" id="ParentOfVMIsRG" :::

Because the virtual machine-related functionality such as `GetVirtualMachines` on `ResourceGroupResource`, is implemented as extension methods, it's impossible to just create a mock of the type and override the method. Instead, you'll also have to create a mock class for the "mockable resource" and wire them together.

The mockable resource type is always in the `Mocking` sub-namespace of the extension method. In the preceding example, the mockable resource type is in the `Azure.ResourceManager.Compute.Mocking` namespace. The mockable resource type is always named after the resource type with "Mockable" and the library name as prefixes. In the preceding example, the mockable resource type is named `MockableComputeResourceGroupResource`, where `ResourceGroupResource` is the resource type of the extension method, and `Compute` is the library name.

One more requirement before you get the unit test running is to mock the `GetCachedClient` method on the resource type of the extension method. Completing this step hooks up the extension method and the method on the mockable resource type.

Here's how it works:

## [Non-library](#tab/csharp)

:::code language="csharp" source="snippets/unit-testing/ResourceManager/NonLibrary/MockMockableComputeResourceGroupResource.cs" :::

## [Moq](#tab/moq)

:::code language="csharp" source="snippets/unit-testing/ResourceManager/Moq/MockComputeResourceGroupMockingExtension_TestSnippets_Moq.cs" :::

# [NSubstitute](#tab/nsubstitute)

:::code language="csharp" source="snippets/unit-testing/ResourceManager/NSubstitute/MockComputeResourceGroupMockingExtension_TestSnippets_NSubstitute.cs" :::

---

## See also

* [Dependency injection in .NET](../../core/extensions/dependency-injection.md)
* [Unit testing best practices](../../core/testing/unit-testing-best-practices.md)
* [Unit testing C# in .NET using dotnet test and xUnit](../../core/testing/unit-testing-csharp-with-xunit.md)
