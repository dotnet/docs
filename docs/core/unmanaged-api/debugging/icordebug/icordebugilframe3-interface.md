---
description: "Learn more about: ICorDebugILFrame3 Interface"
title: "ICorDebugILFrame3 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugILFrame3"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
topic_type:
  - "apiref"
---
# ICorDebugILFrame3 Interface

Provides a method that encapsulates the return value of a function. `ICorDebugILFrame3` is a logical extension of the ICorDebugILFrame and ICorDebugILFrame2 interfaces.

## Methods

|Method|Description|
|------------|-----------------|
|[GetReturnValueForILOffset Method](icordebugilframe3-getreturnvalueforiloffset-method.md)|Gets an ICorDebugValue object that encapsulates the return value of a function.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5.1

## See also

- [ICorDebugCode3 Interface](icordebugcode3-interface.md)
