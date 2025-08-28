---
description: "Learn more about: ICorDebugCode4 Interface"
title: "ICorDebugCode4 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugCode4"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugCode4"
helpviewer_keywords:
  - "ICorDebugCode4 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugCode4 Interface

Provides a method that enables a debugger to enumerate the local variables and arguments in a function.

## Methods

|Method|Description|
|------------|-----------------|
|[EnumerateVariableHomes Method](icordebugcode4-enumeratevariablehomes-method.md)|Gets an enumerator to the local variables and arguments in a function.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6.2

## See also

- [ICorDebugCode3 Interface](icordebugcode3-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
