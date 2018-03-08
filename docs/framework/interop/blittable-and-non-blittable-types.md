---
title: "Blittable and Non-Blittable Types"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "interop marshaling, blittable types"
  - "blittable types, interop marshaling"
ms.assetid: d03b050e-2916-49a0-99ba-f19316e5c1b3
caps.latest.revision: 23
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Blittable and Non-Blittable Types
Most data types have a common representation in both managed and unmanaged memory and do not require special handling by the interop marshaler. These types are called *blittable types* because they do not require conversion when they are passed between managed and unmanaged code.  
  
 Structures that are returned from platform invoke calls must be blittable types. Platform invoke does not support non-blittable structures as return types.  
  
 The following types from the <xref:System> namespace are blittable types:  
  
-   <xref:System.Byte?displayProperty=nameWithType>  
  
-   <xref:System.SByte?displayProperty=nameWithType>  
  
-   <xref:System.Int16?displayProperty=nameWithType>  
  
-   <xref:System.UInt16?displayProperty=nameWithType>  
  
-   <xref:System.Int32?displayProperty=nameWithType>  
  
-   <xref:System.UInt32?displayProperty=nameWithType>  
  
-   <xref:System.Int64?displayProperty=nameWithType>  
  
-   <xref:System.UInt64?displayProperty=nameWithType>  
  
-   <xref:System.IntPtr?displayProperty=nameWithType>  
  
-   <xref:System.UIntPtr?displayProperty=nameWithType>  
  
-   <xref:System.Single?displayProperty=nameWithType>  
  
-   <xref:System.Double?displayProperty=nameWithType>  
  
 The following complex types are also blittable types:  
  
-   One-dimensional arrays of blittable types, such as an array of integers. However, a type that contains a variable array of blittable types is not itself blittable.  
  
-   Formatted value types that contain only blittable types (and classes if they are marshaled as formatted types). For more information about formatted value types, see [Default Marshaling for Value Types](https://msdn.microsoft.com/library/4d9a876c-e05a-40ba-bd85-bd22877f984a(v=vs.100)).  
  
 Object references are not blittable. This includes an array of references to objects that are blittable by themselves. For example, you can define a structure that is blittable, but you cannot define a blittable type that contains an array of references to those structures.  
  
 As an optimization, arrays of blittable types and classes that contain only blittable members are [pinned](../../../docs/framework/interop/copying-and-pinning.md) instead of copied during marshaling. These types can appear to be marshaled as In/Out parameters when the caller and callee are in the same apartment. However, these types are actually marshaled as In parameters, and you must apply the <xref:System.Runtime.InteropServices.InAttribute> and <xref:System.Runtime.InteropServices.OutAttribute> attributes if you want to marshal the argument as an In/Out parameter.  
  
 Some managed data types require a different representation in an unmanaged environment. These non-blittable data types must be converted into a form that can be marshaled. For example, managed strings are non-blittable types because they must be converted into string objects before they can be marshaled.  
  
 The following table lists non-blittable types from the <xref:System> namespace. [Delegates](https://msdn.microsoft.com/library/d176ee76-f982-494b-b03d-92e4118896e2(v=vs.100)), which are data structures that refer to a static method or to a class instance, are also non-blittable.  
  
|Non-blittable type|Description|  
|-------------------------|-----------------|  
|[System.Array](../../../docs/framework/interop/default-marshaling-for-arrays.md)|Converts to a C-style array or a `SAFEARRAY`.|  
|[System.Boolean](https://msdn.microsoft.com/library/d4c00537-70f7-4ca6-8197-bfc1ec037ff9(v=vs.100))|Converts to a 1, 2, or 4-byte value with `true` as 1 or -1.|  
|[System.Char](https://msdn.microsoft.com/library/cecc87c1-075e-4cde-aa56-33d189f66feb(v=vs.100))|Converts to a Unicode or ANSI character.|  
|[System.Class](https://msdn.microsoft.com/library/fe334af5-0123-43d8-be84-26f6f023ddb6(v=vs.100))|Converts to a class interface.|  
|[System.Object](../../../docs/framework/interop/default-marshaling-for-objects.md)|Converts to a variant or an interface.|  
|[System.Mdarray](../../../docs/framework/interop/default-marshaling-for-arrays.md)|Converts to a C-style array or a `SAFEARRAY`.|  
|[System.String](../../../docs/framework/interop/default-marshaling-for-strings.md)|Converts to a string terminating in a null reference or to a BSTR.|  
|[System.Valuetype](https://msdn.microsoft.com/library/4d9a876c-e05a-40ba-bd85-bd22877f984a(v=vs.100))|Converts to a structure with a fixed memory layout.|  
|[System.Szarray](../../../docs/framework/interop/default-marshaling-for-arrays.md)|Converts to a C-style array or a `SAFEARRAY`.|  
  
 Class and object types are supported only by COM interop. For corresponding types in [!INCLUDE[vbprvblong](../../../includes/vbprvblong-md.md)], C#, and C++, see the [Class Library Overview](../../../docs/standard/class-library-overview.md).  
  
## See Also  
 [Default Marshaling Behavior](../../../docs/framework/interop/default-marshaling-behavior.md)
