---
description: "Learn more about: ICorDebugILFrame::EnumerateLocalVariables Method"
title: "ICorDebugILFrame::EnumerateLocalVariables Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugILFrame.EnumerateLocalVariables"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugILFrame::EnumerateLocalVariables"
helpviewer_keywords:
  - "EnumerateLocalVariables method [.NET debugging]"
  - "ICorDebugILFrame::EnumerateLocalVariables method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugILFrame::EnumerateLocalVariables Method

Gets an enumerator for the local variables in this frame.

## Syntax

```cpp
HRESULT EnumerateLocalVariables(
    [out] ICorDebugValueEnum    **ppValueEnum
);
```

## Parameters

 `ppValueEnum`
 [out] A pointer to the address of an ICorDebugValueEnum object that is the enumerator for the local variables in this frame.

## Remarks

 `EnumerateLocalVariables` gets an enumerator that can list the local variables available in the call frame that is represented by this ICorDebugILFrame object. The list may not include all of the local variables in the running function, because some of them may not be active.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
