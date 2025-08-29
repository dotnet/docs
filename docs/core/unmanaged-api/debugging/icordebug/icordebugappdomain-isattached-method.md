---
description: "Learn more about: ICorDebugAppDomain::IsAttached Method"
title: "ICorDebugAppDomain::IsAttached Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAppDomain.IsAttached"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAppDomain::IsAttached"
helpviewer_keywords:
  - "IsAttached method [.NET debugging]"
  - "ICorDebugAppDomain::IsAttached method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAppDomain::IsAttached Method

Gets a value that indicates whether the debugger is attached to the application domain.

## Syntax

```cpp
HRESULT IsAttached (
    [out] BOOL  *pbAttached
);
```

## Parameters

 `pbAttached`
 [out] `true` if the debugger is attached to the application domain; otherwise, `false`.

## Remarks

The ICorDebugController methods cannot be used until the debugger attaches to the application domain.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
