---
title: "ICorDebug::GetProcess Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebug.GetProcess"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebug::GetProcess"
helpviewer_keywords: 
  - "GetProcess method, ICorDebug interface [.NET Framework debugging]"
  - "ICorDebug::GetProcess method [.NET Framework debugging]"
ms.assetid: 10a40ba0-1b65-4721-bd11-cf12d57b280d
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebug::GetProcess Method
Gets a pointer to the "ICorDebugProcess" instance for the specified process.  
  
## Syntax  
  
```cpp  
HRESULT GetProcess (  
    [in] DWORD               dwProcessId,  
    [out] ICorDebugProcess   **ppProcess  
);  
```  
  
## Parameters  
 `dwProcessId`  
 [in] The ID of the process.  
  
 `ppProcess`  
 [out] A pointer to the address of a `ICorDebugProcess` instance for the specified process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorDebug Interface](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md)
