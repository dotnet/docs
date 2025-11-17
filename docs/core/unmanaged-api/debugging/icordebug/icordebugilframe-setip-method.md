---
description: "Learn more about: ICorDebugILFrame::SetIP Method"
title: "ICorDebugILFrame::SetIP Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugILFrame.SetIP"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugILFrame::SetIP"
helpviewer_keywords:
  - "SetIP method, ICorDebugILFrame interface [.NET debugging]"
  - "ICorDebugILFrame::SetIP method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugILFrame::SetIP Method

Sets the instruction pointer to the specified offset location in the common intermediate language (CIL) code.

## Syntax

```cpp
HRESULT SetIP (
    [in] ULONG32 nOffset
);
```

## Parameters

 `nOffset`
The offset location in the CIL code.

## Remarks

Calls to `SetIP` immediately invalidate all frames and chains for the current thread. If the debugger needs frame information after a call to `SetIP`, it must perform a new stack trace.

 [ICorDebug](icordebug-interface.md) will attempt to keep the stack frame in a valid state. However, even if the frame is in a valid state, there still may be problems such as uninitialized local variables. The caller is responsible for ensuring the coherency of the running program.

On 64-bit platforms, the instruction pointer cannot be moved out of a `catch` or `finally` block. If `SetIP` is called to make such a move on a 64-bit platform, it will return an HRESULT indicating failure.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
