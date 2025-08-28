---
description: "Learn more about: ICorDebug::EnumerateProcesses Method"
title: "ICorDebug::EnumerateProcesses Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebug.EnumerateProcesses"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "EnumerateProcesses"
helpviewer_keywords:
  - "EnumerateProcesses method [.NET debugging]"
  - "ICorDebug::EnumerateProcesses method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebug::EnumerateProcesses Method

Gets an enumerator for the processes that are being debugged.

## Syntax

```cpp
HRESULT EnumerateProcesses (
    [out] ICorDebugProcessEnum      **ppProcess
);
```

## Parameters

 `ppProcess`
 A pointer to the address of an ICorDebugProcessEnum object that is the enumerator for the processes being debugged.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebug Interface](icordebug-interface.md)
