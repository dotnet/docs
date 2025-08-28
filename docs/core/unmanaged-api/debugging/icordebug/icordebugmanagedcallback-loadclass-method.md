---
description: "Learn more about: ICorDebugManagedCallback::LoadClass Method"
title: "ICorDebugManagedCallback::LoadClass Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.LoadClass"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::LoadClass"
helpviewer_keywords:
  - "ICorDebugManagedCallback::LoadClass method [.NET debugging]"
  - "LoadClass method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::LoadClass Method

Notifies the debugger that a class has been loaded.

## Syntax

```cpp
HRESULT LoadClass (
    [in] ICorDebugAppDomain *pAppDomain,
    [in] ICorDebugClass     *c
);
```

## Parameters

 `pAppDomain`
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain into which the class has been loaded.

 `c`
 [in] A pointer to an ICorDebugClass object that represents the class.

## Remarks

 This callback occurs only if class loading has been enabled for the module that contains the class. Class loading is always enabled for dynamic modules.

 The `LoadClass` callback provides an appropriate time to bind breakpoints to newly generated classes in dynamic modules.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [UnloadClass Method](icordebugmanagedcallback-unloadclass-method.md)
- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
