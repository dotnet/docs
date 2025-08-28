---
description: "Learn more about: ICorDebugAppDomain2::GetArrayOrPointerType Method"
title: "ICorDebugAppDomain2::GetArrayOrPointerType Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAppDomain2.GetArrayOrPointerType"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAppDomain2::GetArrayOrPointerType"
helpviewer_keywords:
  - "GetArrayOrPointerType method [.NET debugging]"
  - "ICorDebugAppDomain2::GetArrayOrPointerType method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAppDomain2::GetArrayOrPointerType Method

Gets an array of the specified type, or a pointer or reference to the specified type.

## Syntax

```cpp
HRESULT GetArrayOrPointerType (
    [in]  CorElementType    elementType,
    [in]  ULONG32           nRank,
    [in]  ICorDebugType     *pTypeArg,
    [out] ICorDebugType     **ppType
);
```

## Parameters

 `elementType`
 [in] A value of the CorElementType enumeration that specifies the underlying native type (an array, pointer, or reference) to be created.

 `nRank`
 [in] The rank (that is, number of dimensions) of the array. This value must be 0 if `elementType` specifies a pointer or reference type.

 `pTypeArg`
 [in] A pointer to an ICorDebugType object that represents the type of array, pointer, or reference to be created.

 `ppType`
 [out] A pointer to the address of an `ICorDebugType` object that represents the constructed array, pointer type, or reference type.

## Remarks

 The value of *elementType* must be one of the following:

- ELEMENT_TYPE_PTR

- ELEMENT_TYPE_BYREF

- ELEMENT_TYPE_ARRAY or ELEMENT_TYPE_SZARRAY

 If the value of *elementType* is ELEMENT_TYPE_PTR or ELEMENT_TYPE_BYREF, *nRank* must be zero.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
