---
description: "Learn more about: ICorDebugThread::SetDebugState Method"
title: "ICorDebugThread::SetDebugState Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugThread.SetDebugState"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugThread::SetDebugState"
helpviewer_keywords:
  - "ICorDebugThread::SetDebugState method [.NET debugging]"
  - "SetDebugState method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugThread::SetDebugState Method

Sets flags that describe the debugging state of this ICorDebugThread.

## Syntax

```cpp
HRESULT SetDebugState (
    [in] CorDebugThreadState state
);
```

## Parameters

 `state`
 [in] A bitwise combination of CorDebugThreadState enumeration values that specify the debugging state of this thread.

## Remarks

 `SetDebugState` sets the current debug state of the thread. (The "current debug state" represents the debug state if the process were to be continued, not the actual current state.) The normal value for this is THREAD_RUN. Only the debugger can affect the debug state of a thread. Debug states do last across continues, so if you want to keep a thread THREAD_SUSPENDed over multiple continues, you can set it once and thereafter not have to worry about it. Suspending threads and resuming the process can cause deadlocks, though it's usually unlikely. This is an intrinsic quality of threads and processes and is by-design. A debugger can asynchronously break and resume the threads to break the deadlock. If the thread's user state includes USER_UNSAFE_POINT, then the thread may block a garbage collection (GC). This means the suspended thread has a much higher chance of causing a deadlock. This may not affect debug events already queued. Thus a debugger should drain the entire event queue (by calling [ICorDebugController::HasQueuedCallbacks](icordebugcontroller-hasqueuedcallbacks-method.md)) before suspending or resuming threads. Else it may get events on a thread that it believes it has already suspended.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
