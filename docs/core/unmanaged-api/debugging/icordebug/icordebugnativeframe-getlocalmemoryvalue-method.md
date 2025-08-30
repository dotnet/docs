---
description: "Learn more about: ICorDebugNativeFrame::GetLocalMemoryValue Method"
title: "ICorDebugNativeFrame::GetLocalMemoryValue Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugNativeFrame.GetLocalMemoryValue"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugNativeFrame::GetLocalMemoryValue"
helpviewer_keywords:
  - "GetLocalMemoryValue method [.NET debugging]"
  - "ICorDebugNativeFrame::GetLocalMemoryValue method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugNativeFrame::GetLocalMemoryValue Method

Gets the value of an argument or local variable that is stored in the specified memory location for this native frame.

## Syntax

```cpp
HRESULT GetLocalMemoryValue (
    [in]  CORDB_ADDRESS      address,
    [in]  ULONG              cbSigBlob,
    [in]  PCCOR_SIGNATURE    pvSigBlob,
    [out] ICorDebugValue     **ppValue
);
```

## Parameters

 `address`
 [in] A `CORDB_ADDRESS` value that specifies the memory location containing the value.

 `cbSigBlob`
 [in] An integer that specifies the size of the binary metadata signature which is referenced by the `pvSigBlob` parameter.

 `pvSigBlob`
 [in] A `PCCOR_SIGNATURE` value that points to the binary metadata signature of the value's type.

 `ppValue`
 [out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified memory location.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also
