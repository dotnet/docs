---
description: "Learn more about: ICorDebugCode3 Interface"
title: "ICorDebugCode3 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugCode3"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugCode3"
helpviewer_keywords:
  - "ICorDebugCode3 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugCode3 Interface

Provides a method that extends "ICorDebugCode" and "ICorDebugCode2" to provide information about a managed return value.

## Methods

|Method|Description|
|------------|-----------------|
|[GetReturnValueLiveOffset Method](icordebugcode3-getreturnvalueliveoffset-method.md)|For a specified IL offset, gets the native offsets where a breakpoint should be placed so that the debugger can obtain the return value from a function.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5.1

## See also

- [ICorDebugILFrame3 Interface](icordebugilframe3-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
