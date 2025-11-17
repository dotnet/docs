---
description: "Learn more about: CorDebugJITCompilerFlags Enumeration"
title: "CorDebugJITCompilerFlags Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorDebugJITCompilerFlags"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorDebugJITCompilerFlags"
helpviewer_keywords:
  - "CorDebugJITCompilerFlags enumeration [.NET debugging]"
topic_type:
  - "apiref"
---
# CorDebugJITCompilerFlags Enumeration

Contains values that influence the behavior of the managed just-in-time (JIT) compiler.

## Syntax

```cpp
typedef enum CorDebugJITCompilerFlags {

    CORDEBUG_JIT_DEFAULT = 0x1,
    CORDEBUG_JIT_DISABLE_OPTIMIZATION = 0x3,
    CORDEBUG_JIT_ENABLE_ENC = 0x7

} CorDebugJITCompilerFlags;
```

## Members

|Member|Description|
|------------|-----------------|
|`CORDEBUG_JIT_DEFAULT`|Specifies that the compiler should track compilation data, and allows optimizations.|
|`CORDEBUG_JIT_DISABLE_OPTIMIZATION`|Specifies that the compiler should track compilation data, but disables optimizations.|
|`CORDEBUG_JIT_ENABLE_ENC`|Specifies that the compiler should track compilation data, disables optimizations, and enables Edit and Continue technologies.|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
