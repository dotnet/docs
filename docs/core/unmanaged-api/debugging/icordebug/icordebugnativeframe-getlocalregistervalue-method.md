---
description: "Learn more about: ICorDebugNativeFrame::GetLocalRegisterValue Method"
title: "ICorDebugNativeFrame::GetLocalRegisterValue Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugNativeFrame.GetLocalRegisterValue"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugNativeFrame::GetLocalRegisterValue"
helpviewer_keywords:
  - "GetLocalRegisterValue method [.NET debugging]"
  - "ICorDebugNativeFrame::GetLocalRegisterValue method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugNativeFrame::GetLocalRegisterValue Method

Gets the value of an argument or local variable that is stored in the specified register for this native frame.

## Syntax

```cpp
HRESULT GetLocalRegisterValue (
    [in]  CorDebugRegister   reg,
    [in]  ULONG              cbSigBlob,
    [in]  PCCOR_SIGNATURE    pvSigBlob,
    [out] ICorDebugValue     **ppValue
);
```

## Parameters

 `reg`
 [in] A value of the "CorDebugRegister" enumeration that specifies the register containing the value.

 `cbSigBlob`
 [in] An integer that specifies the size of the binary metadata signature which is referenced by the `pvSigBlob` parameter.

 `pvSigBlob`
 [in] A `PCCOR_SIGNATURE` value that points to the binary metadata signature of the value's type.

 `ppValue`
 [out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified register.

## Remarks

The `GetLocalRegisterValue` method can be used either in a native frame or a just-in-time (JIT)-compiled frame.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also
