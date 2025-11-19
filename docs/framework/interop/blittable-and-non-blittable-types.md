---
title: "Blittable and Non-Blittable Types"
description: Learn about blittable and nonblittable types. Blittable data types are commonly represented in managed and unmanaged memory and don't need special handling.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "interop marshalling, blittable types"
  - "blittable types, interop marshalling"
ms.assetid: d03b050e-2916-49a0-99ba-f19316e5c1b3
---
# Blittable and Non-Blittable Types

Most data types have a common representation in both managed and unmanaged memory and don't require special handling by the interop marshaller. These types are called *blittable types* because they don't require conversion when they're passed between managed and unmanaged code.

 Structures that are returned from platform invoke calls must be blittable types. Platform invoke doesn't support nonblittable structures as return types.

 The following types from the <xref:System> namespace are blittable types:

- <xref:System.Byte?displayProperty=nameWithType>
- <xref:System.SByte?displayProperty=nameWithType>
- <xref:System.Int16?displayProperty=nameWithType>
- <xref:System.UInt16?displayProperty=nameWithType>
- <xref:System.Int32?displayProperty=nameWithType>
- <xref:System.UInt32?displayProperty=nameWithType>
- <xref:System.Int64?displayProperty=nameWithType>
- <xref:System.UInt64?displayProperty=nameWithType>
- <xref:System.IntPtr?displayProperty=nameWithType>
- <xref:System.UIntPtr?displayProperty=nameWithType>
- <xref:System.Single?displayProperty=nameWithType>
- <xref:System.Double?displayProperty=nameWithType>

The following complex types are also blittable types:

- One-dimensional arrays of blittable primitive types, such as an array of integers. However, a type that contains a variable array of blittable types is not itself blittable.
- Formatted value types that contain only blittable types (and classes if they're marshalled as formatted types). For more information about formatted value types, see [Default marshalling for value types](default-marshalling-behavior.md#default-marshalling-for-value-types).

 Object references aren't blittable. In addition, an array of references to objects that are blittable by themselves isn't blittable. For example, you can define a structure that's blittable, but you can't define a blittable type that contains an array of references to those structures.

 As an optimization, arrays of blittable primitive types and classes that contain only blittable members are [pinned](copying-and-pinning.md) instead of copied during marshalling. These types can appear to be marshalled as In/Out parameters when the caller and callee are in the same apartment. However, these types are actually marshalled as In parameters, and you must apply the <xref:System.Runtime.InteropServices.InAttribute> and <xref:System.Runtime.InteropServices.OutAttribute> attributes if you want to marshal the argument as an In/Out parameter.

 Some managed data types require a different representation in an unmanaged environment. These nonblittable data types must be converted into a form that can be marshalled. For example, managed strings are nonblittable types because they must be converted into string objects before they can be marshalled.

 The following table lists nonblittable types from the <xref:System> namespace. [Delegates](default-marshalling-behavior.md#default-marshalling-for-delegates), which are data structures that refer to a static method or to a class instance, are also nonblittable.

| Nonblittable type                                | Description                                   |
|---------------------------------------------------|-----------------------------------------------|
| [System.Array](default-marshalling-for-arrays.md) | Converts to a C-style array or a `SAFEARRAY`. |
| [System.Boolean](/previous-versions/dotnet/netframework-4.0/t2t3725f(v=vs.100)) | Converts to a 1, 2, or 4-byte value with `true` as 1 or -1. |
| [System.Char](/previous-versions/dotnet/netframework-4.0/6tyybbf2(v=vs.100)) | Converts to a Unicode or ANSI character. |
| [System.Class](/previous-versions/dotnet/netframework-4.0/s0968xy8(v=vs.100)) | Converts to a class interface. |
| [System.Object](default-marshalling-for-objects.md) | Converts to a variant or an interface. |
| [System.String](default-marshalling-for-strings.md) | Converts to a string terminating in a null reference or to a BSTR. |
| [System.ValueType](/previous-versions/dotnet/netframework-4.0/0t2cwe11(v=vs.100)) | Converts to a structure with a fixed memory layout. |
| [T[]](default-marshalling-for-arrays.md)          | Converts to a C-style array or a `SAFEARRAY`. |

Class and object types are supported only by COM interop.

## See also

- [Default Marshalling Behavior](default-marshalling-behavior.md)
