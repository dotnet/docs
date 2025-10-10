---
description: "Learn more about: IMetaDataImport::GetFieldMarshal Method"
title: "IMetaDataImport::GetFieldMarshal Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetFieldMarshal"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetFieldMarshal"
  - "IMetaDataImport::GetFieldMarshal method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetFieldMarshal Method

Gets a pointer to the native, unmanaged type of the field represented by the specified field metadata token.

## Syntax

```cpp
HRESULT GetFieldMarshal (
   [in]  mdToken             tk,
   [out] PCCOR_SIGNATURE     *ppvNativeType,
   [out] ULONG               *pcbNativeType
);
```

## Parameters

 `tk`
 [in] The metadata token that represents the field to get interop marshalling information for.

 `ppvNativeType`
 [out] A pointer to the metadata signature of the field's native type.

 `pcbNativeType`
 [out] The size in bytes of `ppvNativeType`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
