---
title: "ICorDebugILFrame2::RemapFunction Method"
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
  - "ICorDebugILFrame2.RemapFunction"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugILFrame2::RemapFunction"
helpviewer_keywords: 
  - "ICorDebugILFrame2::RemapFunction method [.NET Framework debugging]"
  - "RemapFunction method [.NET Framework debugging]"
ms.assetid: dd639ba0-f77b-426d-9ff6-f92706840348
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugILFrame2::RemapFunction Method
Remaps an edited function by specifying the new Microsoft intermediate language (MSIL) offset  
  
## Syntax  
  
```  
HRESULT RemapFunction (  
    [in] ULONG32      newILOffset  
);  
```  
  
#### Parameters  
 `newILOffset`  
 [in] The stack frame's new MSIL offset at which the instruction pointer should be placed. This value must be a sequence point.  
  
 It is the caller’s responsibility to ensure the validity of this value. For example, the MSIL offset is not valid if it is outside the bounds of the function.  
  
## Remarks  
 When a frame’s function has been edited, the debugger can call the `RemapFunction` method to swap in the latest version of the frame's function so it can be executed. The code execution will begin at the given MSIL offset.  
  
> [!NOTE]
>  Calling `RemapFunction`, like calling [ICorDebugILFrame::SetIP](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe-setip-method.md), will immediately invalidate all debugging interfaces that are related to generating a stack trace for the thread. These interfaces include [ICorDebugChain](../../../../docs/framework/unmanaged-api/debugging/icordebugchain-interface.md), ICorDebugILFrame, ICorDebugInternalFrame, and ICorDebugNativeFrame.  
  
 The `RemapFunction` method can be called only in the context of the current frame, and only in one of the following cases:  
  
-   After receipt of a [ICorDebugManagedCallback2::FunctionRemapOpportunity](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback2-functionremapopportunity-method.md) callback that has not yet been continued.  
  
-   While code execution is stopped because of an [ICorDebugManagedCallback::EditAndContinueRemap](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-editandcontinueremap-method.md) event for this frame.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
