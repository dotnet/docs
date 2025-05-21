---
title: "Breaking change: ActivatorUtilities.CreateInstance behaves consistently"
description: Learn about the .NET 8 breaking change in .NET extensions where ActivatorUtilities.CreateInstance behaves consistently regardless of the order of constructor overloads.
ms.date: 02/28/2023
ms.topic: concept-article
---
# ActivatorUtilities.CreateInstance behaves consistently

The behavior of <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance%2A?displayProperty=nameWithType> is now more consistent with <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateFactory(System.Type,System.Type[])>. When <xref:Microsoft.Extensions.DependencyInjection.IServiceProviderIsService> isn't present in the dependency injection (DI) container, <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance%2A> falls back to the <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateFactory(System.Type,System.Type[])> logic. In that logic, only one constructor is allowed to match with all the provided input parameters.

In the more general case when <xref:Microsoft.Extensions.DependencyInjection.IServiceProviderIsService> is present, the `CreateInstance` API prefers the longest constructor overload that has all its arguments available. The arguments can be input to the API, registered in the container, or available from default values in the constructor itself.

Consider the following class definition showing two constructors:

```csharp
public class A
{
   A(B b, C c, string st = "default string") { }
   A() { }
}
```

For this class definition, and when `IServiceProviderIsService` is present, `ActivatorUtilities.CreateInstance<A>(serviceProvider, new C())` instantiates `A` by picking the first constructor that takes `B`, `C`, and `string`.

## Version introduced

.NET 8 Preview 1

## Previous behavior

<xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance%2A?displayProperty=nameWithType> behaved unexpectedly in some cases. It made sure all required instances passed to it existed in the chosen constructor. However, the constructor selection was buggy and unreliable.

## New behavior

<xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance%2A> tries to find the longest constructor that matches all parameters based on the behavior of <xref:Microsoft.Extensions.DependencyInjection.IServiceProviderIsService>.

- If no constructors are found or if <xref:Microsoft.Extensions.DependencyInjection.IServiceProviderIsService> isn't present, it falls back to <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateFactory(System.Type,System.Type[])> logic.
- If it finds more than one constructor, it throws an <xref:System.InvalidOperationException>.

> [!NOTE]
> If <xref:Microsoft.Extensions.DependencyInjection.IServiceProviderIsService> is configured incorrectly or doesn't exist, `CreateInstance` may function incorrectly or ambiguously.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was introduced to fix a bug where the behavior changed depending on the order of constructor overload definitions.

## Recommended action

If your app starts behaving differently or throwing an exception after upgrading to .NET 8, carefully examine the constructor definitions for the affected instance type. Refer to the [New behavior](#new-behavior) section.

## Affected APIs

- <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance%60%601(System.IServiceProvider,System.Object[])?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance(System.IServiceProvider,System.Type,System.Object[])?displayProperty=fullName>

## See also

- [ActivatorUtilities.CreateInstance requires non-null provider](activatorutilities-createinstance-null-provider.md)
