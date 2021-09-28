---
description: "Learn more about: ICorDebugThread4::GetCurrentCustomDebuggerNotification Method"
title: "ICorDebugThread4::GetCurrentCustomDebuggerNotification Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugThread4.GetCurrentCustomDebuggerNotification Method"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugThread4::GetCurrentCustomDebuggerNotification"
helpviewer_keywords:
  - "GetCurrentCustomDebuggerNotification method [.NET Framework debugging]"
  - "ICorDebugThread4::GetCurrentCustomDebuggerNotification method [.NET Framework debugging]"
ms.assetid: 57e0f2d2-5f0e-4e2d-99ec-3f26632eb693
topic_type:
  - "apiref"
---

# ICorDebugThread4::GetCurrentCustomDebuggerNotification Method

Gets the current [ICorDebugManagedCallback3::CustomNotification](icordebugmanagedcallback3-customnotification-method.md) object on the current thread.

## Syntax

```cpp
HRESULT GetCurrentCustomDebuggerNotification(
    [out] ICorDebugValue **ppNotificationObject
    );
```

## Parameters

`ppNotificationObject`\
[out] A pointer to the current `ICorDebugManagedCallback3::CustomNotification` object on the current thread.

## Remarks

The value of `ppNotificationObject` is null if the method is not called from within a `ICorDebugManagedCallback3::CustomNotification` callback, or if no current notification object exists.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).

**Header:** CorDebug.idl, CorDebug.h

**Library:** CorGuids.lib

**.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]

## See also

- [ICorDebugThread4 Interface](icordebugthread4-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
