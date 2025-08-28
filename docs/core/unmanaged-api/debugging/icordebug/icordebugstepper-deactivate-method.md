---
description: "Learn more about: ICorDebugStepper::Deactivate Method"
title: "ICorDebugStepper::Deactivate Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugStepper.Deactivate"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugStepper::Deactivate"
helpviewer_keywords:
  - "Deactivate method [.NET debugging]"
  - "ICorDebugStepper::Deactivate method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugStepper::Deactivate Method

Causes this ICorDebugStepper to cancel the last step command that it received.

## Syntax

```cpp
HRESULT Deactivate ();
```

## Remarks

 A new stepping command may be issued after the most recently received step command has been canceled.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
