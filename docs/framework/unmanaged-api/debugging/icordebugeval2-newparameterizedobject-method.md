---
title: "ICorDebugEval2::NewParameterizedObject Method"
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
  - "ICorDebugEval2.NewParameterizedObject"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval2::NewParameterizedObject"
helpviewer_keywords: 
  - "NewParameterizedObject method [.NET Framework debugging]"
  - "ICorDebugEval2::NewParameterizedObject method [.NET Framework debugging]"
ms.assetid: 3d705463-e640-4249-8036-4e8206d03cfe
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugEval2::NewParameterizedObject Method
Instantiates a new parameterized type object and calls the object's constructor method.  
  
## Syntax  
  
```  
HRESULT NewParameterizedObject (  
    [in] ICorDebugFunction     *pConstructor,  
    [in] ULONG32               nTypeArgs,  
    [in, size_is(nTypeArgs)] ICorDebugType *ppTypeArgs[],  
    [in] ULONG32               nArgs,  
    [in, size_is(nArgs)] ICorDebugValue *ppArgs[]  
);  
```  
  
#### Parameters  
 `pConstructor`  
 [in] A pointer to an ICorDebugFunction object that represents the constructor of the object to be instantiated.  
  
 `nTypeArgs`  
 [in] The number of type arguments passed.  
  
 `ppTypeArgs`  
 [in] An array of pointers, each of which points to an ICorDebugType object that represents a type argument for the object that is being instantiated.  
  
 `nArgs`  
 [in] The number of arguments passed to the constructor.  
  
 `ppArgs`  
 [in] An array of pointers, each of which points to an ICorDebugValue object that represents an argument value that is passed to the constructor.  
  
## Remarks  
 The object's constructor may take <xref:System.Type> parameters.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
