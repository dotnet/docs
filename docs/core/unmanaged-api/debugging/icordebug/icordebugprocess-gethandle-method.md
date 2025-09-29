---
description: "Learn more about: ICorDebugProcess::GetHandle Method"
title: "ICorDebugProcess::GetHandle Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess.GetHandle"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess::GetHandle"
helpviewer_keywords:
  - "GetHandle method, ICorDebugProcess interface [.NET debugging]"
  - "ICorDebugProcess::GetHandle method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugProcess::GetHandle Method

Gets a handle to the process.

## Syntax

```cpp
HRESULT GetHandle([out] HPROCESS *phProcessHandle);
```

## Parameters

 `phProcessHandle`
 [out] A pointer to an `HPROCESS` that is the handle to the process.

## Remarks

The retrieved handle is owned by the debugging interface. The debugger should duplicate the handle before using it.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
