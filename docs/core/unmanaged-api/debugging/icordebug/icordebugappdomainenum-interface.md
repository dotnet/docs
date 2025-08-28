---
description: "Learn more about: ICorDebugAppDomainEnum Interface"
title: "ICorDebugAppDomainEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAppDomainEnum"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAppDomainEnum"
helpviewer_keywords:
  - "ICorDebugAppDomainEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAppDomainEnum Interface

Provides the `Next` method, which returns a specified number of `ICorDebugAppDomainEnum` values starting at the next location in the enumeration. This interface is a subclass of "ICorDebugEnum".

## Methods

|Method|Description|
|------------|-----------------|
|[Next Method](icordebugappdomainenum-next-method.md)|Gets the specified number of application domains from the collection, starting at the current cursor position.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebug Interface](icordebug-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
