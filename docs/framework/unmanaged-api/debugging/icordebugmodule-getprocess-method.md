---
title: "ICorDebugModule::GetProcess Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugModule.GetProcess"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModule::GetProcess"
helpviewer_keywords: 
  - "GetProcess method, ICorDebugModule interface [.NET Framework debugging]"
  - "ICorDebugModule::GetProcess method [.NET Framework debugging]"
ms.assetid: 5e13446c-0271-446c-924a-9072c0e6eeae
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugModule::GetProcess Method
Gets the containing process of this module.  
  
## Syntax  
  
```cpp  
HRESULT GetProcess (  
    [out] ICorDebugProcess **ppProcess  
);  
```  
  
## Parameters  
 `ppProcess`  
 [out] A pointer to the address of an ICorDebugProcess object that represents the process containing this module.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
