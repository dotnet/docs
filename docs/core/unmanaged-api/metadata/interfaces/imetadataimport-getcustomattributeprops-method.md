---
description: "Learn more about: IMetaDataImport::GetCustomAttributeProps Method"
title: "IMetaDataImport::GetCustomAttributeProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetCustomAttributeProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetCustomAttributeProps"
  - "IMetaDataImport::GetCustomAttributeProps method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetCustomAttributeProps Method

Gets the value of the custom attribute, given its metadata token.

## Syntax

```cpp
HRESULT GetCustomAttributeProps (
   [in]            mdCustomAttribute   cv,
   [out, optional] mdToken             *ptkObj,
   [out, optional] mdToken             *ptkType,
   [out, optional] void const          **ppBlob,
   [out, optional] ULONG               *pcbSize
);
```

## Parameters

 `cv`
 [in] A metadata token that represents the custom attribute to be retrieved.

 `ptkObj`
 [out, optional] A metadata token representing the object that the custom attribute modifies. This value can be any type of metadata token except `mdCustomAttribute`.

 `ptkType`
 [out, optional] An `mdMethodDef` or `mdMemberRef` metadata token representing the <xref:System.Type> of the returned custom attribute.

 `ppBlob`
 [out, optional] A pointer to an array of data that is the value of the custom attribute.

 `pcbSize`
 [out, optional] The size in bytes of the data returned in *`ppBlob`.

## Remarks

 A custom attribute is stored as an array of data, the format which is understood by the metadata engine.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
