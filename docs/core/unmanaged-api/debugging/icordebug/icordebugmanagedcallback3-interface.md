---
description: "Learn more about: ICorDebugManagedCallback3 Interface"
title: "ICorDebugManagedCallback3 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback3"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback3"
helpviewer_keywords:
  - "ICorDebugManagedCallback3 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback3 Interface

Provides a callback method that indicates that an enabled custom debugger notification has been raised.

## Methods

|Method|Description|
|------------|-----------------|
|[CustomNotification Method](icordebugmanagedcallback3-customnotification-method.md)|Indicates that an enabled custom debugger notification has been raised.|

## Remarks

 This interface is a logical extension of the [ICorDebugManagedCallback](icordebugmanagedcallback-interface.md) and [ICorDebugManagedCallback2](icordebugmanagedcallback2-interface.md) interfaces.

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.0

## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
- [ICorDebugManagedCallback2 Interface](icordebugmanagedcallback2-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
