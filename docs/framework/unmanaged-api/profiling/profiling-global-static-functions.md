---
description: "Learn more about: Profiling Global Static Functions"
title: "Profiling Global Static Functions"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "global static functions [.NET Framework profiling]"
  - "profiling global static functions [.NET Framework]"
  - "unmanaged global static functions [.NET Framework], profiling"
ms.assetid: 08a13a57-dc49-488d-b937-31e3051fda97
---
# Profiling Global Static Functions

This section describes the unmanaged API functions that the profiling API uses.  
  
## In This Section  
  
## .NET Framework version 1 Profiling Functions  

 [FunctionEnter Function](functionenter-function.md)  
 Notifies the profiler that control is being passed to a function. Deprecated in the .NET Framework 2.0.  
  
 [FunctionLeave Function](functionleave-function.md)  
 Notifies the profiler that a function is about to return to the caller. Deprecated in the .NET Framework 2.0.  
  
 [FunctionTailcall Function](functiontailcall-function.md)  
 Notifies the profiler that the currently executing function is about to perform a tail call to another function. Deprecated in the .NET Framework 2.0.  
  
## .NET Framework version 2 Profiling Functions  

 [FunctionIDMapper Function](functionidmapper-function.md)  
 Notifies the profiler that the given identifier of a function may be remapped to an alternative ID to be used in the [FunctionEnter2](functionenter2-function.md), [FunctionLeave2](functionleave2-function.md), and [FunctionTailcall2](functiontailcall2-function.md) callbacks for that function. Also enables the profiler to indicate whether it wants to receive callbacks for that function  
  
 [FunctionEnter2 Function](functionenter2-function.md)  
 Notifies the profiler that control is being passed to a function and provides information about the stack frame and function arguments. Deprecated in the .NET Framework 4.  
  
 [FunctionLeave2 Function](functionleave2-function.md)  
 Notifies the profiler that a function is about to return to the caller and provides information about the stack frame and function return value. Deprecated in the .NET Framework 4.  
  
 [FunctionTailcall2 Function](functiontailcall2-function.md)  
 Notifies the profiler that the currently executing function is about to perform a tail call to another function and provides information about the stack frame. Deprecated in the .NET Framework 4.  
  
 [StackSnapshotCallback Function](stacksnapshotcallback-function.md)  
 Provides the profiler with information about each managed frame and each run of unmanaged frames on the stack during a stack walk, which is initiated by the [ICorProfilerInfo2::DoStackSnapshot](icorprofilerinfo2-dostacksnapshot-method.md) method.  
  
## .NET Framework version 4 Profiling Functions  

 [FunctionIDMapper2 Function](functionidmapper2-function.md)  
 Notifies the profiler that the given identifier of a function may be remapped to an alternative ID to be used in the [FunctionEnter3](functionenter3-function.md), [FunctionLeave3](functionleave3-function.md), and [FunctionTailcall3](functiontailcall3-function.md), or[FunctionEnter3WithInfo](functionenter3withinfo-function.md), [FunctionLeave3WithInfo](functionleave3withinfo-function.md), and [FunctionTailcall3WithInfo](functiontailcall3withinfo-function.md) callbacks for that function. Also enables the profiler to indicate whether it wants to receive callbacks for that function.  
  
 `FunctionIDMapper2` extends the [FunctionIDMapper](functionidmapper-function.md) function with a `clientData` parameter, which profilers may use to disambiguate among runtimes.  
  
 [FunctionEnter3 Function](functionenter3-function.md)  
 Notifies the profiler that control is being passed to a function.  
  
 [FunctionEnter3WithInfo Function](functionenter3withinfo-function.md)  
 Notifies the profiler that control is being passed to a function, and provides a handle that can be passed to [ICorProfilerInfo3::GetFunctionEnter3Info](icorprofilerinfo3-getfunctionenter3info-method.md) to retrieve the stack frame and function arguments.  
  
 [FunctionLeave3 Function](functionleave3-function.md)  
 Notifies the profiler that control is being returned from a function.  
  
 [FunctionLeave3WithInfo Function](functionleave3withinfo-function.md)  
 Notifies the profiler that control is being returned from a function, and provides a handle that can be passed to [ICorProfilerInfo3::GetFunctionLeave3Info](icorprofilerinfo3-getfunctionleave3info-method.md) to retrieve the stack frame and the return value.  
  
 [FunctionTailcall3 Function](functiontailcall3-function.md)  
 Notifies the profiler that the currently executing function is about to perform a tail call to another function.  
  
 [FunctionTailcall3WithInfo Function](functiontailcall3withinfo-function.md)  
 Notifies the profiler that the currently executing function is about to perform a tail call to another function, and provides a handle that can be passed to [ICorProfilerInfo3::GetFunctionTailcall3Info](icorprofilerinfo3-getfunctiontailcall3info-method.md) to retrieve the stack frame.  
  
## Related Sections  

 [Profiling Overview](profiling-overview.md)  
  
 [Profiling Interfaces](profiling-interfaces.md)  
  
 [Profiling Enumerations](profiling-enumerations.md)  
  
 [Profiling Structures](profiling-structures.md)
