---
description: "Learn more about: ICorDebugProcess5::GetTypeFields Method"
title: "ICorDebugProcess5::GetTypeFields Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugProcess5.GetTypeFields"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess5::GetTypeFields"
helpviewer_keywords: 
  - "GetTypeFields method, ICorDebugProcess5 interface [.NET Framework debugging]"
  - "ICorDebugProcess5::GetTypeFields method [.NET Framework debugging]"
ms.assetid: 6a0ad3ee-dacb-47e9-abae-4536bcc4804b
topic_type: 
  - "apiref"
---
# ICorDebugProcess5::GetTypeFields Method

Provides information about the fields that belong to a type.  
  
## Syntax  
  
```cpp  
HRESULT GetTypeFields(  
    [in] COR_TYPEID id,  
    [in] ULONG32 celt,  
    [out] COR_FIELD fields[],
    [out] ULONG32 *pceltNeeded  
);  
```  
  
## Parameters  

 `id`  
 [in] The identifier of the type whose field information is retrieved.  
  
 `celt`  
 [in] The number of [COR_FIELD](cor-field-structure.md) objects whose field information is to be retrieved.  
  
 `fields`  
 [out] An array of [COR_FIELD](cor-field-structure.md) objects that provide information about the fields that belong to the type.  
  
 `pceltNeeded`  
 [out] A pointer to the number of [COR_FIELD](cor-field-structure.md) objects included in `fields`.  
  
## Remarks  

 The `celt` parameter, which specifies the number of fields whose field information the method uses to populate `fields`, should correspond to the value of the `COR_TYPE_LAYOUT::numFields` field.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorDebugProcess5 Interface](icordebugprocess5-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
