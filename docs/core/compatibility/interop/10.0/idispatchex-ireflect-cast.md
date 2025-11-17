---
title: "Breaking change - Casting COM object that implements IDispatchEx to IReflect now fails"
description: "Learn about the breaking change in .NET 10 RC 1 where casting a COM object that implements IDispatchEx to IReflect now fails."
ms.date: 11/17/2025
ai-usage: ai-assisted
---

# Casting COM object that implements IDispatchEx to IReflect now fails

Since .NET 5, casting a COM object that implements `IDispatchEx` to `IReflect` has been possible. However, all members on that `IReflect` instance would throw <xref:System.TypeLoadException>. Starting in .NET 10 RC 1, this behavior changed so that the cast now fails.

## Version introduced

.NET 10 RC 1

## Previous behavior

Previously, casting a COM object that implements `IDispatchEx` to `IReflect` would succeed.

```csharp
using System.Reflection;
var file = Activator.CreateInstance(Type.GetTypeFromProgID("htmlfile"));
Console.WriteLine("IReflect is " + (file is IReflect ? "supported" : "NOT supported"));
// Prints "IReflect is supported"
```

## New behavior

Starting in .NET 10, casting a COM object that implements `IDispatchEx` to `IReflect` now fails.

```csharp
using System.Reflection;
var file = Activator.CreateInstance(Type.GetTypeFromProgID("htmlfile"));
Console.WriteLine("IReflect is " + (file is IReflect ? "supported" : "NOT supported"));
// Prints "IReflect is NOT supported"
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This was removed because all members on the resulting `IReflect` instance would be unusable. The <xref:System.TypeLoadException> exception that would result from accessing any of the members mentioned a type that was never included in .NET Core and was therefore confusing and unhelpful as to the underlying issue. Removal of the cast behavior was therefore deemed appropriate.

## Recommended action

The only viable question that could be asked in .NET 5+ with this cast was, "Does the type implement IDispatchEx?" In this case, the better way to ask that question is as follows:

```csharp
var file = Activator.CreateInstance(Type.GetTypeFromProgID("htmlfile"));
Console.WriteLine("IDispatchEx is " + (file is IDispatchEx ? "supported" : "NOT supported")); 

[ComImport]
[Guid("A6EF9860-C720-11D0-9337-00A0C90DCAA9")]
interface IDispatchEx { }
```

## Affected APIs

None.
