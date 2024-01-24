---
title: System.ValueType.Equals method
description: Learn about the System.ValueType.Equals method.
ms.date: 01/24/2024
---
# System.ValueType.Equals method

[!INCLUDE [context](includes/context.md)]

The <xref:System.ValueType.Equals(System.Object)?displayProperty=nameWithType> method overrides <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType> and provides the default implementation of value equality for all value types in .NET.

The default implementation calls <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType> on each field of the current instance and `obj` and returns `true` if all fields are equal.

> [!TIP]
> Particularly if your value type contains fields that are reference types, you should override the <xref:System.ValueType.Equals(System.Object)> method. This can improve performance and enable you to more closely represent the meaning of equality for the type.

## Notes for the Windows Runtime

When you call the <xref:System.ValueType.Equals%2A> method on a Windows Runtime structure, it provides the default behavior for value types that don't override <xref:System.ValueType.Equals%2A>. This is part of the support that .NET provides for the Windows Runtime (see [.NET Support for Windows Store Apps and Windows Runtime](/dotnet/standard/cross-platform/support-for-windows-store-apps-and-windows-runtime)). Windows Runtime structures can't override <xref:System.ValueType.Equals%2A>, even if they're written with C# or Visual Basic, because they can't have methods. (In addition, structures in the Windows Runtime itself don't inherit <xref:System.ValueType>.) However, they appear to have <xref:System.ValueType.ToString%2A>, <xref:System.ValueType.Equals%2A>, and <xref:System.ValueType.GetHashCode%2A> methods when you use them in your C# or Visual Basic code, and .NET provides the default behavior for these methods.
