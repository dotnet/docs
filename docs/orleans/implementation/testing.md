---
title: Unit testing
description: Learn how to unit test with .NET Orleans.
ms.date: 07/03/2024
ms.topic: article
---

# Unit testing with Orleans

This tutorial shows how to unit test your grains to make sure they behave correctly. There are two main ways to unit test your grains, and the method you choose will depend on the type of functionality you're testing. The [Microsoft.Orleans.TestingHost](https://www.nuget.org/packages/Microsoft.Orleans.TestingHost) NuGet package can be used to create test silos for your grains, or you can use a mocking framework like [Moq](https://github.com/moq/moq) to mock parts of the Orleans runtime that your grain interacts with.

## Use the `TestCluster`

The `Microsoft.Orleans.TestingHost` NuGet package contains <xref:Orleans.TestingHost.TestCluster> which can be used to create an in-memory cluster, comprised of two silos by default, which can be used to test grains.

:::code source="snippets/testing/Orleans-testing/Sample.OrleansTesting/HelloGrainTests.cs":::

Due to the overhead of starting an in-memory cluster, you may wish to create a `TestCluster` and reuse it among multiple test cases. For example, this can be done using xUnit's class or collection fixtures.

To share a `TestCluster` between multiple test cases, first create a fixture type:

:::code source="snippets/testing/Orleans-testing/Sample.OrleansTesting/ClusterFixture.cs":::

Next, create a collection fixture:

:::code source="snippets/testing/Orleans-testing/Sample.OrleansTesting/ClusterCollection.cs":::

You can now reuse a `TestCluster` in your test cases:

:::code source="snippets/testing/Orleans-testing/Sample.OrleansTesting/HelloGrainTestsWithFixture.cs":::

When all tests have been completed and the in-memory cluster silos are stopped, xUnit calls the <xref:System.IDisposable.Dispose> method of the `ClusterFixture` type. `TestCluster` also has a constructor that accepts <xref:Orleans.TestingHost.TestClusterOptions> that you can use to configure the silos in the cluster.

If you're using Dependency Injection in your Silo to make services available to Grains, you can use this pattern as well:

:::code source="snippets/testing/Orleans-testing/Sample.OrleansTesting/ClusterFixtureWithConfig.cs"

## Use mocks

Orleans also makes it possible to mock many parts of the system, and for many scenarios, this is the easiest way to unit test grains. This approach does have limitations (for example, around scheduling reentrancy and serialization) and may require that grains include code used only by your unit tests. The [Orleans TestKit](https://github.com/OrleansContrib/OrleansTestKit) provides an alternative approach, which side-steps many of these limitations.

For example, imagine that the grain you're testing interacts with other grains. To be able to mock those other grains, you also need to mock the <xref:Orleans.Grain.GrainFactory> member of the grain under test. By default `GrainFactory` is a normal `protected` property, but most mocking frameworks require properties to be `public` and `virtual` to be able to mock them. So the first thing you need to do is make `GrainFactory` both a `public` and `virtual` property:

```csharp
public new virtual IGrainFactory GrainFactory
{
    get => base.GrainFactory;
}
```

Now you can create your grain outside of the Orleans runtime and use mocking to control the behavior of `GrainFactory`:

```csharp
using Xunit;
using Moq;

namespace Tests;

public class WorkerGrainTests
{
    [Fact]
    public async Task RecordsMessageInJournal()
    {
        var data = "Hello, World";
        var journal = new Mock<IJournalGrain>();
        var worker = new Mock<WorkerGrain>();
        worker
            .Setup(x => x.GrainFactory.GetGrain<IJournalGrain>(It.IsAny<Guid>()))
            .Returns(journal.Object);

        await worker.DoWork(data)

        journal.Verify(x => x.Record(data), Times.Once());
    }
}
```

Here you create the grain under test, `WorkerGrain`, using Moq, which means you can override the behavior of the `GrainFactory` so that it returns a mocked `IJournalGrain`. You can then verify that the `WorkerGrain` interacts with the `IJournalGrain` as you expect.
