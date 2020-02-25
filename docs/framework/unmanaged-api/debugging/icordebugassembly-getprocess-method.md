---
title: "ICorDebugAssembly::GetProcess Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugAssembly.GetProcess"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAssembly::GetProcess"
helpviewer_keywords: 
  - "ICorDebugAssembly::GetProcess method [.NET Framework debugging]"
  - "GetProcess method, ICorDebugAssembly interface [.NET Framework debugging]"
ms.assetid: ea52be06-0a16-4f57-afca-4287d72e76c4
topic_type: 
  - "apiref"
---
# ICorDebugAssembly::GetProcess Method
Gets an interface pointer to the process in which this ICorDebugAssembly instance is running.  
  
## Syntax  
  
```cpp  
HRESULT GetProcess (  
    [out] ICorDebugProcess **ppProcess  
);  
```  
  
## Parameters  
 `ppProcess`  
 [out] A pointer to an ICorDebugProcess interface that represents the process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
