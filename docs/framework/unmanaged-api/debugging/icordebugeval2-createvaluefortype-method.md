---
title: "ICorDebugEval2::CreateValueForType Method"
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
  - "ICorDebugEval2.CreateValueForType"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval2::CreateValueForType"
helpviewer_keywords: 
  - "CreateValueForType method [.NET Framework debugging]"
  - "ICorDebugEval2::CreateValueForType method [.NET Framework debugging]"
ms.assetid: ea38ae20-7e0a-427a-be77-d78fae719d82
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugEval2::CreateValueForType Method
Gets a pointer to a new ICorDebugValue of the specified type, with an initial value of zero or null.  
  
## Syntax  
  
```  
HRESULT CreateValueForType (  
    [in] ICorDebugType         *pType,  
    [out] ICorDebugValue       **ppValue  
);  
```  
  
#### Parameters  
 `pType`  
 [in] Pointer to an ICorDebugType object that represents the type.  
  
 `ppValue`  
 [out] Pointer to the address of an `ICorDebugValue` object that represents the value.  
  
## Remarks  
 `CreateValueForType` generalizes [ICorDebugEval::CreateValue](../../../../docs/framework/unmanaged-api/debugging/icordebugeval-createvalue-method.md) by allowing you to specify an arbitrary object type, including constructed types such as `List<int>`. The only purpose of this method is to generate a value that can be passed to a function evaluation.  
  
 The type must be a class or a value type. You cannot use this method to create array values or string values.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
