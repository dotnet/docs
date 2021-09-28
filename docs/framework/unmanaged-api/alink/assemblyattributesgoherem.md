---
description: "Learn more about: AssemblyAttributesGoHereM Class"
title: "AssemblyAttributesGoHereM Class (System.Runtime.CompilerServices)"
ms.date: "03/30/2017"
api_name: 
  - "System.Runtime.CompilerServices.AssemblyAttributesGoHereM"
api_location:
  - "mscorlib.dll"
api_type: 
  - "Assembly"
f1_keywords: 
  - "AssemblyAttributesGoHereM"
helpviewer_keywords: 
  - "AssemblyAttributesGoHereM type"
  - "Alink API, AssemblyAttributesGoHereM type"
ms.assetid: caaa8ba9-b4bb-4dd6-934d-57e436b2f3e5
topic_type: 
  - "apiref"
---
# AssemblyAttributesGoHereM Class

Used by ALink as a placeholder to store information about custom attributes.

## Syntax

```csharp
internal sealed class AssemblyAttributesGoHereM
```

## Remarks

References to this type might be embedded inside netmodules whose sources contain assembly custom attributes. When building an assembly manifest from one or more netmodules that contain references to these types, ALink uses information attached to these references to emit real custom attributes. As such, this type is never instantiated, and references to it are used only as part of the build process and serve no purpose in the final assembly.

References to this type indicate custom attributes that are not security related but are multiple-use.

These types are marked "internal" within the .NET Framework and are located in the <xref:System.Runtime.CompilerServices> namespace.

## Requirements

mscorlib.dll

## See also

- [AssemblyAttributesGoHere](assemblyattributesgohere.md)
- [AssemblyAttributesGoHereS](assemblyattributesgoheres.md)
- [AssemblyAttributesGoHereSM](assemblyattributesgoheresm.md)
