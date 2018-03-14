---
title: "AssemblyAttributesGoHereSM"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "AssemblyAttributesGoHereSM"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "AssemblyAttributesGoHereSM"
helpviewer_keywords: 
  - "AssemblyAttributesGoHereSM type"
  - "Alink API, AssemblyAttributesGoHereSM type"
ms.assetid: 4cf9bf39-1527-49e0-a0e9-55e7a018bf66
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# AssemblyAttributesGoHereSM
Used by ALink as a placeholder to store information about custom attributes.  
  
## Syntax  
  
```  
AssemblyAttributeGoHereSM  
```  
  
## Remarks  
 References to this type might be embedded inside netmodules whose sources contain assembly custom attributes. When building an assembly manifest from one or more netmodules that contain references to these types, ALink uses information attached to these references to emit real custom attributes. As such, this type is never instantiated, and references to it are used only as part of the build process and serve no purpose in the final assembly.  
  
 References to this type indicate custom attributes that are security related and multiple-use.  
  
 These types are marked "internal" within the .NET Framework, and are located in <xref:System.Runtime.CompilerServices>.  
  
## Requirements  
 mscorlib.dll  
  
## See Also  
 [AssemblyAttributesGoHere](../../../../docs/framework/unmanaged-api/alink/assemblyattributesgohere.md)  
 [AssemblyAttributesGoHereM](../../../../docs/framework/unmanaged-api/alink/assemblyattributesgoherem.md)  
 [AssemblyAttributesGoHereS](../../../../docs/framework/unmanaged-api/alink/assemblyattributesgoheres.md)
