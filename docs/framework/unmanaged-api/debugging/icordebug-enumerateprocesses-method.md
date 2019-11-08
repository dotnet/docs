---
title: "ICorDebug::EnumerateProcesses Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebug.EnumerateProcesses"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EnumerateProcesses"
helpviewer_keywords: 
  - "EnumerateProcesses method [.NET Framework debugging]"
  - "ICorDebug::EnumerateProcesses method [.NET Framework debugging]"
ms.assetid: ba25d166-1d28-4f1d-aca2-de298bbca669
topic_type: 
  - "apiref"
---
# ICorDebug::EnumerateProcesses Method
Gets an enumerator for the processes that are being debugged.  
  
## Syntax  
  
```cpp  
HRESULT EnumerateProcesses (  
    [out] ICorDebugProcessEnum      **ppProcess  
);  
```  
  
## Parameters  
 `ppProcess`  
 A pointer to the address of an ICorDebugProcessEnum object that is the enumerator for the processes being debugged.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorDebug Interface](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md)
