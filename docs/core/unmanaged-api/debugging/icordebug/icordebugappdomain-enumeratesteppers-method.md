---
description: "Learn more about: ICorDebugAppDomain::EnumerateSteppers Method"
title: "ICorDebugAppDomain::EnumerateSteppers Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAppDomain.EnumerateSteppers"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAppDomain::EnumerateSteppers"
helpviewer_keywords:
  - "ICorDebugAppDomain::EnumerateSteppers method [.NET debugging]"
  - "EnumerateSteppers method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAppDomain::EnumerateSteppers Method

Gets an enumerator for all active steppers in the application domain.

## Syntax

```cpp
HRESULT EnumerateSteppers (
    [out] ICorDebugStepperEnum   **ppSteppers
);
```

## Parameters

 `ppSteppers`
 [out] A pointer to the address of an ICorDebugStepperEnum object that is the enumerator for all active steppers in the application domain.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
