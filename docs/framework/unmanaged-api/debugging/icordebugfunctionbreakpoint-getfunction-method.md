---
title: "ICorDebugFunctionBreakpoint::GetFunction Method"
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
  - "ICorDebugFunctionBreakpoint.GetFunction"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFunctionBreakpoint::GetFunction"
helpviewer_keywords: 
  - "ICorDebugFunctionBreakpoint::GetFunction method [.NET Framework debugging]"
  - "GetFunction method, ICorDebugFunctionBreakpoint interface [.NET Framework debugging]"
ms.assetid: 2a62dae5-dd8a-4696-b817-0e1e586c24a0
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugFunctionBreakpoint::GetFunction Method
Gets an interface pointer to an ICorDebugFunction that references the function in which the breakpoint is set.  
  
## Syntax  
  
```  
HRESULT GetFunction (  
    [out] ICorDebugFunction  **ppFunction  
);  
```  
  
#### Parameters  
 `ppFunction`  
 [out] A pointer to the address of the function in which the breakpoint is set.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
