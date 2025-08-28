---
description: "Learn more about: ICorDebugILFrame2::EnumerateTypeParameters Method"
title: "ICorDebugILFrame2::EnumerateTypeParameters Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugILFrame2.EnumerateTypeParameters"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugILFrame2::EnumerateTypeParameters"
helpviewer_keywords:
  - "EnumerateTypeParameters method, ICorDebugILFrame2 interface [.NET debugging]"
  - "ICorDebugILFrame2::EnumerateTypeParameters method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugILFrame2::EnumerateTypeParameters Method

Gets an ICorDebugTypeEnum object that contains the <xref:System.Type> parameters in this frame.

## Syntax

```cpp
HRESULT EnumerateTypeParameters (
    [out] ICorDebugTypeEnum    **ppTyParEnum
);
```

## Parameters

 `ppTyParEnum`
 A pointer to the address of a ICorDebugTypeEnum interface object that allows enumeration of type parameters.

 The list of type parameters include the class type parameters (if any) followed by the method type parameters (if any).

## Remarks

 Use the [IMetaDataImport2::EnumGenericParams](../../metadata/interfaces/imetadataimport2-enumgenericparams-method.md) method to determine how many class type parameters and method type parameters this list contains.

 The type parameters are not always available.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
