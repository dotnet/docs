---
title: "ICorDebugProcess2::ClearUnmanagedBreakpoint Method"
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
  - "ICorDebugProcess2.ClearUnmanagedBreakpoint"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess2::ClearUnmanagedBreakpoint"
helpviewer_keywords: 
  - "ClearUnmanagedBreakpoint method [.NET Framework debugging]"
  - "ICorDebugProcess2::ClearUnmanagedBreakpoint method [.NET Framework debugging]"
ms.assetid: 12ed0fff-7f0e-4d7a-bb70-b3376371f36c
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess2::ClearUnmanagedBreakpoint Method
Removes a previously set breakpoint at the given address.  
  
## Syntax  
  
```  
HRESULT ClearUnmanagedBreakpoint (  
    [in] CORDB_ADDRESS   address  
);  
```  
  
#### Parameters  
 `address`  
 [in] A `CORDB_ADDRESS` value that specifies the address at which the breakpoint was set.  
  
## Remarks  
 The specified breakpoint would have been previously set by an earlier call to [ICorDebugProcess2::SetUnmanagedBreakpoint](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess2-setunmanagedbreakpoint-method.md).  
  
 The `ClearUnmanagedBreakpoint` method can be called while the process being debugged is running.  
  
 The `ClearUnmanagedBreakpoint` method returns a failure code if the debugger is attached in managed-only mode or if no breakpoint exists at the specified address.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
