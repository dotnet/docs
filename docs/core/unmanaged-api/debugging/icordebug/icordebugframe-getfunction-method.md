---
description: "Learn more about: ICorDebugFrame::GetFunction Method"
title: "ICorDebugFrame::GetFunction Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFrame.GetFunction"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFrame::GetFunction"
helpviewer_keywords:
  - "GetFunction method, ICorDebugFrame interface [.NET debugging]"
  - "ICorDebugFrame::GetFunction method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugFrame::GetFunction Method

Gets the function that contains the code associated with this stack frame.

## Syntax

```cpp
HRESULT GetFunction (
    [out] ICorDebugFunction  **ppFunction
);
```

## Parameters

 `ppFunction`
 [out] A pointer to the address of an ICorDebugFunction object that represents the function containing the code associated with this stack frame.

## Remarks

The `GetFunction` method may fail if the frame is not associated with any particular function.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
