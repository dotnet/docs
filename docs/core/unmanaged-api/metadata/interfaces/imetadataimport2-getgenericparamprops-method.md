---
description: "Learn more about: IMetaDataImport2::GetGenericParamProps Method"
title: "IMetaDataImport2::GetGenericParamProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport2.GetGenericParamProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport2::GetGenericParamProps"
  - "GetGenericParamProps method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport2::GetGenericParamProps Method

Gets the metadata associated with the generic parameter represented by the specified token.

## Syntax

```cpp
HRESULT GetGenericParamProps (
   [in]  mdGenericParam  gp,
   [out] ULONG           *pulParamSeq,
   [out] DWORD           *pdwParamFlags,
   [out] mdToken         *ptOwner,
   [out] DWORD           *reserved,
   [out] LPWSTR          wzName,
   [in]  ULONG           cchName,
   [out] ULONG           *pchName
);
```

## Parameters

 `gp`
 [in] The token that represents the generic parameter for which to return metadata.

 `pulParamSeq`
 [out] The ordinal position of the `Type` parameter in the parent constructor or method.

 `pdwParamFlags`
 [out] A value of the [CorGenericParamAttr](../enumerations/corgenericparamattr-enumeration.md) enumeration that describes the `Type` for the generic parameter.

 `ptOwner`
 [out] A TypeDef or MethodDef token that represents the owner of the parameter.

 `reserved`
 [out] Reserved for future extensibility.

 `wzName`
 [out] The name of the generic parameter.

 `cchName`
 [in] The size of the `wzName` buffer.

 `pchName`
 [out] The returned size of the name, in wide characters.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
