---
title: "ICorDebugNativeFrame::SetIP Method"
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
  - "ICorDebugNativeFrame.SetIP"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugNativeFrame::SetIP"
helpviewer_keywords: 
  - "ICorDebugNativeFrame::SetIP method [.NET Framework debugging]"
  - "SetIP method, ICorDebugNativeFrame interface [.NET Framework debugging]"
ms.assetid: 57784a51-c76d-48f8-9392-584d0e1946d9
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugNativeFrame::SetIP Method
Sets the instruction pointer to the specified offset location in native code.  
  
## Syntax  
  
```  
HRESULT SetIP (  
    [in] ULONG32 nOffset  
);  
```  
  
#### Parameters  
 `nOffset`  
 [in] The offset location in the native code.  
  
## Remarks  
 Calls to `SetIP` immediately invalidate all frames and chains for the current thread. If the debugger needs frame information after a call to `SetIP`, it must perform a new stack trace.  
  
 [ICorDebug](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md) will attempt to keep the stack frame in a valid state. However, even if the frame is in a valid state, as far as the runtime is concerned, there still may be problems, such as uninitialized local variables, and so on. The caller is responsible for insuring coherency of the running program.  
  
 On 64-bit platforms, the instruction pointer cannot be moved out of a `catch` or `finally` block. If `SetIP` is called to make such a move on a 64-bit platform, it will return an HRESULT indicating failure.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 
