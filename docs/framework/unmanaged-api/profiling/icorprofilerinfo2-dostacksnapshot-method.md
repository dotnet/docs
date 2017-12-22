---
title: "ICorProfilerInfo2::DoStackSnapshot Method"
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
  - "ICorProfilerInfo2.DoStackSnapshot"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::DoStackSnapshot"
helpviewer_keywords: 
  - "ICorProfilerInfo2::DoStackSnapshot method [.NET Framework profiling]"
  - "DoStackSnapshot method [.NET Framework profiling]"
ms.assetid: 287b11e9-7c52-4a13-ba97-751203fa97f4
topic_type: 
  - "apiref"
caps.latest.revision: 25
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo2::DoStackSnapshot Method
Walks the managed frames on the stack for the specified thread, and sends information to the profiler through a callback.  
  
## Syntax  
  
```  
HRESULT DoStackSnapshot(  
    [in] ThreadID thread,  
    [in] StackSnapshotCallback *callback,  
    [in] ULONG32 infoFlags,  
    [in] void *clientData,  
    [in, size_is(contextSize), length_is(contextSize)] BYTE context[],  
    [in] ULONG32 contextSize);  
```  
  
#### Parameters  
 `thread`  
 [in] The ID of the target thread.  
  
 Passing null in `thread` yields a snapshot of the current thread. If a `ThreadID` of a different thread is passed, the common language runtime (CLR) suspends that thread, performs the snapshot, and resumes.  
  
 `callback`  
 [in] A pointer to the implementation of the [StackSnapshotCallback](../../../../docs/framework/unmanaged-api/profiling/stacksnapshotcallback-function.md) method, which is called by the CLR to provide the profiler with information on each managed frame and each run of unmanaged frames.  
  
 The `StackSnapshotCallback` method is implemented by the profiler writer.  
  
 `infoFlags`  
 [in] A value of the [COR_PRF_SNAPSHOT_INFO](../../../../docs/framework/unmanaged-api/profiling/cor-prf-snapshot-info-enumeration.md) enumeration, which specifies the amount of data to be passed back for each frame by `StackSnapshotCallback`.  
  
 `clientData`  
 [in] A pointer to the client data, which is passed straight through to the `StackSnapshotCallback` callback function.  
  
 `context`  
 [in] A pointer to a Win32 `CONTEXT` structure, which is used to seed the stack walk. The Win32 `CONTEXT` structure contains values of the CPU registers and represents the state of the CPU at a particular moment in time.  
  
 The seed helps the CLR determine where to begin the stack walk, if the top of the stack is unmanaged helper code; otherwise, the seed is ignored. A seed must be supplied for an asynchronous walk. If you are doing a synchronous walk, no seed is necessary.  
  
 The `context` parameter is valid only if the COR_PRF_SNAPSHOT_CONTEXT flag was passed in the `infoFlags` parameter.  
  
 `contextSize`  
 [in] The size of the `CONTEXT` structure, which is referenced by the `context` parameter.  
  
## Remarks  
 Passing null for `thread` yields a snapshot of the current thread. Snapshots can be taken of other threads only if the target thread is suspended at the time.  
  
 When the profiler wants to walk the stack, it calls `DoStackSnapshot`. Before the CLR returns from that call, it calls your `StackSnapshotCallback` several times, once for each managed frame (or run of unmanaged frames) on the stack. When unmanaged frames are encountered, you must walk them yourself.  
  
 The order in which the stack is walked is the reverse of how the frames were pushed onto the stack: leaf (last-pushed) frame first, main (first-pushed) frame last.  
  
 For more information about how to program the profiler to walk managed stacks, see [Profiler Stack Walking in the .NET Framework 2.0: Basics and Beyond](http://go.microsoft.com/fwlink/?LinkId=73638).  
  
 A stack walk can be synchronous or asynchronous, as explained in the following sections.  
  
## Synchronous Stack Walk  
 A synchronous stack walk involves walking the stack of the current thread in response to a callback. It does not require seeding or suspending.  
  
 You make a synchronous call when, in response to the CLR calling one of your profiler's [ICorProfilerCallback](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md) (or [ICorProfilerCallback2](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback2-interface.md)) methods, you call `DoStackSnapshot` to walk the stack of the current thread. This is useful when you want to see what the stack looks like at a notification such as [ICorProfilerCallback::ObjectAllocated](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-objectallocated-method.md). You just call `DoStackSnapshot` from within your `ICorProfilerCallback` method, passing null in the `context` and `thread` parameters.  
  
## Asynchronous Stack Walk  
 An asynchronous stack walk entails walking the stack of a different thread, or walking the stack of the current thread, not in response to a callback, but by hijacking the current thread's instruction pointer. An asynchronous walk requires a seed if the top of the stack is unmanaged code that is not part of a platform invoke (PInvoke) or COM call, but helper code in the CLR itself. For example, code that does just-in-time (JIT) compiling or garbage collection is helper code.  
  
 You obtain a seed by directly suspending the target thread and walking its stack yourself, until you find the topmost managed frame. After the target thread is suspended, get the target thread's current register context. Next, determine whether the register context points to unmanaged code by calling [ICorProfilerInfo::GetFunctionFromIP](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-getfunctionfromip-method.md) — if it returns a `FunctionID` equal to zero, the frame is unmanaged code. Now, walk the stack until you reach the first managed frame, and then calculate the seed context based on the register context for that frame.  
  
 Call `DoStackSnapshot` with your seed context to begin the asynchronous stack walk. If you do not supply a seed, `DoStackSnapshot` might skip managed frames at the top of the stack and, consequently, will give you an incomplete stack walk. If you do supply a seed, it must point to JIT-compiled or Native Image Generator (Ngen.exe)-generated code; otherwise, `DoStackSnapshot` returns the failure code, CORPROF_E_STACKSNAPSHOT_UNMANAGED_CTX.  
  
 Asynchronous stack walks can easily cause deadlocks or access violations, unless you follow these guidelines:  
  
-   When you directly suspend threads, remember that only a thread that has never run managed code can suspend another thread.  
  
-   Always block in your [ICorProfilerCallback::ThreadDestroyed](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-threaddestroyed-method.md) callback until that thread's stack walk is complete.  
  
-   Do not hold a lock while your profiler calls into a CLR function that can trigger a garbage collection. That is, do not hold a lock if the owning thread might make a call that triggers a garbage collection.  
  
 There is also a risk of deadlock if you call `DoStackSnapshot` from a thread that your profiler has created so that you can walk the stack of a separate target thread. The first time the thread you created enters certain `ICorProfilerInfo*` methods (including `DoStackSnapshot`), the CLR will perform per-thread, CLR-specific initialization on that thread. If your profiler has suspended the target thread whose stack you are trying to walk, and if that target thread happened to own a lock necessary for performing this per-thread initialization, a deadlock will occur. To avoid this deadlock, make an initial call into `DoStackSnapshot` from your profiler-created thread to walk a separate target thread, but do not suspend the target thread first. This initial call ensures that the per-thread initialization can complete without deadlock. If `DoStackSnapshot` succeeds and reports at least one frame, after that point, it will be safe for that profiler-created thread to suspend any target thread and call `DoStackSnapshot` to walk the stack of that target thread.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)  
 [ICorProfilerInfo2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-interface.md)
