---
description: "Learn more about: ICorDebugNativeFrame::GetRegisterSet Method"
title: "ICorDebugNativeFrame::GetRegisterSet Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugNativeFrame.GetRegisterSet"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugNativeFrame::GetRegisterSet"
helpviewer_keywords:
  - "ICorDebugNativeFrame::GetRegisterSet method [.NET debugging]"
  - "GetRegisterSet method, ICorDebugNativeFrame interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugNativeFrame::GetRegisterSet Method

Gets the register set for this stack frame.

## Syntax

```cpp
HRESULT GetRegisterSet (
    [out] ICorDebugRegisterSet **ppRegisters
);
```

## Parameters

 `ppRegisters`
 [out] A pointer to the address of an [ICorDebugRegisterSet](icordebugregisterset-interface.md) object that represents the register set for this stack frame.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also
