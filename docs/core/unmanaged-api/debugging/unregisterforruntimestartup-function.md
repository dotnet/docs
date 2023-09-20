---
description: "Learn more about: UnregisterForRuntimeStartup Function"
title: "UnregisterForRuntimeStartup Function"
ms.date: "03/21/2022"
f1_keywords:
  - "UnregisterForRuntimeStartup"
api_location:
  - "dbgshim.dll"
  - "libdbgshim.so"
  - "libdbgshim.dylib"
helpviewer_keywords:
  - "UnregisterForRuntimeStartup function"
  - "debugging API [.NET Core]"
  - ".NET Core, debugging"
ms.assetid: 35c7a18f-133a-4584-bd25-bb338568b0c6
---
# UnregisterForRuntimeStartup Function for .NET Core

Stops/cancels runtime startup notification.

## Syntax

```cpp
HRESULT UnregisterForRuntimeStartup (
    [in] PVOID pUnregisterToken)
);
```

## Parameters

 `pUnregisterToken`\
 [in] The token from the [RegisterForRuntimeStartup](registerforruntimestartup-function.md) APIs.

## Return Value

 `S_OK`\
 The runtime startup callback was successfully unregistered.

 `E_FAIL` (or other `E_` return codes)\
 Unregister failed.

## Remarks

This API needs to be called during the debugger's shutdown to cleanup the internal data. It can be called in the startup callback. Otherwise, it will block until the callback thread finishes and no more callbacks will be initiated after this API returns.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** dbgshim.h

 **Library:** dbgshim.dll, libdbgshim.so, libdbgshim.dylib

 **.NET Versions:** Available since .NET Core 2.1
