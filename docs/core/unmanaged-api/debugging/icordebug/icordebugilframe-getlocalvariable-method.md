---
description: "Learn more about: ICorDebugILFrame::GetLocalVariable Method"
title: "ICorDebugILFrame::GetLocalVariable Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugILFrame.GetLocalVariable"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugILFrame::GetLocalVariable"
helpviewer_keywords:
  - "ICorDebugILFrame::GetLocalVariable method [.NET debugging]"
  - "GetLocalVariable method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugILFrame::GetLocalVariable Method

Gets the value of the specified local variable in this common intermediate language (CIL) stack frame.

## Syntax

```cpp
HRESULT GetLocalVariable (
    [in] DWORD                  dwIndex,
    [out] ICorDebugValue        **ppValue
);
```

## Parameters

 `dwIndex`
 [in] The index of the local variable in this CIL stack frame.

 `ppValue`
 [out] A pointer to the address of an ICorDebugValue object that represents the retrieved value.

## Remarks

 The `GetLocalVariable` method can be used either in an CIL stack frame or in a just-in-time (JIT) compiled frame.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
