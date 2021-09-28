---
description: "Learn more about: ICorDebugType::GetFirstTypeParameter Method"
title: "ICorDebugType::GetFirstTypeParameter Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugType.GetFirstTypeParameter"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugType::GetFirstTypeParameter"
helpviewer_keywords: 
  - "ICorDebugType::GetFirstTypeParameter method [.NET Framework debugging]"
  - "GetFirstTypeParameter method [.NET Framework debugging]"
ms.assetid: 35bb594f-af6a-4349-83fe-e98702674e03
topic_type: 
  - "apiref"
---
# ICorDebugType::GetFirstTypeParameter Method

Gets an interface pointer to an ICorDebugType that represents the first <xref:System.Type> parameter of the type represented by this `ICorDebugType`.  
  
## Syntax  
  
```cpp  
HRESULT GetFirstTypeParameter (  
    [out] ICorDebugType   **value  
);  
```  
  
## Parameters  

 `value`  
 [out] A pointer to the address of an `ICorDebugType` object that represents the first parameter.  
  
## Remarks  

 `GetFirstTypeParameter` can be called in cases where the additional information about the type involves, at most, one type parameter. In particular, it can be used if the type is an ELEMENT_TYPE_ARRAY, ELEMENT_TYPE_SZARRAY, ELEMENT_TYPE_BYREF, or ELEMENT_TYPE_PTR, as indicated by the [ICorDebugType::GetType](icordebugtype-gettype-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
