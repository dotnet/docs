---
title: Testing with FakeTimeProvider
description: Learn how to test time-dependent code using FakeTimeProvider from Microsoft.Extensions.TimeProvider.Testing in .NET.
ms.date: 02/26/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Testing with FakeTimeProvider

The [📦 `Microsoft.Extensions.TimeProvider.Testing`](https://www.nuget.org/packages/Microsoft.Extensions.TimeProvider.Testing) NuGet package provides a `FakeTimeProvider` class that enables deterministic testing of code that depends on time. This fake implementation allows you to control the system time within your tests, ensuring predictable and repeatable results.

## Why use FakeTimeProvider

Testing code that depends on the current time or uses timers can be challenging:

- **Non-deterministic tests**: Tests that depend on real time can produce inconsistent results.
- **Slow tests**: Tests that need to wait for actual time to pass can significantly slow down test execution.
- **Race conditions**: Time-dependent logic can introduce race conditions that are hard to reproduce.
- **Edge cases**: Testing time-based logic at specific times (such as midnight or month boundaries) is difficult with real time.

The `FakeTimeProvider` addresses these challenges by:

- Providing complete control over the current time.
- Allowing you to advance time instantly without waiting.
- Enabling deterministic testing of time-based behavior.
- Making it easy to test edge cases and boundary conditions.

## Get started

To get started with `FakeTimeProvider`, install the [`Microsoft.Extensions.TimeProvider.Testing`](https://www.nuget.org/packages/Microsoft.Extensions.TimeProvider.Testing) NuGet package.

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.TimeProvider.Testing
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.Extensions.TimeProvider.Testing" Version="10.0.0" />
```

---

For more information, see [dotnet add package](../tools/dotnet-package-add.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

## Basic usage

The `FakeTimeProvider` extends <xref:System.TimeProvider> to provide controllable time for testing:

:::code language="csharp" source="snippets/timeprovider-testing/csharp/basic-usage.cs" id="BasicUsage":::

## Initialize with specific time

You can initialize `FakeTimeProvider` with a specific starting time:

:::code language="csharp" source="snippets/timeprovider-testing/csharp/basic-usage.cs" id="InitializeSpecificTime":::

## Advance time

The `Advance` method moves time forward by a specified duration:

:::code language="csharp" source="snippets/timeprovider-testing/csharp/basic-usage.cs" id="AdvanceTime":::

## Configure time zone

Set the local time zone for the fake time provider:

:::code language="csharp" source="snippets/timeprovider-testing/csharp/basic-usage.cs" id="ConfigureTimeZone":::

## Test delayed operations

`FakeTimeProvider` is particularly useful for testing operations that involve delays:

:::code language="csharp" source="snippets/timeprovider-testing/csharp/DelayedOperationTests.cs" id="DelayedOperationTests":::

## Test periodic operations

Test operations that execute periodically using timers:

:::code language="csharp" source="snippets/timeprovider-testing/csharp/PeriodicOperationTests.cs" id="PeriodicOperationTests":::

## Test time-based business logic

Test business logic that depends on specific times or dates:

:::code language="csharp" source="snippets/timeprovider-testing/csharp/SubscriptionTests.cs" id="SubscriptionTests":::

## Integration with dependency injection

Use `FakeTimeProvider` in tests for services registered with dependency injection:

:::code language="csharp" source="snippets/timeprovider-testing/csharp/CacheServiceTests.cs" id="CacheServiceTests":::

## Best practices

When using `FakeTimeProvider`, consider the following best practices:

- **Inject TimeProvider**: Always inject `TimeProvider` as a dependency rather than using <xref:System.DateTime> or <xref:System.DateTimeOffset> directly. This makes your code testable.
- **Use UTC time**: Work with UTC time in your business logic and convert to local time only when needed for display.
- **Test edge cases**: Use `FakeTimeProvider` to test edge cases like midnight, month boundaries, daylight saving time transitions, and leap years.
- **Clean up timers**: Dispose of timers created with `CreateTimer` to avoid resource leaks in your tests.
- **Advance time deliberately**: Advance time explicitly in your tests to make the test behavior clear and predictable.
- **Avoid mixing real and fake time**: Don't mix real `TimeProvider.System` with `FakeTimeProvider` in the same test, as this can lead to unpredictable behavior.

## See also

- <xref:System.TimeProvider>
- [Unit testing in .NET](../testing/index.md)
- [Dependency injection in .NET](dependency-injection/overview.md)
