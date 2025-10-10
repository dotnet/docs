---
description: "Learn more about: CorDebugSetContextFlag Enumeration"
title: "CorDebugSetContextFlag Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorDebugSetContextFlag"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorDebugSetContextFlag"
helpviewer_keywords:
  - "CorDebugSetContextFlag enumeration [.NET debugging]"
topic_type:
  - "apiref"
---
# CorDebugSetContextFlag Enumeration

Indicates whether the context is from the active (or leaf) frame on the stack or has been computed by unwinding from another frame.

## Syntax

```cpp
typedef enum CorDebugSetContextFlag
{
   SET_CONTEXT_FLAG_ACTIVE_FRAME = 1
   SET_CONTEXT_FLAG_UNWIND_FRAME = 2
}  CorDebugSetContextFlag;
```

## Members

|Member|Description|
|------------|-----------------|
|SET_CONTEXT_FLAG_ACTIVE_FRAME|The context is the thread’s active context.|
|SET_CONTEXT_FLAG_UNWIND_FRAME|The context has been computed by unwinding from another frame.|

## Remarks

 `CorDebugSetContextFlag` provides values that are used by the [ICorDebugStackWalk::SetContext](icordebugstackwalk-setcontext-method.md) method.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.0
