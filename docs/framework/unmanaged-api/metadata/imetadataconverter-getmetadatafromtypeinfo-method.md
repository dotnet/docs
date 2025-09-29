---
description: "Learn more about: IMetaDataConverter::GetMetaDataFromTypeInfo Method"
title: "IMetaDataConverter::GetMetaDataFromTypeInfo Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataConverter.GetMetaDataFromTypeInfo"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataConverter::GetMetaDataFromTypeInfo"
  - "IMetaDataConverter::GetMetaDataFromTypeInfo method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataConverter::GetMetaDataFromTypeInfo Method

Gets a pointer to an [IMetaDataImport](../../../core/unmanaged-api/metadata/interfaces/imetadataimport-interface.md) instance that represents the metadata signature of the type library referenced by the specified `ITypeInfo` instance.

## Syntax

```cpp
HRESULT GetMetaDataFromTypeInfo (
    [in]  ITypeInfo         *pITI,
    [out] IMetaDataImport   **ppMDI
);
```

## Parameters

 `pITI`
 [in] A pointer to an `ITypeInfo` object that refers to the type library.

 `ppMDI`
 [out] A pointer to a location that receives the address of the `IMetaDataImport` instance that represents the metadata signature.

## Requirements

 **Platform:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](../../../core/unmanaged-api/metadata/interfaces/imetadataemit-interface.md)
- [IMetaDataImport Interface](../../../core/unmanaged-api/metadata/interfaces/imetadataimport-interface.md)
