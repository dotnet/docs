---
title: "ICorDebugFunction::GetNativeCode Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugFunction.GetNativeCode"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFunction::GetNativeCode"
helpviewer_keywords: 
  - "GetNativeCode method [.NET Framework debugging]"
  - "ICorDebugFunction::GetNativeCode method [.NET Framework debugging]"
ms.assetid: c8a34916-0eef-4987-8d29-c8bcb4be9cf6
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugFunction::GetNativeCode Method
Gets the native code for the function that is represented by this ICorDebugFunction instance.  
  
## Syntax  
  
```cpp  
HRESULT GetNativeCode (  
    [out] ICorDebugCode **ppCode  
);  
```  
  
## Parameters  
 `ppCode`  
 [out] A pointer to the ICorDebugCode instance that represents the native code for this function, or null, if this function is Microsoft intermediate language (MSIL) code that has not been just-in-time (JIT) compiled.  
  
## Remarks  
 If the function that is represented by this `ICorDebugFunction` instance has been JIT-compiled more than once, as in the case of generic types, `GetNativeCode` returns a random native code object.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
