---
description: "Learn more about: CorDebugRecordFormat Enumeration"
title: "CorDebugRecordFormat Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorDebugRecordFormat"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
topic_type:
  - "apiref"
---
# CorDebugRecordFormat Enumeration

Describes the format of the data in a byte array that contains information about a native exception debug event.

## Syntax

```cpp
typedef enum CorDebugRecordFormat {
    FORMAT_WINDOWS_EXCEPTIONRECORD32 = 1,
    FORMAT_WINDOWS_EXCEPTIONRECORD64 = 2,
} CorDebugRecordFormat;
```

## Members

|Member|Description|
|------------|-----------------|
|`FORMAT_WINDOWS_EXCEPTIONRECORD32`|The data is a 32-bit Windows exception record.|
|`FORMAT_WINDOWS_EXCEPTIONRECORD64`|The data is a 64-bit Windows exception record.|

## Remarks

 A member of the `CorDebugRecordFormat` enumeration is passed to the [DecodeEvent](icordebugprocess6-decodeevent-method.md) method to indicate the format of the byte array in its `pRecord` argument.

> [!NOTE]
> This enumeration is intended for use in .NET Native debugging scenarios only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6
