---
title: "Breaking change - Casting IDispatchEx COM object to IReflect fails"
description: "Learn about the breaking change in .NET 10 where casting a COM object that implements IDispatchEx to IReflect now fails."
ms.date: 11/17/2025
ai-usage: ai-assisted
---

# Casting COM object that implements IDispatchEx to IReflect fails

Since .NET 5, it was possible to cast a COM object that implements [IDispatchEx](/previous-versions/windows/internet-explorer/ie-developer/windows-scripting/reference/idispatchex-interface) to <xref:System.Reflection.IReflect>. However, all members on that `IReflect` instance threw <xref:System.TypeLoadException>. Starting in .NET 10, this behavior changed and the cast now fails.

## Version introduced

.NET 10

## Previous behavior

Previously, casting a COM object that implements `IDispatchEx` to `IReflect` succeeded.

```csharp
using System.Reflection;
var file = Activator.CreateInstance(Type.GetTypeFromProgID("htmlfile"));
Console.WriteLine("IReflect is " + (file is IReflect ? "supported" : "NOT supported"));
// Printed "IReflect is supported".
```

## New behavior

Starting in .NET 10, casting a COM object that implements `IDispatchEx` to `IReflect` fails.

```csharp
using System.Reflection;
var file = Activator.CreateInstance(Type.GetTypeFromProgID("htmlfile"));
Console.WriteLine("IReflect is " + (file is IReflect ? "supported" : "NOT supported"));
// Prints "IReflect is NOT supported".
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This capability was removed because all members on the resulting `IReflect` instance were unusable. Also, the <xref:System.TypeLoadException> exception that resulted from accessing any of the members mentioned a type that was never included in .NET and was therefore confusing and unhelpful as to the underlying issue.

## Recommended action

The only viable question that could be asked in .NET 5+ with this cast was, "Does the type implement IDispatchEx?" In this case, a better way to ask that question is:

```csharp
var file = Activator.CreateInstance(Type.GetTypeFromProgID("htmlfile"));
Console.WriteLine("IDispatchEx is " + (file is IDispatchEx ? "supported" : "NOT supported"));

[ComImport]
[Guid("A6EF9860-C720-11D0-9337-00A0C90DCAA9")]
interface IDispatchEx { }
```

## Affected APIs

None.
