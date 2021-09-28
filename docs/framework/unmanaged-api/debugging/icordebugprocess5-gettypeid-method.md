---
description: "Learn more about: ICorDebugProcess5::GetTypeID Method"
title: "ICorDebugProcess5::GetTypeID Method"
ms.date: "03/30/2017"
dev_langs: 
  - "cpp"
api_name: 
  - "ICorDebugProcess5.GetTypeID"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess5::GetTypeID"
helpviewer_keywords: 
  - "ICorDebugProcess5::GetTypeID method [.NET Framework debugging]"
  - "GetTypeID method, ICorDebugProcess5 interface [.NET Framework debugging]"
ms.assetid: 47dbaea4-8857-462e-93ba-fff880fc9e50
topic_type: 
  - "apiref"
---
# ICorDebugProcess5::GetTypeID Method

Converts an object address to a [COR_TYPEID](cor-typeid-structure.md) identifier.  
  
## Syntax  
  
```cpp
HRESULT GetTypeID(  
    [in] CORDB_ADDRESS obj,  
    [out] COR_TYPEID *pId  
);  
```  
  
## Parameters  

 `obj`  
 [in] The object address.  
  
 `pId`  
 A pointer to the [COR_TYPEID](cor-typeid-structure.md) value that identifies the object.  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorDebugProcess5 Interface](icordebugprocess5-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
