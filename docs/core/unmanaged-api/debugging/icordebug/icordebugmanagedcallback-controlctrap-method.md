---
description: "Learn more about: ICorDebugManagedCallback::ControlCTrap Method"
title: "ICorDebugManagedCallback::ControlCTrap Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.ControlCTrap"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::ControlCTrap"
helpviewer_keywords:
  - "ICorDebugManagedCallback::ControlCTrap method [.NET debugging]"
  - "ControlCTrap method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::ControlCTrap Method

Notifies the debugger that a CTRL+C is trapped in the process that is being debugged.

## Syntax

```cpp
HRESULT ControlCTrap (
    [in] ICorDebugProcess *pProcess
);
```

## Parameters

 `pProcess`
 [in] A pointer to an ICorDebugProcess object that represents the process in which the CTRL+C is trapped.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|The debugger will handle the CTRL+C trap.|
|S_FALSE|The debugger will not handle the CTRL+C trap.|

## Remarks

All application domains within the process are stopped for this callback.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
