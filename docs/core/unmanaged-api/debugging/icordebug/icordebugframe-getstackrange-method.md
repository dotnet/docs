---
description: "Learn more about: ICorDebugFrame::GetStackRange Method"
title: "ICorDebugFrame::GetStackRange Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFrame.GetStackRange"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFrame::GetStackRange"
helpviewer_keywords:
  - "GetStackRange method, ICorDebugFrame interface [.NET debugging]"
  - "ICorDebugFrame::GetStackRange method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugFrame::GetStackRange Method

Gets the absolute address range of this stack frame.

## Syntax

```cpp
HRESULT GetStackRange (
    [out] CORDB_ADDRESS      *pStart,
    [out] CORDB_ADDRESS      *pEnd
);
```

## Parameters

 `pStart`
 [out] A pointer to a `CORDB_ADDRESS` that specifies the starting address of the stack frame represented by this `ICorDebugFrame` object.

 `pEnd`
 [out] A pointer to a `CORDB_ADDRESS` that specifies the ending address of the stack frame represented by this `ICorDebugFrame` object.

## Remarks

 The address range of the stack is useful for piecing together interleaved stack traces gathered from multiple debugging engines. The numeric range provides no information about the contents of the stack frame. It is meaningful only for comparison of stack frame locations.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
