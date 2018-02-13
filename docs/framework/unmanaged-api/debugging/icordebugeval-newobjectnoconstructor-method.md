---
title: "ICorDebugEval::NewObjectNoConstructor Method"
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
  - "ICorDebugEval.NewObjectNoConstructor"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval::NewObjectNoConstructor"
helpviewer_keywords: 
  - "NewObjectNoConstructor method [.NET Framework debugging]"
  - "ICorDebugEval::NewObjectNoConstructor method [.NET Framework debugging]"
ms.assetid: 80d509ca-b5e3-4c46-9c14-800db73d9bf7
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugEval::NewObjectNoConstructor Method
Allocates a new object instance of the specified type, without attempting to call a constructor method.  
  
 This method is obsolete in the .NET Framework version 2.0. Use [ICorDebugEval2::NewParameterizedObjectNoConstructor](../../../../docs/framework/unmanaged-api/debugging/icordebugeval2-newparameterizedobjectnoconstructor-method.md) instead.  
  
## Syntax  
  
```  
HRESULT NewObjectNoConstructor (  
    [in] ICorDebugClass     *pClass  
);  
```  
  
#### Parameters  
 `pClass`  
 [in] Pointer to an ICorDebugClass object that represents the type of object to be instantiated.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 1.1, 1.0  
  
## See Also  
 [NewParameterizedObjectNoConstructor Method](../../../../docs/framework/unmanaged-api/debugging/icordebugeval2-newparameterizedobjectnoconstructor-method.md)
