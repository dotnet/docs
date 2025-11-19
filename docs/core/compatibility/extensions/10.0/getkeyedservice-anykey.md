---
title: "Breaking change: Fix issues in GetKeyedService() and GetKeyedServices() with AnyKey"
description: "Learn about the breaking change in .NET 10 Preview 3 where GetKeyedService() and GetKeyedServices() behavior changed when using KeyedService.AnyKey as the lookup key."
ms.date: 11/19/2025
ai-usage: ai-assisted
---

# Fix issues in GetKeyedService() and GetKeyedServices() with AnyKey

The behavior of `GetKeyedService()` and `GetKeyedServices()` methods in the `Microsoft.Extensions.DependencyInjection` library was updated to address inconsistencies in handling the `KeyedService.AnyKey` registration. Specifically, `GetKeyedService()` now throws an exception when you attempt to resolve a single service using `KeyedService.AnyKey` as the lookup key, and `GetKeyedServices()` no longer returns `AnyKey` registrations when queried with `KeyedService.AnyKey`.

## Version introduced

.NET 10 Preview 3

## Previous behavior

Previously, calling `GetKeyedService()` with `KeyedService.AnyKey` would return a service registration associated with `AnyKey`. This behavior was inconsistent with the intended semantics, as `AnyKey` is meant to represent a special case of keyed services rather than a specific registration.

Additionally, calling `GetKeyedServices()` with `KeyedService.AnyKey` would return all registrations for `AnyKey`. This behavior was also inconsistent with the intended semantics, as `AnyKey` is not meant to enumerate all keyed services.

## New behavior

Starting in .NET 10, calling `GetKeyedService()` with `KeyedService.AnyKey` throws an exception. This ensures that `AnyKey` can't be used to resolve a single service, as it's intended to represent a special case rather than a specific key.

```csharp
var service = serviceProvider.GetKeyedService(typeof(IMyService), KeyedService.AnyKey);
// Throws InvalidOperationException: "Cannot resolve a single service using AnyKey."
```

Additionally, calling `GetKeyedServices()` with `KeyedService.AnyKey` no longer returns registrations for `AnyKey`. Instead, it adheres to the updated semantics where `AnyKey` is treated as a special case and doesn't enumerate services.

```csharp
var services = serviceProvider.GetKeyedServices(typeof(IMyService), KeyedService.AnyKey);
// Returns an empty collection.
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The previous behavior of `GetKeyedService()` and `GetKeyedServices()` with `KeyedService.AnyKey` was inconsistent with the intended semantics of `AnyKey`. The changes were introduced to ensure that `AnyKey` is treated as a special case and can't be used to resolve a single service, and to prevent `GetKeyedServices()` from returning `AnyKey` registrations when queried with `AnyKey`. These updates improve the predictability and correctness of the `Microsoft.Extensions.DependencyInjection` library's behavior when working with keyed services. For more details, see the [pull request](https://github.com/dotnet/runtime/pull/113137) and the associated [merge commit](https://github.com/dotnet/runtime/commit/deee462fc8421a7e18b8916eb5a5eacb9d09169d).

## Recommended action

Developers using `GetKeyedService()` or `GetKeyedServices()` with `KeyedService.AnyKey` should review their code and update it to use specific keys instead of `AnyKey`.

For `GetKeyedService(KeyedService.AnyKey)`, replace calls to `GetKeyedService()` with `KeyedService.AnyKey` with specific keys or alternative logic to handle service resolution.

**Before**:

```csharp
var service = serviceProvider.GetKeyedService(typeof(IMyService), KeyedService.AnyKey);
```

**After**:

```csharp
// Replace AnyKey with a specific key or implement custom logic for service resolution.
var service = serviceProvider.GetKeyedService(typeof(IMyService), specificKey);
```

For `GetKeyedServices(KeyedService.AnyKey)`, update code to explicitly enumerate or query services by specific keys instead of relying on `AnyKey`.

**Before**:

```csharp
var services = serviceProvider.GetKeyedServices(typeof(IMyService), KeyedService.AnyKey);
```

**After**:

```csharp
// Replace AnyKey with specific keys or implement custom logic for service enumeration.
var services = serviceProvider.GetKeyedServices(typeof(IMyService), specificKey);
```

## Affected APIs

- <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetKeyedService(System.IServiceProvider,System.Type,System.Object)?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetKeyedServices(System.IServiceProvider,System.Type,System.Object)?displayProperty=fullName>
