---
title: "Breaking change: FromKeyedServicesAttribute.Key can be null"
description: "Learn about the breaking change in .NET 8 where FromKeyedServicesAttribute.Key is now nullable to support unkeyed services and inheritance."
ms.date: 09/29/2025
ai-usage: ai-assisted
ms.custom: https://dev.azure.com/msft-skilling/Content/_workitems/edit/486863
---

# FromKeyedServicesAttribute.Key can be null

<xref:Microsoft.Extensions.DependencyInjection.FromKeyedServicesAttribute.Key?displayProperty=nameWithType> has been changed from a non-nullable `object` to a nullable `object?` to support null values for unkeyed services and inheritance scenarios.

## Version introduced

.NET 8

## Previous behavior

Previously, <xref:Microsoft.Extensions.DependencyInjection.FromKeyedServicesAttribute.Key?displayProperty=nameWithType> was declared as a non-nullable `object`:

```csharp
public object Key { get; }
```

## New behavior

Starting in .NET 8, <xref:Microsoft.Extensions.DependencyInjection.FromKeyedServicesAttribute.Key?displayProperty=nameWithType> is now declared as a nullable `object?`:

```csharp
public object? Key { get; }
```

A `null` value indicates there is no key and only the parameter type is used to resolve the service. This is useful for dependency injection implementations that require an explicit way to declare that the parameter should be resolved for unkeyed services. A `null` value is also used with inheritance scenarios to indicate that the key should be inherited from the parent scope.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

Support was added for keyed services to annotate parameters as unkeyed. This change allows developers to explicitly indicate when a parameter should be resolved without a key, which is particularly useful in scenarios where both keyed and unkeyed services are registered for the same type.

## Recommended action

Adjust any code that uses <xref:Microsoft.Extensions.DependencyInjection.FromKeyedServicesAttribute.Key?displayProperty=nameWithType> to handle `null` values.

## Affected APIs

- <xref:Microsoft.Extensions.DependencyInjection.FromKeyedServicesAttribute.Key?displayProperty=fullName>
