---
description: "Learn more about: ICorDebug::DebugActiveProcess Method"
title: "ICorDebug::DebugActiveProcess Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebug.DebugActiveProcess"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebug::DebugActiveProcess"
helpviewer_keywords:
  - "DebugActiveProcess method [.NET debugging]"
  - "ICorDebug::DebugActiveProcess method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebug::DebugActiveProcess Method

Attaches the debugger to an existing process.

## Syntax

```cpp
HRESULT DebugActiveProcess (
    [in]  DWORD               id,
    [in]  BOOL                win32Attach,
    [out] ICorDebugProcess    **ppProcess
);
```

## Parameters

 `id`
 [in] The ID of the process to which the debugger is to be attached.

 `win32Attach`
 [in] Boolean value that is set to `true` if the debugger should behave as the Win32 debugger for the process and dispatch the unmanaged callbacks; otherwise, `false`.

 `ppProcess`
 [out] A pointer to the address of an "ICorDebugProcess" object that represents the process to which the debugger has been attached.

## Remarks

 Interop debugging is not supported on Win9x and non-x86 platforms, such as IA-64-based and AMD64-based platforms.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebug Interface](icordebug-interface.md)
