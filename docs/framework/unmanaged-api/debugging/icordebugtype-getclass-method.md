---
description: "Learn more about: ICorDebugType::GetClass Method"
title: "ICorDebugType::GetClass Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugType.GetClass"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugType::GetClass"
helpviewer_keywords: 
  - "ICorDebugType::GetClass method [.NET Framework debugging]"
  - "GetClass method, ICorDebugType interface [.NET Framework debugging]"
ms.assetid: 2644f48b-db3c-429f-ae62-76f1c98a1af5
topic_type: 
  - "apiref"
---
# ICorDebugType::GetClass Method

Gets an interface pointer to an ICorDebugClass that represents the uninstantiated generic type.  
  
## Syntax  
  
```cpp  
HRESULT GetClass (  
    [out] ICorDebugClass   **ppClass  
);  
```  
  
## Parameters  

 `ppClass`  
 [out] A pointer to the address of an `ICorDebugClass` interface that represents the uninstantiated generic type.  
  
## Remarks  

 `GetClass` can be called only under certain conditions. Call [ICorDebugType::GetType](icordebugtype-gettype-method.md) before calling `GetClass`. If `ICorDebugType::GetType` returns a CorElementType value that is ELEMENT_TYPE_CLASS or ELEMENT_TYPE_VALUETYPE, `GetClass` can be called to get the uninstantiated type for a generic type.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
