---
description: "Learn more about: CloseResumeHandle Function"
title: "CloseResumeHandle Function"
ms.date: "03/21/2022"
api_name:
  - "CloseResumeHandle"
api_location:
  - "dbgshim.dll"
  - "libdbgshim.so"
  - "libdbgshim.dylib"
f1_keywords:
  - "CloseResumeHandle"
helpviewer_keywords:
  - "debugging API [.NET Core]"
  - ".NET Core, debugging"
  - "CloseResumeHandle function"
ms.assetid: 5e3c3958-80bb-43b1-a96b-dd3e6dbd9cd7
topic_type:
  - "apiref"
ms.topic: article
---
# CloseResumeHandle function

Closes the handle returned by the [CreateProcessForLaunch function](createprocessforlaunch-function.md).

## Syntax

```cpp
HRESULT CloseResumeHandle (
    [in] HANDLE hResumeHandle
);
```

## Parameters

 `hResumeHandle`\
 [in] The resume handle returned by [CreateProcessForLaunch function](createprocessforlaunch-function.md).

## Return value

 `S_OK`\
 The handle was successfully closed.

 `E_FAIL` (or other `E_` return codes)\
 The handle was invalid.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** dbgshim.h

 **Library:** dbgshim.dll, libdbgshim.so, libdbgshim.dylib

 **.NET Versions:** Available since .NET Core 2.1
