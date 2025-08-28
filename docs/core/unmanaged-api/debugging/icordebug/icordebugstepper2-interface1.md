---
description: "Learn more about: ICorDebugStepper2 Interface"
title: "ICorDebugStepper2 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugStepper2"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugStepper2"
helpviewer_keywords:
  - "ICorDebugStepper2 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugStepper2 Interface

Provides support for just my code (JMC) debugging.

## Methods

|Method|Description|
|------------|-----------------|
|[SetJMC Method](icordebugstepper2-setjmc-method.md)|Sets a value that specifies whether this ICorDebugStepper steps only through code that is authored by an application's developer.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [Debugging Interfaces](debugging-interfaces.md)
