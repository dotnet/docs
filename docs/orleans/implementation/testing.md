---
title: Unit testing
description: Learn how to unit test with .NET Orleans.
ms.date: 03/30/2025
ms.topic: how-to
ms.service: orleans
---

# Unit testing with Orleans

This tutorial shows how to unit test your grains to ensure they behave correctly. There are two main ways to unit test your grains, and the method you choose depends on the type of functionality you're testing. Use the [Microsoft.Orleans.TestingHost](https://www.nuget.org/packages/Microsoft.Orleans.TestingHost) NuGet package to create test silos for your grains, or use a mocking framework like [Moq](https://github.com/moq/moq) to mock parts of the Orleans runtime your grain interacts with.

## Use the `TestCluster`

The `Microsoft.Orleans.TestingHost` NuGet package contains <xref:Orleans.TestingHost.TestCluster>, which you can use to create an in-memory cluster (comprised of two silos by default) for testing grains.

:::code source="snippets/testing/Orleans-testing/Sample.OrleansTesting/HelloGrainTests.cs":::

Due to the overhead of starting an in-memory cluster, you might want to create a `TestCluster` and reuse it among multiple test cases. For example, achieve this using xUnit's class or collection fixtures.

To share a `TestCluster` between multiple test cases, first create a fixture type:

:::code source="snippets/testing/Orleans-testing/Sample.OrleansTesting/ClusterFixture.cs":::

Next, create a collection fixture:

:::code source="snippets/testing/Orleans-testing/Sample.OrleansTesting/ClusterCollection.cs":::

You can now reuse a `TestCluster` in your test cases:

:::code source="snippets/testing/Orleans-testing/Sample.OrleansTesting/HelloGrainTestsWithFixture.cs":::

When all tests complete and the in-memory cluster silos stop, xUnit calls the <xref:System.IDisposable.Dispose> method of the `ClusterFixture` type. `TestCluster` also has a constructor accepting <xref:Orleans.TestingHost.TestClusterOptions> that you can use to configure the silos in the cluster.

If you use Dependency Injection in your Silo to make services available to Grains, you can use this pattern as well:

:::code source="snippets/testing/Orleans-testing/Sample.OrleansTesting/ClusterFixtureWithConfig.cs"

## Use mocks

Orleans also allows mocking many parts of the system. For many scenarios, this is the easiest way to unit test grains. This approach has limitations (e.g., around scheduling reentrancy and serialization) and might require grains to include code used only by your unit tests. The [Orleans TestKit](https://github.com/OrleansContrib/OrleansTestKit) provides an alternative approach that sidesteps many of these limitations.

For example, imagine the grain you're testing interacts with other grains. To mock those other grains, you also need to mock the <xref:Orleans.Grain.GrainFactory> member of the grain under test. By default, `GrainFactory` is a normal `protected` property, but most mocking frameworks require properties to be `public` and `virtual` to enable mocking. So, the first step is to make `GrainFactory` both `public` and `virtual`:

```csharp
public new virtual IGrainFactory GrainFactory
{
    get => base.GrainFactory;
}
```

Now you can create your grain outside the Orleans runtime and use mocking to control the behavior of `GrainFactory`:

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

Here, create the grain under test, `WorkerGrain`, using Moq. This allows overriding the `GrainFactory`'s behavior so it returns a mocked `IJournalGrain`. You can then verify that `WorkerGrain` interacts with `IJournalGrain` as expected.
