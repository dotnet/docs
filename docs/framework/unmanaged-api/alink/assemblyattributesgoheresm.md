---
title: "AssemblyAttributesGoHereSM Class (System.Runtime.CompilerServices)"
ms.date: "03/30/2017"
api_name: 
  - "System.Runtime.CompilerServices.AssemblyAttributesGoHereSM"
api_location:
  - "mscorlib.dll"
api_type: 
  - "Assembly"
f1_keywords:
  - "AssemblyAttributesGoHereSM"
helpviewer_keywords: 
  - "AssemblyAttributesGoHereSM type"
  - "Alink API, AssemblyAttributesGoHereSM type"
ms.assetid: 4cf9bf39-1527-49e0-a0e9-55e7a018bf66
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# AssemblyAttributesGoHereSM Class

Used by ALink as a placeholder to store information about custom attributes.

## Syntax

```csharp
internal sealed class AssemblyAttributesGoHereSM
```

## Remarks

References to this type might be embedded inside netmodules whose sources contain assembly custom attributes. When building an assembly manifest from one or more netmodules that contain references to these types, ALink uses information attached to these references to emit real custom attributes. As such, this type is never instantiated, and references to it are used only as part of the build process and serve no purpose in the final assembly.

References to this type indicate custom attributes that are security related and multiple-use.

These types are marked "internal" within the .NET Framework and are located in the <xref:System.Runtime.CompilerServices> namespace.

## Requirements

mscorlib.dll

## See also

- [AssemblyAttributesGoHere](assemblyattributesgohere.md)
- [AssemblyAttributesGoHereM](assemblyattributesgoherem.md)
- [AssemblyAttributesGoHereS](assemblyattributesgoheres.md)
