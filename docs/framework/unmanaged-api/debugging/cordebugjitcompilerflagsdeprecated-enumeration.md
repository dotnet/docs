---
title: "CorDebugJITCompilerFlagsDeprecated Enumeration | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "CorDebugJITCompilerFlagsDeprecated"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "CorDebugJITCompilerFlagsDeprecated"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "CorDebugJITCompilerFlagsDeprecated enumeration [.NET Framework debugging]"
ms.assetid: af15e2ca-6be1-472b-bd36-03644a1e3ddd
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# CorDebugJITCompilerFlagsDeprecated Enumeration
This enumeration is obsolete. Use the `CORDEBUG_JIT_DEFAULT` member of the [CorDebugJITCompilerFlags](../../../../docs/framework/unmanaged-api/debugging/cordebugjitcompilerflags-enumeration.md) enumeration instead.  
  
## Syntax  
  
```  
typedef enum CorDebugJITCompilerFlagsDeprecated {  
    CORDEBUG_JIT_TRACK_DEBUG_INFO  = 0x1  
} CorDebugJITCompilerFlagsDeprecated;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`CORDEBUG_JIT_TRACK_DEBUG_INFO`|Use `CORDEBUG_JIT_DEFAULT` instead.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 1.0, 1.1  
  
## See Also  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)