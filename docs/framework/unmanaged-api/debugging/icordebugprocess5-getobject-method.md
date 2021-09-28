---
description: "Learn more about: ICorDebugProcess5::GetObject Method"
title: "ICorDebugProcess5::GetObject Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugProcess5.GetObject"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess5::GetObject"
helpviewer_keywords: 
  - "GetObject method, ICorDebugProcess5 interface [.NET Framework debugging]"
  - "ICorDebugProcess5::GetObject method [.NET Framework debugging]"
ms.assetid: c8111502-5a20-447f-9dc2-76e8acd7ed5a
topic_type: 
  - "apiref"
---
# ICorDebugProcess5::GetObject Method

Converts an object address to an "ICorDebugObjectValue" object.  
  
## Syntax  
  
```cpp  
HRESULT GetObject(  
    [in] CORDB_ADDRESS addr,
    [out] ICorDebugObjectValue **ppObject  
);  
```  
  
## Parameters  

 `addr`  
 [in] The object address.  
  
 `ppObject`  
 [out] A pointer to the address of an  "ICorDebugObjectValue" object.  
  
## Remarks  

 If `addr` does not point to a valid managed object, the `GetObject` method returns `E_FAIL`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorDebugProcess5 Interface](icordebugprocess5-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
