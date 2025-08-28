---
description: "Learn more about: ICorDebugStepperEnum Interface"
title: "ICorDebugStepperEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugStepperEnum"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugStepperEnum"
helpviewer_keywords:
  - "ICorDebugStepperEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugStepperEnum Interface

Implements ICorDebugEnum methods, and enumerates ICorDebugStepper arrays.

## Methods

|Method|Description|
|------------|-----------------|
|[Next Method](icordebugstepperenum-next-method.md)|Gets the specified number of `ICorDebugStepper` instances from the enumeration, starting at the current position.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Debugging Interfaces](debugging-interfaces.md)
