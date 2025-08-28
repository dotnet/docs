---
description: "Learn more about: ICorDebugRegisterSet::GetRegisters Method"
title: "ICorDebugRegisterSet::GetRegisters Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugRegisterSet.GetRegisters"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugRegisterSet::GetRegisters"
helpviewer_keywords:
  - "GetRegisters method, ICorDebugRegisterSet interface [.NET debugging]"
  - "ICorDebugRegisterSet::GetRegisters method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugRegisterSet::GetRegisters Method

Gets the value of each register (on the computer that is currently executing code) that is specified by the bit mask.

## Syntax

```cpp
HRESULT GetRegisters (
    [in] ULONG64       mask,
    [in] ULONG32       regCount,
    [out, size_is(regCount), length_is(regCount)]
        CORDB_REGISTER regBuffer[]
);
```

## Parameters

 `mask`
 [in] A bit mask that specifies which register values are to be retrieved. Each bit corresponds to a register. If a bit is set to one, the register's value is retrieved; otherwise, the register's value is not retrieved.

 `regCount`
 [in] The number of register values to be retrieved.

 `regBuffer`
 [out] An array of `CORDB_REGISTER` objects, each of which receives a value of a register.

## Remarks

 The size of the array should be equal to the number of bits set to one in the bit mask. The `regCount` parameter specifies the number of elements in the buffer that will receive the register values. If the `regCount` value is too small for the number of registers indicated by the mask, the higher numbered registers will be truncated from the set. If the `regCount` value is too large, the unused `regBuffer` elements will be unmodified.

 If the bit mask specifies a register that is unavailable, `GetRegisters` returns an indeterminate value for that register.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebugRegisterSet Interface](icordebugregisterset-interface.md)
- [ICorDebugRegisterSet2 Interface](icordebugregisterset2-interface.md)
