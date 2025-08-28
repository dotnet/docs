---
description: "Learn more about: ICorDebugModule::EnableClassLoadCallbacks Method"
title: "ICorDebugModule::EnableClassLoadCallbacks Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule.EnableClassLoadCallbacks"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule::EnableClassLoadCallbacks"
helpviewer_keywords:
  - "ICorDebugModule::EnableClassLoadCallbacks method [.NET debugging]"
  - "EnableClassLoadCallbacks method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugModule::EnableClassLoadCallbacks Method

Controls whether the [ICorDebugManagedCallback::LoadClass](icordebugmanagedcallback-loadclass-method.md) and [ICorDebugManagedCallback::UnloadClass](icordebugmanagedcallback-unloadclass-method.md) callbacks are called for this module.

## Syntax

```cpp
HRESULT EnableClassLoadCallbacks(
    [in] BOOL bClassLoadCallbacks
);
```

## Parameters

 `bClassLoadCallbacks`
 [in] Set this value to `true` to enable the common language runtime (CLR) to call the `ICorDebugManagedCallback::LoadClass` and `ICorDebugManagedCallback::UnloadClass` methods when their associated events occur.

 The default value is `false` for non-dynamic modules. The value is always `true` for dynamic modules and cannot be changed.

## Remarks

 The `ICorDebugManagedCallback::LoadClass` and `ICorDebugManagedCallback::UnloadClass` callbacks are always enabled for dynamic modules and cannot be disabled.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also
