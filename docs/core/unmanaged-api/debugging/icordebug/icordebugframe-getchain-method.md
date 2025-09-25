---
description: "Learn more about: ICorDebugFrame::GetChain Method"
title: "ICorDebugFrame::GetChain Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFrame.GetChain"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFrame::GetChain"
helpviewer_keywords:
  - "ICorDebugFrame::GetChain method [.NET debugging]"
  - "GetChain method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugFrame::GetChain Method

Gets a pointer to the chain this frame is a part of.

## Syntax

```cpp
HRESULT GetChain (
    [out] ICorDebugChain     **ppChain
);
```

## Parameters

 `ppChain`
 [out] A pointer to the address of an ICorDebugChain object that represents the chain containing this frame.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
