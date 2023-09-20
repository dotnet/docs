---
description: "Learn more about: CloseCLREnumeration Function"
title: "CloseCLREnumeration Function"
ms.date: "03/21/2022"
api_name:
  - "CloseCLREnumeration"
api_location:
  - "dbgshim.dll"
  - "libdbgshim.so"
  - "libdbgshim.dylib"
f1_keywords:
  - "CloseCLREnumeration"
helpviewer_keywords:
  - "debugging API [.NET Core]"
  - ".NET Core, debugging"
  - "CloseCLR Enumeration function"
ms.assetid: 5e3c3958-80bb-43b1-a96b-dd3e6dbd9cd7
topic_type:
  - "apiref"
---
# CloseCLREnumeration function

Closes any valid common language runtime (CLR) continue-startup events located in an array of handles returned by the [EnumerateCLRs function](enumerateclrs-function.md), and frees the memory for the handle and string path arrays.

## Syntax

```cpp
HRESULT CloseCLREnumeration (
    [in]  DWORD      pHandleArray,
    [in]  LPWSTR**   pStringArray,
    [in]  DWORD*     dwArrayLength
);
```

## Parameters

 `pHandleArray`\
 [in] Pointer to the array of event handles returned from the [EnumerateCLRs function](enumerateclrs-function.md).

 `pStringArray`\
 [in] Pointer to the array of CLR string paths returned from the [EnumerateCLRs function](enumerateclrs-function.md).

 `dwArrayLength`\
 [in] DWORD that contains the size (length) of either `pHandleArray` or `pStringArray` (they are the same).

## Return value

 `S_OK`\
 Handles opened by the [EnumerateCLRs function](enumerateclrs-function.md) are closed, and memory allocated for the handle and string arrays is freed.

 `E_INVALIDARG`\
 The length of `pHandleArray` does not match the length that is passed in `dwArrayLength`.

 `E_FAIL` (or other `E_` return codes)\
 The function is unable to free the memory for `pHandleArray` and `pStringArray`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** dbgshim.h

 **Library:** dbgshim.dll, libdbgshim.so, libdbgshim.dylib

 **.NET Versions:** Available since .NET Core 2.1
