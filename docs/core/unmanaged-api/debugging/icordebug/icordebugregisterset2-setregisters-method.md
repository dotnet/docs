---
description: "Learn more about: ICorDebugRegisterSet2::SetRegisters Method"
title: "ICorDebugRegisterSet2::SetRegisters Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugRegisterSet2.SetRegisters"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugRegisterSet2::SetRegisters"
helpviewer_keywords:
  - "ICorDebugRegisterSet2::SetRegisters method [.NET debugging]"
  - "SetRegisters method, ICorDebugRegisterSet2 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugRegisterSet2::SetRegisters Method

`SetRegisters` is not implemented.

> [!NOTE]
> Use the higher-level operations such as [ICorDebugILFrame::SetIP](icordebugilframe-setip-method.md) or [ICorDebugNativeFrame::SetIP](icordebugnativeframe-setip-method.md).

## Syntax

```cpp
HRESULT SetRegisters (
    [in] ULONG32 maskCount,
    [in, size_is(maskCount)] BYTE mask[],
    [in] ULONG32 regCount,
    [in, size_is(regCount)] CORDB_REGISTER regBuffer[]
);
```

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorDebugRegisterSet2 Interface](icordebugregisterset2-interface.md)
- [ICorDebugRegisterSet Interface](icordebugregisterset-interface.md)
