---
description: "Learn more about: IMetaDataConverter Interface"
title: "IMetaDataConverter Interface"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataConverter"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataConverter"
topic_type:
  - "apiref"
---
# IMetaDataConverter Interface

Provides methods to map type libraries to their metadata signatures, and to convert from one to the other.

## Methods

|Method|Description|
|------------|-----------------|
|[GetMetaDataFromTypeInfo Method](imetadataconverter-getmetadatafromtypeinfo-method.md)|Gets a pointer to an [IMetaDataImport](imetadataimport-interface.md) instance that represents the metadata signature for the type library referenced by the specified `ITypeInfo` instance.|
|[GetMetaDataFromTypeLib Method](imetadataconverter-getmetadatafromtypelib-method.md)|Gets a pointer to an `IMetaDataImport` instance that represents the metadata signature for the type library represented by the specified `ITypeLib` instance.|
|[GetTypeLibFromMetaData Method](imetadataconverter-gettypelibfrommetadata-method.md)|Gets a pointer to an `ITypeLib` instance that represents the type library that has the specified module and library names.|

## Requirements

 **Platform:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

## See also

- [IMetadata interfaces](imetadata-interfaces.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
