---
description: "Learn more about: IMetaDataImport::GetCustomAttributeByName Method"
title: "IMetaDataImport::GetCustomAttributeByName Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetCustomAttributeByName"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetCustomAttributeByName"
  - "GetCustomAttributeByName method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetCustomAttributeByName Method

Gets the custom attribute, given its name and owner.

## Syntax

```cpp
HRESULT GetCustomAttributeByName (
   [in]  mdToken          tkObj,
   [in]  LPCWSTR          szName,
   [out] const void       **ppData,
   [out] ULONG            *pcbData
);
```

## Parameters

 `tkObj`
 [in] A metadata token representing the object that owns the custom attribute.

 `szName`
 [in] The name of the custom attribute.

 `ppData`
 [out] A pointer to an array of data that is the value of the custom attribute.

 `pcbData`
 [out] The size in bytes of the data returned in *`ppData`.

## Remarks

 It is legal to define multiple custom attributes for the same owner; they may even have the same name. However, `GetCustomAttributeByName` returns only one instance. (`GetCustomAttributeByName` returns the first instance that it encounters.) To find all instances of a custom attribute, call the [IMetaDataImport::EnumCustomAttributes](imetadataimport-enumcustomattributes-method.md) method.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
