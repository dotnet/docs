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
  - "IMetaDataConverter::GetTypeLibFromMetaData method [.NET metadata]"
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

 **Platform:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataConverter Interface](imetadataconverter-interface.md)
