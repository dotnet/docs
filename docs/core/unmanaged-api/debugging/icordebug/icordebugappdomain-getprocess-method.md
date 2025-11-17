---
description: "Learn more about: ICorDebugAppDomain::GetProcess Method"
title: "ICorDebugAppDomain::GetProcess Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAppDomain.GetProcess"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAppDomain::GetProcess"
helpviewer_keywords:
  - "GetProcess method, ICorDebugAppDomain interface [.NET debugging]"
  - "ICorDebugAppDomain::GetProcess method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAppDomain::GetProcess Method

Gets the process containing the application domain.

## Syntax

```cpp
HRESULT GetProcess (
    [out] ICorDebugProcess   **ppProcess
);
```

## Parameters

 `ppProcess`
 [out] A pointer to the address of an ICorDebugProcess object that represents the process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
