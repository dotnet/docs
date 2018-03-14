---
title: "COR_ACTIVE_FUNCTION Structure"
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
  - "COR_ACTIVE_FUNCTION"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_ACTIVE_FUNCTION"
helpviewer_keywords: 
  - "COR_ACTIVE_FUNCTION structure [.NET Framework debugging]"
ms.assetid: ed86185f-2152-459c-961f-10c06d62e83f
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COR_ACTIVE_FUNCTION Structure
Contains information about the functions that are currently active in a thread's frames. This structure is used by the [ICorDebugThread2::GetActiveFunctions](../../../../docs/framework/unmanaged-api/debugging/icordebugthread2-getactivefunctions-method.md) method.  
  
## Syntax  
  
```  
typedef struct  _COR_ACTIVE_FUNCTION {  
    ICorDebugAppDomain   *pAppDomain;  
    ICorDebugModule      *pModule;  
    ICorDebugFunction2   *pFunction;  
    ULONG32              ilOffset;  
    ULONG32              flags;  
} COR_ACTIVE_FUNCTION;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`pAppDomain`|Pointer to the application domain owner of the `ilOffset` field.|  
|`pModule`|Pointer to the module owner of the `ilOffset` field.|  
|`pFunction`|Pointer to the function owner of the `ilOffset` field.|  
|`ilOffset`|The Microsoft intermediate language (MSIL) offset of the frame.|  
|`flags`|Reserved for future extensibility.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
