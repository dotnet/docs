---
description: "Learn more about: ICorDebugMDA::GetFlags Method"
title: "ICorDebugMDA::GetFlags Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugMDA.GetFlags"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugMDA::GetFlags"
helpviewer_keywords: 
  - "ICorDebugMDA::GetFlags method [.NET Framework debugging]"
  - "GetFlags method [.NET Framework debugging]"
ms.assetid: 87ce7c5b-fd82-453e-bf55-c8a32150b183
topic_type: 
  - "apiref"
---
# ICorDebugMDA::GetFlags Method

Gets the flags associated with the managed debugging assistant (MDA) represented by [ICorDebugMDA](icordebugmda-interface.md).  
  
## Syntax  
  
```cpp  
HRESULT GetFlags (  
    [in] CorDebugMDAFlags *pFlags  
);  
```  
  
## Parameters  

 `pFlags`  
 [in] A bitwise combination of the [CorDebugMDAFlags](cordebugmdaflags-enumeration.md) enumeration values that specify the settings of the flags for this MDA.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorDebugMDA Interface](icordebugmda-interface.md)
- [Diagnosing Errors with Managed Debugging Assistants](../../debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
