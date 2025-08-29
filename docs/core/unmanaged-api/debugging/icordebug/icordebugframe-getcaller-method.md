---
description: "Learn more about: ICorDebugFrame::GetCaller Method"
title: "ICorDebugFrame::GetCaller Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFrame.GetCaller"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFrame::GetCaller"
helpviewer_keywords:
  - "GetCaller method, ICorDebugFrame interface [.NET debugging]"
  - "ICorDebugFrame::GetCaller method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugFrame::GetCaller Method

Gets a pointer to the ICorDebugFrame object in the current chain that called this frame.

## Syntax

```cpp
HRESULT GetCaller (
    [out] ICorDebugFrame     **ppFrame
);
```

## Parameters

 `ppFrame`
 [out] A pointer to the address of an `ICorDebugFrame` object that represents the calling frame. This value is null if the called frame is the outermost frame in the current chain.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
