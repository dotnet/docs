---
title: "StackSnapshotCallback Function"
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
  - "StackSnapshotCallback"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "StackSnapshotCallback"
helpviewer_keywords: 
  - "StackSnapshotCallback function [.NET Framework profiling]"
ms.assetid: d0f235b2-91fe-4f82-b7d5-e5c64186eea8
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# StackSnapshotCallback Function
Provides the profiler with information about each managed frame and each run of unmanaged frames on the stack during a stack walk, which is initiated by the [ICorProfilerInfo2::DoStackSnapshot](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-dostacksnapshot-method.md) method.  
  
## Syntax  
  
```  
HRESULT __stdcall StackSnapshotCallback (  
    [in] FunctionID funcId,  
    [in] UINT_PTR ip,  
    [in] COR_PRF_FRAME_INFO frameInfo,  
    [in] ULONG32 contextSize,  
    [in] BYTE context[],  
    [in] void *clientData  
);  
```  
  
#### Parameters  
 `funcId`  
 [in] If this value is zero, this callback is for a run of unmanaged frames; otherwise, it is the identifier of a managed function and this callback is for a managed frame.  
  
 `ip`  
 [in] The value of the native code instruction pointer in the frame.  
  
 `frameInfo`  
 [in] A `COR_PRF_FRAME_INFO` value that references information about the stack frame. This value is valid for use only during this callback.  
  
 `contextSize`  
 [in] The size of the `CONTEXT` structure, which is referenced by the `context` parameter.  
  
 `context`  
 [in] A pointer to a Win32 `CONTEXT` structure that represents the state of the CPU for this frame.  
  
 The `context` parameter is valid only if the COR_PRF_SNAPSHOT_CONTEXT flag was passed in `ICorProfilerInfo2::DoStackSnapshot`.  
  
 `clientData`  
 [in] A pointer to the client data, which is passed straight through from `ICorProfilerInfo2::DoStackSnapshot`.  
  
## Remarks  
 The `StackSnapshotCallback` function is implemented by the profiler writer. You must limit the complexity of work done in `StackSnapshotCallback`. For example, when using `ICorProfilerInfo2::DoStackSnapshot` in an asynchronous manner, the target thread may be holding locks. If code within `StackSnapshotCallback` requires the same locks, a deadlock could ensue.  
  
 The `ICorProfilerInfo2::DoStackSnapshot` method calls the `StackSnapshotCallback` function once per managed frame or once per run of unmanaged frames. If `StackSnapshotCallback` is called for a run of unmanaged frames, the profiler may use the register context (referenced by the `context` parameter) to perform its own unmanaged stack walk. In this case, the Win32 `CONTEXT` structure represents the CPU state for the most recently pushed frame within the run of unmanaged frames. Although the Win32 `CONTEXT` structure includes values for all registers, you should rely only on the values of the stack pointer register, frame pointer register, instruction pointer register, and the nonvolatile (that is, preserved) integer registers.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [DoStackSnapshot Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-dostacksnapshot-method.md)  
 [Profiling Global Static Functions](../../../../docs/framework/unmanaged-api/profiling/profiling-global-static-functions.md)
