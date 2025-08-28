---
description: "Learn more about: ICorDebugModule::EnableJITDebugging Method"
title: "ICorDebugModule::EnableJITDebugging Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule.EnableJITDebugging"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule::EnableJITDebugging"
helpviewer_keywords:
  - "ICorDebugModule::EnableJITDebugging method [.NET debugging]"
  - "EnableJITDebugging method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugModule::EnableJITDebugging Method

Controls whether the just-in-time (JIT) compiler preserves debugging information for methods within this module.

## Syntax

```cpp
HRESULT EnableJITDebugging(
    [in] BOOL bTrackJITInfo,
    [in] BOOL bAllowJitOpts
);
```

## Parameters

 `bTrackJITInfo`
 [in] Set this value to `true` to enable the JIT compiler to preserve mapping information between the common intermediate language (CIL) version and the JIT-compiled version of each method in this module.

 `bAllowJitOpts`
 [in] Set this value to `true` to enable the JIT compiler to generate code with certain JIT-specific optimizations for debugging.

## Remarks

 JIT debugging is enabled by default for all modules that are loaded when the debugger is active. Programmatically enabling or disabling the settings overrides global settings.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
