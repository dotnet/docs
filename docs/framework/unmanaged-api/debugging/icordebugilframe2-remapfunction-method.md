---
description: "Learn more about: ICorDebugILFrame2::RemapFunction Method"
title: "ICorDebugILFrame2::RemapFunction Method"
ms.date: "03/30/2017"
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
---
# ICorDebugILFrame2::RemapFunction Method

Remaps an edited function by specifying the new common intermediate language (CIL) offset

## Syntax

```cpp
HRESULT RemapFunction (
    [in] ULONG32      newILOffset
);
```

## Parameters

 `newILOffset`
 [in] The stack frame's new CIL offset at which the instruction pointer should be placed. This value must be a sequence point.

 It is the caller’s responsibility to ensure the validity of this value. For example, the CIL offset is not valid if it is outside the bounds of the function.

## Remarks

 When a frame’s function has been edited, the debugger can call the `RemapFunction` method to swap in the latest version of the frame's function so it can be executed. The code execution will begin at the given CIL offset.

> [!NOTE]
> Calling `RemapFunction`, like calling [ICorDebugILFrame::SetIP](icordebugilframe-setip-method.md), will immediately invalidate all debugging interfaces that are related to generating a stack trace for the thread. These interfaces include [ICorDebugChain](icordebugchain-interface.md), ICorDebugILFrame, ICorDebugInternalFrame, and ICorDebugNativeFrame.

 The `RemapFunction` method can be called only in the context of the current frame, and only in one of the following cases:

- After receipt of a [ICorDebugManagedCallback2::FunctionRemapOpportunity](icordebugmanagedcallback2-functionremapopportunity-method.md) callback that has not yet been continued.

- While code execution is stopped because of an [ICorDebugManagedCallback::EditAndContinueRemap](icordebugmanagedcallback-editandcontinueremap-method.md) event for this frame.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
