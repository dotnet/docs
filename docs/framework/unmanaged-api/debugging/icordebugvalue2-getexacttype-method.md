---
description: "Learn more about: ICorDebugValue2::GetExactType Method"
title: "ICorDebugValue2::GetExactType Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugValue2.GetExactType"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugValue2::GetExactType"
helpviewer_keywords: 
  - "ICorDebugValue2::GetExactType method [.NET Framework debugging]"
  - "GetExactType method [.NET Framework debugging]"
ms.assetid: 8e9aae1b-d1b7-4b6e-b577-6faf36dcec85
topic_type: 
  - "apiref"
---
# ICorDebugValue2::GetExactType Method

Gets an interface pointer to an "ICorDebugType" object that represents the <xref:System.Type> of this value.  
  
## Syntax  
  
```cpp  
HRESULT GetExactType (  
    [out] ICorDebugType   **ppType  
);  
```  
  
## Parameters  

 `ppType`  
 [out] A pointer to the address of an `ICorDebugType` object that represents the <xref:System.Type> of the value represented by this "ICorDebugValue2" object.  
  
## Remarks  

 The generics-aware `GetExactType` method supersedes both the [ICorDebugObjectValue::GetClass](icordebugobjectvalue-getclass-method.md) and the [ICorDebugValue::GetType](icordebugvalue-gettype-method.md) methods, each of which return information about the type of a value.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
