---
description: "Learn more about: WAITORTIMERCALLBACK Function Pointer"
title: "WAITORTIMERCALLBACK Function Pointer"
ms.date: "03/30/2017"
api_name:
  - "WAITORTIMERCALLBACK"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "WAITORTIMERCALLBACK"
helpviewer_keywords:
  - "WAITORTIMERCALLBACK function pointer [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# WAITORTIMERCALLBACK Function Pointer

Points to a function that notifies the host that a wait handle (<xref:System.Threading.WaitHandle>) has either been signaled or timed out.

 This function pointer has been deprecated in the .NET Framework 4.

## Syntax

```cpp
typedef VOID (__stdcall *WAITORTIMERCALLBACK) (
    [in] PVOID lpParameter,
    [in] BOOL  TimerOrWaitFired
);
```

## Parameters

 `lpParameter`
 [in] A pointer to an object that contains information defined by the host.

 `TimerOrWaitFired`
 [in] `true` if the wait handle timed out, or `false` if it was signaled.

## Remarks

 The function to which `WAITORTIMERCALLBACK` points is a callback function and must be implemented by the writer of the hosting application.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** MSCorWks.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
