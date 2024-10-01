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
  - "ICorDebugManagedCallback3 interface [.NET Framework debugging]"
ms.assetid: a95389d3-cf2e-47a4-9805-61426acc6b65
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

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]

## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
- [ICorDebugManagedCallback2 Interface](icordebugmanagedcallback2-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
