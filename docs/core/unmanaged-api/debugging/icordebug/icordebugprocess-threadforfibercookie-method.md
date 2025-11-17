---
description: "Learn more about: ICorDebugProcess::ThreadForFiberCookie Method"
title: "ICorDebugProcess::ThreadForFiberCookie Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess.ThreadForFiberCookie"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess::ThreadForFiberCookie"
helpviewer_keywords:
  - "ICorDebugProcess::ThreadForFiberCookie method [.NET debugging]"
  - "ThreadForFiberCookie method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugProcess::ThreadForFiberCookie Method

This method is not implemented.

## Syntax

```cpp
HRESULT ThreadForFiberCookie (
    [in] DWORD fiberCookie,
    [out] ICorDebugThread **ppThread
);
```

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
