---
description: "Learn more about: CLRDataDetailedFrameType Enumeration"
title: "CLRDataDetailedFrameType Enumeration"
ms.date: "07/03/2024"
api_name:
  - "CLRDataDetailedFrameType"
api_location:
  - "mscordacwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "CLRDataDetailedFrameType"
helpviewer_keywords:
  - "CLRDataDetailedFrameType enumeration [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# CLRDataDetailedFrameType Enumeration

Describes a type of frame in the call stack in detail.

## Syntax

```cpp
typedef enum CLRDataDetailedFrameType {
    CLRDATA_DETFRAME_UNRECOGNIZED,
    CLRDATA_DETFRAME_UNKNOWN_STUB,
    CLRDATA_DETFRAME_CLASS_INIT,
    CLRDATA_DETFRAME_EXCEPTION_FILTER,
    CLRDATA_DETFRAME_SECURITY,
    CLRDATA_DETFRAME_CONTEXT_POLICY,
    CLRDATA_DETFRAME_INTERCEPTION,
    CLRDATA_DETFRAME_PROCESS_START,
    CLRDATA_DETFRAME_THREAD_START,
    CLRDATA_DETFRAME_TRANSITION_TO_MANAGED,
    CLRDATA_DETFRAME_TRANSITION_TO_UNMANAGED,
    CLRDATA_DETFRAME_COM_INTEROP_STUB,
    CLRDATA_DETFRAME_DEBUGGER_EVAL,
    CLRDATA_DETFRAME_CONTEXT_SWITCH,
    CLRDATA_DETFRAME_FUNC_EVAL,
    CLRDATA_DETFRAME_FINALLY
} CLRDataDetailedFrameType;
```

## Members

|Member|Value|Description|
|------------|-----------------|-----------------|
|`CLRDATA_DETFRAME_UNRECOGNIZED`|0|The frame type is unrecognized.|
|`CLRDATA_DETFRAME_UNKNOWN_STUB`|1|The frame is an unknown stub.|
|`CLRDATA_DETFRAME_CLASS_INIT`|2|The frame is a class initializer.|
|`CLRDATA_DETFRAME_EXCEPTION_FILTER`|3|The frame is an exception filter.|
|`CLRDATA_DETFRAME_SECURITY`|4|The frame has to do with security.|
|`CLRDATA_DETFRAME_CONTEXT_POLICY`|5|The frame has to do with context policy.|
|`CLRDATA_DETFRAME_INTERCEPTION`|6|The frame has to do with interception.|
|`CLRDATA_DETFRAME_PROCESS_START`|7|The frame corresponds to a process start.|
|`CLRDATA_DETFRAME_THREAD_START`|8|The frame corresponds to a thread start.|
|`CLRDATA_DETFRAME_TRANSITION_TO_MANAGED`|9|The frame is a transition frame into managed code.|
|`CLRDATA_DETFRAME_TRANSITION_TO_UNMANAGED`|10|The frame is a transition frame into unmanaged code.|
|`CLRDATA_DETFRAME_COM_INTEROP_STUB`|11|The frame is a COM interop stub.|
|`CLRDATA_DETFRAME_DEBUGGER_EVAL`|12|The frame has to do with a debugger evaluation.|
|`CLRDATA_DETFRAME_CONTEXT_SWITCH`|13|The frame has to do with a context switch.|
|`CLRDATA_DETFRAME_FUNC_EVAL`|14|The frame is a function evaluation.|
|`CLRDATA_DETFRAME_FINALLY`|15|The frame corresponds to a finally block.|

## Remarks

This enumeration lives inside the runtime and is not exposed through any headers or library files. To use it, define the enumeration as specified above.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging Enumerations](debugging-enumerations.md)
- [Debugging](index.md)
- [IXCLRDataStackWalk Interface](ixclrdatastackwalk-interface.md)
- [IXCLRDataStackWalk::GetFrameType Method](ixclrdatastackwalk-getframetype-method.md)
