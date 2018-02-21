---
title: "ICorDebugEval2::NewParameterizedObjectNoConstructor Method"
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
  - "ICorDebugEval2.NewParameterizedObjectNoConstructor"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval2::NewParameterizedObjectNoConstructor"
helpviewer_keywords: 
  - "NewParameterizedObjectNoConstructor method [.NET Framework debugging]"
  - "ICorDebugEval2::NewParameterizedObjectNoConstructor method [.NET Framework debugging]"
ms.assetid: f15b5b78-94f4-4eb9-b3b3-a621272f357c
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugEval2::NewParameterizedObjectNoConstructor Method
Instantiates a new parameterized type object of the specified class without attempting to call a constructor method.  
  
## Syntax  
  
```  
HRESULT NewParameterizedObjectNoConstructor (  
    [in] ICorDebugClass        *pClass,  
    [in] ULONG32               nTypeArgs,  
    [in, size_is(nTypeArgs)] ICorDebugType *ppTypeArgs[]  
);  
```  
  
#### Parameters  
 `pClass`  
 [in] A pointer to an ICorDebugClass object that represents the class of the object to be instantiated.  
  
 `nTypeArgs`  
 [in] The number of type arguments passed.  
  
 `ppTypeArgs`  
 [in] An array of pointers, each of which points to an ICorDebugType object that represents a type argument for the object that is being instantiated.  
  
## Remarks  
 The `NewParameterizedObjectNoConstructor` method will fail if an incorrect number of type arguments or the wrong types of type arguments are passed.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
