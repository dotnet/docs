---
title: "ICorDebugProcess::GetHandle Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugProcess.GetHandle"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess::GetHandle"
helpviewer_keywords: 
  - "GetHandle method, ICorDebugProcess interface [.NET Framework debugging]"
  - "ICorDebugProcess::GetHandle method [.NET Framework debugging]"
ms.assetid: e7d3ecf5-09d2-4d94-abb6-ff3483deebb6
topic_type: 
  - "apiref"
---
# ICorDebugProcess::GetHandle Method
Gets a handle to the process.  
  
## Syntax  
  
```cpp  
HRESULT GetHandle([out] HPROCESS *phProcessHandle);  
```  
  
## Parameters  
 `phProcessHandle`  
 [out] A pointer to an `HPROCESS` that is the handle to the process.  
  
## Remarks  
 The retrieved handle is owned by the debugging interface. The debugger should duplicate the handle before using it.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
