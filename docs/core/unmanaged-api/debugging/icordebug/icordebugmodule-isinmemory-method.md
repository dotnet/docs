---
description: "Learn more about: ICorDebugModule::IsInMemory Method"
title: "ICorDebugModule::IsInMemory Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule.IsInMemory"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule::IsInMemory"
helpviewer_keywords:
  - "IsInMemory method [.NET debugging]"
  - "ICorDebugModule::IsInMemory method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugModule::IsInMemory Method

Gets a value that indicates whether this module exists only in memory.

## Syntax

```cpp
HRESULT IsInMemory(
    [out] BOOL *pInMemory
);
```

## Parameters

 `pInMemory`
 [out] `true` if this module exists only in memory; otherwise, `false`.

## Remarks

The common language runtime (CLR) supports the loading of modules from raw streams of bytes. Such modules are called *in-memory modules* and do not exist on disk.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also
