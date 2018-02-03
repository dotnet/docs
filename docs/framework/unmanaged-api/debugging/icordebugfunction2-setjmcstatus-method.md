---
title: "ICorDebugFunction2::SetJMCStatus Method"
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
  - "ICorDebugFunction2.SetJMCStatus"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFunction2::SetJMCStatus"
helpviewer_keywords: 
  - "ICorDebugFunction2::SetJMCStatus method [.NET Framework debugging]"
  - "SetJMCStatus method, ICorDebugFunction2 interface [.NET Framework debugging]"
ms.assetid: 22c27b01-2869-4214-b840-5921f7c874fc
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugFunction2::SetJMCStatus Method
Marks the function represented by this ICorDebugFunction2 for Just My Code stepping.  
  
## Syntax  
  
```  
HRESULT SetJMCStatus (  
    [in] BOOL   bIsJustMyCode  
);  
```  
  
#### Parameters  
 `bIsJustMyCode`  
 [in] Set to `true` to mark the function as user code; otherwise, set to `false`.  
  
## Return Values  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|The function was successfully marked.|  
|`CORDBG_E_FUNCTION_NOT_DEBUGGABLE`|The function could not be marked as user code because it cannot be debugged.|  
  
## Remarks  
 A Just My Code stepper will skip non-user code. User code must be a subset of debuggable code.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
