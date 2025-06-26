---
description: "Learn more about: IMetaDataDispenser Interface"
title: "IMetaDataDispenser Interface"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataDispenser"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataDispenser"
helpviewer_keywords:
  - "IMetaDataDispenser interface [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataDispenser Interface

Provides methods to create a new metadata scope, or open an existing one.

## Methods

|Method|Description|
|------------|-----------------|
|[DefineScope Method](imetadatadispenser-definescope-method.md)|Creates a new area in memory where you can create new metadata.|
|[OpenScope Method](imetadatadispenser-openscope-method.md)|Opens an existing, on-disk file and maps its metadata into memory.|
|[OpenScopeOnMemory Method](imetadatadispenser-openscopeonmemory-method.md)|Opens an area of memory that contains existing metadata. That is, this method opens a specified area of memory in which the existing data is treated as metadata.|

## Requirements

 **Platform:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataDispenserEx Interface](imetadatadispenserex-interface.md)
- [Metadata Interfaces](metadata-interfaces.md)
