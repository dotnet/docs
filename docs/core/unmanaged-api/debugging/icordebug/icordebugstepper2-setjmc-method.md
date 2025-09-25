---
description: "Learn more about: ICorDebugStepper2::SetJMC Method"
title: "ICorDebugStepper2::SetJMC Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugStepper2.SetJMC"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugStepper2::SetJMC"
helpviewer_keywords:
  - "ICorDebugStepper2::SetJMC method [.NET debugging]"
  - "SetJMC method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugStepper2::SetJMC Method

Sets a value that specifies whether this ICorDebugStepper steps only through code that is authored by an application's developer. This process is also known as just my code (JMC) debugging.

## Syntax

```cpp
HRESULT SetJMC (
    [in] BOOL    fIsJMCStepper
);
```

## Parameters

 `fIsJMCStepper`
 [in] Set to `true` to step only through code that is authored by an application's developer; otherwise, set to `false`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
