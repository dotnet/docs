---
description: "Learn more about: IMetaDataConverter::GetMetaDataFromTypeLib Method"
title: "IMetaDataConverter::GetMetaDataFromTypeLib Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataConverter.GetMetaDataFromTypeLib"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataConverter::GetMetaDataFromTypeLib"
  - "GetMetaDataFromTypeLib method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataConverter::GetMetaDataFromTypeLib Method

Gets an interface pointer to an [IMetaDataImport](imetadataimport-interface.md) instance that represents the metadata signature of the type library represented by the specified `ITypeLib` instance.

## Syntax

```cpp
HRESULT GetMetaDataFromTypeLib (
    [in]  ITypeLib        *pITL,
    [out] IMetaDataImport **ppMDI
);
```

## Parameters

 `pITL`
 [in] Pointer to an `ITypeLib` object that represents the type library.

 `ppMDI`
 [out] Pointer to a location that receives the address of the `IMetaDataImport` instance that represents the metadata signature.

## Requirements

 **Platform:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
