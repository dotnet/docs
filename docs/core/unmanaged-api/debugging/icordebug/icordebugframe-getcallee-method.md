---
description: "Learn more about: ICorDebugFrame::GetCallee Method"
title: "ICorDebugFrame::GetCallee Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFrame.GetCallee"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFrame::GetCallee"
helpviewer_keywords:
  - "ICorDebugFrame::GetCallee method [.NET debugging]"
  - "GetCallee method, ICorDebugFrame interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugFrame::GetCallee Method

Gets a pointer to the ICorDebugFrame object in the current chain that this frame called.

## Syntax

```cpp
HRESULT GetCallee (
    [out] ICorDebugFrame     **ppFrame
);
```

## Parameters

 `ppFrame`
 [out] A pointer to the address of an `ICorDebugFrame` object that represents the called frame. This value is null if the calling frame is the innermost frame in the current chain.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
