---
description: "Learn more about: ICorDebugRegisterSet::SetRegisters Method"
title: "ICorDebugRegisterSet::SetRegisters Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugRegisterSet.SetRegisters"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugRegisterSet::SetRegisters"
helpviewer_keywords:
  - "SetRegisters method, ICorDebugRegisterSet interface [.NET debugging]"
  - "ICorDebugRegisterSet::SetRegisters method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugRegisterSet::SetRegisters Method

`SetRegisters` is not implemented.

> [!NOTE]
> Use the higher-level operations such as [ICorDebugILFrame::SetIP](icordebugilframe-setip-method.md) or [ICorDebugNativeFrame::SetIP](icordebugnativeframe-setip-method.md).

## Syntax

```cpp
HRESULT SetRegisters (
    [in] ULONG64   mask,
    [in] ULONG32   regCount,
    [in, size_is(regCount)] CORDB_REGISTER regBuffer[]
);
```

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** 1.1, 1.0

## See also

- [ICorDebugRegisterSet Interface](icordebugregisterset-interface.md)
- [ICorDebugRegisterSet2 Interface](icordebugregisterset2-interface.md)
