---
description: "Learn more about: ICorDebugILFrame::GetArgument Method"
title: "ICorDebugILFrame::GetArgument Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugILFrame.GetArgument"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugILFrame::GetArgument"
helpviewer_keywords:
  - "GetArgument method [.NET debugging]"
  - "ICorDebugILFrame::GetArgument method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugILFrame::GetArgument Method

Gets the value of the specified argument in this common intermediate language (CIL) stack frame.

## Syntax

```cpp
HRESULT GetArgument (
    [in] DWORD                  dwIndex,
    [out] ICorDebugValue        **ppValue
);
```

## Parameters

 `dwIndex`
 [in] The index of the argument in this CIL stack frame.

 `ppValue`
 [out] A pointer to the address of an ICorDebugValue object that represents the retrieved value.

## Remarks

The `GetArgument` method can be used either in an CIL stack frame or in a just-in-time (JIT) compiled frame.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
