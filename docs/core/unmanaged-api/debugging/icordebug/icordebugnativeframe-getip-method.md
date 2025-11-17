---
description: "Learn more about: ICorDebugNativeFrame::GetIP Method"
title: "ICorDebugNativeFrame::GetIP Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugNativeFrame.GetIP"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugNativeFrame::GetIP"
helpviewer_keywords:
  - "GetIP method, ICorDebugNativeFrame interface [.NET debugging]"
  - "ICorDebugNativeFrame::GetIP method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugNativeFrame::GetIP Method

Gets the native code offset location to which the instruction pointer is currently set.

## Syntax

```cpp
HRESULT GetIP (
    [out] ULONG32           *pnOffset
);
```

## Parameters

 `pnOffset`
 [out] A pointer to the offset location in the native code.

## Remarks

If the stack frame that is represented by this "ICorDebugNativeFrame" is active, the offset is the address of the next instruction to be executed. If this stack frame is not active, the offset is the address of the next instruction to be executed when the stack frame is reactivated.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also
