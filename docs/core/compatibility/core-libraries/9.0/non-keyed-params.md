---
title: FromKeyedServicesAttribute no longer injects non-keyed parameter
description: Learn about the .NET 9 breaking change in core .NET libraries (dependency injection) where FromKeyedServicesAttribute no longer injects a non-keyed parameter.
ms.date: 09/05/2024
---
# FromKeyedServicesAttribute no longer injects non-keyed parameter

When you use <xref:Microsoft.Extensions.DependencyInjection.FromKeyedServicesAttribute> to specify a keyed service to be injected, an incorrect service might be passed.

## Previous behavior

Previously, when a keyed service was intended to be injected as a parameter in a service constructor by using <xref:Microsoft.Extensions.DependencyInjection.FromKeyedServicesAttribute> and the corresponding keyed service (`service1` in the following example) wasn't registered as a keyed service but *was* registered as a non-keyed service type (`IService` in the following example), the non-keyed service was injected instead of throwing an exception.

```csharp
public MyService([FromKeyedServices("service1")] IService service1, ...
```

## New behavior

Starting in .NET 9, an <xref:System.InvalidOperationException> is thrown when <xref:Microsoft.Extensions.DependencyInjection.FromKeyedServicesAttribute> is used and the specified keyed service isn't found. This behavior is consistent with other cases when the requested service can't be found due to lack of registration.

## Version introduced

.NET 9 RC 1 and 8.0.9 servicing

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change adds missing validation logic to detect service misconfiguration bugs. This issue existed when the keyed service feature was added in v8.0.

## Recommended action

If `FromKeyedServicesAttribute` is used, ensure that the corresponding service is registered as a keyed service, such as by using     `IServiceCollection.AddKeyedScoped()`, `IServiceCollection.AddKeyedSingleton()`, or `IServiceCollection.AddKeyedTransient()`.

The fix has also been backported to .NET 8.0.9, so both .NET 8 and .NET 9 have the same behavior. If your application depends on the old behavior, a feature switch was added for .NET 8.0.9 (but not .NET 9) named `Microsoft.Extensions.DependencyInjection.AllowNonKeyedServiceInject`. Set the switch to `true` to keep the old behavior.

## Affected APIs

- <xref:Microsoft.Extensions.DependencyInjection.FromKeyedServicesAttribute.%23ctor(System.Object)>
