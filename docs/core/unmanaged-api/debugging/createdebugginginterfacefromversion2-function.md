---
description: "Learn more about: CreateDebuggingInterfaceFromVersion2 Function"
title: "CreateDebuggingInterfaceFromVersion2 Function"
ms.date: "03/21/2022"
api_location:
  - "dbgshim.dll"
  - "libdbgshim.so"
  - "libdbgshim.dylib"
f1_keywords:
  - "CreateDebuggingInterfaceFromVersion2"
helpviewer_keywords:
  - "CreateDebuggingInterfaceFromVersion2 function"
  - "debugging API [.NET Core]"
  - ".NET Core, debugging"
ms.assetid: 35c7a18f-133a-4584-bd25-bb338568b0c6
---
# CreateDebuggingInterfaceFromVersion2 function

Accepts a common language runtime (CLR) version string that is returned from the [CreateVersionStringFromModule](createversionstringfrommodule-function.md) function, and returns a corresponding debugger interface (typically, [ICorDebug](../../../framework/unmanaged-api/debugging/icordebug-interface.md)).

## Syntax

```cpp
HRESULT CreateDebuggingInterfaceFromVersion2 (
    [in] int iDebuggerVersion,
    [in] LPCWSTR szDebuggeeVersion,
    [in] LPCWSTR szApplicationGroupId,
    [out] IUnknown** ppCordb,
);
```

## Parameters

 `iDebuggerVersion`\
 [in] The version of interface the debugger expects.

 `szDebuggeeVersion`\
 [in] Version string of the CLR in the target debuggee, which is returned by the [CreateVersionStringFromModule](createversionstringfrommodule-function.md) function.

 `szApplicationGroupId`\
 [in] A string representing the application group ID of a sandboxed process running in macOS. Pass NULL if the process is not running in a sandbox on macOS or on other platforms.

 `ppCordb`\
 [out] Pointer to a pointer to a COM object (`IUnknown`). This object will be cast to an [ICorDebug](../../../framework/unmanaged-api/debugging/icordebug-interface.md) object before it is returned.

## Return value

 `S_OK`\
 `ppCordb` references a valid object that implements the [ICorDebug interface](../../../framework/unmanaged-api/debugging/icordebug-interface.md) interface.

 `E_INVALIDARG`\
 Either `szDebuggeeVersion` or `ppCordb` is null.

 `CORDBG_E_DEBUG_COMPONENT_MISSING`\
 A component that is necessary for CLR debugging cannot be located. Either _mscordbi.dll_ or _mscordaccore.dll_ was not found in the same directory as the target CoreCLR.dll.

 `CORDBG_E_INCOMPATIBLE_PROTOCOL`\
 Either mscordbi.dll or mscordaccore.dll is not the same version as the target CoreCLR.dll.

 `E_FAIL` (or other `E_` return codes)\
 Unable to return an [ICorDebug interface](../../../framework/unmanaged-api/debugging/icordebug-interface.md).

## Remarks

 The interface that is returned provides the facilities for attaching to a CLR in a target process and debugging the managed code that the CLR is running.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** dbgshim.h

 **Library:** dbgshim.dll, libdbgshim.so, libdbgshim.dylib

 **.NET Versions:** [!INCLUDE[net_core_31](../../../../includes/net-core-31-md.md)]
