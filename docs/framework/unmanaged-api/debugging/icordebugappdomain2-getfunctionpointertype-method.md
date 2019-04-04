---
title: "ICorDebugAppDomain2::GetFunctionPointerType Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugAppDomain2.GetFunctionPointerType"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAppDomain2::GetFunctionPointerType"
helpviewer_keywords: 
  - "ICorDebugAppDomain2::GetFunctionPointerType method [.NET Framework debugging]"
  - "GetFunctionPointerType method [.NET Framework debugging]"
ms.assetid: 0aba6096-5b38-435c-a72a-86d35db4daef
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugAppDomain2::GetFunctionPointerType Method
Gets a pointer to a function that has a given signature.  
  
## Syntax  
  
```  
HRESULT GetFunctionPointerType (  
    [in] ULONG32                             nTypeArgs,  
    [in, size_is(nTypeArgs)] ICorDebugType   *ppTypeArgs[],  
    [out] ICorDebugType                      **ppType  
);  
```  
  
## Parameters  
 `nTypeArgs`  
 [in] The number of type arguments for the function.  
  
 `ppTypeArgs`  
 [in] An array of pointers, each of which points to an ICorDebugType object that represents a type argument of the function. The first element is the return type; each of the other elements is a parameter type.  
  
 `ppType`  
 [out] A pointer to the address of an `ICorDebugType` object that represents the pointer to the function.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
