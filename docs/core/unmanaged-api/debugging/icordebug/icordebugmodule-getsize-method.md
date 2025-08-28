---
description: "Learn more about: ICorDebugModule::GetSize Method"
title: "ICorDebugModule::GetSize Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule.GetSize"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule::GetSize"
helpviewer_keywords:
  - "GetSize method, ICorDebugModule interface [.NET debugging]"
  - "ICorDebugModule::GetSize method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugModule::GetSize Method

Gets the size, in bytes, of the module.

## Syntax

```cpp
HRESULT GetSize(
    [out] ULONG32 *pcBytes
);
```

## Parameters

 `pcBytes`
 [out] The size of the module in bytes.

 If the module was produced from the native image generator (NGen.exe), the size of the module will be zero.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
