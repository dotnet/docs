---
description: "Learn more about: ICorDebugThread::GetObject Method"
title: "ICorDebugThread::GetObject Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugThread.GetObject"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugThread::GetObject"
helpviewer_keywords:
  - "GetObject method, ICorDebugThread interface [.NET debugging]"
  - "ICorDebugThread::GetObject method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugThread::GetObject Method

Gets an interface pointer to the common language runtime (CLR) thread.

## Syntax

```cpp
HRESULT GetObject (
    [out] ICorDebugValue   **ppObject
);
```

## Parameters

 `ppObject`
 [out] A pointer to the address of an ICorDebugValue interface object that represents the CLR thread.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- <xref:System.Threading.Thread>
