---
title: "COR_DEBUG_STEP_RANGE Structure"
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
  - "COR_DEBUG_STEP_RANGE"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_DEBUG_STEP_RANGE"
helpviewer_keywords: 
  - "COR_DEBUG_STEP_RANGE structure [.NET Framework debugging]"
ms.assetid: 8809d00e-beaa-4dcf-b4e8-e89d0a5406b7
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COR_DEBUG_STEP_RANGE Structure
Contains the offset information for a range of code.  
  
 This structure is used by the [ICorDebugStepper::StepRange](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper-steprange-method.md) method.  
  
## Syntax  
  
```  
typedef struct {  
    ULONG32 startOffset;  
    ULONG32 endOffset;  
} COR_DEBUG_STEP_RANGE;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`startOffset`|The offset of the beginning of the range.|  
|`endOffset`|The offset of the end of the range.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [StepRange Method](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper-steprange-method.md)  
 [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
