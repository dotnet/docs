---
description: "Learn more about: ICorDebugILFrame::CanSetIP Method"
title: "ICorDebugILFrame::CanSetIP Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugILFrame.CanSetIP"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugILFrame::CanSetIP"
helpviewer_keywords:
  - "CanSetIP method, ICorDebugILFrame interface [.NET debugging]"
  - "ICorDebugILFrame::CanSetIP method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugILFrame::CanSetIP Method

Gets an HRESULT that indicates whether it is safe to set the instruction pointer to the specified offset location in common intermediate language (CIL) code.

## Syntax

```cpp
HRESULT CanSetIP (
    [in] ULONG32   nOffset
);
```

## Parameters

 `nOffset`
 [in] The desired setting for the instruction pointer.

## Remarks

 Use the `CanSetIP` method before calling the [ICorDebugILFrame::SetIP](icordebugilframe-setip-method.md) method. If `CanSetIP` returns any HRESULT other than S_OK, you can still invoke `ICorDebugILFrame::SetIP`, but there is no guarantee that the debugger will continue the safe and correct execution of the code being debugged.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug,h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
