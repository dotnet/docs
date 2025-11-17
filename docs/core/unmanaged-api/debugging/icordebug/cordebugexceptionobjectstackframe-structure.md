---
description: "Learn more about: CorDebugExceptionObjectStackFrame Structure"
title: "CorDebugExceptionObjectStackFrame Structure"
ms.date: "03/30/2017"
api_name:
  - "CorDebugExceptionObjectStackFrame"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorDebugExceptionObjectStackFrame"
helpviewer_keywords:
  - "CorDebugExceptionObjectStackFrame structure [.NET debugging]"
topic_type:
  - "apiref"
---
# CorDebugExceptionObjectStackFrame Structure

Represents stack frame information from an exception object.

## Syntax

```cpp
typedef struct CorDebugExceptionObjectStackFrame {
    ICorDebugModule* pModule;
    CORDB_ADDRESS ip;
    mdMethodDef methodDef;
    BOOL isLastForeignExceptionFrame;
} CorDebugExceptionObjectStackFrame;
```

## Members

|Member|Description|
|------------|-----------------|
|`pModule`|A pointer to the ICorDebugModule object for the current frame.|
|`ip`|The value of the instruction pointer (EIP/RIP) for the current frame.|
|`methodDef`|The method token for the current frame.|
|`isLastForeignExceptionFrame`|A value that indicates whether the frame is the last frame in a foreign exception.|

## Remarks

 The caller must release the pointer to the ICorDebugModule object once it is no longer in use.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5
