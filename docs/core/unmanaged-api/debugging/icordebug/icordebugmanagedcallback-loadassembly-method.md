---
description: "Learn more about: ICorDebugManagedCallback::LoadAssembly Method"
title: "ICorDebugManagedCallback::LoadAssembly Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.LoadAssembly"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::LoadAssembly"
helpviewer_keywords:
  - "LoadAssembly method [.NET debugging]"
  - "ICorDebugManagedCallback::LoadAssembly method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::LoadAssembly Method

Notifies the debugger that a common language runtime (CLR) assembly has been successfully loaded.

## Syntax

```cpp
HRESULT LoadAssembly (
    [in] ICorDebugAppDomain *pAppDomain,
    [in] ICorDebugAssembly  *pAssembly
);
```

## Parameters

 `pAppDomain`
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain into which the assembly has been loaded.

 `pAssembly`
 [in] A pointer to an ICorDebugAssembly object that represents the assembly.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [UnloadAssembly Method](icordebugmanagedcallback-unloadassembly-method.md)
- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
