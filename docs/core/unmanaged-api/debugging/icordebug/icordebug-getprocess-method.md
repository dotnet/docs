---
description: "Learn more about: ICorDebug::GetProcess Method"
title: "ICorDebug::GetProcess Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebug.GetProcess"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebug::GetProcess"
helpviewer_keywords:
  - "GetProcess method, ICorDebug interface [.NET debugging]"
  - "ICorDebug::GetProcess method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebug::GetProcess Method

Gets a pointer to the "ICorDebugProcess" instance for the specified process.

## Syntax

```cpp
HRESULT GetProcess (
    [in] DWORD               dwProcessId,
    [out] ICorDebugProcess   **ppProcess
);
```

## Parameters

 `dwProcessId`
 [in] The ID of the process.

 `ppProcess`
 [out] A pointer to the address of a `ICorDebugProcess` instance for the specified process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebug Interface](icordebug-interface.md)
