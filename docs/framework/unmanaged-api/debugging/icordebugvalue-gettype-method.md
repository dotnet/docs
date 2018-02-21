---
title: "ICorDebugValue::GetType Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICorDebugValue.GetType"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugValue::GetType"
helpviewer_keywords: 
  - "ICorDebugValue::GetType method [.NET Framework debugging]"
  - "GetType method, ICorDebugValue interface [.NET Framework debugging]"
ms.assetid: 41e2d503-e1f1-407b-abe0-6a29adb3e0d1
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugValue::GetType Method
Gets the primitive type of this "ICorDebugValue" object.  
  
## Syntax  
  
```  
HRESULT GetType (  
    [out] CorElementType   *pType  
);  
```  
  
#### Parameters  
 `pType`  
 [out] A pointer to a value of the "CorElementType" enumeration that indicates the value's type.  
  
## Remarks  
 If the object is a complex run-time type, that type may be examined through the appropriate subclasses of the `ICorDebugValue` interface. For example, "ICorDebugObjectValue", which inherits from `ICorDebugValue`, represents a complex type.  
  
 The `GetType` and [ICorDebugObjectValue::GetClass](../../../../docs/framework/unmanaged-api/debugging/icordebugobjectvalue-getclass-method.md) methods each return information about the type of a value. They are both superseded by the generics-aware [ICorDebugValue2::GetExactType](../../../../docs/framework/unmanaged-api/debugging/icordebugvalue2-getexacttype-method.md) method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 
