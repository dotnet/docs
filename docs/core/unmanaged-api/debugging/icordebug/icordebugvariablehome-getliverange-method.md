---
description: "Learn more about: IcorDebugVariableHome::GetLiveRange Method"
title: "IcorDebugVariableHome::GetLiveRange Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugVariableHome.GetLiveRange"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugVariableHome::GetLiveRange"
helpviewer_keywords:
  - "ICorDebugVariableHome::GetLiveRange method [.NET debugging]"
  - "GetLiveRange method, ICorDebugVariableFrame interface [.NET debugging]"
topic_type:
  - "apiref"
---
# IcorDebugVariableHome::GetLiveRange Method

Gets the native range over which this variable is live.

## Syntax

```cpp
HRESULT GetLiveRange(
    [out] ULONG32* pStartOffset,
    [out] ULONG32 *pEndOffset
);
```

## Parameters

 `pStartOffset`
 [out] The logical offset at which the variable is first live.

 `pEndOffset`
 [out] The logical offset immediately after the point at which the variable is last live.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6.2

## See also

- [ICorDebugVariableHome Interface](icordebugvariablehome-interface.md)
