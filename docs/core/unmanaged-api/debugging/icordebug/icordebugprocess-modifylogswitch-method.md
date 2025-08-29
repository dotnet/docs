---
description: "Learn more about: ICorDebugProcess::ModifyLogSwitch Method"
title: "ICorDebugProcess::ModifyLogSwitch Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess.ModifyLogSwitch"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess::ModifyLogSwitch"
helpviewer_keywords:
  - "ICorDebugProcess::ModifyLogSwitch method [.NET debugging]"
  - "ModifyLogSwitch method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugProcess::ModifyLogSwitch Method

Sets the severity level of the specified log switch.

## Syntax

```cpp
HRESULT ModifyLogSwitch(
    [in] WCHAR *pLogSwitchName,
    [in] LONG  lLevel);
```

## Parameters

 `pLogSwitchName`
 [in] A pointer to a string that specifies the name of the log switch.

 `lLevel`
 [in] The severity level to be set for the specified log switch.

## Remarks

This method is valid only after the [ICorDebugManagedCallback::CreateProcess](icordebugmanagedcallback-createprocess-method.md) callback has occurred.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
