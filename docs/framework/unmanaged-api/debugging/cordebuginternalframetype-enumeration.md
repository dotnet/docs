---
title: "CorDebugInternalFrameType Enumeration"
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
  - "CorDebugInternalFrameType"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugInternalFrameType"
helpviewer_keywords: 
  - "CorDebugInternalFrameType enumeration [.NET Framework debugging]"
ms.assetid: e4412dc2-c338-4cfb-94d8-f682095dd2b1
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorDebugInternalFrameType Enumeration
Identifies the type of stack frame. This enumeration is used by the [ICorDebugInternalFrame::GetFrameType](../../../../docs/framework/unmanaged-api/debugging/icordebuginternalframe-getframetype-method.md) method.  
  
## Syntax  
  
```  
typedef enum CorDebugInternalFrameType {  
  
    STUBFRAME_NONE                 = 0x00000000,  
    STUBFRAME_M2U                  = 0x00000001,  
    STUBFRAME_U2M                  = 0x00000002,  
    STUBFRAME_APPDOMAIN_TRANSITION = 0x00000003,  
    STUBFRAME_LIGHTWEIGHT_FUNCTION = 0x00000004,  
    STUBFRAME_FUNC_EVAL            = 0x00000005,  
    STUBFRAME_INTERNALCALL         = 0x00000006,  
    STUBFRAME_CLASS_INIT           = 0x00000007,  
    STUBFRAME_EXCEPTION            = 0x00000008,  
    STUBFRAME_SECURITY             = 0x00000009,  
    STUBFRAME_JIT_COMPILATION     = 0x0000000a,  
} CorDebugInternalFrameType;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`STUBFRAME_NONE`|A null value. The `ICorDebugInternalFrame::GetFrameType` method never returns this value.|  
|`STUBFRAME_M2U`|A managed-to-unmanaged stub frame.|  
|`STUBFRAME_U2M`|An unmanaged-to-managed stub frame.|  
|`STUBFRAME_APPDOMAIN_TRANSITION`|A transition between application domains.|  
|`STUBFRAME_LIGHTWEIGHT_FUNCTION`|A lightweight method call.|  
|`STUBFRAME_FUNC_EVAL`|The start of function evaluation.|  
|`STUBFRAME_INTERNALCALL`|An internal call into the common language runtime.|  
|`STUBFRAME_CLASS_INIT`|The start of a class initialization.|  
|`STUBFRAME_EXCEPTION`|An exception that is thrown.|  
|`STUBFRAME_SECURITY`|A frame used for code access security.|  
|`STUBFRAME_JIT_COMPILATION`|The runtime is JIT-compiling a method.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)
