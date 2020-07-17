---
title: "COR_DEBUG_STEP_RANGE Structure"
ms.date: "03/30/2017"
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
---
# COR_DEBUG_STEP_RANGE Structure
Contains the offset information for a range of code.  
  
 This structure is used by the [ICorDebugStepper::StepRange](icordebugstepper-steprange-method.md) method.  
  
## Syntax  
  
```cpp  
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
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [StepRange Method](icordebugstepper-steprange-method.md)
- [Debugging Structures](debugging-structures.md)
- [Debugging](index.md)
