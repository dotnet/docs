---
description: "Learn more about: AssemblyAttributesGoHere Class"
title: "AssemblyAttributesGoHere Class (System.Runtime.CompilerServices)"
ms.date: "03/30/2017"
api_name: 
  - "System.Runtime.CompilerServices.AssemblyAttributesGoHere"
api_location:
  - "mscorlib.dll"
api_type: 
  - "Assembly"
f1_keywords: 
  - "AssemblyAttributesGoHere"
helpviewer_keywords: 
  - "AssemblyAttributesGoHere type"
  - "Alink API, AssemblyAttributesGoHere type"
ms.assetid: 7b26fcb6-94f4-4f09-933e-b33efe451f4f
topic_type: 
  - "apiref"
---
# AssemblyAttributesGoHere Class

Used by ALink as a placeholder to store information about custom attributes.

## Syntax

```csharp
internal sealed class AssemblyAttributesGoHere
```

## Remarks

References to this type might be embedded inside netmodules whose sources contain assembly custom attributes. When building an assembly manifest from one or more netmodules that contain references to these types, ALink uses information attached to these references to emit real custom attributes. As such, this type is never instantiated, and references to it are used only as part of the build process and serve no purpose in the final assembly.

References to this type indicate custom attributes that are not security related and are not multiple-use.

These types are marked "internal" within the .NET Framework and are located in the <xref:System.Runtime.CompilerServices> namespace.

## Requirements

mscorlib.dll

## See also

- [AssemblyAttributesGoHereM](assemblyattributesgoherem.md)
- [AssemblyAttributesGoHereS](assemblyattributesgoheres.md)
- [AssemblyAttributesGoHereSM](assemblyattributesgoheresm.md)
