---
title: System.ValueType.GetHashCode method
description: Learn about the System.ValueType.GetHashCode method.
ms.date: 01/24/2024
---
# System.ValueType.GetHashCode method

[!INCLUDE [context](includes/context.md)]

The <xref:System.ValueType.GetHashCode%2A> method applies to types derived from <xref:System.ValueType>. One or more fields of the derived type is used to calculate the return value. If you call the derived type's `GetHashCode` method, the return value is not likely to be suitable for use as a key in a hash table. Additionally, if the value of one or more of those fields changes, the return value might become unsuitable for use as a key in a hash table. In either case, consider writing your own implementation of the <xref:System.ValueType.GetHashCode%2A> method that more closely represents the concept of a hash code for the type.

For more information, see <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType>, and <xref:System.Collections.Hashtable?displayProperty=nameWithType>.

## Notes for the Windows Runtime

When you call the <xref:System.ValueType.GetHashCode%2A> method on a Windows Runtime structure, it provides the default behavior for value types that don't override <xref:System.ValueType.GetHashCode%2A>. This is part of the support that .NET provides for the Windows Runtime (see [.NET Support for Windows Store Apps and Windows Runtime](/dotnet/standard/cross-platform/support-for-windows-store-apps-and-windows-runtime)). Windows Runtime structures can't override <xref:System.ValueType.GetHashCode%2A>, even if they're written with C# or Visual Basic, because they can't have methods. (In addition, structures in the Windows Runtime itself don't inherit <xref:System.ValueType>.) However, they appear to have <xref:System.ValueType.ToString%2A>, <xref:System.ValueType.Equals%2A>, and <xref:System.ValueType.GetHashCode%2A> methods when you use them in your C# or Visual Basic code, and .NET provides the default behavior for these methods.
