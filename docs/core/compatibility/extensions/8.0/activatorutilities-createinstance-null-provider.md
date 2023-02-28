---
title: "Breaking change: ActivatorUtilities.CreateInstance requires non-null provider"
description: Learn about the .NET 8 breaking change in .NET extensions where ActivatorUtilities.CreateInstance throws an ArgumentNullException if the provider is null.
ms.date: 02/28/2023
---
# ActivatorUtilities.CreateInstance requires non-null provider

The two <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance%2A?displayProperty=nameWithType> methods now throw an <xref:System.ArgumentNullException> exception if the `provider` parameter is `null`.

## Version introduced

.NET 8 Preview 1

## Previous behavior

A `null` value was allowed for the `provider` parameter. In some cases, the specified type was still created correctly.

## New behavior

When `provider` is `null`, an <xref:System.ArgumentNullException> exception is thrown.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

We fixed various the parameter validation along with [constructor-matching issues](activatorutilities-createinstance-behavior.md) to align with the intended purpose of <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance%2A>. The `CreateInstance()` methods have a non-nullable `provider` parameter, so it was generally expected that a `null` provider wasn't allowed.

## Recommended action

Pass a non-null <xref:System.IServiceProvider> for the `provider` argument. If the provider also implements <xref:Microsoft.Extensions.DependencyInjection.IServiceProviderIsService>, constructor arguments can be obtained through that.

Alternatively, if your scenario doesn't require dependency injection, since <xref:System.IServiceProvider> is `null`, use <xref:System.Activator.CreateInstance%2A?displayProperty=nameWithType> instead.

## Affected APIs

- <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance%60%601(System.IServiceProvider,System.Object[])?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance(System.IServiceProvider,System.Type,System.Object[])?displayProperty=fullName>

## See also

- [ActivatorUtilities.CreateInstance behaves consistently](activatorutilities-createinstance-behavior.md)
