---
description: "Learn more about: CorDebugHandleType Enumeration"
title: "CorDebugHandleType Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorDebugHandleType"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorDebugHandleType"
helpviewer_keywords:
  - "CorDebugHandleType enumeration [.NET debugging]"
topic_type:
  - "apiref"
---
# CorDebugHandleType Enumeration

Indicates the handle type.

## Syntax

```cpp
typedef enum CorDebugHandleType {
    HANDLE_STRONG                  = 1,
    HANDLE_WEAK_TRACK_RESURRECTION = 2
} CorDebugHandleType;
```

## Members

|Member|Description|
|------------|-----------------|
|`HANDLE_STRONG`|The handle is strong, which prevents an object from being reclaimed by garbage collection.|
|`HANDLE_WEAK_TRACK_RESURRECTION`|The handle is weak, which does not prevent an object from being reclaimed by garbage collection.<br /><br /> The handle becomes invalid when the object is collected.|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
