---
description: "Learn more about: ICorDebugProcess5::GetTypeForTypeID Method"
title: "ICorDebugProcess5::GetTypeForTypeID Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugProcess5.GetTypeForTypeID"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess5::GetTypeForTypeID"
helpviewer_keywords: 
  - "GetTypeForTypeID method, ICorDebugProcess5 interface [.NET Framework debugging]"
  - "ICorDebugProcess5::GetTypeForTypeID method [.NET Framework debugging]"
ms.assetid: e0eed5a8-fa6d-4818-bd00-7babcea30325
topic_type: 
  - "apiref"
---
# ICorDebugProcess5::GetTypeForTypeID Method

Converts a type identifier to an ICorDebugType value.  
  
## Syntax  
  
```cpp  
HRESULT GetTypeForTypeID(  
    [in] COR_TYPEID id, [  
    out] ICorDebugType **ppType  
);  
```  
  
## Parameters  

 `id`  
 [in] The type identifier.  
  
 `ppType`  
 [out] A pointer to the address of an ICorDebugType object.  
  
## Remarks  

 In some cases, methods that return a type identifier may return a null `COR_TYPEID` value. If this value is passed as the `id` argument, the `GetTypeForTypeID` method will fail and return `E_FAIL`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorDebugProcess5 Interface](icordebugprocess5-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
