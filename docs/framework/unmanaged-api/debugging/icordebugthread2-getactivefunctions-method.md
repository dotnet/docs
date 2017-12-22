---
title: "ICorDebugThread2::GetActiveFunctions Method"
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
  - "ICorDebugThread2.GetActiveFunctions"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread2::GetActiveFunctions"
helpviewer_keywords: 
  - "GetActiveFunctions method [.NET Framework debugging]"
  - "ICorDebugThread2::GetActiveFunctions method [.NET Framework debugging]"
ms.assetid: 27fae01a-ecec-423a-973e-24f8de55826c
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugThread2::GetActiveFunctions Method
Gets information about the active function in each of this thread's frames.  
  
## Syntax  
  
```  
HRESULT GetActiveFunctions (  
    [in]   ULONG32             cFunctions,  
    [out]  ULONG32             *pcFunctions,  
    [in, out, size_is(cFunctions), length_is(*pcFunctions)]  
        COR_ACTIVE_FUNCTION    pFunctions[]  
);  
```  
  
#### Parameters  
 `cFunctions`  
 [in] The size of the `pFunctions` array.  
  
 `pcFunctions`  
 [out] A pointer to the number of objects returned in the `pFunctions` array. The number of objects returned will be equal to the number of managed frames on the stack.  
  
 `pFunctions`  
 [in, out] An array of COR_ACTIVE_FUNCTION objects, each of which contains information about the active functions in this thread's frames.  
  
 The first element will be used for the leaf frame, and so on back to the root of the stack.  
  
## Remarks  
 If `pFunctions` is null on input, `GetActiveFunctions` returns only the number of functions that are on the stack. That is, If `pFunctions` is null on input, `GetActiveFunctions` returns a value only in `pcFunctions`.  
  
 The `GetActiveFunctions` method is intended as an optimization over getting the same information from frames in a stack trace, and includes only frames that would have had an ICorDebugILFrame object for them in the full stack trace.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
