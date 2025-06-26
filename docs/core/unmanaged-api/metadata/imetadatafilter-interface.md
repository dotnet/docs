---
description: "Learn more about: IMetaDataFilter Interface"
title: "IMetaDataFilter Interface"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataFilter"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataFilter"
helpviewer_keywords:
  - "IMetaDataFilter interface [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataFilter Interface

Provides methods for marking and filtering metadata tokens to avoid repeating actions that have already been taken.

## Methods

|Method|Description|
|------------|-----------------|
|[IsTokenMarked Method](imetadatafilter-istokenmarked-method.md)|Gets a value indicating whether the specified metadata token has been processed.|
|[MarkToken Method](imetadatafilter-marktoken-method.md)|Sets a value indicating that the specified metadata token has been processed.|
|[UnmarkAll Method](imetadatafilter-unmarkall-method.md)|Removes the processing marks from all the tokens in the current metadata scope.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Metadata Interfaces](metadata-interfaces.md)
