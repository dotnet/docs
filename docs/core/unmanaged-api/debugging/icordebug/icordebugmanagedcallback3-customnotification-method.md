---
description: "Learn more about: ICorDebugManagedCallback3::CustomNotification Method"
title: "ICorDebugManagedCallback3::CustomNotification Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback3.CustomNotification Method"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback3::CustomNotification"
helpviewer_keywords:
  - "ICorDebugManagedCallback3::CustomNotification method [.NET debugging]"
  - "CustomNotification method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback3::CustomNotification Method

Indicates that a custom debugger notification has been raised.

## Syntax

```cpp
HRESULT CustomNotification(ICorDebugThread *    pThread,
                           ICorDebugAppDomain * pAppDomain);
```

## Parameters

 `pThread`
 [in] A pointer to the thread that raised the notification.

 `pAppDomain`
 [in] A pointer to the application domain that contains the thread that raised the notification.

## Return Value

This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.

|HRESULT|Description|
|-------------|-----------------|
|S_OK|The method completed successfully.|

## Exceptions

## Remarks

A subsequent call to the [ICorDebugThread4::GetCurrentCustomDebuggerNotification](icordebugthread4-getcurrentcustomdebuggernotification-method.md) method retrieves the thread object that was passed to the <xref:System.Diagnostics.Debugger.NotifyOfCrossThreadDependency%2A?displayProperty=nameWithType> method. The thread object's type must have been previously enabled by calling the [ICorDebugProcess3::SetEnableCustomNotification](icordebugprocess3-setenablecustomnotification-method.md) method. The debugger can read type-specific parameters from the fields of the thread object, and can store responses into fields.

The [ICorDebug](icordebug-interface.md) interface imposes no policy on the types of notifications or their contents, and the semantics of the notifications are strictly a contract between debuggers, applications, and .NET.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.0

## See also

- [ICorDebugManagedCallback3 Interface](icordebugmanagedcallback3-interface.md)
