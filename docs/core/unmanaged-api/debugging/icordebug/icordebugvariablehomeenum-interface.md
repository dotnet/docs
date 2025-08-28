---
description: "Learn more about: ICorDebugVariableHomeEnum Interface"
title: "ICorDebugVariableHomeEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugVariableHomeEnum"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugVariableHomeEnum"
helpviewer_keywords:
  - "ICorDebugVariableHomeEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugVariableHomeEnum Interface

Provides an enumerator to the local variables and arguments in a function.

## Methods

|Method|Description|
|------------|-----------------|
|[Next Method](icordebugvariablehomeenum-next-method.md)|Gets the specified number of [ICorDebugVariableHome](icordebugvariablehome-interface.md) instances that contain information about the local variables and arguments in a function.|

## Remarks

 The `ICorDebugVariableHomeEnum` interface implements the ICorDebugEnum interface.

 An `ICorDebugVariableHomeEnum` instance is populated with [ICorDebugVariableHome](icordebugvariablehome-interface.md) instances by calling the [ICorDebugCode4::EnumerateVariableHomes](icordebugcode4-enumeratevariablehomes-method.md) method. Each [ICorDebugVariableHome](icordebugvariablehome-interface.md) instance in the collection represents a local variable or argument in a function. The  [ICorDebugVariableHome](icordebugvariablehome-interface.md) objects in the collection can be enumerated by calling the [ICorDebugVariableHomeEnum::Next](icordebugvariablehomeenum-next-method.md) method.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6.2

## See also

- [ICorDebugVariableHome Interface](icordebugvariablehome-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
