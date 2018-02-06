---
title: "ICorDebugFunction::CreateBreakpoint Method"
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
  - "ICorDebugFunction.CreateBreakpoint"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFunction::CreateBreakpoint"
helpviewer_keywords: 
  - "ICorDebugFunction::CreateBreakpoint method [.NET Framework debugging]"
  - "CreateBreakpoint method, ICorDebugFunction interface [.NET Framework debugging]"
ms.assetid: ffd0f708-0d21-4fae-a395-63b6c45828fa
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugFunction::CreateBreakpoint Method
Creates a breakpoint at the beginning of this function.  
  
## Syntax  
  
```  
HRESULT CreateBreakpoint (  
    [out] ICorDebugFunctionBreakpoint **ppBreakpoint  
);  
```  
  
#### Parameters  
 `ppBreakpoint`  
 [out] A pointer to the address of an ICorDebugFunctionBreakpoint object that represents the new breakpoint for the function.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
