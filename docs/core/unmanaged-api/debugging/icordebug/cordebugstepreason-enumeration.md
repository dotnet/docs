---
description: "Learn more about: CorDebugStepReason Enumeration"
title: "CorDebugStepReason Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorDebugStepReason"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorDebugStepReason"
helpviewer_keywords:
  - "CorDebugStepReason enumeration [.NET debugging]"
topic_type:
  - "apiref"
---
# CorDebugStepReason Enumeration

Indicates the outcome of an individual step.

## Syntax

```cpp
typedef enum CorDebugStepReason {
    STEP_NORMAL,
    STEP_RETURN,
    STEP_CALL,
    STEP_EXCEPTION_FILTER,
    STEP_EXCEPTION_HANDLER,
    STEP_INTERCEPT,
    STEP_EXIT
} CorDebugStepReason;
```

## Members

|Member|Description|
|------------|-----------------|
|`STEP_NORMAL`|Stepping completed normally, within the same function.|
|`STEP_RETURN`|Stepping continued normally, after the function returned.|
|`STEP_CALL`|Stepping continued normally, at the beginning of a newly called function.|
|`STEP_EXCEPTION_FILTER`|An exception was generated and control was passed to an exception filter.|
|`STEP_EXCEPTION_HANDLER`|An exception was generated and control was passed to an exception handler.|
|`STEP_INTERCEPT`|Control was passed to an interceptor.|
|`STEP_EXIT`|The thread exited before the step was completed.|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [StepComplete Method](icordebugmanagedcallback-stepcomplete-method.md)
