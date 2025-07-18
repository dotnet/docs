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
helpviewer_keywords:
  - "GetFieldMarshal method [.NET Framework metadata]"
  - "IMetaDataImport::GetFieldMarshal method [.NET Framework metadata]"
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

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
