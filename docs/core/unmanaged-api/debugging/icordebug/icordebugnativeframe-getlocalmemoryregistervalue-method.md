---
description: "Learn more about: ICorDebugNativeFrame::GetLocalMemoryRegisterValue Method"
title: "ICorDebugNativeFrame::GetLocalMemoryRegisterValue Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugNativeFrame.GetLocalMemoryRegisterValue"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugNativeFrame::GetLocalMemoryRegisterValue"
helpviewer_keywords:
  - "ICorDebugNativeFrame::GetLocalMemoryRegisterValue method [.NET debugging]"
  - "GetLocalMemoryRegisterValue method"
topic_type:
  - "apiref"
---
# ICorDebugNativeFrame::GetLocalMemoryRegisterValue Method

Gets the value of an argument or local variable, of which the low word and high word are stored in the specified register and memory location, respectively, for this native frame.

## Syntax

```cpp
HRESULT GetLocalMemoryRegisterValue (
    [in] CORDB_ADDRESS      highWordAddress,
    [in] CorDebugRegister   lowWordRegister,
    [in] ULONG              cbSigBlob,
    [in] PCCOR_SIGNATURE    pvSigBlob,
    [out] ICorDebugValue    **ppValue
);
```

## Parameters

 `highWordAddress`
 [in] A `CORDB_ADDRESS` value that specifies the memory location containing the high word of the value.

 `lowWordRegister`
 [in] A value of the "CorDebugRegister" enumeration that specifies the register containing the low word of the value.

 `cbSigBlob`
 [in] An integer that specifies the size of the binary metadata signature which is referenced by the `pvSigBlob` parameter.

 `pvSigBlob`
 [in] A `PCCOR_SIGNATURE` value that points to the binary metadata signature of the value's type.

 `ppValue`
 [out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified register and memory location.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also
