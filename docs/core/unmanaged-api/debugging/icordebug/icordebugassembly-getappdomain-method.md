---
description: "Learn more about: ICorDebugAssembly::GetAppDomain Method"
title: "ICorDebugAssembly::GetAppDomain Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAssembly.GetAppDomain"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAssembly::GetAppDomain"
helpviewer_keywords:
  - "ICorDebugAssembly::GetAppDomain method [.NET debugging]"
  - "GetAppDomain method, ICorDebugAssembly interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAssembly::GetAppDomain Method

Gets an interface pointer to the application domain that contains this `ICorDebugAssembly` instance.

## Syntax

```cpp
HRESULT GetAppDomain (
    [out] ICorDebugAppDomain  **ppAppDomain
);
```

## Parameters

 `ppAppDomain`
 [out] A pointer to the address of an ICorDebugAppDomain interface that represents the application domain.

## Remarks

If this assembly is the system assembly, `GetAppDomain` returns null.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
