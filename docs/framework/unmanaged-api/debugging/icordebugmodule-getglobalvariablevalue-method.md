---
title: "ICorDebugModule::GetGlobalVariableValue Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugModule.GetGlobalVariableValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModule::GetGlobalVariableValue"
helpviewer_keywords: 
  - "ICorDebugModule::GetGlobalVariableValue method [.NET Framework debugging]"
  - "GetGlobalVariableValue method [.NET Framework debugging]"
ms.assetid: bbc0881c-6a59-41a0-b5ee-2f3d1b71684c
topic_type: 
  - "apiref"
---
# ICorDebugModule::GetGlobalVariableValue Method
Gets the value of the specified global variable.  
  
## Syntax  
  
```cpp  
HRESULT GetGlobalVariableValue(  
    [in]  mdFieldDef      fieldDef,  
    [out] ICorDebugValue  **ppValue  
);  
```  
  
## Parameters  
 `fieldDef`  
 [in] An `mdFieldDef` token that references the metadata describing the global variable.  
  
 `ppValue`  
 [out] A pointer to the address of an ICorDebugValue object that represents the value of the specified global variable.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
