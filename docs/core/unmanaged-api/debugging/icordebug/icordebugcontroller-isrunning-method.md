---
description: "Learn more about: ICorDebugController::IsRunning Method"
title: "ICorDebugController::IsRunning Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugController.IsRunning"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugController::IsRunning"
helpviewer_keywords:
  - "IsRunning method [.NET debugging]"
  - "ICorDebugController::IsRunning method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugController::IsRunning Method

Gets a value that indicates whether the threads in the process are currently running freely.

## Syntax

```cpp
HRESULT IsRunning (
    [out] BOOL *pbRunning
);
```

## Parameters

 `pbRunning`
 [out] A pointer to a value that is `true` if the threads in the process are running freely; otherwise, `false`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also
