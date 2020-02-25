---
title: "ICorDebugModule::GetAssembly Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugModule.GetAssembly"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModule::GetAssembly"
helpviewer_keywords: 
  - "ICorDebugModule::GetAssembly method [.NET Framework debugging]"
  - "GetAssembly method [.NET Framework debugging]"
ms.assetid: 989762c4-3d15-4485-b8ee-69e0fa8ec895
topic_type: 
  - "apiref"
---
# ICorDebugModule::GetAssembly Method
Gets the containing assembly for this module.  
  
## Syntax  
  
```cpp  
HRESULT GetAssembly(  
    [out] ICorDebugAssembly **ppAssembly  
);  
```  
  
## Parameters  
 `ppAssembly`  
 [out] A pointer to an ICorDebugAssembly object that represents the assembly containing this module.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
