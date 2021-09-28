---
description: "Learn more about: ICorDebugVariableHome::GetCode Method"
title: "ICorDebugVariableHome::GetCode Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugVariableHome.GetCode"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugVariableHome::GetCode"
helpviewer_keywords: 
  - "ICorDebugVariableHome::GetCode method [.NET Framework debugging]"
  - "GetCode method, ICorDebugVariableHome interface [.NET Framework debugging]"
ms.assetid: ef002890-4a7b-4a5d-abbf-16c60083f794
topic_type: 
  - "apiref"
---
# ICorDebugVariableHome::GetCode Method

Gets the "ICorDebugCode" instance that contains this [ICorDebugVariableHome](icordebugvariablehome-interface.md) object.  
  
## Syntax  
  
```cpp  
HRESULT GetCode(  
    [out] ICorDebugCode **ppCode  
);  
```  
  
## Parameters  

 `ppCode`  
 [out] A pointer to the address of the "ICorDebugCode" instance that contains this [ICorDebugVariableHome](icordebugvariablehome-interface.md) object.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v462plus](../../../../includes/net-current-v462plus-md.md)]  
  
## See also

- [ICorDebugVariableHome Interface](icordebugvariablehome-interface.md)
