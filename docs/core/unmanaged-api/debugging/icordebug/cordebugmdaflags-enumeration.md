---
description: "Learn more about: CorDebugMDAFlags Enumeration"
title: "CorDebugMDAFlags Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorDebugMDAFlags"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorDebugMDAFlags"
helpviewer_keywords:
  - "CorDebugMDAFlags enumeration [.NET debugging]"
topic_type:
  - "apiref"
---
# CorDebugMDAFlags Enumeration

Specifies the status of the thread on which the managed debugging assistant (MDA) is fired.

## Syntax

```cpp
typedef enum CorDebugMDAFlags {
    MDA_FLAG_SLIP = 0x2
} CorDebugMDAFlags;
```

## Members

|Member|Description|
|------------|-----------------|
|`MDA_FLAG_SLIP`|The thread on which the MDA was fired has slipped since the MDA was fired.|

## Remarks

 When the call stack no longer describes where the MDA was originally raised, the thread is considered to have *slipped*. This is an unusual circumstance brought about by the thread's execution of an invalid operation upon exiting.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
