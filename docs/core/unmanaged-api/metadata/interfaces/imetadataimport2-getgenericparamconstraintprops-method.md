---
description: "Learn more about: IMetaDataImport2::GetGenericParamConstraintProps Method"
title: "IMetaDataImport2::GetGenericParamConstraintProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport2.GetGenericParamConstraintProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport2::GetGenericParamConstraintProps"
  - "GetGenericParamConstraintProps method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport2::GetGenericParamConstraintProps Method

Gets the metadata associated with the generic parameter constraint represented by the specified constraint token.

## Syntax

```cpp
HRESULT GetGenericParamConstraintProps (
   [in]  mdGenericParamConstraint  gpc,
   [out] mdGenericParam            *ptGenericParam,
   [out] mdToken                   *ptkConstraintType
);
```

## Parameters

 `gpc`
 [in] The token to the generic parameter constraint for which to return the metadata.

 `ptGenericParam`
 [out] A pointer to the token that represents the generic parameter that is constrained.

 `ptkConstraintType`
 [out] A pointer to a TypeDef, TypeRef, or TypeSpec token that represents a constraint on `ptGenericParam`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
