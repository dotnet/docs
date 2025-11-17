---
description: "Learn more about: ICorDebugThread2::GetVolatileOSThreadID Method"
title: "ICorDebugThread2::GetVolatileOSThreadID Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugThread2.GetVolatileOSThreadID"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugThread2::GetVolatileOSThreadID"
helpviewer_keywords:
  - "GetVolatileOSThreadID method [.NET debugging]"
  - "ICorDebugThread2::GetVolatileOSThreadID method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugThread2::GetVolatileOSThreadID Method

Gets the operating system thread identifier for this ICorDebugThread2.

## Syntax

```cpp
HRESULT GetVolatileOSThreadID (
    [out] DWORD    *pdwTid
);
```

## Parameters

 `pdwTid`
 [out] The operating system thread identifier for this thread.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
