---
description: "Learn more about: ICorDebugComObjectValue::GetCachedInterfacePointers Method"
title: "ICorDebugComObjectValue::GetCachedInterfacePointers Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugComObjectValue::GetCachedInterfacePointers"
api_location:
  - "mscordbi.dll"
f1_keywords:
  - "ICorDebugComObjectValue::GetCachedInterfacePointers"
helpviewer_keywords:
  - "ICorDebugComObjectValue::GetCachedInterfacePointers method [.NET debugging]"
  - "GetCachedInterfacePointers method, ICorDebugComObjectValue interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugComObjectValue::GetCachedInterfacePointers Method

Gets the raw interface pointers cached on the current runtime callable wrapper (RCW).

## Syntax

```cpp
HRESULT GetCachedInterfacePointers(
    [in] BOOL bIInspectableOnly,
    [in] ULONG32 celt,
    [out] ULONG32 *pceltFetched,
    [out, size_is(celt), length_is(*pceltFetched) CORDB_ADDRESS *ptrs);
```

## Parameters

 `bIInspectableOnly`
 [in] A value that indicates whether the method will return only Windows Runtime interfaces (`IInspectable` interfaces) or all COM interfaces that are cached by the runtime callable wrapper (RCW).

 `celt`
 [in] The number of objects whose addresses are to be retrieved.

 `pceltFetched`
 [out] A pointer to the number of `CORDB_ADDRESS` values actually returned in `ptrs`.

 `ptrs`
A pointer to the starting address of an array of `CORDB_ADDRESS` values that contain the addresses of cached interface objects.

## Remarks

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5

## See also

- [ICorDebugComObjectValue Interface](icordebugcomobjectvalue-interface.md)
