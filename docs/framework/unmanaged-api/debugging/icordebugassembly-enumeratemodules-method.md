---
title: "ICorDebugAssembly::EnumerateModules Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugAssembly.EnumerateModules"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAssembly::EnumerateModules"
helpviewer_keywords: 
  - "ICorDebugAssembly::EnumerateModules method [.NET Framework debugging]"
  - "EnumerateModules method [.NET Framework debugging]"
ms.assetid: c7ba51a1-0dd5-4452-b471-232febe0f897
topic_type: 
  - "apiref"
---
# ICorDebugAssembly::EnumerateModules Method
Gets an enumerator for the modules contained in the `ICorDebugAssembly`.  
  
## Syntax  
  
```cpp  
HRESULT EnumerateModules (  
    [out] ICorDebugModuleEnum **ppModules  
);  
```  
  
## Parameters  
 `ppModules`  
 [out] A pointer to the address of the ICorDebugModuleEnum interface that is the enumerator.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
