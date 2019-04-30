---
title: "ICorDebugValueBreakpoint::GetValue Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugValueBreakpoint.GetValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugValueBreakpoint::GetValue"
helpviewer_keywords: 
  - "GetValue method, ICorDebugValueBreakpoint interface [.NET Framework debugging]"
  - "ICorDebugValueBreakpoint::GetValue method [.NET Framework debugging]"
ms.assetid: 52a73654-bc47-48b6-b2b1-a4456b10140c
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugValueBreakpoint::GetValue Method
Gets an interface pointer to an "ICorDebugValue" object that represents the value of the object on which the breakpoint is set.  
  
## Syntax  
  
```  
HRESULT GetValue (  
    [out] ICorDebugValue   **ppValue  
);  
```  
  
## Parameters  
 `ppValue`  
 [out] A pointer to the address of an `ICorDebugValue` object.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
