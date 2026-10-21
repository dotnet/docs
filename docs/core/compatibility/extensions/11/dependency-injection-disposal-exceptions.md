---
title: "Breaking change - Dependency injection scope disposal aggregates exceptions"
description: "Learn about the breaking change in .NET 11 where dependency injection disposal continues after failures and aggregates multiple exceptions."
ms.date: 10/21/2026
ai-usage: ai-generated
ms.custom: https://github.com/dotnet/docs/issues/55654
---

# Dependency injection scope disposal aggregates exceptions

In .NET 11, the built-in dependency injection container attempts to dispose every captured disposable service, even if a service throws an exception. This behavior applies to synchronous and asynchronous disposal of scopes and root service providers. Multiple disposal failures produce an <xref:System.AggregateException>.

## Version introduced

.NET 11 Preview 2

## Previous behavior

Previously, scope and root provider disposal processed captured disposable services in reverse capture order but stopped at the first exception. That exception propagated unchanged, and the remaining services weren't disposed.

For example, suppose you resolved `FirstDisposable` and then `SecondDisposable`, and both services threw during disposal. The container disposed `SecondDisposable` first. Its exception prevented disposal of `FirstDisposable`.

## New behavior

Starting in .NET 11, synchronous and asynchronous disposal of built-in scopes and root service providers attempts every captured disposable service in reverse capture order, even after a failure.

After all disposal attempts finish, a single exception is rethrown unchanged. If multiple disposal operations fail, disposal throws an <xref:System.AggregateException> that contains all the exceptions.

In the preceding example, the container attempts to dispose `SecondDisposable` and then `FirstDisposable`. Because both throw, disposal throws an `AggregateException` that contains both exceptions.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

To give every captured service an opportunity to release resources such as timers, event handlers, and unmanaged handles, the container continues disposal after exceptions. Previously, one service's failure prevented other services from releasing their resources.

For more information, see [dotnet/runtime PR #123342](https://github.com/dotnet/runtime/pull/123342).

## Recommended action

No action is required if your disposal implementations don't throw and your code doesn't rely on disposal to stop after the first failure.

To avoid cleanup failures, prefer `Dispose()` and `DisposeAsync()` implementations that don't throw. If your code handles disposal failures, handle both the original exception for a single failure and `AggregateException` for multiple failures. Catch `AggregateException` before a general exception handler, and inspect <xref:System.AggregateException.InnerExceptions> to handle each failure.

Don't rely on a disposal exception to prevent other services from being disposed. No compatibility switch restores the previous behavior.

## Affected APIs

- <xref:Microsoft.Extensions.DependencyInjection.ServiceProvider.Dispose>
- <xref:Microsoft.Extensions.DependencyInjection.ServiceProvider.DisposeAsync>
- <xref:Microsoft.Extensions.DependencyInjection.AsyncServiceScope.Dispose>
- <xref:Microsoft.Extensions.DependencyInjection.AsyncServiceScope.DisposeAsync>
- <xref:System.IDisposable.Dispose> on <xref:Microsoft.Extensions.DependencyInjection.IServiceScope> instances created by the built-in container.
