---
title: "ICorDebugEval2::CallParameterizedFunction Method"
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
  - "ICorDebugEval2.CallParameterizedFunction"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval2::CallParameterizedFunction"
helpviewer_keywords: 
  - "ICorDebugEval2::CallParameterizedFunction method [.NET Framework debugging]"
  - "CallParameterizedFunction method [.NET Framework debugging]"
ms.assetid: 72f54a45-dbe6-4bb4-8c99-e879a27368e5
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugEval2::CallParameterizedFunction Method
Sets up a call to the specified ICorDebugFunction, which can be nested inside a class whose constructor takes <xref:System.Type> parameters, or can itself take <xref:System.Type> parameters.  
  
## Syntax  
  
```  
HRESULT CallParameterizedFunction (  
    [in] ICorDebugFunction     *pFunction,  
    [in] ULONG32               nTypeArgs,  
    [in, size_is(nTypeArgs)] ICorDebugType *ppTypeArgs[],  
    [in] ULONG32               nArgs,  
    [in, size_is(nArgs)] ICorDebugValue *ppArgs[]  
);  
```  
  
#### Parameters  
 `pFunction`  
 [in] A pointer to an `ICorDebugFunction` object that represents the function to be called.  
  
 `nTypeArgs`  
 [in] The number of arguments that the function takes.  
  
 `ppTypeArgs`  
 [in] An array of pointers, each of which points to an ICorDebugType object that represents a function argument.  
  
 `nArgs`  
 [in] The number of values passed in the function.  
  
 `ppArgs`  
 [in] An array of pointers, each of which points to an ICorDebugValue object that represents a value passed in a function argument.  
  
## Remarks  
 `CallParameterizedFunction` is like [ICorDebugEval::CallFunction](../../../../docs/framework/unmanaged-api/debugging/icordebugeval-callfunction-method.md) except that the function may be inside a class with type parameters, may itself take type parameters, or both. The type arguments should be given first for the class, and then for the function.  
  
 If the function is in a different application domain, a transition will occur. However, all type and value arguments must be in the target application domain.  
  
 Function evaluation can be performed only in limited scenarios. If `CallParameterizedFunction` or `ICorDebugEval::CallFunction` fails, the returned HRESULT will indicate the most general possible reason for failure.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
