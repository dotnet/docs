---
description: "Learn more about: ICorDebugFrame::GetFunctionToken Method"
title: "ICorDebugFrame::GetFunctionToken Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFrame.GetFunctionToken"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFrame::GetFunctionToken"
helpviewer_keywords:
  - "ICorDebugFrame::GetFunctionToken method [.NET debugging]"
  - "GetFunctionToken method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugFrame::GetFunctionToken Method

Gets the metadata token for the function that contains the code associated with this stack frame.

## Syntax

```cpp
HRESULT GetFunctionToken (
    [out] mdMethodDef        *pToken
);
```

## Parameters

 `pToken`
 [out] A pointer to an `mdMethodDef` token that references the metadata for the function.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
