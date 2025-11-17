---
description: "Learn more about: ICorDebugAppDomain::GetObject Method"
title: "ICorDebugAppDomain::GetObject Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAppDomain.GetObject"
api_location:
  - "corguids.lib"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAppDomain::GetObject"
helpviewer_keywords:
  - "ICorDebugAppDomain::GetObject method [.NET debugging]"
  - "GetObject method, ICorDebugAppDomain interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAppDomain::GetObject Method

Gets an interface pointer to the common language runtime (CLR) application domain.

## Syntax

```cpp
HRESULT GetObject (
    [out] ICorDebugValue   **ppObject
);
```

## Parameters

 `ppObject`
 [out] A pointer to the address of an ICorDebugValue interface object that represents the CLR application domain.

## Return Value

If a managed <xref:System.AppDomain?displayProperty=nameWithType> object hasn't been constructed for this application domain, the method returns `S_FALSE` and places `NULL` in `*ppObject`.

## Remarks

Each application domain in a process may have a managed <xref:System.AppDomain?displayProperty=nameWithType> object in the runtime that represents it. This function gets an ICorDebugValue interface object that corresponds to this managed <xref:System.AppDomain?displayProperty=nameWithType> object.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5
