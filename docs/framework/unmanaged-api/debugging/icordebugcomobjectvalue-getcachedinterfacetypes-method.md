---
description: "Learn more about: ICorDebugComObjectValue::GetCachedInterfaceTypes Method"
title: "ICorDebugComObjectValue::GetCachedInterfaceTypes Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugComObjectValue::GetCachedInterfaceTypes"
api_location: 
  - "mscordbi.dll"
f1_keywords: 
  - "ICorDebugComObjectValue::GetCachedInterfaceTypes"
helpviewer_keywords: 
  - "GetCachedInterface method, ICorDebugComObjectValue interface [.NET Framework debugging]"
  - "ICorDebugComObjectValue::GetCachedInterface method [.NET Framework debugging]"
ms.assetid: d492284f-d3c5-4614-adb8-d718d5042500
topic_type: 
  - "apiref"
---
# ICorDebugComObjectValue::GetCachedInterfaceTypes Method

Provides an enumerator for the interface types that the current object has been cast to or used as.  
  
## Syntax  
  
```cpp  
HRESULT GetCachedInterfaceTypes(  
    [in] BOOL bIInspectableOnly,  
    [out] ICorDebugTypeEnum **ppInterfacesEnum);  
```  
  
## Parameters  

 `bIInspectableOnly`  
 [in] A value that indicates whether the method returns only Windows Runtime interfaces (`IInspectable` interfaces) or all COM interfaces cached by the runtime callable wrapper (RCW).  
  
 `ppInterfacesEnum`  
 [out] A pointer to the address of an ICorDebugTypeEnum enumerator that provides access to ICorDebugType objects that represent cached interface types filtered according to `bIInspectableOnly`.  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorDebugComObjectValue Interface](icordebugcomobjectvalue-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
