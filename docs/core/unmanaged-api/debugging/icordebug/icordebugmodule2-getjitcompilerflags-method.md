---
description: "Learn more about: ICorDebugModule2::GetJITCompilerFlags Method"
title: "ICorDebugModule2::GetJITCompilerFlags Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule2.GetJITCompilerFlags"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule2::GetJITCompilerFlags"
helpviewer_keywords:
  - "GetJITCompilerFlags method [.NET debugging]"
  - "ICorDebugModule2::GetJITCompilerFlags method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugModule2::GetJITCompilerFlags Method

Gets the flags that control the just-in-time (JIT) compilation of this ICorDebugModule2.

## Syntax

```cpp
HRESULT GetJITCompilerFlags (
    [out] DWORD   *pdwFlags
);
```

## Parameters

 `pdwFlags`
 [out] A pointer to a value of the [CorDebugJITCompilerFlags](cordebugjitcompilerflags-enumeration.md) enumeration that controls the JIT compilation.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
