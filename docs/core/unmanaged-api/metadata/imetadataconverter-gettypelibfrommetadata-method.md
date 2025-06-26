---
description: "Learn more about: IMetaDataConverter::GetTypeLibFromMetaData Method"
title: "IMetaDataConverter::GetTypeLibFromMetaData Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataConverter.GetTypeLibFromMetaData"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataConverter::GetTypeLibFromMetaData"
helpviewer_keywords:
  - "GetTypeLibFromMetaData method [.NET Framework metadata]"
  - "IMetaDataConverter::GetTypeLibFromMetaData method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataConverter::GetTypeLibFromMetaData Method

Gets a pointer to an `ITypeLib` instance that represents the type library that has the specified library and module names.

## Syntax

```cpp
HRESULT GetTypeLibFromMetaData (
    [in]  BSTR     strModule,
    [in]  BSTR     strTlbName,
    [out] ITypeLib **ppITL
);
```

## Parameters

 `strModule`
 [in] The name of the type library's module.

 `strTlbName`
 [in] The name of the type library.

 `ppITL`
 [out] A pointer to a location that receives the address of the `ITypeLib` instance that represents the type library.

## Requirements

 **Platform:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataConverter Interface](imetadataconverter-interface.md)
