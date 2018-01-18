---
title: "ICorDebugILFrame::SetIP Method"
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
  - "ICorDebugILFrame.SetIP"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugILFrame::SetIP"
helpviewer_keywords: 
  - "SetIP method, ICorDebugILFrame interface [.NET Framework debugging]"
  - "ICorDebugILFrame::SetIP method [.NET Framework debugging]"
ms.assetid: 23f38dc1-85e4-4263-9235-2d05bbb6a833
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugILFrame::SetIP Method
Sets the instruction pointer to the specified offset location in the Microsoft intermediate language (MSIL) code.  
  
## Syntax  
  
```  
HRESULT SetIP (  
    [in] ULONG32 nOffset  
);  
```  
  
#### Parameters  
 `nOffset`  
 The offset location in the MSIL code.  
  
## Remarks  
 Calls to `SetIP` immediately invalidate all frames and chains for the current thread. If the debugger needs frame information after a call to `SetIP`, it must perform a new stack trace.  
  
 [ICorDebug](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md) will attempt to keep the stack frame in a valid state. However, even if the frame is in a valid state, there still may be problems such as uninitialized local variables. The caller is responsible for ensuring the coherency of the running program.  
  
 On 64-bit platforms, the instruction pointer cannot be moved out of a `catch` or `finally` block. If `SetIP` is called to make such a move on a 64-bit platform, it will return an HRESULT indicating failure.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
